using System;
using System.Data;
using System.Windows.Forms;

namespace CSStudy
{
    public partial class InStockForm : Form
    {
        public string CurrentUser { get; set; } = "admin";

        // 明细 DataTable，列名要和 InStockRepository 里取的列名一致
        private DataTable _detailTable;

        // 当前主键（null=未加载任何单据）
        private Guid? _currentInGUID;

        // 当前状态：0=草稿（可编辑可审核），1=已审核（只读）
        private int _currentStatus;

        // 当前模式：View/Edit/New
        private enum EditMode { View, Edit, New }
        private EditMode _mode = EditMode.View;

        public InStockForm()
        {
            InitializeComponent();
            LoadMaterials();       // 先给 ComboBox 列设好 DataSource
            InitDetailTable();     // 再绑明细表
            LoadWarehouses();
            LoadSuppliers();
            LoadList();            // 左侧列表
            SetEditMode(EditMode.View);
            ClearRightPanel();
        }

        #region 初始化明细 DataTable
        private void InitDetailTable()
        {
            _detailTable = new DataTable();
            _detailTable.Columns.Add("mGUID", typeof(Guid));
            _detailTable.Columns.Add("inQty", typeof(decimal));
            _detailTable.Columns.Add("inPrice", typeof(decimal));
            _detailTable.Columns.Add("inAmount", typeof(decimal));
            _detailTable.Columns.Add("inUnit", typeof(string));
            dgvDetail.DataSource = _detailTable;
        }
        #endregion

        #region 加载仓库下拉（只保留坯布仓和成品仓）
        private void LoadWarehouses()
        {
            cboWarehouse.SelectedIndexChanged -= cboWarehouse_SelectedIndexChanged;
            DataTable dt = WarehouseRepository.GetAll();
            dt.DefaultView.RowFilter = "wType IN ('坯布','成品')";
            cboWarehouse.DisplayMember = "wName";
            cboWarehouse.ValueMember = "uGUID";
            cboWarehouse.DataSource = dt.DefaultView.ToTable();
            cboWarehouse.SelectedIndexChanged += cboWarehouse_SelectedIndexChanged;
        }
        #endregion

        #region 加载供应商下拉
        private void LoadSuppliers()
        {
            DataTable dt = SupplierRepository.GetAll();
            cboSupplier.DisplayMember = "suppName";
            cboSupplier.ValueMember = "uGUID";
            cboSupplier.DataSource = dt;
        }
        #endregion

        #region 加载物料下拉列
        private void LoadMaterials()
        {
            DataTable dt = MaterialRepository.GetAll();
            colMaterial.DisplayMember = "mName";
            colMaterial.ValueMember = "uGUID";
            colMaterial.DataSource = dt;
        }
        #endregion

        #region 加载左侧入库单列表
        private void LoadList()
        {
            DataTable dt = InStockRepository.GetAll();
            DataTable display = dt.Clone();
            display.Columns["inStatus"].DataType = typeof(string);
            foreach (DataRow row in dt.Rows)
            {
                DataRow r = display.NewRow();
                r["uGUID"] = row["uGUID"];
                r["inNo"] = row["inNo"];
                r["inDate"] = Convert.ToDateTime(row["inDate"]).ToString("yyyy-MM-dd");
                r["wName"] = row["wName"];
                r["inStatus"] = Convert.ToInt32(row["inStatus"]) == 0 ? "草稿" : "已审核";
                r["inRemark"] = row["inRemark"];
                display.Rows.Add(r);
            }
            dgvList.AutoGenerateColumns = false;  // 保险：防止 VS 设计器重置
            dgvList.DataSource = display;

            // 状态列上色
            dgvList.CellFormatting -= dgvList_CellFormatting;
            dgvList.CellFormatting += dgvList_CellFormatting;
        }

        private void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvList.Columns[e.ColumnIndex].Name == "colListStatus")
            {
                string val = e.Value?.ToString() ?? "";
                if (val == "草稿")
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12);   // 橙色
                    e.CellStyle.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold);
                }
                else if (val == "已审核")
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);   // 绿色
                    e.CellStyle.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold);
                }
            }
        }
        #endregion

        #region 列表选择变化 → 加载到右侧（只读查看）
        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvList.CurrentRow == null || dgvList.CurrentRow.Index < 0) return;
            if (dgvList.CurrentRow.DataBoundItem is DataRowView drv)
            {
                Guid guid = (Guid)drv["uGUID"];
                LoadInStock(guid);
            }
        }

        private void LoadInStock(Guid inGUID)
        {
            try
            {
                DataTable hdr = InStockRepository.GetByGUID(inGUID);
                if (hdr.Rows.Count == 0) return;

                DataRow row = hdr.Rows[0];
                _currentInGUID = (Guid)row["uGUID"];
                _currentStatus = Convert.ToInt32(row["inStatus"]);
                txtInNo.Text = row["inNo"].ToString();
                dtpInDate.Value = Convert.ToDateTime(row["inDate"]);
                // 临时取消事件，防止重新生成单号
                cboWarehouse.SelectedIndexChanged -= cboWarehouse_SelectedIndexChanged;
                cboWarehouse.SelectedValue = row["wGUID"];
                cboWarehouse.SelectedIndexChanged += cboWarehouse_SelectedIndexChanged;
                if (row["sGUID"] != DBNull.Value)
                    cboSupplier.SelectedValue = row["sGUID"];
                else
                    cboSupplier.SelectedIndex = -1;
                txtRemark.Text = row["inRemark"]?.ToString() ?? "";

                // 加载明细
                DataTable dtl = InStockRepository.GetDetail(_currentInGUID.Value);
                _detailTable.Rows.Clear();
                foreach (DataRow dr in dtl.Rows)
                {
                    DataRow newRow = _detailTable.NewRow();
                    newRow["mGUID"] = dr["mGUID"];
                    newRow["inQty"] = dr["inQty"];
                    newRow["inPrice"] = dr["inPrice"];
                    newRow["inAmount"] = dr["inAmount"];
                    newRow["inUnit"] = dr["inUnit"];
                    _detailTable.Rows.Add(newRow);
                }

                SetEditMode(EditMode.View);
                UpdateStatusLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载失败：" + ex.Message);
            }
        }
        #endregion

        #region 仓库选择变化 → 自动生成对应编码
        private void cboWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_mode != EditMode.New) return;  // 只有新增时才自动生成
            try
            {
                if (cboWarehouse.SelectedItem is DataRowView drv)
                {
                    string wType = drv["wType"]?.ToString();
                    if (!string.IsNullOrEmpty(wType))
                    {
                        txtInNo.Text = SysCodeRuleRepository.GenerateCodeByWarehouseType(wType, "InStockHdr");
                    }
                }
            }
            catch { }
        }
        #endregion

        #region 按钮状态机
        private void SetEditMode(EditMode mode)
        {
            _mode = mode;
            bool isNew = mode == EditMode.New;
            bool isEdit = mode == EditMode.Edit;
            bool isView = mode == EditMode.View;
            bool isDraft = _currentStatus == 0;  // 当前选中的是草稿
            bool isAudited = _currentStatus == 1; // 当前选中的是已审核

            // 表头编辑控件：仅 New 和 Edit 可编辑
            bool headEditable = isNew || isEdit;
            dtpInDate.Enabled = headEditable;
            cboWarehouse.Enabled = headEditable;
            cboSupplier.Enabled = headEditable;
            txtRemark.ReadOnly = !headEditable;

            // 明细：仅 New 和 Edit 可编辑
            dgvDetail.Enabled = headEditable;
            btnAddRow.Enabled = headEditable;
            btnDelRow.Enabled = headEditable;

            // 按钮状态
            btnNew.Enabled = true;                                    // 新增永远可点
            btnEdit.Enabled = isView && _currentInGUID.HasValue && isDraft; // 只有查看草稿时可编辑
            btnSave.Enabled = isNew || isEdit;                        // 编辑中才显示保存
            btnCancel.Enabled = isNew || isEdit;                      // 编辑中才显示取消
            btnAudit.Enabled = isView && _currentInGUID.HasValue && isDraft; // 查看草稿时可审核
            btnDelete.Enabled = isView && _currentInGUID.HasValue;   // 查看已加载的单可删

            // 审核状态的单据，所有编辑按钮禁用（只能看）
            if (isAudited && isView)
            {
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnEdit.Enabled = false;
            }
        }

        private void UpdateStatusLabel()
        {
            if (!_currentInGUID.HasValue)
            {
                lblStatus.Text = "状态：";
                lblStatus.ForeColor = System.Drawing.Color.Gray;
            }
            else if (_currentStatus == 0)
            {
                lblStatus.Text = "状态：草稿";
                lblStatus.ForeColor = System.Drawing.Color.DarkOrange;
            }
            else
            {
                lblStatus.Text = "状态：已审核";
                lblStatus.ForeColor = System.Drawing.Color.SeaGreen;
            }
        }
        #endregion

        #region 清空右侧面板
        private void ClearRightPanel()
        {
            txtInNo.Clear();
            dtpInDate.Value = DateTime.Now;
            cboWarehouse.SelectedIndex = -1;
            cboSupplier.SelectedIndex = -1;
            txtRemark.Clear();
            _detailTable.Rows.Clear();
            _currentInGUID = null;
            _currentStatus = 0;
            UpdateStatusLabel();
        }
        #endregion

        #region 新增
        private void btnNew_Click(object sender, EventArgs e)
        {
            // 先取消左侧选中，避免 SelectionChanged 回载
            dgvList.ClearSelection();
            ClearRightPanel();
            SetEditMode(EditMode.New);
            cboWarehouse.Focus();
        }
        #endregion

        #region 编辑
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!_currentInGUID.HasValue) { MessageBox.Show("请先从左侧选择一个草稿"); return; }
            if (_currentStatus == 1) { MessageBox.Show("已审核的单据不可编辑"); return; }
            SetEditMode(EditMode.Edit);
        }
        #endregion

        #region 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 校验
            if (string.IsNullOrEmpty(txtInNo.Text.Trim()))
            { MessageBox.Show("请选择仓库以生成单号"); return; }
            if (cboWarehouse.SelectedValue == null)
            { MessageBox.Show("请选择仓库"); return; }
            if (_detailTable.Rows.Count == 0)
            { MessageBox.Show("请至少添加一行明细"); return; }
            foreach (DataRow row in _detailTable.Rows)
            {
                if (row["mGUID"] == DBNull.Value || row["mGUID"] == null)
                { MessageBox.Show("明细行必须选择物料"); return; }
                if (Convert.ToDecimal(row["inQty"]) <= 0)
                { MessageBox.Show("明细数量必须大于 0"); return; }
            }

            try
            {
                string inNo = txtInNo.Text.Trim();
                DateTime inDate = dtpInDate.Value;
                Guid wGUID = (Guid)cboWarehouse.SelectedValue;
                Guid? sGUID = cboSupplier.SelectedValue == null ? null : (Guid?)cboSupplier.SelectedValue;
                string remark = txtRemark.Text.Trim();

                if (_mode == EditMode.New)
                {
                    // 草稿保存
                    _currentInGUID = InStockRepository.SaveDraft(inNo, inDate, wGUID, sGUID, remark, CurrentUser, _detailTable);
                    _currentStatus = 0;
                    MessageBox.Show("草稿保存成功！");
                }
                else // Edit
                {
                    InStockRepository.UpdateDraft(_currentInGUID.Value, inDate, wGUID, sGUID, remark, CurrentUser, _detailTable);
                    MessageBox.Show("修改保存成功！");
                }

                SetEditMode(EditMode.View);
                UpdateStatusLabel();
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败：" + ex.Message);
            }
        }
        #endregion

        #region 取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认放弃当前编辑？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (_currentInGUID.HasValue)
                LoadInStock(_currentInGUID.Value);  // 重新加载
            else
            {
                ClearRightPanel();
                SetEditMode(EditMode.View);
            }
        }
        #endregion

        #region 审核（审核后才算进库存）
        private void btnAudit_Click(object sender, EventArgs e)
        {
            if (!_currentInGUID.HasValue) return;
            if (_currentStatus == 1) { MessageBox.Show("该单已审核"); return; }

            if (MessageBox.Show(
                $"确认审核入库单 {txtInNo.Text}？\n审核后库存将自动增加，且不可修改。",
                "确认审核", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                InStockRepository.Audit(_currentInGUID.Value, CurrentUser);
                _currentStatus = 1;
                MessageBox.Show("审核成功！库存已更新");
                SetEditMode(EditMode.View);
                UpdateStatusLabel();
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("审核失败：" + ex.Message);
            }
        }
        #endregion

        #region 删除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_currentInGUID.HasValue) { MessageBox.Show("请先从左侧选择一个单据"); return; }

            string extra = _currentStatus == 1 ? "\n库存将自动回滚。" : "";
            if (MessageBox.Show(
                $"确认删除入库单 {txtInNo.Text}？{extra}",
                "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            try
            {
                InStockRepository.Delete(_currentInGUID.Value);
                MessageBox.Show("删除成功");
                ClearRightPanel();
                SetEditMode(EditMode.View);
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败：" + ex.Message);
            }
        }
        #endregion

        #region 明细行操作
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            DataRow row = _detailTable.NewRow();
            row["inQty"] = 0;
            row["inPrice"] = 0;
            row["inAmount"] = 0;
            row["inUnit"] = "";
            _detailTable.Rows.Add(row);
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            if (dgvDetail.CurrentRow == null) { MessageBox.Show("请先选中要删除的行"); return; }
            if (MessageBox.Show("确认删除该行？", "确认", MessageBoxButtons.YesNo) == DialogResult.No) return;
            int idx = dgvDetail.CurrentRow.Index;
            if (idx >= 0 && idx < _detailTable.Rows.Count)
                _detailTable.Rows.RemoveAt(idx);
        }

        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataRow row = _detailTable.Rows[e.RowIndex];

            // 选了物料后，自动带出单位和单价
            if (dgvDetail.Columns[e.ColumnIndex].Name == "colMaterial")
            {
                if (row["mGUID"] != DBNull.Value && row["mGUID"] != null)
                {
                    Guid mGuid = (Guid)row["mGUID"];
                    DataTable dt = MaterialRepository.GetAll();
                    foreach (DataRow mr in dt.Rows)
                    {
                        if ((Guid)mr["uGUID"] == mGuid)
                        {
                            row["inUnit"] = mr["mUnit"]?.ToString() ?? "";
                            row["inPrice"] = Convert.ToDecimal(mr["mPrice"]);
                            break;
                        }
                    }
                }
            }

            // 数量或单价变了，重算金额
            if (dgvDetail.Columns[e.ColumnIndex].Name == "colQty" ||
                dgvDetail.Columns[e.ColumnIndex].Name == "colPrice")
            {
                decimal qty = row["inQty"] == DBNull.Value ? 0 : Convert.ToDecimal(row["inQty"]);
                decimal price = row["inPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(row["inPrice"]);
                row["inAmount"] = Math.Round(qty * price, 4);
            }
        }
        #endregion
    }
}
