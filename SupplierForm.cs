using System;
using System.Data;
using System.Windows.Forms;

namespace CSStudy
{
    public partial class SupplierForm : Form
    {
        public string CurrentUser { get; set; }
        private Guid _editGuid = Guid.Empty; //编辑主键uGUID；Empty=新增模式
        public SupplierForm()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            dgvSupplier.DataSource = SupplierRepository.GetAll();

            //隐藏uGUID主键列
            if (dgvSupplier.Columns["uGUID"] != null)
                dgvSupplier.Columns["uGUID"].Visible = false;
        }

        private void dgvSupplier_DoubleClick(object sender, EventArgs e)
        {
            if (dgvSupplier.CurrentRow == null) return;
            DataRowView drv = dgvSupplier.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) return;

            _editGuid = (Guid)drv.Row["uGUID"];

            txtSuppNo.Text = drv.Row["suppNo"].ToString();
            txtSuppName.Text = drv.Row["suppName"].ToString();
            txtSuppContact.Text = drv.Row["suppContact"]?.ToString();
            txtSuppPhone.Text = drv.Row["suppPhone"]?.ToString();
            txtSuppAddress.Text = drv.Row["suppAddress"]?.ToString();
            txtSuppRemark.Text = drv.Row["suppRemark"]?.ToString();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string suppNo = txtSuppNo.Text.Trim();
            string suppName = txtSuppName.Text.Trim();
            string contact = txtSuppContact.Text.Trim();
            string phone = txtSuppPhone.Text.Trim();
            string addr = txtSuppAddress.Text.Trim();
            string remark = txtSuppRemark.Text.Trim();

            if (string.IsNullOrEmpty(suppNo) || string.IsNullOrEmpty(suppName))
            {
                MessageBox.Show("供应商编号、名称不能为空");
                return;
            }

            if (_editGuid == Guid.Empty)
            {
                SupplierRepository.Insert(suppNo, suppName, contact, phone, addr, remark, CurrentUser);
            }
            else
            {
                SupplierRepository.Update(_editGuid, suppNo, suppName, contact, phone, addr, remark, CurrentUser);
            }

            MessageBox.Show("保存成功");
            ClearInput();
            LoadData();
        }
        void ClearInput()
        {
            _editGuid = Guid.Empty;
            txtSuppNo.Clear();
            txtSuppName.Clear();
            txtSuppContact.Clear();
            txtSuppPhone.Clear();
            txtSuppAddress.Clear();
            txtSuppRemark.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }
    }
}
