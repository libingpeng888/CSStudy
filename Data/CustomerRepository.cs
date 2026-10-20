using Microsoft.Data.SqlClient;
using System.Data;

namespace CSStudy
{
    /// <summary>Customer 表的数据访问。</summary>
    public static class CustomerRepository
    {
        private const string SelectCols =
            "uGUID, cNo, cName, cContact, cPhone, cAddress, cRemark";

        public static DataTable GetAll()
        {
            using (SqlConnection conn = Db.Open())
            using (SqlDataAdapter da = new SqlDataAdapter(
                $"SELECT {SelectCols} FROM Customer", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>按指定字段模糊搜索（字段名走白名单，防字段名注入）</summary>
        /// <param name="field">查询字段：客户编号 / 客户名称 / 联系人 / 联系电话</param>
        public static DataTable Search(string field, string keyword)
        {
            // 列名无法用参数占位符，必须白名单校验后才允许拼进 SQL
            string col;
            switch (field)
            {
                case "客户编号": col = "cNo"; break;
                case "客户名称": col = "cName"; break;
                case "联系人": col = "cContact"; break;
                case "联系电话": col = "cPhone"; break;
                default: col = "cNo"; break;   // 非法值兜底，绝不直接拼接
            }

            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                $"SELECT {SelectCols} FROM Customer WHERE {col} LIKE @kw", conn))
            {
                cmd.Parameters.AddWithValue("@kw", $"%{keyword}%");
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(dt);
                return dt;
            }
        }

        public static void Insert(string cNo, string cName, string cContact,
            string cPhone, string cAddress, string cRemark, string createUser)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Customer(cNo,cName,cContact,cPhone,cAddress,cRemark,CreateUser) " +
                "VALUES(@cNo,@cName,@cContact,@cPhone,@cAddress,@cRemark,@CreateUser)", conn))
            {
                AddParams(cmd, cNo, cName, cContact, cPhone, cAddress, cRemark);
                cmd.Parameters.AddWithValue("@CreateUser", createUser);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(Guid uGUID, string cNo, string cName, string cContact,
            string cPhone, string cAddress, string cRemark, string updateUser)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE Customer SET cNo=@cNo,cName=@cName,cContact=@cContact," +
                "cPhone=@cPhone,cAddress=@cAddress,cRemark=@cRemark," +
                "UpdateUser=@UpdateUser,UpdateTime=GETDATE() " +
                "WHERE uGUID=@uGUID", conn))
            {
                AddParams(cmd, cNo, cName, cContact, cPhone, cAddress, cRemark);
                cmd.Parameters.AddWithValue("@UpdateUser", updateUser);
                cmd.Parameters.AddWithValue("@uGUID", uGUID);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(Guid uGUID)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM Customer WHERE uGUID=@uGUID", conn))
            {
                cmd.Parameters.AddWithValue("@uGUID", uGUID);
                cmd.ExecuteNonQuery();
            }
        }

        private static void AddParams(SqlCommand cmd,
            string cNo, string cName, string cContact,
            string cPhone, string cAddress, string cRemark)
        {
            cmd.Parameters.AddWithValue("@cNo", cNo);
            cmd.Parameters.AddWithValue("@cName", cName);
            cmd.Parameters.AddWithValue("@cContact", cContact);
            cmd.Parameters.AddWithValue("@cPhone", cPhone);
            cmd.Parameters.AddWithValue("@cAddress", cAddress);
            cmd.Parameters.AddWithValue("@cRemark", cRemark);
        }
    }
}
