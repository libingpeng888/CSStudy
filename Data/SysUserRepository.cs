using Microsoft.Data.SqlClient;

namespace WinFormsApp1
{
    /// <summary>
    /// SysUser 表的数据访问：登录验证、注册、查重。
    /// 界面（LoginForm / RegisterForm）只调这里的方法，不再直接写 SQL。
    /// 这就是"一个实体一个 Repository"的分层模式。
    /// </summary>
    public static class SysUserRepository
    {
        /// <summary>用户名是否已存在</summary>
        public static bool Exists(string userName)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(1) FROM SysUser WHERE userName=@userName", conn))
            {
                cmd.Parameters.AddWithValue("@userName", userName);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        /// <summary>注册新用户。密码先哈希再入库，明文不落盘</summary>
        public static void Register(string userName, string password)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO SysUser(userName,userPwd) VALUES(@userName,@pwd)", conn))
            {
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.Parameters.AddWithValue("@pwd", PasswordHasher.Hash(password));
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 登录验证。兼容历史明文数据：
        /// 库里是哈希 → 按哈希验证；
        /// 库里还是明文 → 先按明文比对，验证成功立刻把这一行升级成哈希（无感迁移）。
        /// </summary>
        public static bool Validate(string userName, string password)
        {
            using (SqlConnection conn = Db.Open())
            {
                // 1. 取出该用户当前存储的密码串
                string stored;
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT userPwd FROM SysUser WHERE userName=@userName", conn))
                {
                    cmd.Parameters.AddWithValue("@userName", userName);
                    object? result = cmd.ExecuteScalar();
                    if (result == null || result == DBNull.Value)
                        return false; // 用户不存在
                    stored = Convert.ToString(result)!;
                }

                // 2. 已是哈希格式：直接验证
                if (PasswordHasher.IsHashed(stored))
                    return PasswordHasher.Verify(password, stored);

                // 3. 旧的明文数据：比对成功后升级为哈希
                if (stored != password)
                    return false;

                using (SqlCommand up = new SqlCommand(
                    "UPDATE SysUser SET userPwd=@pwd WHERE userName=@userName", conn))
                {
                    up.Parameters.AddWithValue("@pwd", PasswordHasher.Hash(password));
                    up.Parameters.AddWithValue("@userName", userName);
                    up.ExecuteNonQuery();
                }
                return true;
            }
        }
    }
}
