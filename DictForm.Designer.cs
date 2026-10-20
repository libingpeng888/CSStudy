namespace CSStudy
{
    partial class DictForm
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
            txtDictType = new TextBox();
            txtDictCode = new TextBox();
            txtDictName = new TextBox();
            txtSortOrder = new TextBox();
            chkEnabled = new CheckBox();
            txtSearch = new TextBox();
            cboSearchField = new ComboBox();
            btnQuery = new Button();
            btnReset = new Button();
            btnSubmit = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            dgvDict = new DataGridView();
            DictType = new DataGridViewTextBoxColumn();
            DictCode = new DataGridViewTextBoxColumn();
            DictName = new DataGridViewTextBoxColumn();
            SortOrder = new DataGridViewTextBoxColumn();
            IsEnabled = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvDict).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 42);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 0;
            label1.Text = "字典类型";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 89);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 1;
            label2.Text = "字典编码";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 136);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 2;
            label3.Text = "字典名称";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 183);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 3;
            label4.Text = "排序";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 233);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 4;
            label5.Text = "是否启用";
            // 
            // txtDictType
            // 
            txtDictType.Location = new Point(104, 39);
            txtDictType.Name = "txtDictType";
            txtDictType.Size = new Size(125, 27);
            txtDictType.TabIndex = 0;
            // 
            // txtDictCode
            // 
            txtDictCode.Location = new Point(104, 86);
            txtDictCode.Name = "txtDictCode";
            txtDictCode.Size = new Size(125, 27);
            txtDictCode.TabIndex = 1;
            // 
            // txtDictName
            // 
            txtDictName.Location = new Point(104, 133);
            txtDictName.Name = "txtDictName";
            txtDictName.Size = new Size(125, 27);
            txtDictName.TabIndex = 2;
            // 
            // txtSortOrder
            // 
            txtSortOrder.Location = new Point(104, 180);
            txtSortOrder.Name = "txtSortOrder";
            txtSortOrder.Size = new Size(125, 27);
            txtSortOrder.TabIndex = 3;
            // 
            // chkEnabled
            // 
            chkEnabled.AutoSize = true;
            chkEnabled.Location = new Point(104, 230);
            chkEnabled.Name = "chkEnabled";
            chkEnabled.Size = new Size(91, 24);
            chkEnabled.TabIndex = 4;
            chkEnabled.Text = "是否启用";
            chkEnabled.UseVisualStyleBackColor = true;
            // 
            // cboSearchField
            // 
            cboSearchField.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSearchField.FormattingEnabled = true;
            cboSearchField.Items.AddRange(new object[] { "字典类型", "字典编码", "字典名称" });
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
            // dgvDict
            // 
            dgvDict.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDict.Columns.AddRange(new DataGridViewColumn[] { DictType, DictCode, DictName, SortOrder, IsEnabled });
            dgvDict.Location = new Point(436, 78);
            dgvDict.Name = "dgvDict";
            dgvDict.RowHeadersWidth = 51;
            dgvDict.Size = new Size(805, 308);
            dgvDict.TabIndex = 11;
            dgvDict.DoubleClick += dgvDict_DoubleClick;
            // 
            // DictType
            // 
            DictType.DataPropertyName = "DictType";
            DictType.HeaderText = "字典类型";
            DictType.MinimumWidth = 6;
            DictType.Name = "DictType";
            DictType.Width = 150;
            // 
            // DictCode
            // 
            DictCode.DataPropertyName = "DictCode";
            DictCode.HeaderText = "字典编码";
            DictCode.MinimumWidth = 6;
            DictCode.Name = "DictCode";
            DictCode.Width = 125;
            // 
            // DictName
            // 
            DictName.DataPropertyName = "DictName";
            DictName.HeaderText = "字典名称";
            DictName.MinimumWidth = 6;
            DictName.Name = "DictName";
            DictName.Width = 150;
            // 
            // SortOrder
            // 
            SortOrder.DataPropertyName = "SortOrder";
            SortOrder.HeaderText = "排序";
            SortOrder.MinimumWidth = 6;
            SortOrder.Name = "SortOrder";
            SortOrder.Width = 90;
            // 
            // IsEnabled
            // 
            IsEnabled.DataPropertyName = "IsEnabled";
            IsEnabled.HeaderText = "是否启用";
            IsEnabled.MinimumWidth = 6;
            IsEnabled.Name = "IsEnabled";
            IsEnabled.Width = 100;
            // 
            // DictForm
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
            Controls.Add(chkEnabled);
            Controls.Add(txtSortOrder);
            Controls.Add(txtDictName);
            Controls.Add(txtDictCode);
            Controls.Add(txtDictType);
            Controls.Add(dgvDict);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DictForm";
            Text = "数据字典";
            ((System.ComponentModel.ISupportInitialize)dgvDict).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtDictType;
        private TextBox txtDictCode;
        private TextBox txtDictName;
        private TextBox txtSortOrder;
        private CheckBox chkEnabled;
        private TextBox txtSearch;
        private ComboBox cboSearchField;
        private Button btnQuery;
        private Button btnReset;
        private Button btnSubmit;
        private Button btnClear;
        private Button btnDelete;
        private DataGridView dgvDict;
        private DataGridViewTextBoxColumn DictType;
        private DataGridViewTextBoxColumn DictCode;
        private DataGridViewTextBoxColumn DictName;
        private DataGridViewTextBoxColumn SortOrder;
        private DataGridViewCheckBoxColumn IsEnabled;
    }
}
