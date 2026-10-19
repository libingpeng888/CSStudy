using System;
using System.Data;
using System.Windows.Forms;

namespace CSStudy
{
    public partial class MaterialForm : Form
    {
        public string CurrentUser { get; set; }
        private Guid _editGuid = Guid.Empty; //选中行主键uGUID；Empty=新增模式

        public MaterialForm()
        {
            InitializeComponent();
            LoadData();
        }

        #region 查询：从数据库读取全部物料
        void LoadData()
        {
            dgvMaterial.DataSource = MaterialRepository.GetAll();

            //隐藏uGUID主键列
            if (dgvMaterial.Columns["uGUID"] != null)
                dgvMaterial.Columns["uGUID"].Visible = false;
        }
        #endregion

        #region 查询按钮
        private void btnQuery_Click(object sender, EventArgs e)
        {
            string key = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(key))
            {
                LoadData();
                return;
            }
            dgvMaterial.DataSource = MaterialRepository.Search(key);
            if (dgvMaterial.Columns["uGUID"] != null)
                dgvMaterial.Columns["uGUID"].Visible = false;
        }
        #endregion

        #region 重置查询
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadData();
        }
        #endregion

        #region 提交（新增/修改）
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string mNo = txtMNo.Text.Trim();
            string mName = txtMName.Text.Trim();
            string mSpec = txtMSpec.Text.Trim();
            string mUnit = txtMUnit.Text.Trim();
            string mPrice = txtMPrice.Text.Trim();
            string mCategory = cboCategory.Text.Trim();
            string mRemark = txtMRemark.Text.Trim();

            if (string.IsNullOrEmpty(mNo) || string.IsNullOrEmpty(mName))
            {
                MessageBox.Show("物料编号、物料名称不能为空");
                return;
            }

            lstResult.Items.Add($"——————————————");
            lstResult.Items.Add($"物料编号:{mNo}");
            lstResult.Items.Add($"物料名称:{mName}");
            lstResult.Items.Add($"规格型号:{mSpec}");
            lstResult.Items.Add($"计量单位:{mUnit}");
            lstResult.Items.Add($"参考单价:{mPrice}");
            lstResult.Items.Add($"物料分类:{mCategory}");
            lstResult.Items.Add($"备注:{mRemark}");

            if (_editGuid == Guid.Empty)
            {
                MaterialRepository.Insert(mNo, mName, mSpec, mUnit, mPrice, mCategory, mRemark, CurrentUser);
            }
            else
            {
                MaterialRepository.Update(_editGuid, mNo, mName, mSpec, mUnit, mPrice, mCategory, mRemark, CurrentUser);
            }

            ClearInput();
            LoadData();
        }
        #endregion

        #region 清空输入框
        void ClearInput()
        {
            _editGuid = Guid.Empty;
            txtMNo.Clear();
            txtMName.Clear();
            txtMSpec.Clear();
            txtMUnit.Clear();
            txtMPrice.Clear();
            cboCategory.SelectedIndex = -1;
            txtMRemark.Clear();
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
                MessageBox.Show("请先选中一条物料数据");
                return;
            }
            if (MessageBox.Show("确认删除该物料？", "确认", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            MaterialRepository.Delete(_editGuid);
            MessageBox.Show("删除完成");
            ClearInput();
            LoadData();
        }
        #endregion

        #region 双击表格行：回显到输入框，进入编辑模式
        private void dgvMaterial_DoubleClick(object sender, EventArgs e)
        {
            if (dgvMaterial.CurrentRow == null) return;

            DataRowView drv = dgvMaterial.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) return;

            //记录主键，进入编辑模式
            _editGuid = (Guid)drv.Row["uGUID"];

            //回填各个输入框
            txtMNo.Text = drv.Row["mNo"].ToString();
            txtMName.Text = drv.Row["mName"].ToString();
            txtMSpec.Text = drv.Row["mSpec"]?.ToString();
            txtMUnit.Text = drv.Row["mUnit"]?.ToString();
            txtMPrice.Text = drv.Row["mPrice"]?.ToString();
            cboCategory.Text = drv.Row["mCategory"]?.ToString();
            txtMRemark.Text = drv.Row["mRemark"]?.ToString();
        }
        #endregion
    }
}
