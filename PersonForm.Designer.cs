namespace WinFormsApp1
{
    partial class PersonForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSubmit = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtName = new TextBox();
            txtNo = new TextBox();
            rdoMale = new RadioButton();
            rdoFemale = new RadioButton();
            cboDept = new ComboBox();
            chkCsharp = new CheckBox();
            chkSql = new CheckBox();
            chkDelphi = new CheckBox();
            btnClear = new Button();
            lstResult = new ListBox();
            dgvPerson = new DataGridView();
            colSno = new DataGridViewTextBoxColumn();
            colSname = new DataGridViewTextBoxColumn();
            colSgender = new DataGridViewTextBoxColumn();
            colSdept = new DataGridViewTextBoxColumn();
            colSskill = new DataGridViewTextBoxColumn();
            btnDelete = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnResetSearc = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPerson).BeginInit();
            SuspendLayout();
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(53, 327);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(94, 29);
            btnSubmit.TabIndex = 0;
            btnSubmit.Text = "\t提交";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 27);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 1;
            label1.Text = "姓名";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 66);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 2;
            label2.Text = "性别";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 158);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 3;
            label3.Text = "部门";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 109);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 4;
            label4.Text = "工号";
            // 
            // txtName
            // 
            txtName.Location = new Point(87, 24);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 5;
            // 
            // txtNo
            // 
            txtNo.Location = new Point(87, 109);
            txtNo.Name = "txtNo";
            txtNo.Size = new Size(125, 27);
            txtNo.TabIndex = 6;
            // 
            // rdoMale
            // 
            rdoMale.AutoSize = true;
            rdoMale.Location = new Point(86, 66);
            rdoMale.Name = "rdoMale";
            rdoMale.Size = new Size(45, 24);
            rdoMale.TabIndex = 7;
            rdoMale.TabStop = true;
            rdoMale.Text = "男";
            rdoMale.UseVisualStyleBackColor = true;
            // 
            // rdoFemale
            // 
            rdoFemale.AutoSize = true;
            rdoFemale.Location = new Point(137, 66);
            rdoFemale.Name = "rdoFemale";
            rdoFemale.Size = new Size(45, 24);
            rdoFemale.TabIndex = 8;
            rdoFemale.TabStop = true;
            rdoFemale.Text = "女";
            rdoFemale.UseVisualStyleBackColor = true;
            // 
            // cboDept
            // 
            cboDept.FormattingEnabled = true;
            cboDept.Items.AddRange(new object[] { "研发部", "市场部", "财务部", "生产部" });
            cboDept.Location = new Point(87, 158);
            cboDept.Name = "cboDept";
            cboDept.Size = new Size(151, 28);
            cboDept.TabIndex = 9;
            // 
            // chkCsharp
            // 
            chkCsharp.AutoSize = true;
            chkCsharp.Location = new Point(87, 207);
            chkCsharp.Name = "chkCsharp";
            chkCsharp.Size = new Size(51, 24);
            chkCsharp.TabIndex = 10;
            chkCsharp.Text = "C#";
            chkCsharp.UseVisualStyleBackColor = true;
            // 
            // chkSql
            // 
            chkSql.AutoSize = true;
            chkSql.Location = new Point(86, 233);
            chkSql.Name = "chkSql";
            chkSql.Size = new Size(111, 24);
            chkSql.TabIndex = 11;
            chkSql.Text = "SQL Server";
            chkSql.UseVisualStyleBackColor = true;
            // 
            // chkDelphi
            // 
            chkDelphi.AutoSize = true;
            chkDelphi.Location = new Point(87, 263);
            chkDelphi.Name = "chkDelphi";
            chkDelphi.Size = new Size(78, 24);
            chkDelphi.TabIndex = 12;
            chkDelphi.Text = "\tDelphi";
            chkDelphi.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(153, 327);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 13;
            btnClear.Text = "清空";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // lstResult
            // 
            lstResult.FormattingEnabled = true;
            lstResult.Location = new Point(265, 66);
            lstResult.Name = "lstResult";
            lstResult.Size = new Size(150, 264);
            lstResult.TabIndex = 14;
            // 
            // dgvPerson
            // 
            dgvPerson.AllowUserToOrderColumns = true;
            dgvPerson.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPerson.Columns.AddRange(new DataGridViewColumn[] { colSno, colSname, colSgender, colSdept, colSskill });
            dgvPerson.Location = new Point(444, 66);
            dgvPerson.Name = "dgvPerson";
            dgvPerson.RowHeadersWidth = 51;
            dgvPerson.Size = new Size(678, 294);
            dgvPerson.TabIndex = 15;
            dgvPerson.DoubleClick += dataGridView1_DoubleClick;
            // 
            // colSno
            // 
            colSno.DataPropertyName = "sNo";
            colSno.HeaderText = "工号 ";
            colSno.MinimumWidth = 6;
            colSno.Name = "colSno";
            colSno.Width = 125;
            // 
            // colSname
            // 
            colSname.DataPropertyName = "sName";
            colSname.HeaderText = "姓名";
            colSname.MinimumWidth = 6;
            colSname.Name = "colSname";
            colSname.Width = 125;
            // 
            // colSgender
            // 
            colSgender.DataPropertyName = "sGender";
            colSgender.HeaderText = "性别";
            colSgender.MinimumWidth = 6;
            colSgender.Name = "colSgender";
            colSgender.Width = 125;
            // 
            // colSdept
            // 
            colSdept.DataPropertyName = "sDept";
            colSdept.HeaderText = "部门";
            colSdept.MinimumWidth = 6;
            colSdept.Name = "colSdept";
            colSdept.Width = 125;
            // 
            // colSskill
            // 
            colSskill.DataPropertyName = "sSkill";
            colSskill.HeaderText = "技能";
            colSskill.MinimumWidth = 6;
            colSskill.Name = "colSskill";
            colSskill.Width = 125;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(53, 381);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "删除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(444, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(185, 27);
            txtSearch.TabIndex = 17;
            txtSearch.KeyPress += txtSearch_KeyPress;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(635, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 18;
            btnSearch.Text = "查询";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnResetSearc
            // 
            btnResetSearc.Location = new Point(735, 12);
            btnResetSearc.Name = "btnResetSearc";
            btnResetSearc.Size = new Size(94, 29);
            btnResetSearc.TabIndex = 19;
            btnResetSearc.Text = "重置查询";
            btnResetSearc.UseVisualStyleBackColor = true;
            btnResetSearc.Click += btnResetSearc_Click;
            // 
            // PersonForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1211, 480);
            Controls.Add(btnResetSearc);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnDelete);
            Controls.Add(dgvPerson);
            Controls.Add(lstResult);
            Controls.Add(btnClear);
            Controls.Add(chkDelphi);
            Controls.Add(chkSql);
            Controls.Add(chkCsharp);
            Controls.Add(cboDept);
            Controls.Add(rdoFemale);
            Controls.Add(rdoMale);
            Controls.Add(txtNo);
            Controls.Add(txtName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSubmit);
            Name = "PersonForm";
            Text = "人员信息登记";
            ((System.ComponentModel.ISupportInitialize)dgvPerson).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSubmit;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtName;
        private TextBox txtNo;
        private RadioButton rdoMale;
        private RadioButton rdoFemale;
        private ComboBox cboDept;
        private CheckBox chkCsharp;
        private CheckBox chkSql;
        private CheckBox chkDelphi;
        private Button btnClear;
        private ListBox lstResult;
        private DataGridView dgvPerson;
        private Button btnDelete;
        private DataGridViewTextBoxColumn colSno;
        private DataGridViewTextBoxColumn colSname;
        private DataGridViewTextBoxColumn colSgender;
        private DataGridViewTextBoxColumn colSdept;
        private DataGridViewTextBoxColumn colSskill;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnResetSearc;
    }
}
