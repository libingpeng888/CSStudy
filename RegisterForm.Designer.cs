namespace CSStudy
{
    partial class RegisterForm
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
            txtRegUser = new TextBox();
            btnDoRegister = new Button();
            lblRegUser = new Label();
            lblRegPwd2 = new Label();
            lblRegPwd = new Label();
            txtRegPwd2 = new TextBox();
            txtRegPwd = new TextBox();
            btnBackLogin = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(149, 29);
            label1.Name = "label1";
            label1.Size = new Size(96, 50);
            label1.TabIndex = 0;
            label1.Text = "注册";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtRegUser
            // 
            txtRegUser.Font = new Font("Microsoft YaHei UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtRegUser.Location = new Point(149, 112);
            txtRegUser.Name = "txtRegUser";
            txtRegUser.Size = new Size(183, 29);
            txtRegUser.TabIndex = 1;
            // 
            // btnDoRegister
            // 
            btnDoRegister.BackColor = Color.FromArgb(64, 128, 255);
            btnDoRegister.Cursor = Cursors.Hand;
            btnDoRegister.FlatAppearance.BorderSize = 0;
            btnDoRegister.FlatStyle = FlatStyle.Flat;
            btnDoRegister.ForeColor = SystemColors.ButtonHighlight;
            btnDoRegister.Location = new Point(72, 276);
            btnDoRegister.Name = "btnDoRegister";
            btnDoRegister.Size = new Size(94, 29);
            btnDoRegister.TabIndex = 2;
            btnDoRegister.Text = "注册";
            btnDoRegister.UseVisualStyleBackColor = false;
            btnDoRegister.Click += btnDoRegister_Click;
            // 
            // lblRegUser
            // 
            lblRegUser.AutoSize = true;
            lblRegUser.Location = new Point(72, 115);
            lblRegUser.Name = "lblRegUser";
            lblRegUser.Size = new Size(54, 20);
            lblRegUser.TabIndex = 3;
            lblRegUser.Text = "用户名";
            // 
            // lblRegPwd2
            // 
            lblRegPwd2.AutoSize = true;
            lblRegPwd2.Location = new Point(72, 195);
            lblRegPwd2.Name = "lblRegPwd2";
            lblRegPwd2.Size = new Size(69, 20);
            lblRegPwd2.TabIndex = 4;
            lblRegPwd2.Text = "确认密码";
            // 
            // lblRegPwd
            // 
            lblRegPwd.AutoSize = true;
            lblRegPwd.Location = new Point(72, 156);
            lblRegPwd.Name = "lblRegPwd";
            lblRegPwd.Size = new Size(39, 20);
            lblRegPwd.TabIndex = 5;
            lblRegPwd.Text = "密码";
            // 
            // txtRegPwd2
            // 
            txtRegPwd2.Location = new Point(149, 192);
            txtRegPwd2.Name = "txtRegPwd2";
            txtRegPwd2.PasswordChar = '*';
            txtRegPwd2.Size = new Size(183, 27);
            txtRegPwd2.TabIndex = 6;
            // 
            // txtRegPwd
            // 
            txtRegPwd.Location = new Point(149, 153);
            txtRegPwd.Name = "txtRegPwd";
            txtRegPwd.PasswordChar = '*';
            txtRegPwd.Size = new Size(183, 27);
            txtRegPwd.TabIndex = 7;
            // 
            // btnBackLogin
            // 
            btnBackLogin.BackColor = Color.FromArgb(64, 128, 255);
            btnBackLogin.Cursor = Cursors.Hand;
            btnBackLogin.FlatAppearance.BorderSize = 0;
            btnBackLogin.FlatStyle = FlatStyle.Flat;
            btnBackLogin.ForeColor = SystemColors.ButtonHighlight;
            btnBackLogin.Location = new Point(223, 276);
            btnBackLogin.Name = "btnBackLogin";
            btnBackLogin.Size = new Size(94, 29);
            btnBackLogin.TabIndex = 8;
            btnBackLogin.Text = "返回登录";
            btnBackLogin.UseVisualStyleBackColor = false;
            btnBackLogin.Click += btnBackLogin_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 438);
            Controls.Add(btnBackLogin);
            Controls.Add(txtRegPwd);
            Controls.Add(txtRegPwd2);
            Controls.Add(lblRegPwd);
            Controls.Add(lblRegPwd2);
            Controls.Add(lblRegUser);
            Controls.Add(btnDoRegister);
            Controls.Add(txtRegUser);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegisterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtRegUser;
        private Button btnDoRegister;
        private Label lblRegUser;
        private Label lblRegPwd2;
        private Label lblRegPwd;
        private TextBox txtRegPwd2;
        private TextBox txtRegPwd;
        private Button btnBackLogin;
    }
}