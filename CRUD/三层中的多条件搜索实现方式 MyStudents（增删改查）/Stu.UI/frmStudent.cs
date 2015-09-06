using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stu.BLL;
using Stu.Model;

namespace Stu.UI
{
    public partial class frmStudent : Form
    {
        public frmStudent()
        {
            InitializeComponent();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            //加载数据
            InitialStudentData();

            //初始化年龄与性别的下拉菜单
            InitialAgeAndGender();

            //初始化班级
            InitialClass();
        }

        private void InitialClass()
        {
            MyClassBll bll = new MyClassBll();
            //从数据库中读取班级信息并绑定到下拉菜单上
            List<MyClass> list = bll.GetAllClasses();

            List<MyClass> list1 = list.ToList();
            cboClassAdd.DisplayMember = "ClassName";
            cboClassAdd.ValueMember = "ClassId";
            cboClassAdd.DataSource = list;

            cboClassEdit.DisplayMember = "ClassName";
            cboClassEdit.ValueMember = "ClassId";
            cboClassEdit.DataSource = list1;


            List<MyClass> list2 = list.ToList();
            list2.Insert(0, new MyClass() { ClassId = -1, ClassName = "全部" });
            cboClassSearch.DisplayMember = "ClassName";
            cboClassSearch.ValueMember = "ClassId";
            cboClassSearch.DataSource = list2;
        }

        private void InitialAgeAndGender()
        {
            //初始化年龄
            for (int i = 1; i < 120; i++)
            {
                cboAgeAdd.Items.Add(i);
                cboAgeEdit.Items.Add(i);
            }
            cboAgeAdd.SelectedIndex = 0;
            cboAgeEdit.SelectedIndex = 0;

            //初始化性别
            cboGenderAdd.Items.Add("男");
            cboGenderEdit.Items.Add("男");

            cboGenderAdd.Items.Add("女");
            cboGenderEdit.Items.Add("女");

            cboGenderAdd.SelectedIndex = 0;
            cboGenderEdit.SelectedIndex = 0;

            cboGenderSearch.Items.Add("全部");
            cboGenderSearch.Items.Add("男");
            cboGenderSearch.Items.Add("女");
            cboGenderSearch.SelectedIndex = 0;
        }

        private void InitialStudentData()
        {
            MyStudentBll bll = new MyStudentBll();
            List<MyStudent> list = bll.GetAllStudents();
            this.dataGridView1.DataSource = list;
        }

        //在设置单元格显示格式的事件中将MyClass对象中的ClassName获取到并且显示到单元格上。
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.Value is MyClass && e.ColumnIndex == 6)
            {
                MyClass mc = e.Value as MyClass;
                e.Value = mc.ClassName;
            }
        }


        //增加一条数据
        private void button1_Click(object sender, EventArgs e)
        {
            //1.采集数据
            string name = txtNameAdd.Text.Trim();
            int age = int.Parse(cboAgeAdd.Text.Trim());
            string gender = cboGenderAdd.Text.Trim();
            int classid = (int)cboClassAdd.SelectedValue;
            int? math = txtMathAdd.Text.Trim().Length == 0 ? null : (int?)int.Parse(txtMathAdd.Text.Trim());
            int english = int.Parse(txtEnglishAdd.Text.Trim());
            DateTime birthday = datepickerBirthdayAdd.Value;
            //2.创建业务逻辑层
            MyStudentBll bll = new MyStudentBll();
            int r = bll.Add(new MyStudent() { FName = name, FAge = age, FGender = gender, Class = new MyClass() { ClassId = classid }, FMath = math, FEnglish = english, FBirthday = birthday });
            //3.执行添加学生操作
            MessageBox.Show("成功插入：" + r + "条记录。");
            ResetAddNewStudent();
            InitialStudentData();
        }


        //重置增加数据的区域
        private void ResetAddNewStudent()
        {
            txtNameAdd.Text = string.Empty;
            cboAgeAdd.SelectedIndex = 0;
            cboGenderAdd.SelectedIndex = 0;
            cboClassAdd.SelectedIndex = 0;
            txtMathAdd.Text = string.Empty;
            txtEnglishAdd.Text = string.Empty;
            datepickerBirthdayAdd.Value = System.DateTime.Now;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //1.获取当前选中的行
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            if (row != null)
            {
                lblAutoId.Text = row.Cells[0].Value.ToString();
                txtNameEdit.Text = row.Cells[1].Value.ToString();
                cboAgeEdit.Text = row.Cells[2].Value.ToString();
                cboGenderEdit.Text = row.Cells[3].Value.ToString();
                txtMathEdit.Text = row.Cells[4].Value == null ? string.Empty : row.Cells[5].Value.ToString();
                txtEnglishEdit.Text = row.Cells[5].Value.ToString();
                MyClass myclass = row.Cells[6].Value as MyClass;
                cboClassEdit.SelectedValue = myclass.ClassId;

                datepickerBirthdayEdit.Value = Convert.ToDateTime(row.Cells[7].Value);
            }

            //2.将当前选中行的信息显示到编辑框中


        }


        //更新
        private void button3_Click(object sender, EventArgs e)
        {
            //保存修改
            MyStudentBll bll = new MyStudentBll();
            //采集数据
            MyStudent model = new MyStudent();
            model.Fid = int.Parse(lblAutoId.Text.Trim());
            model.FName = txtNameEdit.Text.Trim();
            model.FAge = int.Parse(cboAgeEdit.Text.Trim());
            model.FGender = cboGenderEdit.Text.Trim();
            model.FMath = txtMathEdit.Text.Trim().Length == 0 ? null : (int?)int.Parse(txtMathEdit.Text.Trim());
            model.FEnglish = int.Parse(txtEnglishEdit.Text.Trim());
            model.Class = new MyClass() { ClassId = Convert.ToInt32(cboClassEdit.SelectedValue) };
            model.FBirthday = datepickerBirthdayEdit.Value;

            //执行修改操作
            bll.Update(model);

            InitialStudentData();
        }



        //删除
        private void button2_Click(object sender, EventArgs e)
        {
            MyStudentBll bll = new MyStudentBll();
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells[0].Value);
                int r = bll.Delete(id);
                MessageBox.Show("成功删除了" + r + "行。");
                InitialStudentData();
            }


        }


        //查询
        private void button4_Click(object sender, EventArgs e)
        {
            //1.构建查询条件
            List<Condition> listWhere = new List<Condition>();
            if (txtNameSearch.Text.Trim().Length != 0)
            {
                listWhere.Add(new Condition() { PropertyName = "fname", Operation = Opt.Like, Value = txtNameSearch.Text.Trim() });
            }
            if (cboClassSearch.SelectedIndex != 0)
            {
                listWhere.Add(new Condition() { PropertyName = "fclassid", Operation = Opt.Equal, Value = cboClassSearch.SelectedValue });
            }
            if (cboGenderSearch.SelectedIndex != 0)
            {
                listWhere.Add(new Condition() { PropertyName = "fgender", Operation = Opt.Equal, Value = cboGenderSearch.Text.Trim() });
            }

            //调用查询方法
            MyStudentBll bll = new MyStudentBll();
            List<MyStudent> listData = bll.SearchData(listWhere);
            this.dataGridView1.DataSource = listData;
            lblResult.Text = "查询总记录条数为：" + listData.Count.ToString();

        }
    }
}
