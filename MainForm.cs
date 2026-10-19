using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        //接收登录窗体传过来的账号
        public string LoginUserName { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            //状态栏显示当前登录用户
            //MessageBox.Show($"调试收到用户名：【{LoginUserName}】");
            lblUser.Text = $"当前登录用户：【{LoginUserName}】";
        }

        private void 人员信息登记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //避免重复打开同一个窗口
            foreach (Form childFrm in this.MdiChildren)
            {
                if (childFrm.Name == "Person")
                {
                    childFrm.Activate();
                    return;
                }
            }
            //Person frmPerson = new Person();
            //frmPerson.MdiParent = this;  //把子窗体嵌入MainForm容器
            //frmPerson.Show();
            PersonForm frm = new PersonForm();
            frm.MdiParent = this;       //指定MDI父窗口为MainForm
            frm.CurrentUser = this.LoginUserName;  //传入登录账号
            frm.WindowState = FormWindowState.Maximized; //子窗体最大化铺满
            frm.Show();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart(); //重启程序，回到登录界面
        }

        private void 客户档案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childFrm in this.MdiChildren)
            {
                if (childFrm.GetType() == typeof(CustomerForm))
                {
                    childFrm.Activate();
                    return;
                }
            }
            CustomerForm frm = new CustomerForm();
            frm.MdiParent = this;
            frm.CurrentUser = this.LoginUserName;  //传入登录账号
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            //找到MDI容器
            MdiClient mdiClient = null;
            foreach (Control c in this.Controls)
            {
                if (c is MdiClient)
                {
                    mdiClient = c as MdiClient;
                    break;
                }
            }
            if (mdiClient != null)
            {
                mdiClient.Paint += (s, pe) =>
                {
                    //从程序目录读取背景图
                    string bgPath = Path.Combine(Application.StartupPath, "main_bg.jpg");
                    if (File.Exists(bgPath))
                    {
                        Image img = Image.FromFile(bgPath);
                        pe.Graphics.DrawImage(img, pe.ClipRectangle);
                    }
                };
                mdiClient.Invalidate();
            }
        }

        private void 供应商档案ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form childFrm in this.MdiChildren)
            {
                if (childFrm.GetType() == typeof(SupplierForm))
                {
                    childFrm.Activate();
                    return;
                }
            }
            SupplierForm frm = new SupplierForm();
            frm.MdiParent = this;
            frm.CurrentUser = this.LoginUserName;  //传入登录账号
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 物料档案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childFrm in this.MdiChildren)
            {
                if (childFrm.GetType() == typeof(MaterialForm))
                {
                    childFrm.Activate();
                    return;
                }
            }
            MaterialForm frm = new MaterialForm();
            frm.MdiParent = this;
            frm.CurrentUser = this.LoginUserName;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 采购申请ToolStripMenuItem_Click(object sender, EventArgs e)
        {
     
        }

        private void 采购订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void 采购入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void 应付账款ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
