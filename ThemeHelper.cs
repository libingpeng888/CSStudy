using System;
using System.Drawing;
using System.Windows.Forms;

namespace CSStudy
{
    /// <summary>
    /// 统一界面美化辅助类
    /// </summary>
    public static class ThemeHelper
    {
        // 配色方案
        public static Color HeaderBackColor = Color.FromArgb(241, 245, 249);      // 列表表头背景
        public static Color HeaderForeColor = Color.FromArgb(71, 85, 105);        // 列表表头文字
        public static Color AltRowBackColor = Color.FromArgb(248, 250, 252);      // 交替行背景
        public static Color RowForeColor = Color.FromArgb(30, 41, 59);            // 行文字
        public static Color SelectBackColor = Color.FromArgb(59, 130, 246);       // 选中高亮
        public static Color SelectForeColor = Color.White;                        // 选中文字
        public static Color PrimaryBlue = Color.FromArgb(59, 130, 246);          // 主色调蓝
        public static Color DangerRed = Color.FromArgb(220, 38, 38);              // 危险红
        public static Color SuccessGreen = Color.FromArgb(34, 197, 94);           // 成功绿
        public static Color WarningOrange = Color.FromArgb(249, 115, 22);         // 警告橙

        /// <summary>
        /// 美化窗体上所有 DataGridView 和 Button
        /// </summary>
        public static void Apply(Form form)
        {
            ApplyToControls(form.Controls);
        }

        private static void ApplyToControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is DataGridView dgv)
                {
                    StyleDataGridView(dgv);
                }
                else if (ctrl is Button btn)
                {
                    StyleButton(btn);
                }
                // 递归处理子容器
                if (ctrl.HasChildren)
                {
                    ApplyToControls(ctrl.Controls);
                }
            }
        }

        /// <summary>
        /// 美化 DataGridView
        /// </summary>
        public static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = Color.FromArgb(226, 232, 240);
            dgv.EnableHeadersVisualStyles = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;

            // 表头
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 36;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = HeaderBackColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = HeaderForeColor;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // 默认行
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = RowForeColor;
            dgv.DefaultCellStyle.Font = new Font("微软雅黑", 10F);
            dgv.DefaultCellStyle.SelectionBackColor = SelectBackColor;
            dgv.DefaultCellStyle.SelectionForeColor = SelectForeColor;

            // 交替行
            dgv.AlternatingRowsDefaultCellStyle.BackColor = AltRowBackColor;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = RowForeColor;
            dgv.AlternatingRowsDefaultCellStyle.Font = new Font("微软雅黑", 10F);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = SelectBackColor;
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = SelectForeColor;

            // 行高
            dgv.RowTemplate.Height = 36;

            // 去掉行头（如果本来就没设的话）
            dgv.RowHeadersVisible = false;
        }

        /// <summary>
        /// 美化 Button（按文字关键字自动配色）
        /// </summary>
        public static void StyleButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("微软雅黑", 9F);
            btn.Cursor = Cursors.Hand;

            string text = btn.Text ?? "";
            if (text.Contains("删除") || text.Contains("清空"))
            {
                btn.BackColor = Color.FromArgb(254, 242, 242);
                btn.ForeColor = DangerRed;
            }
            else if (text.Contains("保存") || text.Contains("提交") || text.Contains("新增") || text.Contains("添加"))
            {
                btn.BackColor = Color.FromArgb(239, 246, 255);
                btn.ForeColor = PrimaryBlue;
            }
            else if (text.Contains("查询") || text.Contains("搜索"))
            {
                btn.BackColor = Color.FromArgb(240, 253, 244);
                btn.ForeColor = SuccessGreen;
            }
            else
            {
                btn.BackColor = Color.FromArgb(241, 245, 249);
                btn.ForeColor = Color.FromArgb(71, 85, 105);
            }
        }
    }
}
