using Microsoft.Data.SqlClient;
using System.Data;

namespace CSStudy
{
    /// <summary>Supplier 表的数据访问。</summary>
    public static class SupplierRepository
    {
        private const string SelectCols =
            "uGUID, suppNo, suppName, suppContact, suppPhone, suppAddress, suppRemark";

        public static DataTable GetAll()
        {
            using (SqlConnection conn = Db.Open())
            using (SqlDataAdapter da = new SqlDataAdapter(
                $"SELECT {SelectCols} FROM Supplier", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>按指定字段模糊搜索（字段名走白名单，防字段名注入）</summary>
        /// <param name="field">查询字段：供应商编号 / 供应商名称 / 联系人 / 联系电话</param>
        public static DataTable Search(string field, string keyword)
        {
            // 列名无法用参数占位符，必须白名单校验后才允许拼进 SQL
            string col;
            switch (field)
            {
                case "供应商编号": col = "suppNo"; break;
                case "供应商名称": col = "suppName"; break;
                case "联系人": col = "suppContact"; break;
                case "联系电话": col = "suppPhone"; break;
                default: col = "suppNo"; break;   // 非法值兜底，绝不直接拼接
            }

            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                $"SELECT {SelectCols} FROM Supplier WHERE {col} LIKE @kw", conn))
            {
                cmd.Parameters.AddWithValue("@kw", $"%{keyword}%");
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(dt);
                return dt;
            }
        }

        public static void Insert(string suppNo, string suppName, string suppContact,
            string suppPhone, string suppAddress, string suppRemark, string createUser)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Supplier(suppNo,suppName,suppContact,suppPhone,suppAddress,suppRemark,CreateUser) " +
                "VALUES(@suppNo,@suppName,@suppContact,@suppPhone,@suppAddress,@suppRemark,@CreateUser)", conn))
            {
                AddParams(cmd, suppNo, suppName, suppContact, suppPhone, suppAddress, suppRemark);
                cmd.Parameters.AddWithValue("@CreateUser", createUser);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(Guid uGUID, string suppNo, string suppName, string suppContact,
            string suppPhone, string suppAddress, string suppRemark, string updateUser)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE Supplier SET suppNo=@suppNo,suppName=@suppName,suppContact=@suppContact," +
                "suppPhone=@suppPhone,suppAddress=@suppAddress,suppRemark=@suppRemark," +
                "UpdateUser=@UpdateUser,UpdateTime=GETDATE() " +
                "WHERE uGUID=@uGUID", conn))
            {
                AddParams(cmd, suppNo, suppName, suppContact, suppPhone, suppAddress, suppRemark);
                cmd.Parameters.AddWithValue("@UpdateUser", updateUser);
                cmd.Parameters.AddWithValue("@uGUID", uGUID);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(Guid uGUID)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM Supplier WHERE uGUID=@uGUID", conn))
            {
                cmd.Parameters.AddWithValue("@uGUID", uGUID);
                cmd.ExecuteNonQuery();
            }
        }

        private static void AddParams(SqlCommand cmd,
            string suppNo, string suppName, string suppContact,
            string suppPhone, string suppAddress, string suppRemark)
        {
            cmd.Parameters.AddWithValue("@suppNo", suppNo);
            cmd.Parameters.AddWithValue("@suppName", suppName);
            cmd.Parameters.AddWithValue("@suppContact", suppContact);
            cmd.Parameters.AddWithValue("@suppPhone", suppPhone);
            cmd.Parameters.AddWithValue("@suppAddress", suppAddress);
            cmd.Parameters.AddWithValue("@suppRemark", suppRemark);
        }
    }
}
