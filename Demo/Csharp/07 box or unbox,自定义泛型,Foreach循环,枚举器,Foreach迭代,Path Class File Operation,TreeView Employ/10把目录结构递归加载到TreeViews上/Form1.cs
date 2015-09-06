using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace _10把目录结构递归加载到TreeViews上
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region 加载一级目录

            //string path = @"C:\DRIVERS\WIN\DISPLAY3";

            ////1.把指定目录下的所子目录加载到TreeView上。
            //string[] dirs = Directory.GetDirectories(path);
            //foreach (string dir in dirs)
            //{
            //    treeView1.Nodes.Add(Path.GetFileName(dir));
            //}

            ////2.把指定目录下的所有子文件加载到TreeView上。
            //string[] files = Directory.GetFiles(path);
            //foreach (string item in files)
            //{
            //    treeView1.Nodes.Add(Path.GetFileName(item));
            //}
            #endregion

            #region 递归加载

            string path = @"C:\DRIVERS\WIN\DISPLAY3";

            LoadData(path, treeView1.Nodes);

            #endregion

        }

        private void LoadData(string path, TreeNodeCollection treeNodeCollection)
        {
            //1.获取子目录并加载
            string[] dirs = Directory.GetDirectories(path);
            foreach (string item in dirs)
            {
                TreeNode node = treeNodeCollection.Add(Path.GetFileName(item));
                LoadData(item, node.Nodes);
            }

            //2.获取子文件并加载
            string[] files = Directory.GetFiles(path);
            foreach (string item in files)
            {
                treeNodeCollection.Add(Path.GetFileName(item));
            }
        }
    }
}
