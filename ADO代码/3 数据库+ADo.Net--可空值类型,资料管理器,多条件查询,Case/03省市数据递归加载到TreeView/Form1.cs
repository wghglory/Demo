using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using _02省市联动;

namespace _03省市数据递归加载到TreeView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////1.把所有的省份及直辖市加载到TreeView的根节点上。
            //List<Area> listProvince = GetSubItemByParentId(0);
            //foreach (Area item in listProvince)
            //{
            //    treeView1.Nodes.Add(item.AreaName);
            //}


            //递归将省市加载到TreeView中
            LoadDataToTree(treeView1.Nodes, 0);
        }
        //递归加载到TreeView
        private void LoadDataToTree(TreeNodeCollection treeNodeCollection, int pid)
        {
            //1.根据指定的pid获取该城市下的子城市
            List<Area> listCity = GetSubItemByParentId(pid);

            //2.遍历将获取到的数据绑定到treeNodeCollection节点集合中
            foreach (var item in listCity)
            {
                //返回刚刚增加的这个节点
                TreeNode node = treeNodeCollection.Add(item.AreaName);
                LoadDataToTree(node.Nodes, item.Areaid);
            }
        }

        //先封装一个方法，根据父Id查询下面的所有子项
        private List<Area> GetSubItemByParentId(int pid)
        {
            List<Area> list = new List<Area>();
            string sql = "select * from TblArea where areaPid=@pid";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@pid", pid)))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Area model = new Area();
                        model.Areaid = reader.GetInt32(0);
                        model.AreaName = reader.GetString(1);
                        model.AreaPid = reader.GetInt32(2);
                        list.Add(model);

                        ///...........不要直接在这里递归，一定要先把数据获取到一个集合中，然后再递归
                        /////否则会打开很多个连接。
                    }
                }
            }

            return list;
        }
    }
}
