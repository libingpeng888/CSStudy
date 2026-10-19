using System.Data;

namespace CSStudy
{
    public partial class PersonForm : Form
    {
        public string CurrentUser { get; set; }
        private DataTable dtPerson;
        private bool _isEditMode = false;      // true=编辑；false=新增
        private Guid _editGuid;                // 当前编辑行的主键uGUID

        private string _searchKey = "";
        public PersonForm()
        {
            InitializeComponent(); //初始化窗体控件

            dtPerson = new DataTable();
            dtPerson.Columns.Add("uGUID", typeof(Guid));
            dtPerson.Columns.Add("sNo");
            dtPerson.Columns.Add("sName");
            dtPerson.Columns.Add("sGender");
            dtPerson.Columns.Add("sDept");
            dtPerson.Columns.Add("sSkill");

            dgvPerson.AutoGenerateColumns = false;
            dgvPerson.AllowUserToAddRows = false;
            dgvPerson.DataSource = dtPerson;

            //窗体加载，读取数据库全部数据到表格
            LoadDataFromDB();
        }

        #region 查询：从数据库读取全部人员，填充dtPerson
        private void LoadDataFromDB(string searchKey = "")
        {
            DataTable source;
            if (string.IsNullOrWhiteSpace(searchKey))
                source = PersonRepository.GetAll();
            else
                source = PersonRepository.Search(searchKey);

            dtPerson.Clear();
            foreach (DataRow row in source.Rows)
            {
                DataRow dr = dtPerson.NewRow();
                dr["uGUID"] = row["uGUID"];
                dr["sNo"] = row["sNo"];
                dr["sName"] = row["sName"];
                dr["sGender"] = row["sGender"];
                dr["sDept"] = row["sDept"];
                dr["sSkill"] = row["sSkill"];
                dtPerson.Rows.Add(dr);
            }
        }
        #endregion

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // 1. 取输入框的值
            string name = txtName.Text.Trim();
            string no = txtNo.Text.Trim();

            // 2. 简单校验
            if (name == "" || no == "")
            {
                MessageBox.Show("姓名和工号不能为空！");
                return;
            }

            // 3. 取性别
            string gender = rdoMale.Checked ? "男" : "女";

            // 4. 取部门
            string dept = cboDept.Text;

            // 5. 取选中的技能
            string skills = "";
            if (chkCsharp.Checked) skills += "C# ";
            if (chkSql.Checked) skills += "SQL ";
            if (chkDelphi.Checked) skills += "Delphi ";
            skills = skills.Trim();

            lstResult.Items.Add($"——————————————");
            lstResult.Items.Add($"工号:{no}");
            lstResult.Items.Add($"姓名:{name}");
            lstResult.Items.Add($"性别:{gender}");
            lstResult.Items.Add($"部门:{dept}");
            lstResult.Items.Add($"技能:{skills}");

            if (_isEditMode)
            {
                PersonRepository.Update(_editGuid, no, name, gender, dept, skills, CurrentUser);
            }
            else
            {
                PersonRepository.Insert(no, name, gender, dept, skills, CurrentUser);
            }

            LoadDataFromDB(_searchKey);

            // ✅提交完成后，重置为【新增模式】！！非常关键
            _isEditMode = false;
            _editGuid = Guid.Empty;

            // 7. 提交后清空输入框
            btnClear_Click(null, null);
        }

        #region 删除示例：比如新增一个【删除按钮 btnDelete】
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPerson.CurrentRow == null)
            {
                MessageBox.Show("请选中一行");
                return;
            }
            DataRowView drv = dgvPerson.CurrentRow.DataBoundItem as DataRowView;
            Guid guid = (Guid)drv.Row["uGUID"];

            PersonRepository.Delete(guid);
            LoadDataFromDB(_searchKey);
        }
        #endregion

        #region 修改示例：双击表格行，回显到输入框，再点提交做更新
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dgvPerson.CurrentRow == null) return;
            DataRowView drv = dgvPerson.CurrentRow.DataBoundItem as DataRowView;

            // ✅标记进入编辑模式，记录主键
            _isEditMode = true;
            _editGuid = (Guid)drv.Row["uGUID"];

            txtNo.Text = drv.Row["sNo"].ToString();
            txtName.Text = drv.Row["sName"].ToString();
            string g = drv.Row["sGender"].ToString();
            rdoMale.Checked = g == "男";
            rdoFemale.Checked = g == "女";
            cboDept.Text = drv.Row["sDept"].ToString();
            string sk = drv.Row["sSkill"].ToString();
            chkCsharp.Checked = sk.Contains("C#");
            chkSql.Checked = sk.Contains("SQL");
            chkDelphi.Checked = sk.Contains("Delphi");
        }
        #endregion

        //清空输入框，不清数据库
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtNo.Clear();
            rdoMale.Checked = true;
            cboDept.SelectedIndex = -1;
            chkCsharp.Checked = false;
            chkSql.Checked = false;
            chkDelphi.Checked = false;

            //清空同时重置状态，防止还停留在编辑模式
            _isEditMode = false;
            _editGuid = Guid.Empty;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _searchKey = txtSearch.Text.Trim();
            LoadDataFromDB(_searchKey);
        }

        private void btnResetSearc_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            _searchKey = "";
            LoadDataFromDB(); //加载全部
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }
    }
}
