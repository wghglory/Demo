using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _01对TblStudent表实现增删查改
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //添加数据
        private void button1_Click(object sender, EventArgs e)
        {
            // tSName,  tSAddress, tSPhone, tSAge, tSBirthday, tSCardId
            //采集用户的输入
            //tSId, tSName, tSGender, tSAddress, tSPhone, tSAge, tSBirthday, tSCardId, tSClassId
            string name = txtName.Text.Trim().Length == 0 ? null : txtName.Text.Trim();
            string gender = cboGender.Text.Trim();
            string address = txtAddress.Text.Trim().Length == 0 ? null : txtAddress.Text.Trim();
            string phone = txtPhone.Text.Trim().Length == 0 ? null : txtPhone.Text.Trim();
            int? age = txtAge.Text.Trim().Length == 0 ? null : (int?)int.Parse(txtAge.Text.Trim());
            DateTime birthday = dateTimePicker1.Value;

            string cardid = txtCardId.Text.Trim().Length == 0 ? null : txtCardId.Text.Trim();

            int classId = Convert.ToInt32(cboClass.SelectedValue);


            int r = 0;
            string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = string.Format("insert into TblStudent(tSName, tSGender, tSAddress, tSPhone, tSAge, tSBirthday, tSCardId, tSClassId) values({0},'{1}',{2},{3},{4},'{5}',{6},{7})", name == null ? "null" : "'" + name + "'", gender, address == null ? "null" : "'" + address + "'", phone == null ? "null" : "'" + phone + "'", age == null ? "null" : age.ToString(), birthday, cardid == null ? "null" : "'" + cardid + "'", classId);
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    r = cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("成功添加" + r + "行数据。");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //把班级表中的数据加载到下拉菜单中。
            LoadClassInfoToCombox();


            //窗体加载的时候加载学生数据到DataGridView
            LoadStuddents();
        }

        private void LoadStuddents()
        {
            string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";

            List<Student> list = new List<Student>();

            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = "select * from TblStudent";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                //tSId, tSName, tSGender, tSAddress, tSPhone, tSAge, tSBirthday, tSCardId, tSClassId
                                Student model = new Student()
                                {
                                    TsId = reader.GetInt32(0),
                                    TsName = reader.IsDBNull(1) ? null : reader.GetString(1),
                                    Gender = reader.GetString(2),
                                    Address = reader.IsDBNull(3) ? null : reader.GetString(3),
                                    Phone = reader.IsDBNull(4) ? null : reader.GetString(4),
                                    Age = reader.IsDBNull(5) ? null : (int?)reader.GetInt32(5),
                                    Birthday = reader.IsDBNull(6) ? null : (DateTime?)reader.GetDateTime(6),

                                    TsCardId = reader.IsDBNull(7) ? null : reader.GetString(7),
                                    ClassId = reader.GetInt32(8)

                                };
                                list.Add(model);
                            }
                        }
                    }
                }
            }
            dataGridView1.DataSource = list;

        }

        private void LoadClassInfoToCombox()
        {
            List<ClassModel> list = new List<ClassModel>();
            string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                //把班级表中的数据查询出来。
                string sql = "select tclassName,tclassId from TblClass";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    //应该调用cmd.ExecuteReader()方法，因为返回的是多行多列。
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        //在使用DataReader的时候必须保证SqlConnection是打开状态。
                        // con.Close();
                        if (reader.HasRows)
                        {
                            //循环获取数据
                            while (reader.Read())
                            {
                                #region 通过Items.Add()方式向ComboBox中添加数据

                                //int clsId = reader.GetInt32(1);
                                //string clsName = reader.GetString(0);
                                //ClassModel model = new ClassModel();
                                //model.ClassId = clsId;
                                //model.ClassName = clsName;
                                //cboClass.Items.Add(model);

                                #endregion


                                #region 构建一个数据源List集合
                                int clsId = reader.GetInt32(1);
                                string clsName = reader.GetString(0);
                                ClassModel model = new ClassModel();
                                model.ClassId = clsId;
                                model.ClassName = clsName;

                                list.Add(model);

                                #endregion

                            }
                        }
                    }
                }
            }


            //设置CombBox的数据源
            //一般在做数据绑定的时候，指定的名称必须是属性的名称，不能是字段。
            cboClass.DisplayMember = "ClassName";
            cboClass.ValueMember = "ClassId";
            cboClass.DataSource = list;

            //绑定编辑里面的下拉菜单
            cboEditClassId.DisplayMember = "ClassName";
            cboEditClassId.ValueMember = "ClassId";
            cboEditClassId.DataSource = list;
        }



        //当通过cob.Items.Add()方式向combobox中添加数据时，获取Id的方式。
        private void button4_Click(object sender, EventArgs e)
        {
            if (cboClass.SelectedItem != null)
            {
                ClassModel model = cboClass.SelectedItem as ClassModel;
                if (model != null)
                {
                    MessageBox.Show(model.ClassName + "    " + model.ClassId);
                }

            }
        }


        //获取通过数据源绑定的ComboBox的选中项名称和Id
        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cboClass.Text + "    " + cboClass.SelectedValue);
            //MessageBox.Show(cboClass.SelectedItem.ToString());
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //获取当前选中行
            //e.RowIndex
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            //row.Cells[0]
            //tSId, tSName, tSGender, tSAddress, tSPhone, tSAge, tSBirthday, tSCardId, tSClassId
            txtEditId.Text = row.Cells[0].Value.ToString();
            txtEditName.Text = row.Cells[1].Value == null ? string.Empty : row.Cells[1].Value.ToString();
            if (row.Cells[2].Value.ToString() == "男")
            {
                cboEditGender.SelectedIndex = 0;
            }
            else
            {
                cboEditGender.SelectedIndex = 1;

            }
            txtEditAddress.Text = row.Cells[3].Value == null ? string.Empty : row.Cells[3].Value.ToString();
            txtEditPhone.Text = row.Cells[4].Value == null ? string.Empty : row.Cells[4].Value.ToString();
            txtEditAge.Text = row.Cells[5].Value == null ? string.Empty : row.Cells[5].Value.ToString();
            if (row.Cells[6].Value != null)
            {
                dtpickerEdit.Value = DateTime.Parse(row.Cells[6].Value.ToString());
            }

            txtEditCardId.Text = row.Cells[7].Value == null ? string.Empty : row.Cells[7].Value.ToString();


            //设置下拉菜单的SelectedValue为某个值，则下拉菜单会自动选中这个值。
            //注意：在数据源绑定的时候ValueMemeber是int类型，所以这里设置SelectedValue的时候也必须使用int类型。
            cboEditClassId.SelectedValue = int.Parse(row.Cells[8].Value.ToString());


        }


        //实现更新操作
        private void button2_Click(object sender, EventArgs e)
        {
            //tSId, tSName, tSGender, tSAddress, tSPhone, tSAge, tSBirthday, tSCardId, tSClassId
            string sql_update = "update TblStudent set tsname=@name,tsgender=@gender,tsaddress=@address,tsphone=@phone,tsage=@age,tsbirthday=@birthday,tscardId=@cardId,tsclassId=@classId where tsid=@tsid";

            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@name",SqlDbType.VarChar,50),
            new SqlParameter("@gender",SqlDbType.Char,2),
            new SqlParameter("@address",SqlDbType.VarChar,300),
            new SqlParameter("@phone",SqlDbType.VarChar,100),
            new SqlParameter("@age",SqlDbType.Int),
            new SqlParameter("@birthday",SqlDbType.DateTime),
            new SqlParameter("@cardId",SqlDbType.VarChar,18),
            new SqlParameter("@classId",SqlDbType.Int),
            new SqlParameter("@tsid",SqlDbType.Int)
            };
            //当使用带参数的Sql语句时候，如果要向数据库中插入空值，必须使用DBNull.Value,不能直接写null
            //DBNull.Value;
            // tSName,  tSAddress, tSPhone, tSAge, tSBirthday, tSCardId
            pms[0].Value = txtEditName.Text.Trim().Length == 0 ? DBNull.Value : (object)txtEditName.Text.Trim();
            pms[1].Value = cboEditGender.Text;
            pms[2].Value = txtEditAddress.Text.Trim().Length == 0 ? DBNull.Value : (object)txtEditAddress.Text.Trim();
            pms[3].Value = txtEditPhone.Text.Trim().Length == 0 ? DBNull.Value : (object)txtEditPhone.Text.Trim();
            pms[4].Value = txtEditAge.Text.Trim().Length == 0 ? DBNull.Value : (object)txtEditAge.Text.Trim();
            pms[5].Value = dtpickerEdit.Value;
            pms[6].Value = txtCardId.Text.Trim().Length == 0 ? DBNull.Value : (object)txtCardId.Text.Trim();
            pms[7].Value = cboEditClassId.SelectedValue;
            pms[8].Value = txtEditId.Text.Trim();

            int r = _06自己封装一个SqlHelper.SqlHelper.ExecuteNonQuery(sql_update, pms);

            MessageBox.Show("成功修改了" + r + "行。");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //SelectedRows.Count > 0表示有选中行。
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //根据Id来删除某条记录
                //1.获取当前选中行的Id
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                //根据Id删除当前选中记录
                string constr = "Data Source=steve-pc;Initial Catalog=itcast2013;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string sql = string.Format("delete from TblStudent where tsid={0}", id);
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadStuddents();
            }


        }
    }
}
