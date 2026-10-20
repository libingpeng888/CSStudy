using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CSStudy
{
    public partial class LoginForm : Form
    {
        public string LoggedInUserName { get; set; }
        private readonly string saveFile = Path.Combine(Application.UserAppDataPath, "login.cache.txt");
        private Panel _cardPanel;

        public LoginForm()
        {
            InitializeComponent();

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
