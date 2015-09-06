using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace _03将指定目录下的所有文件与文件夹显示到TreeView上
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = txtPath.Text.Trim();

            //假设path是我们要找的根路径，我们需要将根路径下的内容都加到TreeView的根节点中（即：treeView的Nodes集合）
            LoadInfo(path, treeView1.Nodes);


        }
        //方法内部自己调用自己，我们就叫做：“递归”
        private void LoadInfo(string path, TreeNodeCollection collection)
        {
            //2.获取指定目录下的所有的（目录）文件夹
            string[] dirs = Directory.GetDirectories(path);
            //遍历将每个目录都加载到TreeView上
            foreach (var item in dirs)
            {
                //通过Path.GetFileName()获取文件名部分
                //TreeNode tnode = treeView1.Nodes.Add(Path.GetFileName(item));
                TreeNode tnode = collection.Add(Path.GetFileName(item));

                //找item（当前遍历的目录）
                LoadInfo(item, tnode.Nodes);
            }



            //1.获取指定目录下的所有的文件
            string[] files = Directory.GetFiles(path);
            //1.1将每个文件都遍历显示到TreeView上。
            foreach (string item in files)
            {
                //通过Path.GetFileName()获取文件名部分
               // treeView1.Nodes.Add(Path.GetFileName(item));
                collection.Add(Path.GetFileName(item));
            }
        }
    }
}
