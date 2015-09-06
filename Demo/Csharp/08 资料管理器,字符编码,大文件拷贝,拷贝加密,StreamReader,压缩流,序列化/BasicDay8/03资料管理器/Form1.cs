using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace _03资料管理器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //读取文件路径加载TreeView
            string path = "资料";
            TreeNode rootNode = treeView1.Nodes.Add(path);
            path = Path.GetFullPath(path);
            LoadToTree(path, rootNode.Nodes);

            //DirectoryInfo info;
            //info.EnumerateFileSystemInfos(
        }

        private void LoadToTree(string path, TreeNodeCollection treeNodeCollection)
        {
            //1.加载所有目录
            string[] dirs = Directory.GetDirectories(path);
            foreach (var item in dirs)
            {
                TreeNode node = treeNodeCollection.Add(Path.GetFileName(item));
                //目录不需要存储它的完整路径。
                //node.Tag = item;
                LoadToTree(item, node.Nodes);
            }

            //2.加载所有文本文件，*.txt
            string[] files = Directory.GetFiles(path, "*.txt");
            foreach (var item in files)
            {
                TreeNode node = treeNodeCollection.Add(Path.GetFileName(item));
                node.Tag = item;
            }
        }


        //选择TreeView的节点双击事件
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                //证明当前节点是个文件节点
                textBox1.Text = File.ReadAllText(e.Node.Tag.ToString(), Encoding.Default);
            }
        }


        //搜索节点
        private void button1_Click(object sender, EventArgs e)
        {
            string nodeName = txtNodeName.Text.Trim();
            SearchNode(nodeName, treeView1.Nodes);
        }

        private void SearchNode(string nodeName, TreeNodeCollection treeNodeCollection)
        {
            foreach (TreeNode item in treeNodeCollection)
            {
                if (item.Text.Trim().Contains(nodeName))
                {
                    item.BackColor = Color.Red;

                    //让当前节点可见
                    item.EnsureVisible();
                }
                else
                {
                    item.BackColor = Color.White;
                }

                //实现递归
                SearchNode(nodeName, item.Nodes);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = Path.GetFullPath(this.treeView1.SelectedNode.FullPath);

            //Path.GetFullPath("");
            MessageBox.Show(path);

            //获取当前Exe的绝对路径：
            //Assembly.GetExecutingAssembly().Location
            //Environment.CurrentDirectory
        }
    }
}
