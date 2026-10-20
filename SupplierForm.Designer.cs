namespace CSStudy
{
    partial class SupplierForm
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
            label6 = new Label();
            txtSuppNo = new TextBox();
            txtSuppName = new TextBox();
            txtSuppContact = new TextBox();
            txtSuppPhone = new TextBox();
            txtSuppAddress = new TextBox();
            txtSuppRemark = new TextBox();
            lstResult = new ListBox();
            txtSearch = new TextBox();
            cboSearchField = new ComboBox();
            btnQuery = new Button();
            btnReset = new Button();
            btnSubmit = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            dgvSupplier = new DataGridView();
            sNo = new DataGridViewTextBoxColumn();
            sName = new DataGridViewTextBoxColumn();
            sContact = new DataGridViewTextBoxColumn();
            sPhone = new DataGridViewTextBoxColumn();
            sAddress = new DataGridViewTextBoxColumn();
            sRemark = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvSupplier).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 53);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 0;
            label1.Text = "供应商编号";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 91);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 1;
            label2.Text = "供应商名称";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 134);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 2;
            label3.Text = "联系人";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(37, 178);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 3;
            label4.Text = "联系电话";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(37, 220);
            label5.Name = "label5";
            label5.Size = new Size(39, 20);
            label5.TabIndex = 4;
            label5.Text = "地址";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(36, 262);
            label6.Name = "label6";
            label6.Size = new Size(39, 20);
            label6.TabIndex = 5;
            label6.Text = "备注";
            // 
            // txtSuppNo
            // 
            txtSuppNo.Location = new Point(126, 50);
            txtSuppNo.Name = "txtSuppNo";
            txtSuppNo.Size = new Size(125, 27);
            txtSuppNo.TabIndex = 6;
            // 
            // txtSuppName
            // 
            txtSuppName.Location = new Point(126, 88);
            txtSuppName.Name = "txtSuppName";
            txtSuppName.Size = new Size(125, 27);
            txtSuppName.TabIndex = 7;
            // 
            // txtSuppContact
            // 
            txtSuppContact.Location = new Point(126, 131);
            txtSuppContact.Name = "txtSuppContact";
            txtSuppContact.Size = new Size(125, 27);
            txtSuppContact.TabIndex = 8;
            // 
            // txtSuppPhone
            // 
            txtSuppPhone.Location = new Point(126, 175);
            txtSuppPhone.Name = "txtSuppPhone";
            txtSuppPhone.Size = new Size(125, 27);
            txtSuppPhone.TabIndex = 9;
            // 
            // txtSuppAddress
            // 
            txtSuppAddress.Location = new Point(126, 217);
            txtSuppAddress.Name = "txtSuppAddress";
            txtSuppAddress.Size = new Size(125, 27);
            txtSuppAddress.TabIndex = 10;
            // 
            // txtSuppRemark
            // 
            txtSuppRemark.Location = new Point(126, 259);
            txtSuppRemark.Name = "txtSuppRemark";
            txtSuppRemark.Size = new Size(125, 27);
            txtSuppRemark.TabIndex = 11;
            // 
            // lstResult
            // 
            lstResult.FormattingEnabled = true;
            lstResult.Location = new Point(291, 53);
            lstResult.Name = "lstResult";
            lstResult.Size = new Size(150, 264);
            lstResult.TabIndex = 20;
            // 
            // cboSearchField
            // 
            cboSearchField.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSearchField.FormattingEnabled = true;
            cboSearchField.Items.AddRange(new object[] { "供应商编号", "供应商名称", "联系人", "联系电话" });
            cboSearchField.Location = new Point(496, 27);
            cboSearchField.Name = "cboSearchField";
            cboSearchField.Size = new Size(120, 28);
            cboSearchField.TabIndex = 22;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(626, 27);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(164, 27);
            txtSearch.TabIndex = 27;
            txtSearch.KeyPress += txtSearch_KeyPress;
            // 
            // btnQuery
            // 
            btnQuery.Location = new Point(800, 27);
            btnQuery.Name = "btnQuery";
            btnQuery.Size = new Size(94, 29);
            btnQuery.TabIndex = 23;
            btnQuery.Text = "查询";
            btnQuery.UseVisualStyleBackColor = true;
            btnQuery.Click += btnQuery_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(904, 25);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 24;
            btnReset.Text = "重置查询";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(37, 346);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(94, 29);
            btnSubmit.TabIndex = 25;
            btnSubmit.Text = "提交";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(148, 346);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 26;
            btnClear.Text = "清空";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(37, 403);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 27;
            btnDelete.Text = "删除";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // dgvSupplier
            // 
            dgvSupplier.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSupplier.Columns.AddRange(new DataGridViewColumn[] { sNo, sName, sContact, sPhone, sAddress, sRemark });
            dgvSupplier.Location = new Point(496, 70);
            dgvSupplier.Name = "dgvSupplier";
            dgvSupplier.RowHeadersWidth = 51;
            dgvSupplier.Size = new Size(804, 362);
            dgvSupplier.TabIndex = 28;
            dgvSupplier.DoubleClick += dgvSupplier_DoubleClick;
            // 
            // sNo
            // 
            sNo.DataPropertyName = "suppNo";
            sNo.HeaderText = "供应商编号";
            sNo.MinimumWidth = 6;
            sNo.Name = "sNo";
            sNo.Width = 125;
            // 
            // sName
            // 
            sName.DataPropertyName = "suppName";
            sName.HeaderText = "供应商名称";
            sName.MinimumWidth = 6;
            sName.Name = "sName";
            sName.Width = 125;
            // 
            // sContact
            // 
            sContact.DataPropertyName = "suppContact";
            sContact.HeaderText = "联系人";
            sContact.MinimumWidth = 6;
            sContact.Name = "sContact";
            sContact.Width = 125;
            // 
            // sPhone
            // 
            sPhone.DataPropertyName = "suppPhone";
            sPhone.HeaderText = "联系电话";
            sPhone.MinimumWidth = 6;
            sPhone.Name = "sPhone";
            sPhone.Width = 125;
            // 
            // sAddress
            // 
            sAddress.DataPropertyName = "suppAddress";
            sAddress.HeaderText = "地址";
            sAddress.MinimumWidth = 6;
            sAddress.Name = "sAddress";
            sAddress.Width = 125;
            // 
            // sRemark
            // 
            sRemark.DataPropertyName = "suppRemark";
            sRemark.HeaderText = "备注";
            sRemark.MinimumWidth = 6;
            sRemark.Name = "sRemark";
            sRemark.Width = 125;
            // 
            // SupplierForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1332, 529);
            Controls.Add(dgvSupplier);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(btnSubmit);
            Controls.Add(btnReset);
            Controls.Add(btnQuery);
            Controls.Add(cboSearchField);
            Controls.Add(txtSearch);
            Controls.Add(lstResult);
            Controls.Add(txtSuppRemark);
            Controls.Add(txtSuppAddress);
            Controls.Add(txtSuppPhone);
            Controls.Add(txtSuppContact);
            Controls.Add(txtSuppName);
            Controls.Add(txtSuppNo);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SupplierForm";
            Text = "供应商档案";
            ((System.ComponentModel.ISupportInitialize)dgvSupplier).EndInit();
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
        private TextBox txtSuppNo;
        private TextBox txtSuppName;
        private TextBox txtSuppContact;
        private TextBox txtSuppPhone;
        private TextBox txtSuppAddress;
        private TextBox txtSuppRemark;
        private ListBox lstResult;
        private TextBox txtSearch;
        private ComboBox cboSearchField;
        private Button btnQuery;
        private Button btnReset;
        private Button btnSubmit;
        private Button btnClear;
        private Button btnDelete;
        private DataGridView dgvSupplier;
        private DataGridViewTextBoxColumn sNo;
        private DataGridViewTextBoxColumn sName;
        private DataGridViewTextBoxColumn sContact;
        private DataGridViewTextBoxColumn sPhone;
        private DataGridViewTextBoxColumn sAddress;
        private DataGridViewTextBoxColumn sRemark;
    }
}