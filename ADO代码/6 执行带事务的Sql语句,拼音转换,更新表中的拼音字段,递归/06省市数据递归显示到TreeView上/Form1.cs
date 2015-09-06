using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Itcast.Cn;
using System.Data.SqlClient;

namespace _06省市数据递归显示到TreeView上
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //加载
        private void button1_Click(object sender, EventArgs e)
        {
            //treeView1.Nodes
            LoadData(treeView1.Nodes, GetAreaByParent(0));
        }
        private void LoadData(TreeNodeCollection treeNodeCollection, List<TblArea> list)
        {
            foreach (TblArea item in list)
            {
                TreeNode node = treeNodeCollection.Add(item.AreaName);
                node.Tag = item.AreaId;
                LoadData(node.Nodes, GetAreaByParent(item.AreaId));
            }
        }
        //根据类别的父Id加载子城市
        public List<TblArea> GetAreaByParent(int pid)
        {
            List<TblArea> list = new List<TblArea>();
            string sql = "select AreaId,AreaName from TblArea where AreaPid=@pid";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text, new SqlParameter("@pid", pid)))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TblArea model = new TblArea();
                        model.AreaId = reader.GetInt32(0);
                        model.AreaName = reader.GetString(1);
                        list.Add(model);
                    }
                }
            }
            return list;
        }


    }
}
