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
using System.Xml.Linq;

namespace WinFormsApp1
{
    public partial class CustomerForm : Form
    {
        public string CurrentUser { get; set; }
        private Guid _editGuid = Guid.Empty; //选中行主键uGUID；Empty=新增模式
        public CustomerForm()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData(string where = "")
        {
            using (SqlConnection conn = Db.Open())
            {
                string sql = "SELECT uGUID,cNo,cName,cContact,cPhone,cAddress,cRemark FROM Customer ";
                if (!string.IsNullOrEmpty(where))
                    sql += where;

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCustomer.DataSource = dt;

                //隐藏uGUID主键列
                if (dgvCustomer.Columns["uGUID"] != null)
                    dgvCustomer.Columns["uGUID"].Visible = false;
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string key = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(key))
            {
                LoadData();
                return;
            }
            string where = $" WHERE cNo LIKE '%{key}%' OR cName LIKE '%{key}%'";
            LoadData(where);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadData();
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

            using (SqlConnection conn = Db.Open())
            {
                SqlCommand cmd;
                if (_editGuid == Guid.Empty)
                {
                    //新增，uGUID由数据库DEFAULT NEWID()生成
                    string insertSql = @"INSERT INTO Customer(cNo,cName,cContact,cPhone,cAddress,cRemark,CreateUser)
                    VALUES(@cNo,@cName,@cContact,@cPhone,@cAddress,@cRemark,@CreateUser)";
                    cmd = new SqlCommand(insertSql, conn);
                    cmd.Parameters.AddWithValue("@CreateUser", CurrentUser);
                }
                else
                {
                    //修改
                    string updateSql = @"UPDATE Customer SET cNo=@cNo,cName=@cName,cContact=@cContact,
                    cPhone=@cPhone,cAddress=@cAddress,cRemark=@cRemark,UpdateUser=@UpdateUser, UpdateTime=GETDATE() WHERE uGUID=@uGUID";
                    cmd = new SqlCommand(updateSql, conn);
                    cmd.Parameters.AddWithValue("@uGUID", _editGuid);
                    cmd.Parameters.AddWithValue("@UpdateUser", CurrentUser);
                }
                cmd.Parameters.AddWithValue("@cNo", cno);
                cmd.Parameters.AddWithValue("@cName", cname);
                cmd.Parameters.AddWithValue("@cContact", contact);
                cmd.Parameters.AddWithValue("@cPhone", phone);
                cmd.Parameters.AddWithValue("@cAddress", addr);
                cmd.Parameters.AddWithValue("@cRemark", remark);


                cmd.ExecuteNonQuery();
                //MessageBox.Show("保存成功");
                ClearInput();
                LoadData();
            }

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

            using (SqlConnection conn = Db.Open())
            {
                string delSql = "DELETE FROM Customer WHERE uGUID=@uGUID";
                SqlCommand cmd = new SqlCommand(delSql, conn);
                cmd.Parameters.AddWithValue("@uGUID", _editGuid);
                cmd.ExecuteNonQuery();
                MessageBox.Show("删除完成");
                ClearInput();
                LoadData();
            }
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
