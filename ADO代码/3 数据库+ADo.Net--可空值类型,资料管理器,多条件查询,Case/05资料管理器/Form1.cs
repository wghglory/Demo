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
            //加载类别到TreeView
            LoadCategoryToTree(treeView1.Nodes, GetCategoriesByParentId(-1));

            //设置TreeView中节点单击的时候显示右键菜单

            AddMouseClickShowContentMenu();
        }

        private void AddMouseClickShowContentMenu()
        {
            //遍历TreeView的每个节点
            SearchNode(treeView1.Nodes);
        }

        private void SearchNode(TreeNodeCollection treeNodeCollection)
        {
            foreach (TreeNode item in treeNodeCollection)
            {
                if (item.Level == 1)
                {
                    item.ContextMenuStrip = contextMenuStrip1;
                }
                SearchNode(item.Nodes);
            }
        }

        //递归加载类别信息到TreeView
        private void LoadCategoryToTree(TreeNodeCollection treeNodeCollection, List<Category> list)
        {
            foreach (Category item in list)
            {
                //把当前节点加到treeNodeCollection集合中
                TreeNode tnode = treeNodeCollection.Add(item.TName);

                //把当前类别的Id记录到Tag中。
                tnode.Tag = item.TId;
                //List<Category> listSub = GetCategoriesByParentId(item.TId);
                //if (listSub.Count == 0)
                //{
                //    tnode.ContextMenuStrip = contextMenuStrip1;
                //}
                LoadCategoryToTree(tnode.Nodes, GetCategoriesByParentId(item.TId));
            }
        }



        private List<Category> GetCategoriesByParentId(int pid)
        {
            List<Category> list = new List<Category>();
            string sql = "select tid,tname from Category where tParentId=@pid";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@pid", pid)))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Category model = new Category();
                        model.TId = reader.GetInt32(0);
                        model.TName = reader.GetString(1);
                        list.Add(model);
                    }
                }
            }
            return list;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                LoadTitleToListBox(e.Node);

            }
        }

        private void LoadTitleToListBox(TreeNode node)
        {

            //获取当前节点对应的类别id
            int categoryId = (int)node.Tag;
            //从文章表中查询dtid为categoryId的所有文章
            List<ContentInfo> list = GetContentByCategoryId(categoryId);
            listBox1.Items.Clear();
            //遍历list集合将文章信息加到Listbox中
            foreach (var item in list)
            {
                listBox1.Items.Add(item);
            }
        }

        private List<ContentInfo> GetContentByCategoryId(int categoryId)
        {
            List<ContentInfo> list = new List<ContentInfo>();
            //select did,dname from ContentInfo where dtid=@categoryId
            using (SqlDataReader reader = SqlHelper.ExecuteReader("select did,dname from ContentInfo where dtid=@categoryId", new SqlParameter("@categoryId", categoryId)))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ContentInfo model = new ContentInfo();
                        model.DId = reader.GetInt32(0);
                        model.DName = reader.GetString(1);
                        list.Add(model);
                    }
                }
            }

            return list;

        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //ListBox的鼠标双击事件
            // e.
            if (listBox1.SelectedItem != null)
            {
                //获取选中项中的文章的Id
                ContentInfo article = listBox1.SelectedItem as ContentInfo;
                int id = article.DId;
                textBox1.Text = GetContentInfoByContentId(id);
            }
        }

        //根据文章Id获取文章内容
        private string GetContentInfoByContentId(int id)
        {
            //string sql = "select dcontent from ContentInfo where did=@id";
            //using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@id", id)))
            //{
            //    if (reader.HasRows)
            //    {
            //        if (reader.Read())
            //        {
            //            return reader.GetString(0);
            //        }
            //    }
            //}
            //return string.Empty;
            string sql = "select dcontent from ContentInfo where did=@id";
            return SqlHelper.ExecuteScalar(sql, new SqlParameter("@id", id)).ToString();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView1.SelectedNode = e.Node;
        }

        private void 导入文章ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                //获取当前选中类别的categoryId
                int categoryId = (int)treeView1.SelectedNode.Tag;
                openFileDialog1.Multiselect = false;
                openFileDialog1.Filter = "txt files (*.txt)|*.txt";
                openFileDialog1.FileName = string.Empty;
                //导入文章
                //1.弹出一个选择路径的一个对话框
                DialogResult result = openFileDialog1.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    //获取用户选择的文件的路径
                    string path = openFileDialog1.FileName;
                    string title = Path.GetFileNameWithoutExtension(path);
                    string content = File.ReadAllText(path, System.Text.Encoding.Default);
                    //执行insert语句将该文章导入到数据库中
                    string sql = "insert into ContentInfo(dtid,dname,dcontent) values(@categoryId,@title,@content)";
                    SqlParameter[] pms = new SqlParameter[] { 
                    new SqlParameter("@categoryId",categoryId),
                    new SqlParameter("@title",title),
                    new SqlParameter("@content",content)
                    };
                    //直接执行插入语句
                    SqlHelper.ExecuteNonQuery(sql, pms);
                }

                //重新加载ListBox
                LoadTitleToListBox(treeView1.SelectedNode);
            }

        }
    }
}
