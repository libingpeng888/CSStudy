namespace WinFormsApp1
{
    partial class CustomerForm
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
            txtCNo = new TextBox();
            btnSubmit = new Button();
            dgvCustomer = new DataGridView();
            cNo = new DataGridViewTextBoxColumn();
            cName = new DataGridViewTextBoxColumn();
            cContact = new DataGridViewTextBoxColumn();
            cPhone = new DataGridViewTextBoxColumn();
            cAddress = new DataGridViewTextBoxColumn();
            cRemark = new DataGridViewTextBoxColumn();
            txtSearch = new TextBox();
            txtRemark = new TextBox();
            txtAddress = new TextBox();
            txtCName = new TextBox();
            txtContact = new TextBox();
            txtPhone = new TextBox();
            btnClear = new Button();
            btnDelete = new Button();
            btnQuery = new Button();
            btnReset = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            lstResult = new ListBox();
            ((System.ComponentModel.ISupportInitialize)dgvCustomer).BeginInit();
            SuspendLayout();
            // 
            // txtCNo
            // 
            txtCNo.Location = new Point(104, 39);
            txtCNo.Name = "txtCNo";
            txtCNo.Size = new Size(125, 27);
            txtCNo.TabIndex = 0;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(30, 344);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(94, 29);
            btnSubmit.TabIndex = 1;
            btnSubmit.Text = "提交";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // dgvCustomer
            // 
            dgvCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomer.Columns.AddRange(new DataGridViewColumn[] { cNo, cName, cContact, cPhone, cAddress, cRemark });
            dgvCustomer.Location = new Point(436, 78);
            dgvCustomer.Name = "dgvCustomer";
            dgvCustomer.RowHeadersWidth = 51;
            dgvCustomer.Size = new Size(805, 308);
            dgvCustomer.TabIndex = 2;
            dgvCustomer.DoubleClick += btnQuery_Click;
            // 
            // cNo
            // 
            cNo.DataPropertyName = "cNo";
            cNo.HeaderText = "客户编号";
            cNo.MinimumWidth = 6;
            cNo.Name = "cNo";
            cNo.Width = 125;
            // 
            // cName
            // 
            cName.DataPropertyName = "cName";
            cName.HeaderText = "客户名称";
            cName.MinimumWidth = 6;
            cName.Name = "cName";
            cName.Width = 125;
            // 
            // cContact
            // 
            cContact.DataPropertyName = "cContact";
            cContact.HeaderText = "联系人";
            cContact.MinimumWidth = 6;
            cContact.Name = "cContact";
            cContact.Width = 125;
            // 
            // cPhone
            // 
            cPhone.DataPropertyName = "cPhone";
            cPhone.HeaderText = "联系电话";
            cPhone.MinimumWidth = 6;
            cPhone.Name = "cPhone";
            cPhone.Width = 125;
            // 
            // cAddress
            // 
            cAddress.DataPropertyName = "cAddress";
            cAddress.HeaderText = "地址";
            cAddress.MinimumWidth = 6;
            cAddress.Name = "cAddress";
            cAddress.Width = 125;
            // 
            // cRemark
            // 
            cRemark.DataPropertyName = "cRemark";
            cRemark.HeaderText = "备注";
            cRemark.MinimumWidth = 6;
            cRemark.Name = "cRemark";
            cRemark.Width = 125;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(436, 28);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(164, 27);
            txtSearch.TabIndex = 3;
            // 
            // txtRemark
            // 
            txtRemark.Location = new Point(104, 283);
            txtRemark.Multiline = true;
            txtRemark.Name = "txtRemark";
            txtRemark.Size = new Size(125, 27);
            txtRemark.TabIndex = 4;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(104, 231);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(125, 27);
            txtAddress.TabIndex = 5;
            // 
            // txtCName
            // 
            txtCName.Location = new Point(104, 88);
            txtCName.Name = "txtCName";
            txtCName.Size = new Size(125, 27);
            txtCName.TabIndex = 6;
            // 
            // txtContact
            // 
            txtContact.Location = new Point(104, 135);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(125, 27);
            txtContact.TabIndex = 7;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(104, 184);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(125, 27);
            txtPhone.TabIndex = 8;
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
            // btnQuery
            // 
            btnQuery.Location = new Point(606, 26);
            btnQuery.Name = "btnQuery";
            btnQuery.Size = new Size(94, 29);
            btnQuery.TabIndex = 11;
            btnQuery.Text = "查询";
            btnQuery.UseVisualStyleBackColor = true;
            btnQuery.Click += btnQuery_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(706, 26);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 12;
            btnReset.Text = "重置查询";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 42);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 13;
            label1.Text = "客户编号";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 286);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 14;
            label2.Text = "备注";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 234);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 15;
            label3.Text = "地址";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 187);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 16;
            label4.Text = "联系电话";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 138);
            label5.Name = "label5";
            label5.Size = new Size(54, 20);
            label5.TabIndex = 17;
            label5.Text = "联系人";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(30, 91);
            label6.Name = "label6";
            label6.Size = new Size(69, 20);
            label6.TabIndex = 18;
            label6.Text = "客户名称";
            // 
            // lstResult
            // 
            lstResult.FormattingEnabled = true;
            lstResult.Location = new Point(268, 42);
            lstResult.Name = "lstResult";
            lstResult.Size = new Size(150, 264);
            lstResult.TabIndex = 19;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1302, 548);
            Controls.Add(lstResult);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnReset);
            Controls.Add(btnQuery);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(txtPhone);
            Controls.Add(txtContact);
            Controls.Add(txtCName);
            Controls.Add(txtAddress);
            Controls.Add(txtRemark);
            Controls.Add(txtSearch);
            Controls.Add(dgvCustomer);
            Controls.Add(btnSubmit);
            Controls.Add(txtCNo);
            Name = "CustomerForm";
            Text = "客户档案";
            ((System.ComponentModel.ISupportInitialize)dgvCustomer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCNo;
        private Button btnSubmit;
        private DataGridView dgvCustomer;
        private TextBox txtSearch;
        private TextBox txtRemark;
        private TextBox txtAddress;
        private TextBox txtCName;
        private TextBox txtContact;
        private TextBox txtPhone;
        private Button btnClear;
        private Button btnDelete;
        private Button btnQuery;
        private Button btnReset;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ListBox lstResult;
        private DataGridViewTextBoxColumn cNo;
        private DataGridViewTextBoxColumn cName;
        private DataGridViewTextBoxColumn cContact;
        private DataGridViewTextBoxColumn cPhone;
        private DataGridViewTextBoxColumn cAddress;
        private DataGridViewTextBoxColumn cRemark;
    }
}