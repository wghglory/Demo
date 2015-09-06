using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Itcast.Cn;

namespace _04更新表中的拼音列
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //先查询出姓名与Id
            string sql = "select cc_autoId,cc_customername from T_Customers";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int autoId = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string py = ConvertToPy(name);

                        UpdateTable(autoId, py);
                    }
                }
            }
            MessageBox.Show("ok");
        }

        private string ConvertToPy(string name)
        {
            return CommonHelper.ConvertChineseToPinyin(name);
        }

        private void UpdateTable(int autoId, string py)
        {
            string sql_update = "update T_Customers set cc_py=@py where cc_autoId=@autoId";
            SqlParameter[] pms = new SqlParameter[]{
            new SqlParameter("@autoId",autoId),
            new SqlParameter("@py",py)
            };
            SqlHelper.ExecuteNonQuery(sql_update, CommandType.Text, pms);
        }
    }
}
