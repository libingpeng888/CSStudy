namespace CSStudy
{
    partial class LoginForm
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
            txtUserName = new TextBox();
            txtPwd = new TextBox();
            btnLogin = new Button();
            btnExit = new Button();
            label1 = new Label();
            lblUser = new Label();
            lblPwd = new Label();
            lblGoRegister = new Label();
            chkRememberPwd = new CheckBox();
            SuspendLayout();
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(154, 118);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(182, 27);
            txtUserName.TabIndex = 0;
            // 
            // txtPwd
            // 
            txtPwd.Location = new Point(154, 169);
            txtPwd.Name = "txtPwd";
            txtPwd.PasswordChar = '*';
            txtPwd.Size = new Size(182, 27);
            txtPwd.TabIndex = 1;
            txtPwd.KeyPress += txtPwd_KeyPress;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(64, 128, 255);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = SystemColors.ButtonHighlight;
            btnLogin.Location = new Point(79, 306);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "登录";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(64, 128, 255);
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.ForeColor = SystemColors.ButtonHighlight;
            btnExit.Location = new Point(242, 306);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
            btnExit.TabIndex = 3;
            btnExit.Text = "退出";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(154, 22);
            label1.Name = "label1";
            label1.Size = new Size(96, 50);
            label1.TabIndex = 4;
            label1.Text = "登录";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblUser.Location = new Point(52, 116);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(72, 27);
            lblUser.TabIndex = 5;
            lblUser.Text = "用户名";
            // 
            // lblPwd
            // 
            lblPwd.AutoSize = true;
            lblPwd.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblPwd.Location = new Point(52, 167);
            lblPwd.Name = "lblPwd";
            lblPwd.Size = new Size(52, 27);
            lblPwd.TabIndex = 6;
            lblPwd.Text = "密码";
            // 
            // lblGoRegister
            // 
            lblGoRegister.AutoSize = true;
            lblGoRegister.Cursor = Cursors.Hand;
            lblGoRegister.ForeColor = SystemColors.HotTrack;
            lblGoRegister.Location = new Point(127, 421);
            lblGoRegister.Name = "lblGoRegister";
            lblGoRegister.Size = new Size(129, 20);
            lblGoRegister.TabIndex = 7;
            lblGoRegister.Text = "没有账号？去注册";
            lblGoRegister.Click += lblGoRegister_Click;
            // 
            // chkRememberPwd
            // 
            chkRememberPwd.AutoSize = true;
            chkRememberPwd.Location = new Point(227, 211);
            chkRememberPwd.Name = "chkRememberPwd";
            chkRememberPwd.Size = new Size(91, 24);
            chkRememberPwd.TabIndex = 8;
            chkRememberPwd.Text = "记住密码";
            chkRememberPwd.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 450);
            Controls.Add(chkRememberPwd);
            Controls.Add(lblGoRegister);
            Controls.Add(lblPwd);
            Controls.Add(lblUser);
            Controls.Add(label1);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(txtPwd);
            Controls.Add(txtUserName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUserName;
        private TextBox txtPwd;
        private Button btnLogin;
        private Button btnExit;
        private Label label1;
        private Label lblUser;
        private Label lblPwd;
        private Label lblGoRegister;
        private CheckBox chkRememberPwd;
    }
}