using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class RegisterForm : Form
    {
        private Panel _cardPanel;

        public RegisterForm()
        {
            InitializeComponent();

            //纯色背景
            this.BackColor = Color.FromArgb(245, 248, 250);

            //BuildModernLayout();
        }

        private void BuildModernLayout()
        {
            Color cardColor = Color.White;
            Color accentColor = Color.FromArgb(52, 152, 219);
            Color textColor = Color.FromArgb(50, 50, 50);
            Color hintColor = Color.FromArgb(140, 140, 140);

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
            label1.Text = "创建账号";
            label1.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Bold);
            label1.ForeColor = textColor;
            label1.Location = new Point(30, 35);
            label1.Size = new Size(280, 40);
            label1.BackColor = Color.Transparent;
            label1.TextAlign = ContentAlignment.MiddleLeft;

            //副标题
            Label subtitle = new Label();
            subtitle.Text = "填写以下信息完成注册";
            subtitle.Font = new Font("Microsoft YaHei UI", 9F);
            subtitle.ForeColor = hintColor;
            subtitle.Location = new Point(30, 72);
            subtitle.Size = new Size(280, 20);
            subtitle.BackColor = Color.Transparent;
            _cardPanel.Controls.Add(subtitle);

            //用户名
            lblRegUser.Text = "用户名";
            lblRegUser.Font = new Font("Microsoft YaHei UI", 9.5F);
            lblRegUser.ForeColor = textColor;
            lblRegUser.Location = new Point(30, 105);
            lblRegUser.Size = new Size(60, 20);
            lblRegUser.BackColor = Color.Transparent;

            txtRegUser.Font = new Font("Microsoft YaHei UI", 10F);
            txtRegUser.ForeColor = textColor;
            txtRegUser.Location = new Point(30, 128);
            txtRegUser.Size = new Size(280, 32);
            txtRegUser.BackColor = Color.White;
            txtRegUser.BorderStyle = BorderStyle.None;

            Panel line1 = new Panel();
            line1.Size = new Size(280, 1);
            line1.BackColor = Color.FromArgb(200, 200, 200);
            line1.Location = new Point(30, 160);
            _cardPanel.Controls.Add(line1);

            //密码
            lblRegPwd.Text = "密码";
            lblRegPwd.Font = new Font("Microsoft YaHei UI", 9.5F);
            lblRegPwd.ForeColor = textColor;
            lblRegPwd.Location = new Point(30, 175);
            lblRegPwd.Size = new Size(50, 20);
            lblRegPwd.BackColor = Color.Transparent;

            txtRegPwd.Font = new Font("Microsoft YaHei UI", 10F);
            txtRegPwd.ForeColor = textColor;
            txtRegPwd.Location = new Point(30, 198);
            txtRegPwd.Size = new Size(280, 32);
            txtRegPwd.BackColor = Color.White;
            txtRegPwd.BorderStyle = BorderStyle.None;

            Panel line2 = new Panel();
            line2.Size = new Size(280, 1);
            line2.BackColor = Color.FromArgb(200, 200, 200);
            line2.Location = new Point(30, 230);
            _cardPanel.Controls.Add(line2);

            //确认密码
            lblRegPwd2.Text = "确认密码";
            lblRegPwd2.Font = new Font("Microsoft YaHei UI", 9.5F);
            lblRegPwd2.ForeColor = textColor;
            lblRegPwd2.Location = new Point(30, 245);
            lblRegPwd2.Size = new Size(65, 20);
            lblRegPwd2.BackColor = Color.Transparent;

            txtRegPwd2.Font = new Font("Microsoft YaHei UI", 10F);
            txtRegPwd2.ForeColor = textColor;
            txtRegPwd2.Location = new Point(30, 268);
            txtRegPwd2.Size = new Size(280, 32);
            txtRegPwd2.BackColor = Color.White;
            txtRegPwd2.BorderStyle = BorderStyle.None;

            Panel line3 = new Panel();
            line3.Size = new Size(280, 1);
            line3.BackColor = Color.FromArgb(200, 200, 200);
            line3.Location = new Point(30, 300);
            _cardPanel.Controls.Add(line3);

            //注册按钮
            btnDoRegister.Text = "注 册";
            btnDoRegister.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold);
            btnDoRegister.Location = new Point(30, 330);
            btnDoRegister.Size = new Size(130, 42);
            btnDoRegister.FlatStyle = FlatStyle.Flat;
            btnDoRegister.FlatAppearance.BorderSize = 0;
            btnDoRegister.FlatAppearance.MouseOverBackColor = Color.FromArgb(42, 132, 199);
            btnDoRegister.FlatAppearance.MouseDownBackColor = Color.FromArgb(32, 112, 179);
            btnDoRegister.BackColor = accentColor;
            btnDoRegister.ForeColor = Color.White;
            btnDoRegister.Cursor = Cursors.Hand;

            //返回按钮
            btnBackLogin.Text = "返回登录";
            btnBackLogin.Font = new Font("Microsoft YaHei UI", 10F);
            btnBackLogin.Location = new Point(180, 330);
            btnBackLogin.Size = new Size(130, 42);
            btnBackLogin.FlatStyle = FlatStyle.Flat;
            btnBackLogin.FlatAppearance.BorderSize = 0;
            btnBackLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(230, 230, 230);
            btnBackLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(210, 210, 210);
            btnBackLogin.BackColor = Color.FromArgb(240, 240, 240);
            btnBackLogin.ForeColor = textColor;
            btnBackLogin.Cursor = Cursors.Hand;

            //把控件移到面板
            var controls = new Control[]
            {
                label1, lblRegUser, txtRegUser, lblRegPwd, txtRegPwd,
                lblRegPwd2, txtRegPwd2, btnDoRegister, btnBackLogin
            };
            foreach (Control c in controls)
            {
                this.Controls.Remove(c);
                _cardPanel.Controls.Add(c);
            }

            this.Controls.Add(_cardPanel);
            _cardPanel.BringToFront();
        }



        private void btnDoRegister_Click(object sender, EventArgs e)
        {
            string userName = txtRegUser.Text.Trim();
            string pwd1 = txtRegPwd.Text.Trim();
            string pwd2 = txtRegPwd2.Text.Trim();

            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("请输入用户名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(pwd1))
            {
                MessageBox.Show("请输入密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (pwd1 != pwd2)
            {
                MessageBox.Show("两次输入的密码不一致！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRegPwd.Clear();
                txtRegPwd2.Clear();
                return;
            }

            if (SysUserRepository.Exists(userName))
            {
                MessageBox.Show("该用户名已经存在，请换一个", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SysUserRepository.Register(userName, pwd1);

            MessageBox.Show("注册成功！请返回登录", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnBackLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
