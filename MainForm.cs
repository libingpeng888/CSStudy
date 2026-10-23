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

namespace CSStudy
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
            lblUser.Text = $"当前登录用户：【{LoginUserName}】";
        }


        /// <summary>
        /// 统一打开/激活 MDI 子窗体
        /// </summary>
        private void OpenOrActivate<T>(Action<T> init = null) where T : Form, new()
        {
            // 已打开 → 激活并强制最大化
            foreach (Form child in this.MdiChildren)
            {
                if (child is T existing)
                {
                    existing.WindowState = FormWindowState.Maximized;
                    existing.Activate();
                    return;
                }
            }
            // 新建
            T frm = new T();
            init?.Invoke(frm);
            frm.MdiParent = this;
            frm.ControlBox = false;        // 干掉最小化/最大化/关闭三个按钮
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void 人员信息登记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenOrActivate<PersonForm>(f => f.CurrentUser = LoginUserName);
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void 客户档案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenOrActivate<CustomerForm>(f => f.CurrentUser = LoginUserName);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            MdiClient mdiClient = null;
            foreach (Control c in this.Controls)
            {
                if (c is MdiClient mc) { mdiClient = mc; break; }
            }
            if (mdiClient != null)
            {
                mdiClient.Paint += (s, pe) =>
                {
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
            OpenOrActivate<SupplierForm>(f => f.CurrentUser = LoginUserName);
        }

        private void 物料档案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenOrActivate<MaterialForm>(f => f.CurrentUser = LoginUserName);
        }

        private void 仓库档案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenOrActivate<WarehouseForm>(f => f.CurrentUser = LoginUserName);
        }

        private void 计量单位ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenOrActivate<UnitForm>(f => f.CurrentUser = LoginUserName);
        }

        private void 数据字典ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenOrActivate<DictForm>(f => f.CurrentUser = LoginUserName);
        }

        private void 采购入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenOrActivate<InStockForm>(f => f.CurrentUser = LoginUserName);
        }

        private void 编码规则ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenOrActivate<CodeRuleForm>(f => f.CurrentUser = LoginUserName);
        }

        private void 应付账款ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 销售应收ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
