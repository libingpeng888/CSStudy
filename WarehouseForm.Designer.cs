namespace CSStudy
{
    partial class WarehouseForm
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
            txtWNo = new TextBox();
            txtWName = new TextBox();
            txtLocation = new TextBox();
            txtRemark = new TextBox();
            txtSearch = new TextBox();
            cboSearchField = new ComboBox();
            btnQuery = new Button();
            btnReset = new Button();
            btnSubmit = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            dgvWarehouse = new DataGridView();
            wNo = new DataGridViewTextBoxColumn();
            wName = new DataGridViewTextBoxColumn();
            wLocation = new DataGridViewTextBoxColumn();
            wRemark = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvWarehouse).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 42);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 0;
            label1.Text = "仓库编号";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 89);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 1;
            label2.Text = "仓库名称";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 136);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 2;
            label3.Text = "库位";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 183);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 3;
            label4.Text = "备注";
            // 
            // txtWNo
            // 
            txtWNo.Location = new Point(104, 39);
            txtWNo.Name = "txtWNo";
            txtWNo.Size = new Size(125, 27);
            txtWNo.TabIndex = 0;
            // 
            // txtWName
            // 
            txtWName.Location = new Point(104, 86);
            txtWName.Name = "txtWName";
            txtWName.Size = new Size(125, 27);
            txtWName.TabIndex = 1;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(104, 133);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(125, 27);
            txtLocation.TabIndex = 2;
            // 
            // txtRemark
            // 
            txtRemark.Location = new Point(104, 180);
            txtRemark.Multiline = true;
            txtRemark.Name = "txtRemark";
            txtRemark.Size = new Size(125, 54);
            txtRemark.TabIndex = 3;
            // 
            // cboSearchField
            // 
            cboSearchField.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSearchField.FormattingEnabled = true;
            cboSearchField.Items.AddRange(new object[] { "仓库编号", "仓库名称", "库位","备注" });
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
            txtSearch.TabIndex = 4;
            txtSearch.KeyPress += txtSearch_KeyPress;
            // 
            // btnQuery
            // 
            btnQuery.Location = new Point(736, 26);
            btnQuery.Name = "btnQuery";
            btnQuery.Size = new Size(94, 29);
            btnQuery.TabIndex = 5;
            btnQuery.Text = "查询";
            btnQuery.UseVisualStyleBackColor = true;
            btnQuery.Click += btnQuery_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(836, 26);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 6;
            btnReset.Text = "重置查询";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(30, 344);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(94, 29);
            btnSubmit.TabIndex = 7;
            btnSubmit.Text = "提交";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(158, 344);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 8;
            btnClear.Text = "清空";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(30, 403);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "删除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvWarehouse
            // 
            dgvWarehouse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWarehouse.Columns.AddRange(new DataGridViewColumn[] { wNo, wName, wLocation, wRemark });
            dgvWarehouse.Location = new Point(436, 78);
            dgvWarehouse.Name = "dgvWarehouse";
            dgvWarehouse.RowHeadersWidth = 51;
            dgvWarehouse.Size = new Size(805, 308);
            dgvWarehouse.TabIndex = 10;
            dgvWarehouse.DoubleClick += dgvWarehouse_DoubleClick;
            // 
            // wNo
            // 
            wNo.DataPropertyName = "wNo";
            wNo.HeaderText = "仓库编号";
            wNo.MinimumWidth = 6;
            wNo.Name = "wNo";
            wNo.Width = 125;
            // 
            // wName
            // 
            wName.DataPropertyName = "wName";
            wName.HeaderText = "仓库名称";
            wName.MinimumWidth = 6;
            wName.Name = "wName";
            wName.Width = 125;
            // 
            // wLocation
            // 
            wLocation.DataPropertyName = "wLocation";
            wLocation.HeaderText = "库位";
            wLocation.MinimumWidth = 6;
            wLocation.Name = "wLocation";
            wLocation.Width = 125;
            // 
            // wRemark
            // 
            wRemark.DataPropertyName = "wRemark";
            wRemark.HeaderText = "备注";
            wRemark.MinimumWidth = 6;
            wRemark.Name = "wRemark";
            wRemark.Width = 150;
            // 
            // WarehouseForm
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
            Controls.Add(txtRemark);
            Controls.Add(txtLocation);
            Controls.Add(txtWName);
            Controls.Add(txtWNo);
            Controls.Add(dgvWarehouse);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "WarehouseForm";
            Text = "仓库档案";
            ((System.ComponentModel.ISupportInitialize)dgvWarehouse).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtWNo;
        private TextBox txtWName;
        private TextBox txtLocation;
        private TextBox txtRemark;
        private TextBox txtSearch;
        private ComboBox cboSearchField;
        private Button btnQuery;
        private Button btnReset;
        private Button btnSubmit;
        private Button btnClear;
        private Button btnDelete;
        private DataGridView dgvWarehouse;
        private DataGridViewTextBoxColumn wNo;
        private DataGridViewTextBoxColumn wName;
        private DataGridViewTextBoxColumn wLocation;
        private DataGridViewTextBoxColumn wRemark;
    }
}
