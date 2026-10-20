namespace CSStudy
{
    partial class MaterialForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed;</param>
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtMNo = new TextBox();
            txtMName = new TextBox();
            txtMSpec = new TextBox();
            txtMUnit = new TextBox();
            txtMPrice = new TextBox();
            txtMRemark = new TextBox();
            lstResult = new ListBox();
            txtSearch = new TextBox();
            cboSearchField = new ComboBox();
            cboSearchValue = new ComboBox();
            btnQuery = new Button();
            btnReset = new Button();
            btnSubmit = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            dgvMaterial = new DataGridView();
            cboCategory = new ComboBox();
            label7 = new Label();
            mNo = new DataGridViewTextBoxColumn();
            mName = new DataGridViewTextBoxColumn();
            mSpec = new DataGridViewTextBoxColumn();
            mUnit = new DataGridViewTextBoxColumn();
            mPrice = new DataGridViewTextBoxColumn();
            mCategory = new DataGridViewTextBoxColumn();
            mRemark = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvMaterial).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 42);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 0;
            label1.Text = "物料编号";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 86);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 1;
            label2.Text = "物料名称";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 132);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 2;
            label3.Text = "规格型号";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 178);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 3;
            label4.Text = "计量单位";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 224);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 4;
            label5.Text = "参考单价";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(30, 316);
            label6.Name = "label6";
            label6.Size = new Size(39, 20);
            label6.TabIndex = 5;
            label6.Text = "备注";
            // 
            // txtMNo
            // 
            txtMNo.Location = new Point(104, 39);
            txtMNo.Name = "txtMNo";
            txtMNo.Size = new Size(125, 27);
            txtMNo.TabIndex = 0;
            // 
            // txtMName
            // 
            txtMName.Location = new Point(104, 83);
            txtMName.Name = "txtMName";
            txtMName.Size = new Size(125, 27);
            txtMName.TabIndex = 1;
            // 
            // txtMSpec
            // 
            txtMSpec.Location = new Point(104, 129);
            txtMSpec.Name = "txtMSpec";
            txtMSpec.Size = new Size(125, 27);
            txtMSpec.TabIndex = 2;
            // 
            // txtMUnit
            // 
            txtMUnit.Location = new Point(104, 175);
            txtMUnit.Name = "txtMUnit";
            txtMUnit.Size = new Size(125, 27);
            txtMUnit.TabIndex = 3;
            // 
            // txtMPrice
            // 
            txtMPrice.Location = new Point(104, 221);
            txtMPrice.Name = "txtMPrice";
            txtMPrice.Size = new Size(125, 27);
            txtMPrice.TabIndex = 4;
            // 
            // txtMRemark
            // 
            txtMRemark.Location = new Point(104, 313);
            txtMRemark.Multiline = true;
            txtMRemark.Name = "txtMRemark";
            txtMRemark.Size = new Size(125, 54);
            txtMRemark.TabIndex = 6;
            // 
            // lstResult
            // 
            lstResult.FormattingEnabled = true;
            lstResult.Location = new Point(268, 42);
            lstResult.Name = "lstResult";
            lstResult.Size = new Size(150, 304);
            lstResult.TabIndex = 7;
            // 
            // cboSearchField
            // 
            cboSearchField.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSearchField.FormattingEnabled = true;
            cboSearchField.Items.AddRange(new object[] { "物料编号", "物料名称", "规格型号", "物料分类" });
            cboSearchField.Location = new Point(436, 28);
            cboSearchField.Name = "cboSearchField";
            cboSearchField.Size = new Size(120, 28);
            cboSearchField.TabIndex = 20;
            cboSearchField.SelectedIndexChanged += cboSearchField_SelectedIndexChanged;
            // 
            // cboSearchValue
            // 
            cboSearchValue.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSearchValue.FormattingEnabled = true;
            cboSearchValue.Location = new Point(566, 28);
            cboSearchValue.Name = "cboSearchValue";
            cboSearchValue.Size = new Size(164, 27);
            cboSearchValue.TabIndex = 21;
            cboSearchValue.Visible = false;
            cboSearchValue.KeyDown += cboSearchValue_KeyDown;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(566, 28);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(164, 27);
            txtSearch.TabIndex = 8;
            txtSearch.KeyPress += txtSearch_KeyPress;
            // 
            // btnQuery
            // 
            btnQuery.Location = new Point(736, 26);
            btnQuery.Name = "btnQuery";
            btnQuery.Size = new Size(94, 29);
            btnQuery.TabIndex = 9;
            btnQuery.Text = "查询";
            btnQuery.UseVisualStyleBackColor = true;
            btnQuery.Click += btnQuery_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(836, 26);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 10;
            btnReset.Text = "重置查询";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(30, 390);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(94, 29);
            btnSubmit.TabIndex = 11;
            btnSubmit.Text = "提交";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(158, 390);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 12;
            btnClear.Text = "清空";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(30, 448);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "删除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvMaterial
            // 
            dgvMaterial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMaterial.Columns.AddRange(new DataGridViewColumn[] { mNo, mName, mSpec, mUnit, mPrice, mCategory, mRemark });
            dgvMaterial.Location = new Point(436, 83);
            dgvMaterial.Name = "dgvMaterial";
            dgvMaterial.RowHeadersWidth = 51;
            dgvMaterial.Size = new Size(805, 382);
            dgvMaterial.TabIndex = 14;
            dgvMaterial.DoubleClick += dgvMaterial_DoubleClick;
            // 
            // cboCategory
            // 
            cboCategory.FormattingEnabled = true;
            cboCategory.Items.AddRange(new object[] { "原材料", "半成品", "成品", "辅料", "包装物" });
            cboCategory.Location = new Point(104, 267);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(125, 28);
            cboCategory.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(30, 270);
            label7.Name = "label7";
            label7.Size = new Size(69, 20);
            label7.TabIndex = 15;
            label7.Text = "物料分类";
            // 
            // mNo
            // 
            mNo.DataPropertyName = "mNo";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            mNo.DefaultCellStyle = dataGridViewCellStyle1;
            mNo.HeaderText = "物料编号";
            mNo.MinimumWidth = 6;
            mNo.Name = "mNo";
            mNo.Width = 110;
            // 
            // mName
            // 
            mName.DataPropertyName = "mName";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            mName.DefaultCellStyle = dataGridViewCellStyle2;
            mName.HeaderText = "物料名称";
            mName.MinimumWidth = 6;
            mName.Name = "mName";
            mName.Width = 120;
            // 
            // mSpec
            // 
            mSpec.DataPropertyName = "mSpec";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            mSpec.DefaultCellStyle = dataGridViewCellStyle3;
            mSpec.HeaderText = "规格型号";
            mSpec.MinimumWidth = 6;
            mSpec.Name = "mSpec";
            mSpec.Width = 120;
            // 
            // mUnit
            // 
            mUnit.DataPropertyName = "mUnit";
            mUnit.HeaderText = "单位";
            mUnit.MinimumWidth = 6;
            mUnit.Name = "mUnit";
            mUnit.Width = 80;
            // 
            // mPrice
            // 
            mPrice.DataPropertyName = "mPrice";
            mPrice.HeaderText = "单价";
            mPrice.MinimumWidth = 6;
            mPrice.Name = "mPrice";
            mPrice.Width = 80;
            // 
            // mCategory
            // 
            mCategory.DataPropertyName = "mCategory";
            mCategory.HeaderText = "分类";
            mCategory.MinimumWidth = 6;
            mCategory.Name = "mCategory";
            // 
            // mRemark
            // 
            mRemark.DataPropertyName = "mRemark";
            mRemark.HeaderText = "备注";
            mRemark.MinimumWidth = 6;
            mRemark.Name = "mRemark";
            mRemark.Width = 150;
            // 
            // MaterialForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1302, 548);
            Controls.Add(label7);
            Controls.Add(cboCategory);
            Controls.Add(dgvMaterial);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(btnSubmit);
            Controls.Add(btnReset);
            Controls.Add(btnQuery);
            Controls.Add(cboSearchValue);
            Controls.Add(cboSearchField);
            Controls.Add(txtSearch);
            Controls.Add(lstResult);
            Controls.Add(txtMRemark);
            Controls.Add(txtMPrice);
            Controls.Add(txtMUnit);
            Controls.Add(txtMSpec);
            Controls.Add(txtMName);
            Controls.Add(txtMNo);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MaterialForm";
            Text = "物料档案";
            ((System.ComponentModel.ISupportInitialize)dgvMaterial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtMNo;
        private TextBox txtMName;
        private TextBox txtMSpec;
        private TextBox txtMUnit;
        private TextBox txtMPrice;
        private TextBox txtMRemark;
        private ListBox lstResult;
        private TextBox txtSearch;
        private ComboBox cboSearchField;
        private ComboBox cboSearchValue;
        private Button btnQuery;
        private Button btnReset;
        private Button btnSubmit;
        private Button btnClear;
        private Button btnDelete;
        private DataGridView dgvMaterial;
        private ComboBox cboCategory;
        private Label label7;
        private DataGridViewTextBoxColumn mNo;
        private DataGridViewTextBoxColumn mName;
        private DataGridViewTextBoxColumn mSpec;
        private DataGridViewTextBoxColumn mUnit;
        private DataGridViewTextBoxColumn mPrice;
        private DataGridViewTextBoxColumn mCategory;
        private DataGridViewTextBoxColumn mRemark;
    }
}
