using Microsoft.Data.SqlClient;
using System.Data;

namespace CSStudy
{
    /// <summary>
    /// SysDict 表（数据字典，单表多类型）的数据访问。
    /// 界面（DictForm）只调这里的方法，不再直接写 SQL。
    /// </summary>
    public static class SysDictRepository
    {
        // 查询列集合（所有 SELECT 共用，改表结构时只改这一处）
        private const string SelectCols =
            "uGUID, DictType, DictCode, DictName, SortOrder, IsEnabled";

        /// <summary>全量查询</summary>
        public static DataTable GetAll()
        {
            using (SqlConnection conn = Db.Open())
            using (SqlDataAdapter da = new SqlDataAdapter(
                $"SELECT {SelectCols} FROM SysDict", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>按字典类型取"启用"的字典项（按 SortOrder 排序），用于填充下拉框</summary>
        public static DataTable GetByType(string dictType)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT DictName FROM SysDict WHERE DictType=@DictType AND IsEnabled=1 " +
                "ORDER BY SortOrder, DictCode", conn))
            {
                cmd.Parameters.AddWithValue("@DictType", dictType);
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(dt);
                return dt;
            }
        }

        /// <summary>取某类型下所有启用的字典名称（用于填充下拉框）</summary>
        public static List<string> GetNames(string dictType)
        {
            List<string> names = new List<string>();
            foreach (DataRow row in GetByType(dictType).Rows)
            {
                names.Add(row["DictName"].ToString());
            }
            return names;
        }

        /// <summary>按指定字段模糊搜索（字段名走白名单，防字段名注入）</summary>
        /// <param name="field">查询字段：字典类型 / 字典编码 / 字典名称</param>
        public static DataTable Search(string field, string keyword)
        {
            // 列名无法用参数占位符，必须白名单校验后才允许拼进 SQL
            string col;
            switch (field)
            {
                case "字典类型": col = "DictType"; break;
                case "字典编码": col = "DictCode"; break;
                case "字典名称": col = "DictName"; break;
                default: col = "DictType"; break;   // 非法值兜底，绝不直接拼接
            }

            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                $"SELECT {SelectCols} FROM SysDict WHERE {col} LIKE @kw", conn))
            {
                cmd.Parameters.AddWithValue("@kw", $"%{keyword}%");
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(dt);
                return dt;
            }
        }

        /// <summary>新增字典项（uGUID 由数据库 DEFAULT NEWID() 生成）</summary>
        /// <param name="sortOrder">排序号，按字符串传，交给 SQL 隐式转换</param>
        /// <param name="isEnabled">是否启用：1=启用，0=停用（SQL bit 可接受 int）</param>
        public static void Insert(string dictType, string dictCode, string dictName,
            string sortOrder, int isEnabled, string createUser)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO SysDict(DictType,DictCode,DictName,SortOrder,IsEnabled,CreateUser) " +
                "VALUES(@DictType,@DictCode,@DictName,@SortOrder,@IsEnabled,@CreateUser)", conn))
            {
                AddParams(cmd, dictType, dictCode, dictName, sortOrder, isEnabled);
                cmd.Parameters.AddWithValue("@CreateUser", createUser);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>修改字典项</summary>
        public static void Update(Guid uGUID, string dictType, string dictCode, string dictName,
            string sortOrder, int isEnabled, string updateUser)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE SysDict SET DictType=@DictType,DictCode=@DictCode,DictName=@DictName," +
                "SortOrder=@SortOrder,IsEnabled=@IsEnabled," +
                "UpdateUser=@UpdateUser,UpdateTime=GETDATE() " +
                "WHERE uGUID=@uGUID", conn))
            {
                AddParams(cmd, dictType, dictCode, dictName, sortOrder, isEnabled);
                cmd.Parameters.AddWithValue("@UpdateUser", updateUser);
                cmd.Parameters.AddWithValue("@uGUID", uGUID);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>删除字典项</summary>
        public static void Delete(Guid uGUID)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM SysDict WHERE uGUID=@uGUID", conn))
            {
                cmd.Parameters.AddWithValue("@uGUID", uGUID);
                cmd.ExecuteNonQuery();
            }
        }

        // 公共参数赋值（Insert/Update 共用，改字段时只改这一处）
        private static void AddParams(SqlCommand cmd,
            string dictType, string dictCode, string dictName,
            string sortOrder, int isEnabled)
        {
            cmd.Parameters.AddWithValue("@DictType", dictType);
            cmd.Parameters.AddWithValue("@DictCode", dictCode);
            cmd.Parameters.AddWithValue("@DictName", dictName);
            cmd.Parameters.AddWithValue("@SortOrder", sortOrder);
            cmd.Parameters.AddWithValue("@IsEnabled", isEnabled);
        }
    }
}
