using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
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
            string sql = @"SELECT uGUID,suppNo,suppName,suppContact,suppPhone,suppAddress,suppRemark,
CreateUser,CreateTime,UpdateUser,UpdateTime FROM Supplier";
            SqlDataAdapter da = new SqlDataAdapter(sql, Db.ConnectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvSupplier.DataSource = dt;

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

            using (SqlConnection conn = Db.Open())
            {
                SqlCommand cmd;
                if (_editGuid == Guid.Empty)
                {
                    //新增，uGUID由数据库DEFAULT NEWID()生成，只填CreateUser，时间数据库默认
                    string insertSql = @"INSERT INTO Supplier(suppNo,suppName,suppContact,suppPhone,suppAddress,suppRemark,CreateUser)
VALUES(@suppNo,@suppName,@suppContact,@suppPhone,@suppAddress,@suppRemark,@CreateUser)";
                    cmd = new SqlCommand(insertSql, conn);
                    cmd.Parameters.AddWithValue("@CreateUser", CurrentUser);
                }
                else
                {
                    //修改，更新人+更新时间，不动创建信息
                    string updateSql = @"UPDATE Supplier SET
suppNo=@suppNo,suppName=@suppName,suppContact=@suppContact,suppPhone=@suppPhone,
suppAddress=@suppAddress,suppRemark=@suppRemark,UpdateUser=@UpdateUser,UpdateTime=GETDATE()
WHERE uGUID=@uGUID";
                    cmd = new SqlCommand(updateSql, conn);
                    cmd.Parameters.AddWithValue("@uGUID", _editGuid);
                    cmd.Parameters.AddWithValue("@UpdateUser", CurrentUser);
                }

                cmd.Parameters.AddWithValue("@suppNo", suppNo);
                cmd.Parameters.AddWithValue("@suppName", suppName);
                cmd.Parameters.AddWithValue("@suppContact", contact);
                cmd.Parameters.AddWithValue("@suppPhone", phone);
                cmd.Parameters.AddWithValue("@suppAddress", addr);
                cmd.Parameters.AddWithValue("@suppRemark", remark);

                cmd.ExecuteNonQuery();
                MessageBox.Show("保存成功");
                ClearInput();
                LoadData();
            }
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
