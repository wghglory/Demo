using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRUD_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadClass();
            LoadStudent();
            LoadGender();
        }

        //only gender, class cannot be null
        private void LoadClass()
        {
            cboClassEdit.Items.Clear();
            cboClass.Items.Clear();

            #region method 1: add model to combobox, override ToString();  "controls.Items.Add(model)"

            //string sql = "SELECT tClassId, tClassName from dbo.TblClass";
            //using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text, null))
            //{
            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {
            //            ClassModel classModel = new ClassModel();
            //            classModel.ClassId = reader.GetInt32(0);
            //            classModel.ClassName = reader.GetString(1);
            //            cboClass.Items.Add(classModel);
            //            cboClassEdit.Items.Add(classModel);
            //        }
            //    }
            //}
            //ClassModel classDefault = new ClassModel();
            //classDefault.ClassId = -1;
            //classDefault.ClassName = "Please select";
            //cboClass.Items.Insert(0, classDefault);
            //cboClassEdit.Items.Insert(0, classDefault);

            //cboClass.SelectedIndex = 0;
            //cboClassEdit.SelectedIndex = 0;
            #endregion

            #region method 2: controls.DataSource = list

            string sql = "SELECT tClassId, tClassName from dbo.TblClass";
            List<ClassModel> cms = new List<ClassModel>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text, null))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ClassModel cm = new ClassModel();
                        cm.ClassId = reader.GetInt32(0);
                        cm.ClassName = reader.GetString(1);
                        cms.Add(cm);
                    }
                }
            }
            ClassModel cmDefault = new ClassModel();
            cmDefault.ClassId = -1;
            cmDefault.ClassName = "Please select class";
            cms.Insert(0, cmDefault);

            //设置CombBox的数据源
            //一般在做数据绑定的时候，指定的名称必须是属性的名称，不能是字段。
            cboClass.DisplayMemberPath = "ClassName";
            cboClass.SelectedValuePath = "ClassId";
            cboClassEdit.DisplayMemberPath = "ClassName";
            cboClassEdit.SelectedValuePath = "ClassId";

            cboClass.ItemsSource = cms;
            cboClassEdit.ItemsSource = cms;
            cboClass.SelectedIndex = 0;
            cboClassEdit.SelectedIndex = 0;

            #endregion
        }

        private void LoadStudent()
        {
            //method 2: dataSource = list<>; "controls.DataSource = modelList"
            List<Student> students = new List<Student>();

            string sql = "SELECT  tSId, tSName, tSGender, tSAddress, tSPhone, tSAge, tSBirthday, tSCardId, tSClassId FROM dbo.TblStudent";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text, null))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Student stu = new Student();
                        stu.Sid = reader.GetInt32(0);
                        stu.Name = reader.IsDBNull(1) ? null : reader.GetString(1);
                        stu.Gender = reader.GetString(2);
                        stu.Address = reader.IsDBNull(3) ? null : reader.GetString(3);
                        stu.Phone = reader.IsDBNull(4) ? null : reader.GetString(4);
                        stu.Age = reader.IsDBNull(5) ? null : (int?)reader.GetInt32(5);
                        stu.Birthday = reader.IsDBNull(6) ? null : (DateTime?)reader.GetDateTime(6);
                        stu.CardId = reader.IsDBNull(7) ? null : reader.GetString(7);
                        stu.ClassId = reader.GetInt32(8);
                        students.Add(stu);
                    }
                }
            }
            dgStudent.ItemsSource = students;

        }

        private void LoadGender()
        {
            cboGender.Items.Clear();
            cboGenderEdit.Items.Clear();

            cboGender.Items.Add("男");
            cboGender.Items.Add("女");
            cboGenderEdit.Items.Add("男");
            cboGenderEdit.Items.Add("女");
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string sqlInsert = "insert into TblStudent(tSName, tSGender, tSAddress, tSPhone, tSAge, tSBirthday, tSCardId, tSClassId) values(@name, @gender, @address, @phone, @age, @birthday, @cardId, @classId)";

            ClassModel cm = cboClass.SelectedItem as ClassModel;
            if (cboGender.SelectedValue == null || cm == null)
            {
                MessageBox.Show("class and gender cannot be null.");
                return;
            }

            int classId = cm.ClassId;

            SqlParameter[] pms = new SqlParameter[]
            {
                //当使用带参数的Sql语句时候，如果要向数据库中插入空值，必须使用DBNull.Value,不能直接写null
                new SqlParameter("@name", txtName.Text.Length == 0 ?DBNull.Value:(object)txtName.Text),
                new SqlParameter("@gender",cboGender.SelectedValue),
                new SqlParameter("@address",txtAddress.Text =="" ? DBNull.Value:(object)txtAddress.Text),
                new SqlParameter("@phone",txtPhone.Text=="" ? DBNull.Value:(object)txtPhone.Text),
                new SqlParameter("@age",txtAge.Text=="" ? DBNull.Value:(object)txtAge.Text),
                new SqlParameter("@birthday",dpBirthday.SelectedDate==null ? DBNull.Value:(object)dpBirthday.SelectedDate),
                new SqlParameter("@cardId",txtCard.Text==""?DBNull.Value:(object)txtCard.Text),
                //new SqlParameter("@classId", classId)   //both method 1 and 2 work
                new SqlParameter("@classId", cboClass.SelectedValue)   //only works for method 2
            };

            #region specify data type if above doesn't work
            //SqlParameter[] pms = new SqlParameter[] { 
            //new SqlParameter("@name",SqlDbType.VarChar,50),
            //new SqlParameter("@gender",SqlDbType.Char,2),
            //new SqlParameter("@address",SqlDbType.VarChar,300),
            //new SqlParameter("@phone",SqlDbType.VarChar,100),
            //new SqlParameter("@age",SqlDbType.Int),
            //new SqlParameter("@birthday",SqlDbType.DateTime),
            //new SqlParameter("@cardId",SqlDbType.VarChar,18),
            //new SqlParameter("@classId",SqlDbType.Int)
            ////,new SqlParameter("@tsid",SqlDbType.Int)
            //};


            //pms[0].Value = txtName.Text.Trim().Length == 0 ? DBNull.Value : (object)txtName.Text.Trim();
            //pms[1].Value = cboGender.Text;
            //pms[2].Value = txtAddress.Text.Trim().Length == 0 ? DBNull.Value : (object)txtAddress.Text.Trim();
            ////=="" 不如length==0
            //pms[3].Value = txtPhone.Text == "" ? DBNull.Value : (object)txtPhone.Text.Trim();
            //pms[4].Value = txtAge.Text.Trim().Length == 0 ? DBNull.Value : (object)txtAge.Text.Trim();
            //pms[5].Value = dpBirthday.SelectedDate == null ? DBNull.Value : (object)dpBirthday.SelectedDate;
            //pms[6].Value = txtCard.Text.Trim().Length == 0 ? DBNull.Value : (object)txtCard.Text.Trim();
            //pms[7].Value = classId;
            #endregion

            int r = 0;
            r = SqlHelper.ExecuteNonQuery(sqlInsert, CommandType.Text, pms);
            LoadStudent();
            MessageBox.Show("Successfully add " + r + " data");
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Student stu = dgStudent.SelectedItem as Student;
            int r = 0;
            string sqlDelete = "delete from TblStudent where tSId = @sid";

            if (stu != null)
            {
                r = SqlHelper.ExecuteNonQuery(sqlDelete, CommandType.Text, new SqlParameter("@sid", stu.Sid));
                //Todo: add javascript to confirm delete.
                LoadStudent();
                MessageBox.Show("Successfully delete " + r + " data");
            }
            else
            {
                MessageBox.Show("Please select a row");
            }

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string sqlUpdate = "UPDATE TblStudent SET [tSName] = @name,[tSGender] = @gender,[tSAddress] = @address, [tSPhone] = @phone, [tSAge] = @age, [tSBirthday] = @birthday, tSCardId = @cardId, [tSClassId] = @classId WHERE tSId=@sid";

            ClassModel cm = cboClassEdit.SelectedItem as ClassModel;
            int classId = cm.ClassId;

            //update I don't specify the data type.
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@name", txtNameEdit.Text.Length == 0 ? DBNull.Value:(object)txtNameEdit.Text),
                new SqlParameter("@gender",cboGenderEdit.SelectedValue),
                new SqlParameter("@address",txtAddressEdit.Text =="" ? DBNull.Value:(object)txtAddressEdit.Text),
                new SqlParameter("@phone",txtPhoneEdit.Text=="" ? DBNull.Value:(object)txtPhoneEdit.Text),
                new SqlParameter("@age",txtAgeEdit.Text=="" ? DBNull.Value:(object)txtAgeEdit.Text),
                new SqlParameter("@birthday",dpBirthdayEdit.SelectedDate==null ? DBNull.Value:(object)dpBirthdayEdit.SelectedDate),
                new SqlParameter("@cardId",txtCardEdit.Text==""?DBNull.Value:(object)txtCardEdit.Text),
                //new SqlParameter("@classId", classId),  //method 1 and 2 both work
                new SqlParameter("@classId", cboClassEdit.SelectedValue),  //only works for method 2
                new SqlParameter("@sid", (int)lblId.Content)
            };


            int r = 0;
            r = SqlHelper.ExecuteNonQuery(sqlUpdate, CommandType.Text, pms);
            LoadStudent();
            MessageBox.Show("Successfully update " + r + " data");
        }

        private void dgStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //load select row into downside textboxes

            Student stu = dgStudent.SelectedItem as Student;
            if (stu != null)
            {
                txtNameEdit.Text = stu.Name;
                txtAddressEdit.Text = stu.Address;
                txtAgeEdit.Text = stu.Age.ToString();
                txtCardEdit.Text = stu.CardId;
                txtPhoneEdit.Text = stu.Phone;
                lblId.Content = stu.Sid;

                cboGenderEdit.SelectedValue = stu.Gender;

                dpBirthdayEdit.SelectedDate = stu.Birthday;

                //cboClassEdit.SelectedIndex = stu.ClassId;  //attention: selectedindex just correspond to classId. SelectedValue cannot work here because I use method 1, controls.Add(model). If using method 2: bind list to control, SelectedValue should work well.

                cboClassEdit.SelectedValue = stu.ClassId;  //method 2
            }
        }


    }

}
