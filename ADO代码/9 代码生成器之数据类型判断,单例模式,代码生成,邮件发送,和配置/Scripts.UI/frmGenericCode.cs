using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Scripts.UI
{
    public partial class frmGenericCode : Form
    {
        public frmGenericCode()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //根据指定的连接字符串创建连接对象
            using (SqlConnection con = new SqlConnection(txtConStr.Text.Trim()))
            {
                con.Open();
                this.Text = "连接成功！！！";
                DataTable dt = new DataTable();
                //select * from INFORMATION_SCHEMA.TABLES
                //执行查询语句把数据查询出来显示到ListBox中
                using (SqlDataAdapter adapter = new SqlDataAdapter("select table_name from INFORMATION_SCHEMA.TABLES", con))
                {
                    adapter.Fill(dt);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lboxTables.Items.Add(dt.Rows[i][0].ToString());
                }
            }
        }


        //生成代码
        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("");
            sb.AppendLine("namespace " + txtNs.Text.Trim());
            sb.AppendLine("{");
            sb.AppendLine("    public class " + ConvertName(lboxTables.SelectedItem.ToString()));
            sb.AppendLine("    {");
            //==============生成属性===========================================
            //1.查询出当前选中表中列的个数
            //把当前选中的表名传递进去
            List<ColumnInfo> list = GetColumns(lboxTables.SelectedItem.ToString());
            //遍历表中的每一列
            foreach (var item in list)
            {
                sb.AppendLine("        private " + GetCSharpType(item) + " _" + item.ColumnName + ";");
                sb.AppendLine("        public " + GetCSharpType(item) + " " + ConvertName(item.ColumnName));
                sb.AppendLine("        {");
                sb.AppendLine("            get");
                sb.AppendLine("            {");
                sb.AppendLine("                return _" + item.ColumnName + ";");
                sb.AppendLine("            }");
                sb.AppendLine("            set");
                sb.AppendLine("            {");
                sb.AppendLine("                _" + item.ColumnName + " = value;");
                sb.AppendLine("            }");
                sb.AppendLine("        }");
            }

            //=========================================================

            sb.AppendLine("    }");
            sb.AppendLine("}");
            txtCode.Text = sb.ToString();
        }

        //根据指定列的信息生成一个对应的c sharp的数据类型
        private string GetCSharpType(ColumnInfo item)
        {
            string data_type_string = string.Empty;
            Type data_type = null;
            switch (item.DataType.ToLower())
            {
                case "char":
                case "nchar":
                case "varchar":
                case "nvarchar":
                case "text":
                case "ntext":
                    data_type_string = "string";
                    data_type = typeof(string);
                    break;
                case "bit":
                    data_type_string = "bool";
                    data_type = typeof(bool);
                    break;
                case "int":
                    data_type_string = "int";
                    data_type = typeof(int);
                    break;
                case "datetime":
                    data_type_string = "DateTime";
                    data_type = typeof(DateTime);
                    break;
            }

            if (data_type != null && item.IsNullable.ToLower() == "yes" && data_type.IsValueType)
            {
                data_type_string += "?";
            }

            return data_type_string;
        }

        private List<ColumnInfo> GetColumns(string p)
        {
            List<ColumnInfo> list = new List<ColumnInfo>();
            //1.执行查询语句将数据查询放到List结合中
            string sql = "select column_name,is_nullable,data_type from INFORMATION_SCHEMA.COLUMNS where table_name=@tbname";
            using (SqlConnection con = new SqlConnection(txtConStr.Text.Trim()))
            {
                DataTable dt = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, con))
                {
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@tbname", p));
                    adapter.Fill(dt);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ColumnInfo model = new ColumnInfo();
                    model.ColumnName = dt.Rows[i][0].ToString();
                    model.IsNullable = dt.Rows[i][1].ToString();
                    model.DataType = dt.Rows[i][2].ToString();
                    list.Add(model);
                }
            }
            return list;
        }

        private string ConvertName(string p)
        {
            return char.ToUpper(p[0]).ToString() + p.Substring(1);
        }
    }

    public class ColumnInfo
    {
        public string ColumnName
        {
            get;
            set;
        }
        public string IsNullable
        {
            get;
            set;
        }
        public string DataType
        {
            get;
            set;
        }
    }
}
