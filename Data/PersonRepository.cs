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

        /// <summary>按指定字段模糊搜索（字段名走白名单，防字段名注入）</summary>
        /// <param name="field">查询字段：工号 / 姓名 / 性别 / 部门</param>
        /// <param name="keyword">查询关键字</param>
        public static DataTable Search(string field, string keyword)
        {
            // 白名单映射：界面字段 → 数据库列名。
            // 列名无法用参数占位符，必须白名单校验后才允许拼进 SQL，
            // 否则 field 传入恶意串会形成字段名注入。
            string col;
            switch (field)
            {
                case "工号": col = "sNo"; break;
                case "姓名": col = "sName"; break;
                case "性别": col = "sGender"; break;
                case "部门": col = "sDept"; break;
                default: col = "sNo"; break;   // 非法值兜底，绝不直接拼接
            }

            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                $"SELECT {SelectCols} FROM Person " +
                $"WHERE {col} LIKE @kw " +
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
