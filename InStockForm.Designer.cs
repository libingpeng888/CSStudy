namespace CSStudy
{
    partial class InStockForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            pnlTopBar = new Panel();
            lblTitle = new Label();
            btnNew = new Button();
            btnEdit = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            btnAudit = new Button();
            btnDelete = new Button();
            lblStatus = new Label();
            splitMain = new SplitContainer();
            pnlList = new Panel();
            dgvList = new DataGridView();
            colListNo = new DataGridViewTextBoxColumn();
            colListDate = new DataGridViewTextBoxColumn();
            colListStatus = new DataGridViewTextBoxColumn();
            lblListTitle = new Label();
            pnlRight = new Panel();
            grpDetail = new GroupBox();
            btnAddRow = new Button();
            btnDelRow = new Button();
            dgvDetail = new DataGridView();
            colMaterial = new DataGridViewComboBoxColumn();
            colQty = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colAmount = new DataGridViewTextBoxColumn();
            colUnit = new DataGridViewTextBoxColumn();
            grpHdr = new GroupBox();
            lblRemark = new Label();
            lblSupplier = new Label();
            lblWarehouse = new Label();
            lblInDate = new Label();
            lblInNo = new Label();
            txtRemark = new TextBox();
            cboSupplier = new ComboBox();
            cboWarehouse = new ComboBox();
            dtpInDate = new DateTimePicker();
            txtInNo = new TextBox();
            colListWarehouse = new DataGridViewTextBoxColumn();
            pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitMain).BeginInit();
            splitMain.Panel1.SuspendLayout();
            splitMain.Panel2.SuspendLayout();
            splitMain.SuspendLayout();
            pnlList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            pnlRight.SuspendLayout();
            grpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetail).BeginInit();
            grpHdr.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTopBar
            // 
            pnlTopBar.BackColor = Color.FromArgb(245, 247, 250);
            pnlTopBar.Controls.Add(lblTitle);
            pnlTopBar.Controls.Add(btnNew);
            pnlTopBar.Controls.Add(btnEdit);
            pnlTopBar.Controls.Add(btnSave);
            pnlTopBar.Controls.Add(btnCancel);
            pnlTopBar.Controls.Add(btnAudit);
            pnlTopBar.Controls.Add(btnDelete);
            pnlTopBar.Controls.Add(lblStatus);
            pnlTopBar.Dock = DockStyle.Top;
            pnlTopBar.Location = new Point(0, 0);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Padding = new Padding(12, 8, 12, 8);
            pnlTopBar.Size = new Size(1100, 52);
            pnlTopBar.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("微软雅黑", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(51, 65, 85);
            lblTitle.Location = new Point(12, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(112, 27);
            lblTitle.TabIndex = 10;
            lblTitle.Text = "采购入库单";
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(59, 130, 246);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("微软雅黑", 9F);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(140, 12);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(72, 30);
            btnNew.TabIndex = 0;
            btnNew.Text = "  新增";
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Click += btnNew_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(16, 185, 129);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("微软雅黑", 9F);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(220, 12);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(72, 30);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "  编辑";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(59, 130, 246);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("微软雅黑", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(300, 12);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(72, 30);
            btnSave.TabIndex = 2;
            btnSave.Text = "  保存";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(156, 163, 175);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("微软雅黑", 9F);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(380, 12);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(72, 30);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "  取消";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnAudit
            // 
            btnAudit.BackColor = Color.FromArgb(245, 158, 11);
            btnAudit.FlatStyle = FlatStyle.Flat;
            btnAudit.Font = new Font("微软雅黑", 9F);
            btnAudit.ForeColor = Color.White;
            btnAudit.Location = new Point(460, 12);
            btnAudit.Name = "btnAudit";
            btnAudit.Size = new Size(72, 30);
            btnAudit.TabIndex = 4;
            btnAudit.Text = "  审核";
            btnAudit.UseVisualStyleBackColor = false;
            btnAudit.Click += btnAudit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(239, 68, 68);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("微软雅黑", 9F);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(540, 12);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(72, 30);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "  删除";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
            lblStatus.ForeColor = Color.Gray;
            lblStatus.Location = new Point(970, 17);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(112, 24);
            lblStatus.TabIndex = 9;
            lblStatus.Text = "状态：未加载";
            lblStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // splitMain
            // 
            splitMain.BackColor = Color.FromArgb(203, 213, 225);
            splitMain.Dock = DockStyle.Fill;
            splitMain.FixedPanel = FixedPanel.Panel1;
            splitMain.Location = new Point(0, 52);
            splitMain.Name = "splitMain";
            splitMain.Size = new Size(1100, 628);
            splitMain.SplitterDistance = 300;
            splitMain.TabIndex = 1;
            // 
            // splitMain.Panel1
            // 
            splitMain.Panel1.Controls.Add(pnlList);
            // 
            // splitMain.Panel2
            // 
            splitMain.Panel2.Controls.Add(pnlRight);
            // 
            // pnlList
            // 
            pnlList.Controls.Add(dgvList);
            pnlList.Controls.Add(lblListTitle);
            pnlList.Dock = DockStyle.Fill;
            pnlList.Location = new Point(0, 0);
            pnlList.Name = "pnlList";
            pnlList.Padding = new Padding(10);
            pnlList.Size = new Size(300, 628);
            pnlList.TabIndex = 0;
            // 
            // dgvList
            // 
            dgvList.AllowUserToAddRows = false;
            dgvList.AllowUserToDeleteRows = false;
            dgvList.AllowUserToResizeRows = false;
            dgvList.AutoGenerateColumns = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle1.Font = new Font("微软雅黑", 10F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(59, 130, 246);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvList.BackgroundColor = Color.White;
            dgvList.BorderStyle = BorderStyle.None;
            dgvList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(241, 245, 249);
            dataGridViewCellStyle2.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(71, 85, 105);
            dataGridViewCellStyle2.Padding = new Padding(4);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvList.ColumnHeadersHeight = 36;
            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvList.Columns.AddRange(new DataGridViewColumn[] { colListNo, colListDate, colListStatus });
            dataGridViewCellStyle3.Font = new Font("微软雅黑", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(59, 130, 246);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dgvList.DefaultCellStyle = dataGridViewCellStyle3;
            dgvList.Dock = DockStyle.Fill;
            dgvList.EnableHeadersVisualStyles = false;
            dgvList.GridColor = Color.FromArgb(226, 232, 240);
            dgvList.Location = new Point(10, 10);
            dgvList.MultiSelect = false;
            dgvList.Name = "dgvList";
            dgvList.ReadOnly = true;
            dgvList.RowHeadersVisible = false;
            dgvList.RowHeadersWidth = 51;
            dgvList.RowTemplate.Height = 36;
            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.Size = new Size(280, 608);
            dgvList.TabIndex = 0;
            dgvList.SelectionChanged += dgvList_SelectionChanged;
            // 
            // colListNo
            // 
            colListNo.FillWeight = 140F;
            colListNo.HeaderText = "单号";
            colListNo.MinimumWidth = 6;
            colListNo.Name = "colListNo";
            colListNo.ReadOnly = true;
            // 
            // colListDate
            // 
            colListDate.FillWeight = 80F;
            colListDate.HeaderText = "日期";
            colListDate.MinimumWidth = 6;
            colListDate.Name = "colListDate";
            colListDate.ReadOnly = true;
            // 
            // colListStatus
            // 
            colListStatus.FillWeight = 60F;
            colListStatus.HeaderText = "状态";
            colListStatus.MinimumWidth = 6;
            colListStatus.Name = "colListStatus";
            colListStatus.ReadOnly = true;
            // 
            // lblListTitle
            // 
            lblListTitle.AutoSize = true;
            lblListTitle.Font = new Font("微软雅黑", 9F, FontStyle.Bold);
            lblListTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblListTitle.Location = new Point(13, 10);
            lblListTitle.Name = "lblListTitle";
            lblListTitle.Size = new Size(84, 19);
            lblListTitle.TabIndex = 1;
            lblListTitle.Text = "入库单列表";
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(grpDetail);
            pnlRight.Controls.Add(grpHdr);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(0, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(14, 10, 14, 14);
            pnlRight.Size = new Size(796, 628);
            pnlRight.TabIndex = 0;
            // 
            // grpDetail
            // 
            grpDetail.Controls.Add(btnAddRow);
            grpDetail.Controls.Add(btnDelRow);
            grpDetail.Controls.Add(dgvDetail);
            grpDetail.Font = new Font("微软雅黑", 9F, FontStyle.Bold);
            grpDetail.Location = new Point(14, 126);
            grpDetail.Name = "grpDetail";
            grpDetail.Size = new Size(768, 520);
            grpDetail.TabIndex = 1;
            grpDetail.TabStop = false;
            grpDetail.Text = " 入库明细 ";
            // 
            // btnAddRow
            // 
            btnAddRow.BackColor = Color.FromArgb(241, 245, 249);
            btnAddRow.FlatStyle = FlatStyle.Flat;
            btnAddRow.Font = new Font("微软雅黑", 9F);
            btnAddRow.Location = new Point(15, 24);
            btnAddRow.Name = "btnAddRow";
            btnAddRow.Size = new Size(90, 28);
            btnAddRow.TabIndex = 0;
            btnAddRow.Text = "+ 新增行";
            btnAddRow.UseVisualStyleBackColor = false;
            btnAddRow.Click += btnAddRow_Click;
            // 
            // btnDelRow
            // 
            btnDelRow.BackColor = Color.FromArgb(254, 242, 242);
            btnDelRow.FlatStyle = FlatStyle.Flat;
            btnDelRow.Font = new Font("微软雅黑", 9F);
            btnDelRow.ForeColor = Color.FromArgb(220, 38, 38);
            btnDelRow.Location = new Point(110, 24);
            btnDelRow.Name = "btnDelRow";
            btnDelRow.Size = new Size(90, 28);
            btnDelRow.TabIndex = 1;
            btnDelRow.Text = "- 删除行";
            btnDelRow.UseVisualStyleBackColor = false;
            btnDelRow.Click += btnDelRow_Click;
            // 
            // dgvDetail
            // 
            dgvDetail.AllowUserToAddRows = false;
            dgvDetail.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(248, 250, 252);
            dgvDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetail.BackgroundColor = Color.White;
            dgvDetail.BorderStyle = BorderStyle.None;
            dgvDetail.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(241, 245, 249);
            dataGridViewCellStyle4.Font = new Font("微软雅黑", 9F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(71, 85, 105);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvDetail.ColumnHeadersHeight = 34;
            dgvDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDetail.Columns.AddRange(new DataGridViewColumn[] { colMaterial, colQty, colPrice, colAmount, colUnit });
            dgvDetail.GridColor = Color.FromArgb(226, 232, 240);
            dgvDetail.Location = new Point(12, 58);
            dgvDetail.MultiSelect = false;
            dgvDetail.Name = "dgvDetail";
            dgvDetail.RowHeadersWidth = 40;
            dgvDetail.RowTemplate.Height = 30;
            dgvDetail.Size = new Size(720, 426);
            dgvDetail.TabIndex = 2;
            dgvDetail.CellEndEdit += dgvDetail_CellEndEdit;
            // 
            // colMaterial
            // 
            colMaterial.DataPropertyName = "mGUID";
            colMaterial.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            colMaterial.FillWeight = 280F;
            colMaterial.HeaderText = "物料";
            colMaterial.MinimumWidth = 6;
            colMaterial.Name = "colMaterial";
            // 
            // colQty
            // 
            colQty.DataPropertyName = "inQty";
            colQty.FillWeight = 120F;
            colQty.HeaderText = "数量";
            colQty.MinimumWidth = 6;
            colQty.Name = "colQty";
            // 
            // colPrice
            // 
            colPrice.DataPropertyName = "inPrice";
            colPrice.FillWeight = 120F;
            colPrice.HeaderText = "单价";
            colPrice.MinimumWidth = 6;
            colPrice.Name = "colPrice";
            // 
            // colAmount
            // 
            colAmount.DataPropertyName = "inAmount";
            colAmount.FillWeight = 120F;
            colAmount.HeaderText = "金额";
            colAmount.MinimumWidth = 6;
            colAmount.Name = "colAmount";
            // 
            // colUnit
            // 
            colUnit.DataPropertyName = "inUnit";
            colUnit.FillWeight = 80F;
            colUnit.HeaderText = "单位";
            colUnit.MinimumWidth = 6;
            colUnit.Name = "colUnit";
            // 
            // grpHdr
            // 
            grpHdr.Controls.Add(lblRemark);
            grpHdr.Controls.Add(lblSupplier);
            grpHdr.Controls.Add(lblWarehouse);
            grpHdr.Controls.Add(lblInDate);
            grpHdr.Controls.Add(lblInNo);
            grpHdr.Controls.Add(txtRemark);
            grpHdr.Controls.Add(cboSupplier);
            grpHdr.Controls.Add(cboWarehouse);
            grpHdr.Controls.Add(dtpInDate);
            grpHdr.Controls.Add(txtInNo);
            grpHdr.Font = new Font("微软雅黑", 9F, FontStyle.Bold);
            grpHdr.Location = new Point(14, 10);
            grpHdr.Name = "grpHdr";
            grpHdr.Size = new Size(768, 108);
            grpHdr.TabIndex = 0;
            grpHdr.TabStop = false;
            grpHdr.Text = " 基本信息 ";
            // 
            // lblRemark
            // 
            lblRemark.AutoSize = true;
            lblRemark.Font = new Font("微软雅黑", 9F);
            lblRemark.ForeColor = Color.FromArgb(100, 116, 139);
            lblRemark.Location = new Point(370, 70);
            lblRemark.Name = "lblRemark";
            lblRemark.Size = new Size(39, 20);
            lblRemark.TabIndex = 14;
            lblRemark.Text = "备注";
            // 
            // lblSupplier
            // 
            lblSupplier.AutoSize = true;
            lblSupplier.Font = new Font("微软雅黑", 9F);
            lblSupplier.ForeColor = Color.FromArgb(100, 116, 139);
            lblSupplier.Location = new Point(18, 70);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(54, 20);
            lblSupplier.TabIndex = 13;
            lblSupplier.Text = "供应商";
            // 
            // lblWarehouse
            // 
            lblWarehouse.AutoSize = true;
            lblWarehouse.Font = new Font("微软雅黑", 9F);
            lblWarehouse.ForeColor = Color.FromArgb(100, 116, 139);
            lblWarehouse.Location = new Point(490, 29);
            lblWarehouse.Name = "lblWarehouse";
            lblWarehouse.Size = new Size(39, 20);
            lblWarehouse.TabIndex = 12;
            lblWarehouse.Text = "仓库";
            // 
            // lblInDate
            // 
            lblInDate.AutoSize = true;
            lblInDate.Font = new Font("微软雅黑", 9F);
            lblInDate.ForeColor = Color.FromArgb(100, 116, 139);
            lblInDate.Location = new Point(258, 29);
            lblInDate.Name = "lblInDate";
            lblInDate.Size = new Size(69, 20);
            lblInDate.TabIndex = 11;
            lblInDate.Text = "入库日期";
            // 
            // lblInNo
            // 
            lblInNo.AutoSize = true;
            lblInNo.Font = new Font("微软雅黑", 9F);
            lblInNo.ForeColor = Color.FromArgb(100, 116, 139);
            lblInNo.Location = new Point(18, 30);
            lblInNo.Name = "lblInNo";
            lblInNo.Size = new Size(69, 20);
            lblInNo.TabIndex = 10;
            lblInNo.Text = "入库单号";
            // 
            // txtRemark
            // 
            txtRemark.Font = new Font("微软雅黑", 9F);
            txtRemark.Location = new Point(420, 66);
            txtRemark.Name = "txtRemark";
            txtRemark.Size = new Size(310, 27);
            txtRemark.TabIndex = 4;
            // 
            // cboSupplier
            // 
            cboSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSupplier.Font = new Font("微软雅黑", 9F);
            cboSupplier.FormattingEnabled = true;
            cboSupplier.Location = new Point(90, 66);
            cboSupplier.Name = "cboSupplier";
            cboSupplier.Size = new Size(270, 28);
            cboSupplier.TabIndex = 3;
            // 
            // cboWarehouse
            // 
            cboWarehouse.DropDownStyle = ComboBoxStyle.DropDownList;
            cboWarehouse.Font = new Font("微软雅黑", 9F);
            cboWarehouse.FormattingEnabled = true;
            cboWarehouse.Location = new Point(535, 26);
            cboWarehouse.Name = "cboWarehouse";
            cboWarehouse.Size = new Size(195, 28);
            cboWarehouse.TabIndex = 2;
            cboWarehouse.SelectedIndexChanged += cboWarehouse_SelectedIndexChanged;
            // 
            // dtpInDate
            // 
            dtpInDate.Font = new Font("微软雅黑", 9F);
            dtpInDate.Location = new Point(333, 26);
            dtpInDate.Name = "dtpInDate";
            dtpInDate.Size = new Size(151, 27);
            dtpInDate.TabIndex = 1;
            // 
            // txtInNo
            // 
            txtInNo.Font = new Font("微软雅黑", 9F);
            txtInNo.Location = new Point(90, 26);
            txtInNo.Name = "txtInNo";
            txtInNo.ReadOnly = true;
            txtInNo.Size = new Size(162, 27);
            txtInNo.TabIndex = 0;
            // 
            // colListWarehouse
            // 
            colListWarehouse.FillWeight = 70F;
            colListWarehouse.HeaderText = "仓库";
            colListWarehouse.MinimumWidth = 6;
            colListWarehouse.Name = "colListWarehouse";
            colListWarehouse.ReadOnly = true;
            colListWarehouse.Width = 70;
            // 
            // InStockForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1100, 680);
            Controls.Add(splitMain);
            Controls.Add(pnlTopBar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "InStockForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "采购入库单管理";
            pnlTopBar.ResumeLayout(false);
            pnlTopBar.PerformLayout();
            splitMain.Panel1.ResumeLayout(false);
            splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitMain).EndInit();
            splitMain.ResumeLayout(false);
            pnlList.ResumeLayout(false);
            pnlList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            pnlRight.ResumeLayout(false);
            grpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDetail).EndInit();
            grpHdr.ResumeLayout(false);
            grpHdr.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAudit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListWarehouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colListStatus;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.GroupBox grpHdr;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Label lblInNo;
        private System.Windows.Forms.Label lblInDate;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.TextBox txtInNo;
        private System.Windows.Forms.DateTimePicker dtpInDate;
        private System.Windows.Forms.ComboBox cboWarehouse;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Button btnDelRow;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.DataGridViewComboBoxColumn colMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnit;
    }
}
