using System;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CSStudy
{
    public static class InStockRepository
    {
        private const string SelectCols =
            "uGUID, inNo, inDate, wGUID, sGUID, inStatus, inRemark";

        /// <summary>查全部（带仓库名用于左侧列表显示）</summary>
        public static DataTable GetAll()
        {
            using (SqlConnection conn = Db.Open())
            using (SqlDataAdapter da = new SqlDataAdapter(
                "SELECT h.uGUID, h.inNo, h.inDate, w.wName, h.inStatus, h.inRemark " +
                "FROM InStockHdr h LEFT JOIN Warehouse w ON h.wGUID=w.uGUID " +
                "ORDER BY h.inDate DESC, h.inNo DESC", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>按单号查表头</summary>
        public static DataTable GetByNo(string inNo)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlDataAdapter da = new SqlDataAdapter(
                $"SELECT {SelectCols} FROM InStockHdr WHERE inNo=@inNo", conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@inNo", inNo);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>按主键查表头</summary>
        public static DataTable GetByGUID(Guid inGUID)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlDataAdapter da = new SqlDataAdapter(
                $"SELECT {SelectCols} FROM InStockHdr WHERE uGUID=@inGUID", conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@inGUID", inGUID);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>按主键查明细</summary>
        public static DataTable GetDetail(Guid inGUID)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM InStockDtl WHERE inGUID=@inGUID", conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@inGUID", inGUID);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>保存草稿（只插表头+明细，不动库存，inStatus=0）</summary>
        public static Guid SaveDraft(
            string inNo, DateTime inDate, Guid wGUID, Guid? sGUID,
            string inRemark, string createUser, DataTable detail)
        {
            Guid hdrGuid = Guid.NewGuid();
            using (SqlConnection conn = Db.Open())
            using (SqlTransaction tran = conn.BeginTransaction())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO InStockHdr(uGUID, inNo, inDate, wGUID, sGUID, inStatus, inRemark) " +
                        "VALUES(@uGUID, @inNo, @inDate, @wGUID, @sGUID, 0, @inRemark)", conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@uGUID", hdrGuid);
                        cmd.Parameters.AddWithValue("@inNo", inNo);
                        cmd.Parameters.AddWithValue("@inDate", inDate);
                        cmd.Parameters.AddWithValue("@wGUID", wGUID);
                        cmd.Parameters.AddWithValue("@sGUID", (object)sGUID ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@inRemark", inRemark);
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO InStockDtl(inGUID, mGUID, inQty, inPrice, inAmount, inUnit, CreateUser) " +
                        "VALUES(@inGUID, @mGUID, @inQty, @inPrice, @inAmount, @inUnit, @createUser)", conn, tran))
                    {
                        foreach (DataRow row in detail.Rows)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@inGUID", hdrGuid);
                            cmd.Parameters.AddWithValue("@mGUID", row["mGUID"]);
                            cmd.Parameters.AddWithValue("@inQty", row["inQty"]);
                            cmd.Parameters.AddWithValue("@inPrice", row["inPrice"]);
                            cmd.Parameters.AddWithValue("@inAmount", row["inAmount"]);
                            cmd.Parameters.AddWithValue("@inUnit", row["inUnit"]);
                            cmd.Parameters.AddWithValue("@createUser", createUser);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                    return hdrGuid;
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        /// <summary>更新草稿（先删旧明细再插新明细）</summary>
        public static void UpdateDraft(
            Guid inGUID, DateTime inDate, Guid wGUID, Guid? sGUID,
            string inRemark, string createUser, DataTable detail)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlTransaction tran = conn.BeginTransaction())
            {
                try
                {
                    // 校验必须是草稿
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT inStatus FROM InStockHdr WHERE uGUID=@inGUID", conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@inGUID", inGUID);
                        object obj = cmd.ExecuteScalar();
                        if (obj == null || Convert.ToInt32(obj) != 0)
                            throw new Exception("只能修改草稿状态的入库单");
                    }

                    // 更新表头
                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE InStockHdr SET inDate=@inDate, wGUID=@wGUID, sGUID=@sGUID, inRemark=@inRemark WHERE uGUID=@inGUID",
                        conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@inGUID", inGUID);
                        cmd.Parameters.AddWithValue("@inDate", inDate);
                        cmd.Parameters.AddWithValue("@wGUID", wGUID);
                        cmd.Parameters.AddWithValue("@sGUID", (object)sGUID ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@inRemark", inRemark);
                        cmd.ExecuteNonQuery();
                    }

                    // 删旧明细 + 插新明细
                    using (SqlCommand cmd = new SqlCommand(
                        "DELETE FROM InStockDtl WHERE inGUID=@inGUID", conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@inGUID", inGUID);
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO InStockDtl(inGUID, mGUID, inQty, inPrice, inAmount, inUnit, CreateUser) " +
                        "VALUES(@inGUID, @mGUID, @inQty, @inPrice, @inAmount, @inUnit, @createUser)", conn, tran))
                    {
                        foreach (DataRow row in detail.Rows)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@inGUID", inGUID);
                            cmd.Parameters.AddWithValue("@mGUID", row["mGUID"]);
                            cmd.Parameters.AddWithValue("@inQty", row["inQty"]);
                            cmd.Parameters.AddWithValue("@inPrice", row["inPrice"]);
                            cmd.Parameters.AddWithValue("@inAmount", row["inAmount"]);
                            cmd.Parameters.AddWithValue("@inUnit", row["inUnit"]);
                            cmd.Parameters.AddWithValue("@createUser", createUser);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        /// <summary>审核入库单（事务：更新库存 + 设为已审核 inStatus=1）</summary>
        public static void Audit(Guid inGUID, string auditUser)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlTransaction tran = conn.BeginTransaction())
            {
                try
                {
                    // 1. 校验必须是草稿
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT inStatus FROM InStockHdr WHERE uGUID=@inGUID", conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@inGUID", inGUID);
                        object obj = cmd.ExecuteScalar();
                        if (obj == null) throw new Exception("入库单不存在");
                        if (Convert.ToInt32(obj) == 1) throw new Exception("该单已审核，不可重复审核");
                    }

                    // 2. 取 wGUID 供库存更新用
                    Guid wGUID;
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT wGUID FROM InStockHdr WHERE uGUID=@inGUID", conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@inGUID", inGUID);
                        wGUID = (Guid)cmd.ExecuteScalar();
                    }

                    // 3. 更新库存（UPSERT）
                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE Inventory SET stockQty = stockQty + d.inQty " +
                        "FROM Inventory i INNER JOIN InStockDtl d ON i.mGUID=d.mGUID " +
                        "WHERE d.inGUID=@inGUID AND i.wGUID=@wGUID; " +
                        "INSERT INTO Inventory(wGUID, mGUID, stockQty, CreateUser) " +
                        "SELECT @wGUID, d.mGUID, d.inQty, @auditUser FROM InStockDtl d " +
                        "WHERE d.inGUID=@inGUID AND NOT EXISTS " +
                        "(SELECT 1 FROM Inventory i WHERE i.wGUID=@wGUID AND i.mGUID=d.mGUID)",
                        conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@inGUID", inGUID);
                        cmd.Parameters.AddWithValue("@wGUID", wGUID);
                        cmd.Parameters.AddWithValue("@auditUser", auditUser);
                        cmd.ExecuteNonQuery();
                    }

                    // 4. 标记为已审核
                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE InStockHdr SET inStatus=1 WHERE uGUID=@inGUID", conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@inGUID", inGUID);
                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        /// <summary>删除入库单（草稿直接删，已审核先回滚库存再删）</summary>
        public static void Delete(Guid inGUID)
        {
            using (SqlConnection conn = Db.Open())
            using (SqlTransaction tran = conn.BeginTransaction())
            {
                try
                {
                    int status;
                    Guid wGUID;
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT inStatus, wGUID FROM InStockHdr WHERE uGUID=@inGUID", conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@inGUID", inGUID);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (!dr.Read()) throw new Exception("入库单不存在");
                            status = Convert.ToInt32(dr["inStatus"]);
                            wGUID = (Guid)dr["wGUID"];
                        }
                    }

                    // 已审核的要先回滚库存
                    if (status == 1)
                    {
                        using (SqlCommand cmd = new SqlCommand(
                            "UPDATE i SET i.stockQty = i.stockQty - d.inQty " +
                            "FROM Inventory i INNER JOIN InStockDtl d ON i.mGUID=d.mGUID " +
                            "WHERE d.inGUID=@inGUID AND i.wGUID=@wGUID",
                            conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@inGUID", inGUID);
                            cmd.Parameters.AddWithValue("@wGUID", wGUID);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 删明细
                    using (SqlCommand cmd = new SqlCommand(
                        "DELETE FROM InStockDtl WHERE inGUID=@inGUID", conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@inGUID", inGUID);
                        cmd.ExecuteNonQuery();
                    }

                    // 删表头
                    using (SqlCommand cmd = new SqlCommand(
                        "DELETE FROM InStockHdr WHERE uGUID=@inGUID", conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@inGUID", inGUID);
                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }
    }
}
