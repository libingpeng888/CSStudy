using Microsoft.Data.SqlClient;
using System.Data;

namespace CSStudy
{
    /// <summary>
    /// Warehouse 表的数据访问。
    /// 界面（WarehouseForm）只调这里的方法，不再直接写 SQL。
    /// </summary>
    public static class WarehouseRepository
    {
        // 查询列集合（所有 SELECT 共用，改表结构时只改这一处）
        private const string SelectCols =
            "uGUID, wNo, wName, wLocation, wRemark";

        /// <summary>全量查询</summary>
        public static DataTable GetAll()
        {
            using (SqlConnection conn = Db.Open())
            using (SqlDataAdapter da = new SqlDataAdapter(
                $"SELECT {SelectCols} FROM Warehouse", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>按指定字段模糊搜索（字段名走白名单，防字段名注入）</summary>
        /// <param name="field">查询字段：仓库编号 / 仓库名称 / 库位</param>
        public static DataTable Search(string field, string keyword)
        {
            // 列名无法用参数占位符，必须白名单校验后才允许拼进 SQL
            string col;
            switch (field)
            {
                case "仓库编号": col = "wNo"; break;
                case "仓库名称": col = "wName"; break;
                case "库位": col = "wLocation"; break;
                default: col = "wNo"; break;   // 非法值兜底，绝不直接拼接
            }

            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                $"SELECT {SelectCols} FROM Warehouse WHERE {col} LIKE @kw", conn))
            {
                cmd.Parameters.AddWithValue("@kw", $"%{keyword}%");
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(dt);
                return dt;
            }
        }

        /// <summary>新增仓库（uGUID 由数据库 DEFAULT NEWID() 生成）</summary>
        public static void Insert(string wNo, string wName, string wLocation,
            string wRemark, string createUser)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Warehouse(wNo,wName,wLocation,wRemark,CreateUser) " +
                "VALUES(@wNo,@wName,@wLocation,@wRemark,@CreateUser)", conn))
            {
                AddParams(cmd, wNo, wName, wLocation, wRemark);
                cmd.Parameters.AddWithValue("@CreateUser", createUser);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>修改仓库</summary>
        public static void Update(Guid uGUID, string wNo, string wName, string wLocation,
            string wRemark, string updateUser)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE Warehouse SET wNo=@wNo,wName=@wName,wLocation=@wLocation,wRemark=@wRemark," +
                "UpdateUser=@UpdateUser,UpdateTime=GETDATE() " +
                "WHERE uGUID=@uGUID", conn))
            {
                AddParams(cmd, wNo, wName, wLocation, wRemark);
                cmd.Parameters.AddWithValue("@UpdateUser", updateUser);
                cmd.Parameters.AddWithValue("@uGUID", uGUID);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>删除仓库</summary>
        public static void Delete(Guid uGUID)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM Warehouse WHERE uGUID=@uGUID", conn))
            {
                cmd.Parameters.AddWithValue("@uGUID", uGUID);
                cmd.ExecuteNonQuery();
            }
        }

        // 公共参数赋值（Insert/Update 共用，改字段时只改这一处）
        private static void AddParams(SqlCommand cmd,
            string wNo, string wName, string wLocation, string wRemark)
        {
            cmd.Parameters.AddWithValue("@wNo", wNo);
            cmd.Parameters.AddWithValue("@wName", wName);
            cmd.Parameters.AddWithValue("@wLocation", wLocation);
            cmd.Parameters.AddWithValue("@wRemark", wRemark);
        }
    }
}
