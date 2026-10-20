using System;
using System.Data;
using System.Windows.Forms;

namespace CSStudy
{
    public partial class UnitForm : Form
    {
        public string CurrentUser { get; set; }
        private Guid _editGuid = Guid.Empty; //选中行主键uGUID；Empty=新增模式
        private string _searchField = "单位编码";  // 当前查询字段
        private string _searchKey = "";            // 当前查询关键字

        public UnitForm()
        {
            InitializeComponent();
            cboSearchField.SelectedIndex = 0; // 默认选中"单位编码"
            LoadData();
        }

        #region 查询：从数据库读取全部计量单位
        void LoadData()
        {
            dgvUnit.DataSource = UnitRepository.GetAll();

            //隐藏uGUID主键列
            if (dgvUnit.Columns["uGUID"] != null)
                dgvUnit.Columns["uGUID"].Visible = false;
        }
        #endregion

        #region 查询按钮
        private void btnQuery_Click(object sender, EventArgs e)
        {
            _searchField = cboSearchField.Text;
            _searchKey = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(_searchKey))
            {
                LoadData();
                return;
            }
            dgvUnit.DataSource = UnitRepository.Search(_searchField, _searchKey);
            if (dgvUnit.Columns["uGUID"] != null)
                dgvUnit.Columns["uGUID"].Visible = false;
        }
        #endregion

        #region 重置查询
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            _searchKey = "";
            _searchField = "单位编码";
            cboSearchField.SelectedIndex = 0;
            LoadData();
        }
        #endregion

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnQuery_Click(null, null);
        }

        #region 提交（新增/修改）
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string uNo = txtUnitNo.Text.Trim();
            string uName = txtUnitName.Text.Trim();
            string uFactor = txtFactor.Text.Trim();
            int uBase = chkBase.Checked ? 1 : 0;
            string uRemark = txtUnitRemark.Text.Trim();

            if (string.IsNullOrEmpty(uNo) || string.IsNullOrEmpty(uName))
            {
                MessageBox.Show("单位编码、单位名称不能为空");
                return;
            }

            if (_editGuid == Guid.Empty)
            {
                UnitRepository.Insert(uNo, uName, uFactor, uBase, uRemark, CurrentUser);
            }
            else
            {
                UnitRepository.Update(_editGuid, uNo, uName, uFactor, uBase, uRemark, CurrentUser);
            }

            btnClear_Click(null, null); //复位编辑状态与输入框
            LoadData();
        }
        #endregion

        #region 清空输入框
        void ClearInput()
        {
            _editGuid = Guid.Empty;
            txtUnitNo.Clear();
            txtUnitName.Clear();
            txtFactor.Clear();
            chkBase.Checked = false;
            txtUnitRemark.Clear();
        }
        #endregion

        #region 清空按钮
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }
        #endregion

        #region 删除按钮
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_editGuid == Guid.Empty)
            {
                MessageBox.Show("请先选中一条计量单位数据");
                return;
            }
            if (MessageBox.Show("确认删除该计量单位？", "确认", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            UnitRepository.Delete(_editGuid);
            MessageBox.Show("删除完成");
            ClearInput();
            LoadData();
        }
        #endregion

        #region 双击表格行：回显到输入框，进入编辑模式
        private void dgvUnit_DoubleClick(object sender, EventArgs e)
        {
            if (dgvUnit.CurrentRow == null) return;

            DataRowView drv = dgvUnit.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) return;

            //记录主键，进入编辑模式
            _editGuid = (Guid)drv.Row["uGUID"];

            //回填各个输入框
            txtUnitNo.Text = drv.Row["uNo"].ToString();
            txtUnitName.Text = drv.Row["uName"].ToString();
            txtFactor.Text = drv.Row["uFactor"]?.ToString();
            chkBase.Checked = Convert.ToBoolean(drv.Row["uBase"]);
            txtUnitRemark.Text = drv.Row["uRemark"]?.ToString();
        }
        #endregion
    }
}
