using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _06多条件查询的时候的Sql语句问题
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //books
            //select * from books
            //select * from books where bookname like '%T-Sql%'
            #region 方式1

            //StringBuilder sb = new StringBuilder("select * from books where 1=1");
            //if (txtBookName.Text.Trim().Length != 0)
            //{
            //    sb.Append(" and bookName like '%" + txtBookName.Text.Trim() + "%'");
            //}
            //if (txtPubName.Text.Trim().Length > 0)
            //{
            //    sb.Append(" and PublishName like '%" + txtPubName.Text.Trim() + "%'");
            //}
            //if (txtPrice.Text.Trim().Length > 0)
            //{
            //    sb.Append(" and Price =" + double.Parse(txtPrice.Text.Trim()) + "");
            //}
            //MessageBox.Show(sb.ToString());
            #endregion

            #region 方式二


            //StringBuilder sb = new StringBuilder("select * from books");
            //List<string> listConditions = new List<string>();

            //if (txtBookName.Text.Trim().Length != 0)
            //{
            //    //sb.Append(" and bookName like '%" + txtBookName.Text.Trim() + "%'");
            //    listConditions.Add(" bookName like '%" + txtBookName.Text.Trim() + "%' ");
            //}
            //if (txtPubName.Text.Trim().Length > 0)
            //{
            //    listConditions.Add(" PublishName like '%" + txtPubName.Text.Trim() + "%' ");
            //    //sb.Append(" and PublishName like '%" + txtPubName.Text.Trim() + "%'");
            //}
            //if (txtPrice.Text.Trim().Length > 0)
            //{
            //    //sb.Append(" and Price =" + double.Parse(txtPrice.Text.Trim()) + "");
            //    listConditions.Add(" Price =" + double.Parse(txtPrice.Text.Trim()) + " ");
            //}

            ////?????
            //if (listConditions.Count > 0)
            //{
            //    sb.Append(" where ");
            //    string[] wheres = listConditions.ToArray();
            //    string wherestring = string.Join(" and ", wheres);

            //    sb.Append(wherestring);
            //    //sb.Append(" " + string.Join(" and ", listConditions.ToArray()) + "  ");
            //}
            //MessageBox.Show(sb.ToString());

            #endregion


            #region 通过带参数的Sql语句来实现模糊查询（多条件查询）

            StringBuilder sb = new StringBuilder("select * from books");
            List<string> listWheres = new List<string>();
            List<SqlParameter> listParams = new List<SqlParameter>();
            if (txtBookName.Text.Trim().Length > 0)
            {
                listWheres.Add(" bookName like @bkName ");
                listParams.Add(new SqlParameter("@bkName", "%" + txtBookName.Text.Trim() + "%"));
            }

            if (txtPubName.Text.Trim().Length > 0)
            {
                listWheres.Add(" PublishName like @pubName ");
                listParams.Add(new SqlParameter("@pubName", "%" + txtPubName.Text.Trim() + "%"));
            }

            if (txtPrice.Text.Trim().Length > 0)
            {
                listWheres.Add(" Price = @price");
                listParams.Add(new SqlParameter("@price", double.Parse(txtPrice.Text.Trim())));
            }
            if (listWheres.Count > 0)
            {
                sb.Append(" where ");
                string wheres = string.Join(" and ", listWheres.ToArray());
                sb.Append(wheres);
            }
            MessageBox.Show(sb.ToString());

            SqlParameter[] pms = listParams.ToArray();

            #endregion

        }
    }
}
