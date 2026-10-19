using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CSStudy
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
