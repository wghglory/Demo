using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CRUD_WINFORM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadClass();
            LoadStudent();
        }

        public void LoadClass()
        {
            cboEditClass.Items.Clear();
            cboClass.Items.Clear();

            #region method 1: controls.Add(model)
            //string sql = "SELECT tClassId, tClassName from dbo.TblClass";
            //using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text, null))
            //{
            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {
            //            ClassModel cm = new ClassModel();
            //            cm.ClassId = reader.GetInt32(0);
            //            cm.ClassName = reader.GetString(1);
            //            cboClass.Items.Add(cm);
            //            cboEditClass.Items.Add(cm);
            //        }
            //    }
            //}
            //ClassModel cmDefault = new ClassModel();
            //cmDefault.ClassId = -1;
            //cmDefault.ClassName = "Please select";

            //cboClass.Items.Insert(0, cmDefault);
            //cboEditClass.Items.Insert(0, cmDefault);

            #endregion

            #region method 2: control.DataSource = list<model>: a bug in webform: 2 combobox are not independent.

            List<ClassModel> cms = new List<ClassModel>();

            string sql = "SELECT tClassId, tClassName from dbo.TblClass";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text, null))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ClassModel cm = new ClassModel();
                        cm.ClassName = reader.GetString(1);
                        cm.ClassId = reader.GetInt32(0);
                        cms.Add(cm);
                    }
                }
            }
            ClassModel cmDefault = new ClassModel();
            cmDefault.ClassId = -1;
            cmDefault.ClassName = "Please select";

            cms.Insert(0, cmDefault);

            cboClass.DisplayMember = "ClassName";
            cboClass.ValueMember = "ClassId";
            cboClass.DataSource = cms;

            cboEditClass.DisplayMember = "ClassName";
            cboEditClass.ValueMember = "ClassId";
            cboEditClass.DataSource = cms;

            #endregion

            cboClass.SelectedIndex = 0;
            
        }

        public void LoadStudent()
        {
            string sql = "SELECT  tSId, tSName, tSGender, tSAddress, tSPhone, tSAge, tSBirthday, tSCardId, tSClassId FROM dbo.TblStudent";

            List<Student> students = new List<Student>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text, null))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.IsDBNull(1) ? null : reader.GetString(1);
                        string gender = reader.GetString(2);
                        string address = reader.IsDBNull(3) ? null : reader.GetString(3);
                        string phone = reader.IsDBNull(4) ? null : reader.GetString(4);
                        int? age = reader.IsDBNull(5) ? null : (int?)reader.GetInt32(5);
                        DateTime? birthday = reader.IsDBNull(6) ? null : (DateTime?)reader.GetDateTime(6);
                        string cardId = reader.IsDBNull(7) ? null : reader.GetString(7);
                        int classId = reader.GetInt32(8);

                        Student stu = new Student();
                        stu.Sid = id;
                        stu.Name = name;
                        stu.Gender = gender;
                        stu.Address = address;
                        stu.Phone = phone;
                        stu.Age = age;
                        stu.Birthday = birthday;
                        stu.CardId = cardId;
                        stu.ClassId = classId;

                        students.Add(stu);
                    }
                }
            }

            dgStudent.DataSource = students;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string sqlInsert = "insert into TblStudent(tSName, tSGender, tSAddress, tSPhone, tSAge, tSBirthday, tSCardId, tSClassId) values(@name, @gender, @address, @phone, @age, @birthday, @cardId, @classId)";

            object name = txtName.Text.Length == 0 ? DBNull.Value : (object)txtName.Text;
            object gender = cboGender.Text;
            object address = txtAddress.Text.Length == 0 ? DBNull.Value : (object)txtAddress.Text;
            object phone = txtPhone.Text.Length == 0 ? DBNull.Value : (object)txtPhone.Text;
            object age = txtAge.Text.Length == 0 ? DBNull.Value : (object)txtAge.Text;
            object birthday = dpBirthday.Text.Length == 0 ? DBNull.Value : (object)dpBirthday.Text;
            object cardId = txtCardId.Text.Length == 0 ? DBNull.Value : (object)txtCardId.Text;

            ClassModel cm = cboClass.SelectedItem as ClassModel;
            int classId = Convert.ToInt32(cboClass.SelectedValue); //for method 2.  //cboClass.SelectedIndex; for method 1 //cm.ClassId;  both work

            if (cboGender.SelectedItem == null || cm == null)
            {
                MessageBox.Show("class and gender cannot be null.");
                return;
            }

            #region not specify data type, might get error
            //SqlParameter[] pms = new SqlParameter[]{
            //    new SqlParameter("@name",name)
            //    ,new SqlParameter("@gender",gender)
            //    ,new SqlParameter("@address",address)
            //    ,new SqlParameter("@phone",phone)
            //    ,new SqlParameter("@age",age)
            //    ,new SqlParameter("@birthday",birthday)
            //    ,new SqlParameter("@cardId",cardId)
            //    ,new SqlParameter("@classId", cboClass.SelectedIndex)   //classId)
            //};

            //exec sp_executesql N'insert into TblStudent(tSName, tSGender, tSAddress, tSPhone, tSAge, tSBirthday, tSCardId, tSClassId) values(@name, @gender, @address, @phone, @age, @birthday, @cardId, @classId)',N'@name nvarchar(4000),@gender nvarchar(1),@address nvarchar(4000),@phone nvarchar(4000),@age nvarchar(4000),@birthday nvarchar(10),@cardId nvarchar(4000),@classId int',@name=NULL,@gender=N'男',@address=NULL,@phone=NULL,@age=NULL,@birthday=N'2015年1月27日',@cardId=NULL,@classId=4
            #endregion

            #region specify data type if above doesn't work

            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@name",SqlDbType.VarChar,50),
            new SqlParameter("@gender",SqlDbType.Char,2),
            new SqlParameter("@address",SqlDbType.VarChar,300),
            new SqlParameter("@phone",SqlDbType.VarChar,100),
            new SqlParameter("@age",SqlDbType.Int),
            new SqlParameter("@birthday",SqlDbType.DateTime),
            new SqlParameter("@cardId",SqlDbType.VarChar,18),
            new SqlParameter("@classId",SqlDbType.Int)
            //,new SqlParameter("@tsid",SqlDbType.Int)
            };

            pms[0].Value = name;
            pms[1].Value = gender;
            pms[2].Value = address;
            pms[3].Value = phone;
            pms[4].Value = age;
            pms[5].Value = birthday;
            pms[6].Value = cardId;
            pms[7].Value = classId;
            #endregion

            int r = 0;
            r = SqlHelper.ExecuteNonQuery(sqlInsert, CommandType.Text, pms);
            LoadStudent();
            MessageBox.Show("Successfully insert " + r + " data");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sqlDelete = "delete from TblStudent where tSid = @sid";

            if (dgStudent.SelectedRows != null)
            {
                int sid = (int)dgStudent.SelectedRows[0].Cells[0].Value;  //selected row first cell is id
                int r = 0;
                r = SqlHelper.ExecuteNonQuery(sqlDelete, CommandType.Text, new SqlParameter("@sid", sid));
                LoadStudent();
                MessageBox.Show("Successfully delete " + r + " data");
            }
            else
            {
                MessageBox.Show("Please select a row");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sqlUpdate = "UPDATE TblStudent SET [tSName] = @name,[tSGender] = @gender,[tSAddress] = @address, [tSPhone] = @phone, [tSAge] = @age, [tSBirthday] = @birthday, tSCardId = @cardId, [tSClassId] = @classId WHERE tSId=@sid";


            ClassModel cm = cboEditClass.SelectedItem as ClassModel;
            int classId = cm.ClassId;

            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@name",txtEditName.Text==""?DBNull.Value:(object)txtEditName.Text)
                , new SqlParameter("@gender",cboEditGender.Text)
                , new SqlParameter("@address",txtEditAddress.Text==""?DBNull.Value:(object)txtEditAddress.Text)
                , new SqlParameter("@phone",txtEditPhone.Text==""?DBNull.Value:(object)txtEditPhone.Text)
                , new SqlParameter("@age",txtEditAge.Text==""?DBNull.Value:(object)txtEditAge.Text)
                , new SqlParameter("@birthday",dpEditBirthday.Value)
                , new SqlParameter("@cardId",txtEditCardId.Text==""?DBNull.Value:(object)txtEditCardId.Text)
                , new SqlParameter("@classId",cboEditClass.SelectedValue)    //only for method 2   
                //classId: this works both
                , new SqlParameter("@sid",txtEditId.Text==""?DBNull.Value:(object)txtEditId.Text)            
            };

            int r = 0;
            r = SqlHelper.ExecuteNonQuery(sqlUpdate, CommandType.Text, pms);
            MessageBox.Show("Successfully update " + r + " data");
        }

        private void dgStudent_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            //DataGridViewRow d = dgStudent.SelectedRows[0];  //not working
            //获取当前选中行
            DataGridViewRow dgv = dgStudent.Rows[e.RowIndex];

            txtEditId.Text = dgv.Cells[0].Value.ToString();
            txtEditName.Text = dgv.Cells[1].Value == null ? string.Empty : dgv.Cells[1].Value.ToString();
            if (dgv.Cells[2].Value.ToString() == "男")
            {
                cboEditGender.SelectedIndex = 0;
            }
            else { cboEditGender.SelectedIndex = 1; }

            txtEditAddress.Text = dgv.Cells[3].Value == null ? string.Empty : dgv.Cells[3].Value.ToString();
            txtEditPhone.Text = dgv.Cells[4].Value == null ? string.Empty : dgv.Cells[4].Value.ToString();
            txtEditAge.Text = dgv.Cells[5].Value == null ? string.Empty : dgv.Cells[5].Value.ToString();
            if (dgv.Cells[6].Value != null)
            {
                dpEditBirthday.Value = (DateTime)dgv.Cells[6].Value;
            }

            txtEditCardId.Text = dgv.Cells[7].Value == null ? string.Empty : dgv.Cells[7].Value.ToString();

            //cboEditClass.SelectedIndex = (int)dgv.Cells[8].Value;  //method 1 works. attention: selectedindex just correspond to classId. SelectedValue cannot work here because I use method 1, controls.Add(model). If using method 2: bind list to control, SelectedValue should work well.

            cboEditClass.SelectedValue = (int)dgv.Cells[8].Value; //method 2
        }

        //private void dgStudent_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        //{
        //    //avoid selecting the first row when loaded.
        //    dgStudent.ClearSelection();
        //    //dgStudent.Rows[0].Selected = false;
        //}

    }
}
