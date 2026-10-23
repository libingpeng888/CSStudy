using System;
using System.Data;
using System.Windows.Forms;

namespace CSStudy
{
    public partial class CodeRuleForm : Form
    {
        public string CurrentUser { get; set; }
        private Guid _currentGUID;

        public CodeRuleForm()
        {
            InitializeComponent();
            ThemeHelper.Apply(this);
            cboSeqReset.SelectedIndex = 0;
            LoadList();
        }

        private void LoadList()
        {
            DataTable dt = SysCodeRuleRepository.GetAll();
            dgvList.DataSource = dt;
            // 隐藏主键列
            if (dgvList.Columns["uGUID"] != null)
                dgvList.Columns["uGUID"].Visible = false;
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvList.Rows[e.RowIndex];
            _currentGUID = (Guid)row.Cells["uGUID"].Value;
            txtRuleNo.Text = row.Cells["ruleNo"].Value?.ToString();
            txtRuleName.Text = row.Cells["ruleName"].Value?.ToString();
            txtPrefix.Text = row.Cells["prefix"].Value?.ToString();
            txtDateFormat.Text = row.Cells["dateFormat"].Value?.ToString();
            nudSeqLength.Value = Convert.ToDecimal(row.Cells["seqLength"].Value);
            cboSeqReset.SelectedIndex = Convert.ToInt32(row.Cells["seqReset"].Value) == 1 ? 0 : 1;
            txtBizTable.Text = row.Cells["bizTable"].Value?.ToString();
            txtWType.Text = row.Cells["wType"].Value?.ToString();
            txtRemark.Text = row.Cells["remark"].Value?.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRuleNo.Text.Trim()))
            {
                MessageBox.Show("请输入规则编号");
                return;
            }
            if (string.IsNullOrEmpty(txtRuleName.Text.Trim()))
            {
                MessageBox.Show("请输入规则名称");
                return;
            }
            if (string.IsNullOrEmpty(txtPrefix.Text.Trim()))
            {
                MessageBox.Show("请输入前缀");
                return;
            }

            try
            {
                int seqReset = cboSeqReset.SelectedIndex == 0 ? 1 : 0;
                SysCodeRuleRepository.Insert(
                    txtRuleNo.Text.Trim(),
                    txtRuleName.Text.Trim(),
                    txtPrefix.Text.Trim(),
                    txtDateFormat.Text.Trim(),
                    (int)nudSeqLength.Value,
                    seqReset,
                    txtBizTable.Text.Trim(),
                    txtWType.Text.Trim(),
                    txtRemark.Text.Trim(),
                    CurrentUser);
                MessageBox.Show("新增成功");
                LoadList();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增失败：" + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_currentGUID == Guid.Empty)
            {
                MessageBox.Show("请先选择要修改的规则");
                return;
            }
            if (string.IsNullOrEmpty(txtRuleNo.Text.Trim()))
            {
                MessageBox.Show("请输入规则编号");
                return;
            }

            try
            {
                int seqReset = cboSeqReset.SelectedIndex == 0 ? 1 : 0;
                SysCodeRuleRepository.Update(
                    _currentGUID,
                    txtRuleNo.Text.Trim(),
                    txtRuleName.Text.Trim(),
                    txtPrefix.Text.Trim(),
                    txtDateFormat.Text.Trim(),
                    (int)nudSeqLength.Value,
                    seqReset,
                    txtBizTable.Text.Trim(),
                    txtWType.Text.Trim(),
                    txtRemark.Text.Trim(),
                    CurrentUser);
                MessageBox.Show("修改成功");
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败：" + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_currentGUID == Guid.Empty)
            {
                MessageBox.Show("请先选择要删除的规则");
                return;
            }
            if (MessageBox.Show("确认删除该规则？", "确认", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                SysCodeRuleRepository.Delete(_currentGUID);
                MessageBox.Show("删除成功");
                LoadList();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败：" + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            _currentGUID = Guid.Empty;
            txtRuleNo.Clear();
            txtRuleName.Clear();
            txtPrefix.Clear();
            txtDateFormat.Clear();
            nudSeqLength.Value = 3;
            cboSeqReset.SelectedIndex = 0;
            txtBizTable.Clear();
            txtWType.Clear();
            txtRemark.Clear();
        }
    }
}
