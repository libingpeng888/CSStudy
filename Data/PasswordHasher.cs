using System.Security.Cryptography;

namespace CSStudy
{
    /// <summary>
    /// 密码哈希工具（PBKDF2-SHA256，.NET 自带，无需第三方包）。
    /// 存储格式：v1.迭代次数.盐(Base64).哈希(Base64)，全长约 80 字符。
    /// 带 v1 版本号：以后想换更强的算法时，能识别出旧格式并兼容。
    /// </summary>
    public static class PasswordHasher
    {
        private const string Prefix = "v1";
        private const int Iterations = 100_000; // 迭代次数：越大越难被暴力破解
        private const int SaltSize = 16;        // 盐长度（字节），每个用户随机生成
        private const int HashSize = 32;        // 输出哈希长度（字节）

        /// <summary>把明文密码转成可入库的哈希串</summary>
        public static string Hash(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                password, salt, Iterations, HashAlgorithmName.SHA256, HashSize);
            return $"{Prefix}.{Iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
        }

        /// <summary>判断库里存的串是不是哈希格式（用来区分历史遗留的明文密码）</summary>
        public static bool IsHashed(string stored) =>
            !string.IsNullOrEmpty(stored) && stored.StartsWith(Prefix + ".");

        /// <summary>验证：用户输入的明文密码，与库里存的哈希是否匹配</summary>
        public static bool Verify(string password, string stored)
        {
            string[] parts = stored.Split('.');
            if (parts.Length != 4 || parts[0] != Prefix)
                return false;

            int iterations = int.Parse(parts[1]);
            byte[] salt = Convert.FromBase64String(parts[2]);
            byte[] expected = Convert.FromBase64String(parts[3]);

            byte[] actual = Rfc2898DeriveBytes.Pbkdf2(
                password, salt, iterations, HashAlgorithmName.SHA256, expected.Length);

            // 固定时间比较：防止通过"比较耗时"推测出正确内容（计时攻击）
            return CryptographicOperations.FixedTimeEquals(actual, expected);
        }
    }
}
