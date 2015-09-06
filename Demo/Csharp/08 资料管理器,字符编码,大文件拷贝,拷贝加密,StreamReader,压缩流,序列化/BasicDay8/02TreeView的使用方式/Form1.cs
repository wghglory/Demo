using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _02TreeView的使用方式
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //清空TreeView的节点集合
            tvList.Nodes.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //1.获取用户的输入
            string txt = txtNodeName.Text.Trim();
            //Add()方法的返回值就是刚刚增加的节点
            TreeNode node = tvList.Nodes.Add(txt);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //获取当前用户选择的节点
            if (tvList.SelectedNode != null)//表示有选中节点
            {
                MessageBox.Show(tvList.SelectedNode.Text);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //1.获取选中节点
            TreeNode node = tvList.SelectedNode;
            if (node != null)
            {
                node.Nodes.Add(txtNodeName.Text.Trim());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //删除选中节点
            //"自杀"
            tvList.SelectedNode.Remove();
            


            //tvList.xxxx
            //TreeNode node;
           // node.

            //tvList.Nodes.
        }
    }
}
