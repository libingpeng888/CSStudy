using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class LoginForm : Form
    {
        public string LoggedInUserName { get; set; }
        private readonly string saveFile = Path.Combine(Application.UserAppDataPath, "login.cache.txt");
        private Panel _cardPanel;

        public LoginForm()
        {
            InitializeComponent();

            ////纯色背景
            //this.BackColor = Color.FromArgb(245, 248, 250);

            //BuildModernLayout();

            //窗体加载读取缓存
            if (File.Exists(saveFile))
            {
                string[] lines = File.ReadAllLines(saveFile);
                if (lines.Length >= 2)
                {
                    txtUserName.Text = lines[0];
                    txtPwd.Text = lines[1];
                    chkRememberPwd.Checked = true;
                }
            }
        }

        private void BuildModernLayout()
        {
            Color cardColor = Color.White;
            Color accentColor = Color.FromArgb(52, 152, 219);
            Color textColor = Color.FromArgb(50, 50, 50);
            Color hintColor = Color.FromArgb(140, 140, 140);

            //面板填满窗体
            _cardPanel = new Panel();
            _cardPanel.Dock = DockStyle.Fill;
            _cardPanel.BackColor = cardColor;

            //顶部装饰条
            Panel topBar = new Panel();
            topBar.Dock = DockStyle.Top;
            topBar.Height = 6;
            topBar.BackColor = accentColor;
            _cardPanel.Controls.Add(topBar);

            //标题
            label1.Text = "欢迎登录";
            label1.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Bold);
            label1.ForeColor = textColor;
            label1.Location = new Point(30, 35);
            label1.Size = new Size(280, 40);
            label1.BackColor = Color.Transparent;
            label1.TextAlign = ContentAlignment.MiddleLeft;

            //副标题
            Label subtitle = new Label();
            subtitle.Text = "请输入您的账号信息";
            subtitle.Font = new Font("Microsoft YaHei UI", 9F);
            subtitle.ForeColor = hintColor;
            subtitle.Location = new Point(30, 72);
            subtitle.Size = new Size(280, 20);
            subtitle.BackColor = Color.Transparent;
            _cardPanel.Controls.Add(subtitle);

            //用户名标签
            lblUser.Text = "用户名";
            lblUser.Font = new Font("Microsoft YaHei UI", 9.5F);
            lblUser.ForeColor = textColor;
            lblUser.Location = new Point(30, 105);
            lblUser.Size = new Size(60, 20);
            lblUser.BackColor = Color.Transparent;

            //用户名输入框
            txtUserName.Font = new Font("Microsoft YaHei UI", 10F);
            txtUserName.ForeColor = textColor;
            txtUserName.Location = new Point(30, 128);
            txtUserName.Size = new Size(280, 32);
            txtUserName.BackColor = Color.White;
            txtUserName.BorderStyle = BorderStyle.None;

            //用户名下划线
            Panel line1 = new Panel();
            line1.Size = new Size(280, 1);
            line1.BackColor = Color.FromArgb(200, 200, 200);
            line1.Location = new Point(30, 160);
            _cardPanel.Controls.Add(line1);

            //密码标签
            lblPwd.Text = "密码";
            lblPwd.Font = new Font("Microsoft YaHei UI", 9.5F);
            lblPwd.ForeColor = textColor;
            lblPwd.Location = new Point(30, 175);
            lblPwd.Size = new Size(50, 20);
            lblPwd.BackColor = Color.Transparent;

            //密码输入框
            txtPwd.Font = new Font("Microsoft YaHei UI", 10F);
            txtPwd.ForeColor = textColor;
            txtPwd.Location = new Point(30, 198);
            txtPwd.Size = new Size(280, 32);
            txtPwd.BackColor = Color.White;
            txtPwd.BorderStyle = BorderStyle.None;

            //密码下划线
            Panel line2 = new Panel();
            line2.Size = new Size(280, 1);
            line2.BackColor = Color.FromArgb(200, 200, 200);
            line2.Location = new Point(30, 230);
            _cardPanel.Controls.Add(line2);

            //记住密码
            chkRememberPwd.Text = "记住密码";
            chkRememberPwd.Font = new Font("Microsoft YaHei UI", 9F);
            chkRememberPwd.ForeColor = hintColor;
            chkRememberPwd.BackColor = Color.White;
            chkRememberPwd.Location = new Point(30, 245);
            chkRememberPwd.Size = new Size(100, 22);

            //登录按钮
            btnLogin.Text = "登 录";
            btnLogin.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold);
            btnLogin.Location = new Point(30, 285);
            btnLogin.Size = new Size(130, 42);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 132, 199);
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(32, 112, 179);
            btnLogin.BackColor = accentColor;
            btnLogin.ForeColor = Color.White;
            btnLogin.Cursor = Cursors.Hand;

            //退出按钮
            btnExit.Text = "退 出";
            btnExit.Font = new Font("Microsoft YaHei UI", 11F);
            btnExit.Location = new Point(180, 285);
            btnExit.Size = new Size(130, 42);
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 230, 230);
            btnExit.FlatAppearance.MouseDownBackColor = Color.FromArgb(210, 210, 210);
            btnExit.BackColor = Color.FromArgb(240, 240, 240);
            btnExit.ForeColor = textColor;
            btnExit.Cursor = Cursors.Hand;

            //注册链接
            lblGoRegister.Text = "没有账号？去注册";
            lblGoRegister.Font = new Font("Microsoft YaHei UI", 9F);
            lblGoRegister.ForeColor = accentColor;
            lblGoRegister.BackColor = Color.Transparent;
            lblGoRegister.Location = new Point(100, 340);
            lblGoRegister.Size = new Size(140, 22);
            lblGoRegister.Cursor = Cursors.Hand;

            //把控件移到面板
            var controls = new Control[]
            {
                label1, lblUser, txtUserName, lblPwd, txtPwd,
                chkRememberPwd, btnLogin, btnExit, lblGoRegister
            };
            foreach (Control c in controls)
            {
                this.Controls.Remove(c);
                _cardPanel.Controls.Add(c);
            }

            this.Controls.Add(_cardPanel);
            _cardPanel.BringToFront();

        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUserName.Text.Trim();
            string pwd = txtPwd.Text.Trim();

            if (string.IsNullOrEmpty(user))
            {
                MessageBox.Show("请输入用户名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("请输入密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (SysUserRepository.Validate(user, pwd))
            {
                if (chkRememberPwd.Checked)
                {
                    File.WriteAllLines(saveFile, new string[] { user, pwd });
                }
                else
                {
                    if (File.Exists(saveFile))
                        File.Delete(saveFile);
                }
                this.LoggedInUserName = txtUserName.Text.Trim();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("用户名或密码错误！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPwd.Clear();
                txtPwd.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }

        private void lblGoRegister_Click(object sender, EventArgs e)
        {
            RegisterForm regForm = new RegisterForm();
            regForm.ShowDialog();
        }
    }
}
