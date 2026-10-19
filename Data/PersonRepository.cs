using Microsoft.Data.SqlClient;
using System.Data;

namespace CSStudy
{
    /// <summary>Person 表的数据访问。</summary>
    public static class PersonRepository
    {
        private const string SelectCols =
            "uGUID, sNo, sName, sGender, sDept, sSkill";

        public static DataTable GetAll()
        {
            using (SqlConnection conn = Db.Open())
            using (SqlDataAdapter da = new SqlDataAdapter(
                $"SELECT {SelectCols} FROM Person ORDER BY sNo", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>按工号或姓名模糊搜索（参数化）</summary>
        public static DataTable Search(string keyword)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                $"SELECT {SelectCols} FROM Person " +
                "WHERE sNo LIKE @kw OR sName LIKE @kw " +
                "ORDER BY sNo", conn))
            {
                cmd.Parameters.AddWithValue("@kw", $"%{keyword}%");
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(dt);
                return dt;
            }
        }

        public static void Insert(string sNo, string sName, string sGender,
            string sDept, string sSkill, string createUser)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Person(sNo,sName,sGender,sDept,sSkill,CreateUser) " +
                "VALUES(@sNo,@sName,@sGender,@sDept,@sSkill,@CreateUser)", conn))
            {
                AddParams(cmd, sNo, sName, sGender, sDept, sSkill);
                cmd.Parameters.AddWithValue("@CreateUser", createUser);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(Guid uGUID, string sNo, string sName, string sGender,
            string sDept, string sSkill, string updateUser)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE Person SET sNo=@sNo,sName=@sName,sGender=@sGender," +
                "sDept=@sDept,sSkill=@sSkill," +
                "UpdateUser=@UpdateUser,UpdateTime=GETDATE() " +
                "WHERE uGUID=@uGUID", conn))
            {
                AddParams(cmd, sNo, sName, sGender, sDept, sSkill);
                cmd.Parameters.AddWithValue("@UpdateUser", updateUser);
                cmd.Parameters.AddWithValue("@uGUID", uGUID);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(Guid uGUID)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM Person WHERE uGUID=@uGUID", conn))
            {
                cmd.Parameters.AddWithValue("@uGUID", uGUID);
                cmd.ExecuteNonQuery();
            }
        }

        private static void AddParams(SqlCommand cmd,
            string sNo, string sName, string sGender, string sDept, string sSkill)
        {
            cmd.Parameters.AddWithValue("@sNo", sNo);
            cmd.Parameters.AddWithValue("@sName", sName);
            cmd.Parameters.AddWithValue("@sGender", sGender);
            cmd.Parameters.AddWithValue("@sDept", sDept);
            cmd.Parameters.AddWithValue("@sSkill", sSkill);
        }
    }
}
