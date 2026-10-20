using System;
using System.Data;
using System.Windows.Forms;

namespace CSStudy
{
    public partial class DictForm : Form
    {
        public string CurrentUser { get; set; }
        private Guid _editGuid = Guid.Empty; //选中行主键uGUID；Empty=新增模式
        private string _searchField = "字典类型";  // 当前查询字段
        private string _searchKey = "";            // 当前查询关键字

        public DictForm()
        {
            InitializeComponent();
            cboSearchField.SelectedIndex = 0; // 默认选中"字典类型"
            LoadData();
        }

        #region 查询：从数据库读取全部字典项
        void LoadData()
        {
            dgvDict.DataSource = SysDictRepository.GetAll();

            //隐藏uGUID主键列
            if (dgvDict.Columns["uGUID"] != null)
                dgvDict.Columns["uGUID"].Visible = false;
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
            dgvDict.DataSource = SysDictRepository.Search(_searchField, _searchKey);
            if (dgvDict.Columns["uGUID"] != null)
                dgvDict.Columns["uGUID"].Visible = false;
        }
        #endregion

        #region 重置查询
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            _searchKey = "";
            _searchField = "字典类型";
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
            string dictType = txtDictType.Text.Trim();
            string dictCode = txtDictCode.Text.Trim();
            string dictName = txtDictName.Text.Trim();
            string sortOrder = txtSortOrder.Text.Trim();
            int isEnabled = chkEnabled.Checked ? 1 : 0;

            if (string.IsNullOrEmpty(dictCode) || string.IsNullOrEmpty(dictName))
            {
                MessageBox.Show("字典编码、字典名称不能为空");
                return;
            }

            if (_editGuid == Guid.Empty)
            {
                SysDictRepository.Insert(dictType, dictCode, dictName, sortOrder, isEnabled, CurrentUser);
            }
            else
            {
                SysDictRepository.Update(_editGuid, dictType, dictCode, dictName, sortOrder, isEnabled, CurrentUser);
            }

            btnClear_Click(null, null); //复位编辑状态与输入框
            LoadData();
        }
        #endregion

        #region 清空输入框
        void ClearInput()
        {
            _editGuid = Guid.Empty;
            txtDictType.Clear();
            txtDictCode.Clear();
            txtDictName.Clear();
            txtSortOrder.Clear();
            chkEnabled.Checked = false;
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
                MessageBox.Show("请先选中一条字典数据");
                return;
            }
            if (MessageBox.Show("确认删除该字典项？", "确认", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            SysDictRepository.Delete(_editGuid);
            MessageBox.Show("删除完成");
            ClearInput();
            LoadData();
        }
        #endregion

        #region 双击表格行：回显到输入框，进入编辑模式
        private void dgvDict_DoubleClick(object sender, EventArgs e)
        {
            if (dgvDict.CurrentRow == null) return;

            DataRowView drv = dgvDict.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) return;

            //记录主键，进入编辑模式
            _editGuid = (Guid)drv.Row["uGUID"];

            //回填各个输入框
            txtDictType.Text = drv.Row["DictType"].ToString();
            txtDictCode.Text = drv.Row["DictCode"].ToString();
            txtDictName.Text = drv.Row["DictName"].ToString();
            txtSortOrder.Text = drv.Row["SortOrder"]?.ToString();
            chkEnabled.Checked = Convert.ToBoolean(drv.Row["IsEnabled"]);
        }
        #endregion
    }
}
