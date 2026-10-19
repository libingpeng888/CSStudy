using Microsoft.Data.SqlClient;

namespace WinFormsApp1
{
    /// <summary>
    /// 数据库连接的唯一入口：整个项目只在这里写一次连接字符串。
    /// 以后要换服务器或数据库，只改下面 ConnectionString 这一行即可。
    /// </summary>
    public static class Db
    {
        // 连接字符串（全项目唯一一处）
        public static readonly string ConnectionString =
            @"Server=.;Database=TestDB;Trusted_Connection=True;TrustServerCertificate=True;";

        /// <summary>
        /// 打开一个已连接的连接对象，调用方用 using 包住即可自动关闭。
        /// 用法：using (SqlConnection conn = Db.Open()) { ... }
        /// </summary>
        public static SqlConnection Open()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }
    }
}
