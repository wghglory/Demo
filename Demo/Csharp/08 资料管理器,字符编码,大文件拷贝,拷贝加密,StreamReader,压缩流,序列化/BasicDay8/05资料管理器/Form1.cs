using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace _05资料管理器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //1加载路劲下的内容
            string path = "demo";

            LoadData(path, treeView1.Nodes);
        }

        private void LoadData(string path, TreeNodeCollection treeNodeCollection)
        {

            //1.获取path下的所有文件夹
            string[] dirs = Directory.GetDirectories(path);
            foreach (var item in dirs)
            {
                TreeNode tnode = treeNodeCollection.Add(Path.GetFileName(item));
                LoadData(item, tnode.Nodes);
            }

            //2.获取path下的所有的文本文件
            string[] files = Directory.GetFiles(path, "*.txt");
            foreach (var item in files)
            {
                TreeNode node = treeNodeCollection.Add(Path.GetFileName(item));
                node.Tag = item;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(treeView1.SelectedNode.FullPath);
        }

        //在节点的双击事件中
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)//表示是文件节点
            {
                textBox1.Text = File.ReadAllText(e.Node.Tag.ToString(), Encoding.Default);
            }
        }
    }
}
