using System;
using System.Data;
using System.Windows.Forms;

namespace CSStudy
{
    public partial class WarehouseForm : Form
    {
        public string CurrentUser { get; set; }
        private Guid _editGuid = Guid.Empty; //选中行主键uGUID；Empty=新增模式
        private string _searchField = "仓库编号";  // 当前查询字段
        private string _searchKey = "";            // 当前查询关键字

        public WarehouseForm()
        {
            InitializeComponent();
            cboSearchField.SelectedIndex = 0; // 默认选中"仓库编号"
            LoadData();
        }

        #region 查询：从数据库读取全部仓库
        void LoadData()
        {
            dgvWarehouse.DataSource = WarehouseRepository.GetAll();

            //隐藏uGUID主键列
            if (dgvWarehouse.Columns["uGUID"] != null)
                dgvWarehouse.Columns["uGUID"].Visible = false;
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
            dgvWarehouse.DataSource = WarehouseRepository.Search(_searchField, _searchKey);
            if (dgvWarehouse.Columns["uGUID"] != null)
                dgvWarehouse.Columns["uGUID"].Visible = false;
        }
        #endregion

        #region 重置查询
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            _searchKey = "";
            _searchField = "仓库编号";
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
            string wNo = txtWNo.Text.Trim();
            string wName = txtWName.Text.Trim();
            string wLocation = txtLocation.Text.Trim();
            string wRemark = txtRemark.Text.Trim();

            if (string.IsNullOrEmpty(wNo) || string.IsNullOrEmpty(wName))
            {
                MessageBox.Show("仓库编号、仓库名称不能为空");
                return;
            }

            if (_editGuid == Guid.Empty)
            {
                if (WarehouseRepository.ExistsByNo(wNo))
                {
                    MessageBox.Show("该仓库编号已存在");
                    return;
                }
                WarehouseRepository.Insert(wNo, wName, wLocation, wRemark, CurrentUser);
            }
            else
            {
                WarehouseRepository.Update(_editGuid, wNo, wName, wLocation, wRemark, CurrentUser);
            }

            btnClear_Click(null, null); //复位编辑状态与输入框
            LoadData();
        }
        #endregion

        #region 清空输入框
        void ClearInput()
        {
            _editGuid = Guid.Empty;
            txtWNo.Clear();
            txtWName.Clear();
            txtLocation.Clear();
            txtRemark.Clear();
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
                MessageBox.Show("请先选中一条仓库数据");
                return;
            }
            if (MessageBox.Show("确认删除该仓库？", "确认", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            WarehouseRepository.Delete(_editGuid);
            MessageBox.Show("删除完成");
            ClearInput();
            LoadData();
        }
        #endregion

        #region 双击表格行：回显到输入框，进入编辑模式
        private void dgvWarehouse_DoubleClick(object sender, EventArgs e)
        {
            if (dgvWarehouse.CurrentRow == null) return;

            DataRowView drv = dgvWarehouse.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) return;

            //记录主键，进入编辑模式
            _editGuid = (Guid)drv.Row["uGUID"];

            //回填各个输入框
            txtWNo.Text = drv.Row["wNo"].ToString();
            txtWName.Text = drv.Row["wName"].ToString();
            txtLocation.Text = drv.Row["wLocation"]?.ToString();
            txtRemark.Text = drv.Row["wRemark"]?.ToString();
        }
        #endregion
    }
}
