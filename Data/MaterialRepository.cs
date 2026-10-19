using Microsoft.Data.SqlClient;
using System.Data;

namespace CSStudy
{
    /// <summary>
    /// Material 表的数据访问。
    /// 界面（MaterialForm）只调这里的方法，不再直接写 SQL。
    /// </summary>
    public static class MaterialRepository
    {
        // 查询列集合（所有 SELECT 共用，改表结构时只改这一处）
        private const string SelectCols =
            "uGUID, mNo, mName, mSpec, mUnit, mPrice, mCategory, mRemark";

        /// <summary>全量查询</summary>
        public static DataTable GetAll()
        {
            using (SqlConnection conn = Db.Open())
            using (SqlDataAdapter da = new SqlDataAdapter(
                $"SELECT {SelectCols} FROM Material", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>按编号或名称模糊搜索（参数化，防注入）</summary>
        public static DataTable Search(string keyword)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                $"SELECT {SelectCols} FROM Material " +
                "WHERE mNo LIKE @kw OR mName LIKE @kw", conn))
            {
                cmd.Parameters.AddWithValue("@kw", $"%{keyword}%");
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(dt);
                return dt;
            }
        }

        /// <summary>新增物料（uGUID 由数据库 DEFAULT NEWID() 生成）</summary>
        public static void Insert(string mNo, string mName, string mSpec,
            string mUnit, string mPrice, string mCategory, string mRemark, string createUser)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Material(mNo,mName,mSpec,mUnit,mPrice,mCategory,mRemark,CreateUser) " +
                "VALUES(@mNo,@mName,@mSpec,@mUnit,@mPrice,@mCategory,@mRemark,@CreateUser)", conn))
            {
                AddParams(cmd, mNo, mName, mSpec, mUnit, mPrice, mCategory, mRemark);
                cmd.Parameters.AddWithValue("@CreateUser", createUser);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>修改物料</summary>
        public static void Update(Guid uGUID, string mNo, string mName, string mSpec,
            string mUnit, string mPrice, string mCategory, string mRemark, string updateUser)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE Material SET mNo=@mNo,mName=@mName,mSpec=@mSpec,mUnit=@mUnit," +
                "mPrice=@mPrice,mCategory=@mCategory,mRemark=@mRemark," +
                "UpdateUser=@UpdateUser,UpdateTime=GETDATE() " +
                "WHERE uGUID=@uGUID", conn))
            {
                AddParams(cmd, mNo, mName, mSpec, mUnit, mPrice, mCategory, mRemark);
                cmd.Parameters.AddWithValue("@UpdateUser", updateUser);
                cmd.Parameters.AddWithValue("@uGUID", uGUID);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>删除物料</summary>
        public static void Delete(Guid uGUID)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM Material WHERE uGUID=@uGUID", conn))
            {
                cmd.Parameters.AddWithValue("@uGUID", uGUID);
                cmd.ExecuteNonQuery();
            }
        }

        // 公共参数赋值（Insert/Update 共用，改字段时只改这一处）
        private static void AddParams(SqlCommand cmd,
            string mNo, string mName, string mSpec,
            string mUnit, string mPrice, string mCategory, string mRemark)
        {
            cmd.Parameters.AddWithValue("@mNo", mNo);
            cmd.Parameters.AddWithValue("@mName", mName);
            cmd.Parameters.AddWithValue("@mSpec", mSpec);
            cmd.Parameters.AddWithValue("@mUnit", mUnit);
            cmd.Parameters.AddWithValue("@mPrice", mPrice);
            cmd.Parameters.AddWithValue("@mCategory", mCategory);
            cmd.Parameters.AddWithValue("@mRemark", mRemark);
        }
    }
}
