using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Collections;

namespace _03Xml操作
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //向xml中增加一条记录。
            //1.加载xml到Dom对象
            XDocument document = XDocument.Load("UserData.xml");
            XElement rootElement = document.Root;
            string id = txtId.Text.Trim();
            string name = txtName.Text.Trim();
            string pwd = txtPwd.Text;
            //2.编辑修改添加Dom对象
            //增加之前要先判断当前的xml文件中是否存在一个Id为用户输入的Id的元素
            IEnumerable<XElement> users = rootElement.Elements("user").Where(x => x.Attribute("id").Value == id);
            if (users.Count() > 0)
            {
                MessageBox.Show("该用户已经存在");
            }
            else
            {
                //添加该用户
                XElement userElement = new XElement("user");
                userElement.SetAttributeValue("id", id);
                userElement.SetElementValue("name", name);
                userElement.SetElementValue("password", pwd);
                rootElement.Add(userElement);
                //3.将Dom对象保存到xml文件。
                document.Save("UserData.xml");
                MessageBox.Show("ok");
            }
        }
        /// <summary>
        /// 加载xml文件到ListView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            LoadUsers();

        }

        private void LoadUsers()
        {
            listView1.Items.Clear();
            //1.加载Xml到Dom
            XDocument document = XDocument.Load("UserData.xml");

            //2.循环遍历每个user节点加载到ListView中。
            foreach (XElement userItem in document.Root.Elements("user"))
            {
                string id = userItem.Attribute("id").Value;
                string name = userItem.Element("name").Value;
                string password = userItem.Element("password").Value;

                //每次遇到一个user节点都要在ListView中增加一项
                //ListViewItem
                ListViewItem lvItem = new ListViewItem(id);
                lvItem.SubItems.Add(name);
                lvItem.SubItems.Add(password);
                listView1.Items.Add(lvItem);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ColumnHeader ch = new ColumnHeader();
            //ch.Text = "编号";
            //listView1.Columns.Add(ch);
            //listView1.View = View.Details;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //根据Id来删除某个数据项
            if (listView1.SelectedItems.Count > 0)
            {
                //获取当前选中项
                ListViewItem lvItem = listView1.SelectedItems[0];
                string id = lvItem.SubItems[0].Text;

                //在xml中找到当前选中的这个user元素
                XDocument document = XDocument.Load("UserData.xml");
                IEnumerable<XElement> users = document.Descendants("user").Where(x => x.Attribute("id").Value == id);
                if (users.Count() > 0)
                {
                    //从xml中删除该元素 
                    users.First().Remove();
                }
                document.Save("UserData.xml");
                LoadUsers();

            }
            else
            {
                MessageBox.Show("ListView没有选中项.");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem lvItem = listView1.SelectedItems[0];
                string id = lvItem.SubItems[0].Text;
                string name = lvItem.SubItems[1].Text;
                string pwd = lvItem.SubItems[2].Text;


                txtEditId.Text = id;
                txtEditName.Text = name;
                txtEditPassword.Text = pwd;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //编辑节点
            //1.在整个xml中搜索id为用户选择的id
            XDocument document = XDocument.Load("UserData.xml");
            IEnumerable<XElement> users = document.Descendants("user").Where(x => x.Attribute("id").Value == txtEditId.Text.Trim());
            if (users.Count() > 0)
            {
                users.First().Element("name").Value = txtEditName.Text.Trim();
                users.First().Element("password").Value = txtEditPassword.Text.Trim();
                document.Save("UserData.xml");
                LoadUsers();
                //users.ElementAt(0)
            }
            else
            {
                MessageBox.Show("删除失败，没有找到该用户。");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //登录
            //获取用户的输入
            string loginId = txtLoginId.Text.Trim();
            string loginPwd = txtLoginPwd.Text;

            //验证登录
            XDocument document = XDocument.Load("UserData.xml");
            IEnumerable<XElement> users = document.Descendants("user").Where(x =>
            {
                return x.Element("name").Value == loginId && x.Element("password").Value == loginPwd;
            });
            if (users.Count() > 0)
            {
                MessageBox.Show("登录成功！");
            }
            else
            {
                MessageBox.Show("失败！");
            }
        }
    }
}
