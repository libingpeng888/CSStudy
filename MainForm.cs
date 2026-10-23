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
            this.MdiChildActivate += MainForm_MdiChildActivate;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUser.Text = $"当前登录用户：【{LoginUserName}】";
        }

        #region 标签栏维护
        private void MainForm_MdiChildActivate(object sender, EventArgs e)
        {
            // 只改激活按钮的颜色，不重建控件（避免卡顿）
            UpdateTabColors();
        }

        private void MainForm_MdiChildClosed(object sender, FormClosedEventArgs e)
        {
            RefreshTabs();
        }

        /// <summary>
        /// 重建所有标签（只在子窗体打开/关闭时调用）
        /// </summary>
        private void RefreshTabs()
        {
            pnlTabs.SuspendLayout();
            pnlTabs.Controls.Clear();
            if (this.MdiChildren.Length == 0)
            {
                pnlTabs.ResumeLayout();
                return;
            }

            int x = 8;
            Form active = this.ActiveMdiChild;
            foreach (Form child in this.MdiChildren)
            {
                bool isActive = (active == child);

                Button btnTab = new Button();
                btnTab.Text = child.Text;
                btnTab.Font = new Font("微软雅黑", 9F);
                btnTab.FlatStyle = FlatStyle.Flat;
                btnTab.FlatAppearance.BorderSize = 0;
                btnTab.Size = new Size(120, 28);
                btnTab.Location = new Point(x, 4);
                btnTab.Cursor = Cursors.Hand;
                btnTab.Tag = child;
                btnTab.BackColor = isActive ? Color.FromArgb(59, 130, 246) : Color.White;
                btnTab.ForeColor = isActive ? Color.White : Color.FromArgb(51, 65, 85);
                btnTab.Click += (s, args) => child.Activate();
                pnlTabs.Controls.Add(btnTab);

                Button btnClose = new Button();
                btnClose.Text = "✕";
                btnClose.Font = new Font("微软雅黑", 8F, FontStyle.Bold);
                btnClose.FlatStyle = FlatStyle.Flat;
                btnClose.FlatAppearance.BorderSize = 0;
                btnClose.Size = new Size(24, 28);
                btnClose.Location = new Point(x + 116, 4);
                btnClose.Cursor = Cursors.Hand;
                btnClose.Tag = child;
                btnClose.BackColor = btnTab.BackColor;
                btnClose.ForeColor = isActive ? Color.White : Color.FromArgb(148, 163, 184);
                btnClose.Click += (s, args) => child.Close();
                pnlTabs.Controls.Add(btnClose);

                x += 148;
            }
            pnlTabs.ResumeLayout();
        }

        /// <summary>
        /// 只更新按钮颜色（Activate 时调用，不重建控件）
        /// </summary>
        private void UpdateTabColors()
        {
            Form active = this.ActiveMdiChild;
            if (active == null) return;

            pnlTabs.SuspendLayout();
            foreach (Control c in pnlTabs.Controls)
            {
                if (c is Button btn && btn.Tag is Form frm)
                {
                    bool isActive = (frm == active);
                    btn.BackColor = isActive ? Color.FromArgb(59, 130, 246) : Color.White;
                    btn.ForeColor = isActive ? Color.White : Color.FromArgb(51, 65, 85);

                    // 配对的 Close 按钮也同步颜色
                    int idx = pnlTabs.Controls.IndexOf(btn);
                    if (idx + 1 < pnlTabs.Controls.Count && pnlTabs.Controls[idx + 1] is Button closeBtn)
                    {
                        closeBtn.BackColor = btn.BackColor;
                        closeBtn.ForeColor = isActive ? Color.White : Color.FromArgb(148, 163, 184);
                    }
                }
            }
            pnlTabs.ResumeLayout();
        }
        #endregion

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
            frm.WindowState = FormWindowState.Maximized;
            frm.FormClosed += MainForm_MdiChildClosed;
            frm.Show();
            RefreshTabs();
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
