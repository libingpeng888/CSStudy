using Microsoft.Data.SqlClient;
using System.Data;

namespace CSStudy
{
    /// <summary>
    /// Unit 表的数据访问。
    /// 界面（UnitForm）只调这里的方法，不再直接写 SQL。
    /// </summary>
    public static class UnitRepository
    {
        // 查询列集合（所有 SELECT 共用，改表结构时只改这一处）
        private const string SelectCols =
            "uGUID, uNo, uName, uFactor, uBase, uRemark";

        /// <summary>全量查询</summary>
        public static DataTable GetAll()
        {
            using (SqlConnection conn = Db.Open())
            using (SqlDataAdapter da = new SqlDataAdapter(
                $"SELECT {SelectCols} FROM Unit", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>取全部单位名称（按编码排序），用于填充下拉框</summary>
        public static List<string> GetNames()
        {
            List<string> list = new List<string>();
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand("SELECT uName FROM Unit ORDER BY uNo", conn))
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                    list.Add(Convert.ToString(rd["uName"]) ?? "");
            }
            return list;
        }

        /// <summary>按指定字段模糊搜索（字段名走白名单，防字段名注入）</summary>
        /// <param name="field">查询字段：单位编码 / 单位名称</param>
        public static DataTable Search(string field, string keyword)
        {
            // 列名无法用参数占位符，必须白名单校验后才允许拼进 SQL
            string col;
            switch (field)
            {
                case "单位编码": col = "uNo"; break;
                case "单位名称": col = "uName"; break;
                default: col = "uNo"; break;   // 非法值兜底，绝不直接拼接
            }

            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                $"SELECT {SelectCols} FROM Unit WHERE {col} LIKE @kw", conn))
            {
                cmd.Parameters.AddWithValue("@kw", $"%{keyword}%");
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(dt);
                return dt;
            }
        }

        /// <summary>新增计量单位（uGUID 由数据库 DEFAULT NEWID() 生成）</summary>
        /// <param name="uFactor">换算系数，按字符串传，交给 SQL 隐式转换</param>
        /// <param name="uBase">是否基准单位：1=是，0=否（SQL bit 可接受 int）</param>
        public static void Insert(string uNo, string uName, string uFactor,
            int uBase, string uRemark, string createUser)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Unit(uNo,uName,uFactor,uBase,uRemark,CreateUser) " +
                "VALUES(@uNo,@uName,@uFactor,@uBase,@uRemark,@CreateUser)", conn))
            {
                AddParams(cmd, uNo, uName, uFactor, uBase, uRemark);
                cmd.Parameters.AddWithValue("@CreateUser", createUser);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>修改计量单位</summary>
        public static void Update(Guid uGUID, string uNo, string uName, string uFactor,
            int uBase, string uRemark, string updateUser)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE Unit SET uNo=@uNo,uName=@uName,uFactor=@uFactor,uBase=@uBase,uRemark=@uRemark," +
                "UpdateUser=@UpdateUser,UpdateTime=GETDATE() " +
                "WHERE uGUID=@uGUID", conn))
            {
                AddParams(cmd, uNo, uName, uFactor, uBase, uRemark);
                cmd.Parameters.AddWithValue("@UpdateUser", updateUser);
                cmd.Parameters.AddWithValue("@uGUID", uGUID);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>删除计量单位</summary>
        public static void Delete(Guid uGUID)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM Unit WHERE uGUID=@uGUID", conn))
            {
                cmd.Parameters.AddWithValue("@uGUID", uGUID);
                cmd.ExecuteNonQuery();
            }
        }

        // 公共参数赋值（Insert/Update 共用，改字段时只改这一处）
        private static void AddParams(SqlCommand cmd,
            string uNo, string uName, string uFactor, int uBase, string uRemark)
        {
            cmd.Parameters.AddWithValue("@uNo", uNo);
            cmd.Parameters.AddWithValue("@uName", uName);
            cmd.Parameters.AddWithValue("@uFactor", uFactor);
            cmd.Parameters.AddWithValue("@uBase", uBase);
            cmd.Parameters.AddWithValue("@uRemark", uRemark);
        }
    }
}
