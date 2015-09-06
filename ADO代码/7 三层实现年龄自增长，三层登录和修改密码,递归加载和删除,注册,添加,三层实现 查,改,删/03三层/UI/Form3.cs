using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _01三层.BLL;
using _01三层.Model;

namespace _01三层.UI
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        TblAreaBll bll = new TblAreaBll();
        private void button1_Click(object sender, EventArgs e)
        {
            LoadDataToTree(treeView1.Nodes, bll.GetAreasByParentId(0));
        }

        private void LoadDataToTree(TreeNodeCollection treeNodeCollection, List<Model.TblArea> list)
        {
            //将list中的数据绑定到treeNodeCollection集合上
            foreach (TblArea item in list)
            {
                TreeNode node = treeNodeCollection.Add(item.AreaName);
                node.Tag = item.AreaId;
                LoadDataToTree(node.Nodes, bll.GetAreasByParentId(item.AreaId));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //1.获取用户选中的节点

            TreeNode node = treeView1.SelectedNode;
            if (node != null)
            {
                //2.获取选中节点的Id
                int autoId = (int)node.Tag;
                TblAreaBll bll = new TblAreaBll();
                bll.DeleteAreaDiGui(autoId);
                //将界面上的这个元素删除掉
                node.Remove();
                //MessageBox.Show(autoId.ToString());
            }
            else
            {
                MessageBox.Show("请选中节点！");
            }
        }
    }
}
