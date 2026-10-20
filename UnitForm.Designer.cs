namespace CSStudy
{
    partial class UnitForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtUnitNo = new TextBox();
            txtUnitName = new TextBox();
            txtFactor = new TextBox();
            chkBase = new CheckBox();
            txtUnitRemark = new TextBox();
            txtSearch = new TextBox();
            cboSearchField = new ComboBox();
            btnQuery = new Button();
            btnReset = new Button();
            btnSubmit = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            dgvUnit = new DataGridView();
            uNo = new DataGridViewTextBoxColumn();
            uName = new DataGridViewTextBoxColumn();
            uFactor = new DataGridViewTextBoxColumn();
            uBase = new DataGridViewCheckBoxColumn();
            uRemark = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvUnit).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 42);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 0;
            label1.Text = "单位编码";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 89);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 1;
            label2.Text = "单位名称";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 136);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 2;
            label3.Text = "换算系数";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 183);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 3;
            label4.Text = "基准";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 230);
            label5.Name = "label5";
            label5.Size = new Size(39, 20);
            label5.TabIndex = 4;
            label5.Text = "备注";
            // 
            // txtUnitNo
            // 
            txtUnitNo.Location = new Point(104, 39);
            txtUnitNo.Name = "txtUnitNo";
            txtUnitNo.Size = new Size(125, 27);
            txtUnitNo.TabIndex = 0;
            // 
            // txtUnitName
            // 
            txtUnitName.Location = new Point(104, 86);
            txtUnitName.Name = "txtUnitName";
            txtUnitName.Size = new Size(125, 27);
            txtUnitName.TabIndex = 1;
            // 
            // txtFactor
            // 
            txtFactor.Location = new Point(104, 133);
            txtFactor.Name = "txtFactor";
            txtFactor.Size = new Size(125, 27);
            txtFactor.TabIndex = 2;
            // 
            // chkBase
            // 
            chkBase.AutoSize = true;
            chkBase.Location = new Point(104, 183);
            chkBase.Name = "chkBase";
            chkBase.Size = new Size(91, 24);
            chkBase.TabIndex = 3;
            chkBase.Text = "是否基准单位";
            chkBase.UseVisualStyleBackColor = true;
            // 
            // txtUnitRemark
            // 
            txtUnitRemark.Location = new Point(104, 227);
            txtUnitRemark.Multiline = true;
            txtUnitRemark.Name = "txtUnitRemark";
            txtUnitRemark.Size = new Size(125, 54);
            txtUnitRemark.TabIndex = 4;
            // 
            // cboSearchField
            // 
            cboSearchField.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSearchField.FormattingEnabled = true;
            cboSearchField.Items.AddRange(new object[] { "单位编码", "单位名称" });
            cboSearchField.Location = new Point(436, 28);
            cboSearchField.Name = "cboSearchField";
            cboSearchField.Size = new Size(120, 28);
            cboSearchField.TabIndex = 20;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(566, 28);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(164, 27);
            txtSearch.TabIndex = 5;
            txtSearch.KeyPress += txtSearch_KeyPress;
            // 
            // btnQuery
            // 
            btnQuery.Location = new Point(736, 26);
            btnQuery.Name = "btnQuery";
            btnQuery.Size = new Size(94, 29);
            btnQuery.TabIndex = 6;
            btnQuery.Text = "查询";
            btnQuery.UseVisualStyleBackColor = true;
            btnQuery.Click += btnQuery_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(836, 26);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 7;
            btnReset.Text = "重置查询";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(30, 344);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(94, 29);
            btnSubmit.TabIndex = 8;
            btnSubmit.Text = "提交";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(158, 344);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 9;
            btnClear.Text = "清空";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(30, 403);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "删除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvUnit
            // 
            dgvUnit.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUnit.Columns.AddRange(new DataGridViewColumn[] { uNo, uName, uFactor, uBase, uRemark });
            dgvUnit.Location = new Point(436, 78);
            dgvUnit.Name = "dgvUnit";
            dgvUnit.RowHeadersWidth = 51;
            dgvUnit.Size = new Size(805, 308);
            dgvUnit.TabIndex = 11;
            dgvUnit.DoubleClick += dgvUnit_DoubleClick;
            // 
            // uNo
            // 
            uNo.DataPropertyName = "uNo";
            uNo.HeaderText = "单位编码";
            uNo.MinimumWidth = 6;
            uNo.Name = "uNo";
            uNo.Width = 125;
            // 
            // uName
            // 
            uName.DataPropertyName = "uName";
            uName.HeaderText = "单位名称";
            uName.MinimumWidth = 6;
            uName.Name = "uName";
            uName.Width = 125;
            // 
            // uFactor
            // 
            uFactor.DataPropertyName = "uFactor";
            uFactor.HeaderText = "换算系数";
            uFactor.MinimumWidth = 6;
            uFactor.Name = "uFactor";
            uFactor.Width = 125;
            // 
            // uBase
            // 
            uBase.DataPropertyName = "uBase";
            uBase.HeaderText = "基准单位";
            uBase.MinimumWidth = 6;
            uBase.Name = "uBase";
            uBase.Width = 125;
            // 
            // uRemark
            // 
            uRemark.DataPropertyName = "uRemark";
            uRemark.HeaderText = "备注";
            uRemark.MinimumWidth = 6;
            uRemark.Name = "uRemark";
            uRemark.Width = 150;
            // 
            // UnitForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1302, 548);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(btnSubmit);
            Controls.Add(btnReset);
            Controls.Add(btnQuery);
            Controls.Add(txtSearch);
            Controls.Add(cboSearchField);
            Controls.Add(txtUnitRemark);
            Controls.Add(chkBase);
            Controls.Add(txtFactor);
            Controls.Add(txtUnitName);
            Controls.Add(txtUnitNo);
            Controls.Add(dgvUnit);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UnitForm";
            Text = "计量单位";
            ((System.ComponentModel.ISupportInitialize)dgvUnit).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtUnitNo;
        private TextBox txtUnitName;
        private TextBox txtFactor;
        private CheckBox chkBase;
        private TextBox txtUnitRemark;
        private TextBox txtSearch;
        private ComboBox cboSearchField;
        private Button btnQuery;
        private Button btnReset;
        private Button btnSubmit;
        private Button btnClear;
        private Button btnDelete;
        private DataGridView dgvUnit;
        private DataGridViewTextBoxColumn uNo;
        private DataGridViewTextBoxColumn uName;
        private DataGridViewTextBoxColumn uFactor;
        private DataGridViewCheckBoxColumn uBase;
        private DataGridViewTextBoxColumn uRemark;
    }
}
