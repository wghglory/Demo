using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Scripts.BLL;

namespace Scripts.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        T_ScriptsBll bll = new T_ScriptsBll();
        private void Form1_Load(object sender, EventArgs e)
        {
            //窗体加载的时候把数据加载到TreeView上。
            LoadData(treeView1.Nodes, bll.GetScriptsByParentId(0));
        }

        private void LoadData(TreeNodeCollection treeNodeCollection, List<Model.T_Scripts> list)
        {
            foreach (var item in list)
            {
                TreeNode node = treeNodeCollection.Add(item.ScriptTitle);
                node.Tag = item.ScriptId;
                LoadData(node.Nodes, bll.GetScriptsByParentId(item.ScriptId));
            }
        }

        private void UpdateTreeView()
        {
            treeView1.Nodes.Clear();
            //窗体加载的时候把数据加载到TreeView上。
            LoadData(treeView1.Nodes, bll.GetScriptsByParentId(0));
        }

        //节点被选中事件
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //1.获取当前选中节点的Id
            if (treeView1.SelectedNode != null)
            {
                int scriptId = (int)treeView1.SelectedNode.Tag;
                T_ScriptsBll bll = new T_ScriptsBll();
                textBox1.Text = bll.GetScriptMessageByScriptId(scriptId);
            }
        }

        //增加一级类别
        private void 增加一级节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddScripts frm = new frmAddScripts(0, UpdateTreeView);
            frm.Show();
        }

        private void 增加子节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //1.先判断当前是否有选中节点
            if (treeView1.SelectedNode != null)
            {
                //增加子类别
                frmAddScripts frm = new frmAddScripts((int)treeView1.SelectedNode.Tag, UpdateTreeView);
                frm.Show();
            }
            else
            {
                MessageBox.Show("请选择类别");
            }


        }

        //删除选中的节点及其所有子节点
        private void 删除选中节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //1.获取用户选择的节点
            if (treeView1.SelectedNode != null)
            {
                //2.获取ScriptId
                int scriptId = (int)treeView1.SelectedNode.Tag;
                T_ScriptsBll bll = new T_ScriptsBll();
                bll.DeleteScriptsDiGui(scriptId);
                //更新TreeView
                treeView1.SelectedNode.Remove();

            }
            else
            {
                MessageBox.Show("请选择节点！");
            }
        }


        //编辑当前选中节点
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //1.获取当前选中节点
            if (treeView1.SelectedNode != null)
            {
                //2.获取当前选择节点的ScriptId
                int scriptId = (int)treeView1.SelectedNode.Tag;
                frmEdit frm = new frmEdit(scriptId, treeView1.SelectedNode.Text, textBox1.Text.Trim());
                DialogResult result = frm.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    //表示用户成功更新了当前节点，刷新数据

                    treeView1.SelectedNode.Text = frm.Title;
                    textBox1.Text = frm.Message;
                }
                else if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    //什么都不用做。
                }

            }
            else
            {
                MessageBox.Show("请选择");
            }


            //Console.WriteLine(result);
        }


        //实现搜索功能
        private void 搜索ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //遍历当前TreeView中的每个节点，获取每个节点的Text值，判断当前的Text字符串中是否包含了用户输入的内容
            //1.循环遍历每个TreeView的节点
            SearchText(treeView1.Nodes, tsTextSearch.Text.Trim());
        }

        private void SearchText(TreeNodeCollection treeNodeCollection, string p)
        {
            foreach (TreeNode node in treeNodeCollection)
            {
                node.BackColor = Color.White;
                //判断当前节点中是否包含指定的字符串p
                if (node.Text.Contains(p))
                {
                    node.BackColor = Color.Red;
                    node.EnsureVisible();
                }
                //
                //无论当前节点是否包含指定的字符串，都要继续遍历当前节点的子节点
                SearchText(node.Nodes, p);
            }
        }
    }
}
