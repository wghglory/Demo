using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _09TreeView控件使用
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //清空所有节点
        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
        }


        //添加根节点
        private void button2_Click(object sender, EventArgs e)
        {
            string nodeName = txtName.Text.Trim();

            //添加根节点
            //TreeNode就表示一个节点对象，而返回值正是刚刚增加的那个节点。
            TreeNode node = treeView1.Nodes.Add(nodeName);
        }

        //添加子节点
        private void button3_Click(object sender, EventArgs e)
        {
            string nodeName = txtName.Text.Trim();

            //获取用户选中节点
            TreeNode node = treeView1.SelectedNode;
            if (node != null)
            {
                node.Nodes.Add(nodeName);
            }
            else
            {
                //表示用户没有选中任何节点！
                MessageBox.Show("请选择节点！");
            }
        }

        //获取选中节点的文本
        private void button4_Click(object sender, EventArgs e)
        {
            //获取用户选中的节点
            if (treeView1.SelectedNode != null)
            {
                MessageBox.Show(treeView1.SelectedNode.Text);
            }
        }


        //删除某个节点
        private void button5_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                treeView1.SelectedNode.Remove();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //展开选中节点
            if (treeView1.SelectedNode != null)
            {
                // treeView1.SelectedNode.Expand();
                treeView1.SelectedNode.ExpandAll();
            }
        }

        //关闭选中节点
        private void button7_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                treeView1.SelectedNode.Collapse();
            }
        }

        //private void button8_Click(object sender, EventArgs e)
        //{
        //    treeView1.Nodes[1].Nodes[2].Nodes[0].EnsureVisible();
        //    treeView1.Nodes[1].Nodes[2].Nodes[0].BackColor = Color.Red;
        //}
    }
}
