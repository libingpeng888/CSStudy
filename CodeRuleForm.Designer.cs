namespace CSStudy
{
    partial class CodeRuleForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblRuleNo = new Label();
            lblRuleName = new Label();
            lblPrefix = new Label();
            lblDateFormat = new Label();
            lblSeqLength = new Label();
            lblSeqReset = new Label();
            lblBizTable = new Label();
            lblRemark = new Label();
            txtRuleNo = new TextBox();
            txtRuleName = new TextBox();
            txtPrefix = new TextBox();
            txtDateFormat = new TextBox();
            nudSeqLength = new NumericUpDown();
            cboSeqReset = new ComboBox();
            txtBizTable = new TextBox();
            txtRemark = new TextBox();
            lblWType = new Label();
            txtWType = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            dgvList = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudSeqLength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            SuspendLayout();
            //
            // lblRuleNo
            //
            lblRuleNo.AutoSize = true;
            lblRuleNo.Location = new Point(30, 30);
            lblRuleNo.Name = "lblRuleNo";
            lblRuleNo.Size = new Size(69, 20);
            lblRuleNo.Text = "规则编号";
            //
            // lblRuleName
            //
            lblRuleName.AutoSize = true;
            lblRuleName.Location = new Point(300, 30);
            lblRuleName.Name = "lblRuleName";
            lblRuleName.Size = new Size(69, 20);
            lblRuleName.Text = "规则名称";
            //
            // lblPrefix
            //
            lblPrefix.AutoSize = true;
            lblPrefix.Location = new Point(620, 30);
            lblPrefix.Name = "lblPrefix";
            lblPrefix.Size = new Size(39, 20);
            lblPrefix.Text = "前缀";
            //
            // lblDateFormat
            //
            lblDateFormat.AutoSize = true;
            lblDateFormat.Location = new Point(30, 80);
            lblDateFormat.Name = "lblDateFormat";
            lblDateFormat.Size = new Size(69, 20);
            lblDateFormat.Text = "日期格式";
            //
            // lblSeqLength
            //
            lblSeqLength.AutoSize = true;
            lblSeqLength.Location = new Point(300, 80);
            lblSeqLength.Name = "lblSeqLength";
            lblSeqLength.Size = new Size(69, 20);
            lblSeqLength.Text = "序号位数";
            //
            // lblSeqReset
            //
            lblSeqReset.AutoSize = true;
            lblSeqReset.Location = new Point(620, 80);
            lblSeqReset.Name = "lblSeqReset";
            lblSeqReset.Size = new Size(84, 20);
            lblSeqReset.Text = "序号重置";
            //
            // lblBizTable
            //
            lblBizTable.AutoSize = true;
            lblBizTable.Location = new Point(30, 130);
            lblBizTable.Name = "lblBizTable";
            lblBizTable.Size = new Size(69, 20);
            lblBizTable.Text = "业务表名";
            //
            // lblWType
            //
            lblWType.AutoSize = true;
            lblWType.Location = new Point(280, 130);
            lblWType.Name = "lblWType";
            lblWType.Size = new Size(69, 20);
            lblWType.Text = "仓库类型";
            //
            // lblRemark
            //
            lblRemark.AutoSize = true;
            lblRemark.Location = new Point(530, 130);
            lblRemark.Name = "lblRemark";
            lblRemark.Size = new Size(39, 20);
            lblRemark.Text = "备注";
            //
            // txtRuleNo
            //
            txtRuleNo.Location = new Point(110, 27);
            txtRuleNo.Name = "txtRuleNo";
            txtRuleNo.Size = new Size(150, 27);
            txtRuleNo.TabIndex = 0;
            //
            // txtRuleName
            //
            txtRuleName.Location = new Point(390, 27);
            txtRuleName.Name = "txtRuleName";
            txtRuleName.Size = new Size(200, 27);
            txtRuleName.TabIndex = 1;
            //
            // txtPrefix
            //
            txtPrefix.Location = new Point(670, 27);
            txtPrefix.Name = "txtPrefix";
            txtPrefix.Size = new Size(150, 27);
            txtPrefix.TabIndex = 2;
            //
            // txtDateFormat
            //
            txtDateFormat.Location = new Point(110, 77);
            txtDateFormat.Name = "txtDateFormat";
            txtDateFormat.Size = new Size(150, 27);
            txtDateFormat.TabIndex = 3;
            //
            // nudSeqLength
            //
            nudSeqLength.Location = new Point(390, 77);
            nudSeqLength.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudSeqLength.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSeqLength.Name = "nudSeqLength";
            nudSeqLength.Size = new Size(150, 27);
            nudSeqLength.TabIndex = 4;
            nudSeqLength.Value = new decimal(new int[] { 3, 0, 0, 0 });
            //
            // cboSeqReset
            //
            cboSeqReset.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSeqReset.Items.AddRange(new object[] { "按日重置", "累计不重置" });
            cboSeqReset.Location = new Point(710, 77);
            cboSeqReset.Name = "cboSeqReset";
            cboSeqReset.Size = new Size(150, 28);
            cboSeqReset.TabIndex = 5;
            //
            // txtBizTable
            //
            txtBizTable.Location = new Point(110, 127);
            txtBizTable.Name = "txtBizTable";
            txtBizTable.Size = new Size(150, 27);
            txtBizTable.TabIndex = 6;
            //
            // txtWType
            //
            txtWType.Location = new Point(360, 127);
            txtWType.Name = "txtWType";
            txtWType.Size = new Size(150, 27);
            txtWType.TabIndex = 7;
            //
            // txtRemark
            //
            txtRemark.Location = new Point(610, 127);
            txtRemark.Name = "txtRemark";
            txtRemark.Size = new Size(300, 27);
            txtRemark.TabIndex = 8;
            //
            // btnAdd
            //
            btnAdd.Location = new Point(30, 180);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 32);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "新增";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            //
            // btnUpdate
            //
            btnUpdate.Location = new Point(150, 180);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 32);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "修改";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            //
            // btnDelete
            //
            btnDelete.Location = new Point(270, 180);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 32);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "删除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            //
            // btnClear
            //
            btnClear.Location = new Point(390, 180);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 32);
            btnClear.TabIndex = 11;
            btnClear.Text = "清空";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            //
            // dgvList
            //
            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvList.Location = new Point(30, 230);
            dgvList.Name = "dgvList";
            dgvList.RowHeadersWidth = 51;
            dgvList.Size = new Size(1140, 300);
            dgvList.TabIndex = 12;
            dgvList.CellClick += dgvList_CellClick;
            //
            // CodeRuleForm
            //
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 560);
            Controls.Add(dgvList);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(txtRemark);
            Controls.Add(txtWType);
            Controls.Add(txtBizTable);
            Controls.Add(cboSeqReset);
            Controls.Add(nudSeqLength);
            Controls.Add(txtDateFormat);
            Controls.Add(txtPrefix);
            Controls.Add(txtRuleName);
            Controls.Add(txtRuleNo);
            Controls.Add(lblRemark);
            Controls.Add(lblWType);
            Controls.Add(lblBizTable);
            Controls.Add(lblSeqReset);
            Controls.Add(lblSeqLength);
            Controls.Add(lblDateFormat);
            Controls.Add(lblPrefix);
            Controls.Add(lblRuleName);
            Controls.Add(lblRuleNo);
            Name = "CodeRuleForm";
            Text = "编码规则管理";
            ((System.ComponentModel.ISupportInitialize)nudSeqLength).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRuleNo;
        private Label lblRuleName;
        private Label lblPrefix;
        private Label lblDateFormat;
        private Label lblSeqLength;
        private Label lblSeqReset;
        private Label lblBizTable;
        private Label lblWType;
        private Label lblRemark;
        private TextBox txtRuleNo;
        private TextBox txtRuleName;
        private TextBox txtPrefix;
        private TextBox txtDateFormat;
        private NumericUpDown nudSeqLength;
        private ComboBox cboSeqReset;
        private TextBox txtBizTable;
        private TextBox txtWType;
        private TextBox txtRemark;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private DataGridView dgvList;
    }
}
