using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CSStudy
{
    public static class SysCodeRuleRepository
    {
        private const string SelectCols =
            "uGUID, ruleNo, ruleName, prefix, dateFormat, seqLength, seqReset, currentSeq, bizTable, remark";

        public static DataTable GetAll()
        {
            using (SqlConnection conn = Db.Open())
            using (SqlDataAdapter da = new SqlDataAdapter(
                "SELECT " + SelectCols + " FROM SysCodeRule ORDER BY ruleNo", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataRow GetByName(string ruleName)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT " + SelectCols + " FROM SysCodeRule WHERE ruleName=@ruleName", conn))
            {
                cmd.Parameters.AddWithValue("@ruleName", ruleName);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt.Rows.Count > 0 ? dt.Rows[0] : null;
                }
            }
        }

        public static void Insert(string ruleNo, string ruleName, string prefix,
            string dateFormat, int seqLength, int seqReset, string bizTable, string wType, string remark, string createUser)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO SysCodeRule(ruleNo, ruleName, prefix, dateFormat, seqLength, seqReset, currentSeq, bizTable, wType, remark, CreateUser)" +
                " VALUES(@ruleNo, @ruleName, @prefix, @dateFormat, @seqLength, @seqReset, 0, @bizTable, @wType, @remark, @CreateUser)", conn))
            {
                AddParams(cmd, ruleNo, ruleName, prefix, dateFormat, seqLength, seqReset, bizTable, wType, remark, createUser);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(Guid uGUID, string ruleNo, string ruleName, string prefix,
            string dateFormat, int seqLength, int seqReset, string bizTable, string wType, string remark, string updateUser)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE SysCodeRule SET ruleNo=@ruleNo, ruleName=@ruleName, prefix=@prefix, dateFormat=@dateFormat," +
                " seqLength=@seqLength, seqReset=@seqReset, bizTable=@bizTable, wType=@wType, remark=@remark, UpdateUser=@UpdateUser, UpdateTime=GETDATE()" +
                " WHERE uGUID=@uGUID", conn))
            {
                AddParams(cmd, ruleNo, ruleName, prefix, dateFormat, seqLength, seqReset, bizTable, wType, remark, updateUser);
                cmd.Parameters.AddWithValue("@uGUID", uGUID);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(Guid uGUID)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM SysCodeRule WHERE uGUID=@uGUID", conn))
            {
                cmd.Parameters.AddWithValue("@uGUID", uGUID);
                cmd.ExecuteNonQuery();
            }
        }

        private static void AddParams(SqlCommand cmd, string ruleNo, string ruleName, string prefix,
            string dateFormat, int seqLength, int seqReset, string bizTable, string wType, string remark, string user)
        {
            cmd.Parameters.AddWithValue("@ruleNo", ruleNo);
            cmd.Parameters.AddWithValue("@ruleName", ruleName);
            cmd.Parameters.AddWithValue("@prefix", prefix);
            cmd.Parameters.AddWithValue("@dateFormat", (object)dateFormat ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@seqLength", seqLength);
            cmd.Parameters.AddWithValue("@seqReset", seqReset);
            cmd.Parameters.AddWithValue("@bizTable", (object)bizTable ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@wType", (object)wType ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@remark", (object)remark ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CreateUser", (object)user ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@UpdateUser", (object)user ?? DBNull.Value);
        }

        /// <summary>
        /// 根据规则名称生成编码（按规则名精确匹配）
        /// </summary>
        public static string GenerateCode(string ruleName)
        {
            DataRow rule = GetByName(ruleName);
            if (rule == null)
                throw new Exception("编码规则不存在：" + ruleName);
            return DoGenerateCode(rule);
        }

        /// <summary>
        /// 根据仓库类型 + 业务表自动匹配规则生成编码（推荐）
        /// </summary>
        public static string GenerateCodeByWarehouseType(string wType, string bizTable)
        {
            DataRow rule = GetByWarehouseType(wType, bizTable);
            if (rule == null)
                throw new Exception("找不到编码规则：仓库类型=" + wType + "，业务表=" + bizTable);
            return DoGenerateCode(rule);
        }

        private static DataRow GetByWarehouseType(string wType, string bizTable)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT " + SelectCols + " FROM SysCodeRule WHERE wType=@wType AND bizTable=@bizTable", conn))
            {
                cmd.Parameters.AddWithValue("@wType", (object)wType ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@bizTable", bizTable);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt.Rows.Count > 0 ? dt.Rows[0] : null;
                }
            }
        }

        private static string DoGenerateCode(DataRow rule)
        {

            string prefix = rule["prefix"].ToString();
            string dateFormat = rule["dateFormat"]?.ToString();
            int seqLength = Convert.ToInt32(rule["seqLength"]);
            int seqReset = Convert.ToInt32(rule["seqReset"]);
            string bizTable = rule["bizTable"]?.ToString();

            // 拼前缀
            string code = prefix;

            // 拼日期
            string datePart = "";
            if (!string.IsNullOrEmpty(dateFormat))
            {
                datePart = DateTime.Now.ToString(dateFormat);
                code += datePart;
            }

            // 生成序号
            int seq;
            if (seqReset == 1)
            {
                // 按日重置：查业务表里当天最大序号
                seq = GetMaxSeqByDay(bizTable, prefix, datePart, seqLength);
            }
            else
            {
                // 累计：用 currentSeq + 1，并更新
                seq = Convert.ToInt32(rule["currentSeq"]) + 1;
                UpdateCurrentSeq((Guid)rule["uGUID"], seq);
            }

            code += seq.ToString("D" + seqLength);
            return code;
        }

        /// <summary>
        /// 按日查业务表里的最大序号
        /// </summary>
        private static int GetMaxSeqByDay(string bizTable, string prefix, string datePart, int seqLength)
        {
            if (string.IsNullOrEmpty(bizTable))
                return 1;

            // 白名单校验表名，防止注入
            if (!IsValidTableName(bizTable))
                throw new Exception("非法的业务表名：" + bizTable);

            // 单号字段统一叫 inNo，这里用参数化 + 白名单表名
            string likePattern = prefix + datePart + "%";
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT MAX(inNo) FROM " + bizTable + " WHERE inNo LIKE @likePattern", conn))
            {
                cmd.Parameters.AddWithValue("@likePattern", likePattern);
                object result = cmd.ExecuteScalar();
                if (result == DBNull.Value || result == null)
                    return 1;

                string maxNo = result.ToString();
                string prefixAndDate = prefix + datePart;
                if (maxNo.Length > prefixAndDate.Length)
                {
                    string seqStr = maxNo.Substring(prefixAndDate.Length);
                    if (int.TryParse(seqStr, out int lastSeq))
                        return lastSeq + 1;
                }
                return 1;
            }
        }

        private static void UpdateCurrentSeq(Guid uGUID, int currentSeq)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE SysCodeRule SET currentSeq=@currentSeq WHERE uGUID=@uGUID", conn))
            {
                cmd.Parameters.AddWithValue("@currentSeq", currentSeq);
                cmd.Parameters.AddWithValue("@uGUID", uGUID);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 表名白名单校验
        /// </summary>
        private static bool IsValidTableName(string tableName)
        {
            string[] allowedTables = { "InStockHdr", "OutStockHdr" };
            foreach (string t in allowedTables)
            {
                if (t == tableName)
                    return true;
            }
            return false;
        }
    }
}
