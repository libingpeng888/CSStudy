using System;
using System.Data;
using System.Windows.Forms;

namespace CSStudy
{
    public partial class CustomerForm : Form
    {
        public string CurrentUser { get; set; }
        private Guid _editGuid = Guid.Empty; //选中行主键uGUID；Empty=新增模式
        private string _searchField = "客户编号";  // 当前查询字段
        private string _searchKey = "";            // 当前查询关键字
        public CustomerForm()
        {
            InitializeComponent();
            cboSearchField.SelectedIndex = 0; // 默认选中"客户编号"
            LoadData();
        }

        void LoadData()
        {
            dgvCustomer.DataSource = CustomerRepository.GetAll();

            //隐藏uGUID主键列
            if (dgvCustomer.Columns["uGUID"] != null)
                dgvCustomer.Columns["uGUID"].Visible = false;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            _searchField = cboSearchField.Text;
            _searchKey = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(_searchKey))
            {
                LoadData();
                return;
            }
            dgvCustomer.DataSource = CustomerRepository.Search(_searchField, _searchKey);
            if (dgvCustomer.Columns["uGUID"] != null)
                dgvCustomer.Columns["uGUID"].Visible = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            _searchKey = "";
            _searchField = "客户编号";
            cboSearchField.SelectedIndex = 0;
            LoadData();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnQuery_Click(null, null);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string cno = txtCNo.Text.Trim();
            string cname = txtCName.Text.Trim();
            string contact = txtContact.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string addr = txtAddress.Text.Trim();
            string remark = txtRemark.Text.Trim();

            if (string.IsNullOrEmpty(cno) || string.IsNullOrEmpty(cname))
            {
                MessageBox.Show("客户编号、客户名称不能为空");
                return;
            }

            lstResult.Items.Add($"——————————————");
            lstResult.Items.Add($"客户编号:{cno}");
            lstResult.Items.Add($"客户名称:{cname}");
            lstResult.Items.Add($"联系人:{contact}");
            lstResult.Items.Add($"电话:{phone}");
            lstResult.Items.Add($"地址:{addr}");
            lstResult.Items.Add($"备注:{remark}");

            if (_editGuid == Guid.Empty)
            {
                CustomerRepository.Insert(cno, cname, contact, phone, addr, remark, CurrentUser);
            }
            else
            {
                CustomerRepository.Update(_editGuid, cno, cname, contact, phone, addr, remark, CurrentUser);
            }

            ClearInput();
            LoadData();
        }

        //清空输入框
        void ClearInput()
        {
            _editGuid = Guid.Empty;
            txtCNo.Clear();
            txtCName.Clear();
            txtContact.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtRemark.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_editGuid == Guid.Empty)
            {
                MessageBox.Show("请先选中一条客户数据");
                return;
            }
            if (MessageBox.Show("确认删除该客户？", "确认", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            CustomerRepository.Delete(_editGuid);
            MessageBox.Show("删除完成");
            ClearInput();
            LoadData();
        }

        private void dgvCustomer_DoubleClick(object sender, EventArgs e)
        {
            if (dgvCustomer.CurrentRow == null) return;

            //拿到绑定的DataRow
            DataRowView drv = dgvCustomer.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null) return;

            //记录主键，进入编辑模式
            _editGuid = (Guid)drv.Row["uGUID"];

            //回填各个输入框
            txtCNo.Text = drv.Row["cNo"].ToString();
            txtCName.Text = drv.Row["cName"].ToString();
            txtContact.Text = drv.Row["cContact"]?.ToString();
            txtPhone.Text = drv.Row["cPhone"]?.ToString();
            txtAddress.Text = drv.Row["cAddress"]?.ToString();
            txtRemark.Text = drv.Row["cRemark"]?.ToString();
        }
    }
}
