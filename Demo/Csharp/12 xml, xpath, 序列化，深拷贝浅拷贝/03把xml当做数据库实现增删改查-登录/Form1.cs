using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace _03把xml当做数据库实现增删改查_登录
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            listView1.Items.Clear();
            //1.读取Xml文件
            XmlDocument document = new XmlDocument();
            document.Load("UserData.xml");
            XmlNodeList nodeList = document.SelectNodes("/Users/user");
            //遍历选择到的节点加载到ListView中
            foreach (XmlNode userNode in nodeList)
            {
                //创建一个ListViewItem的一个项
                ListViewItem lvItem = new ListViewItem(userNode.Attributes["id"].Value);
                //获取name节点并绑定
                lvItem.SubItems.Add(userNode.SelectSingleNode("name").InnerText);
                lvItem.SubItems.Add(userNode.SelectSingleNode("password").InnerText);
                listView1.Items.Add(lvItem);
            }
        }

        //增加一个用户
        private void button1_Click(object sender, EventArgs e)
        {
            //====================================XDocument方法，用这个好================================================
            //XDocument document = XDocument.Load("UserData.xml");
            //document.Root.Add();
            //document.Save();

            //==================================XmlDocument方法，这里为了练习SelectNode(xpath)=========================
            string id = txtId.Text.Trim();
            string name = txtLoginId.Text.Trim();
            string password = txtPwd.Text;
            XmlDocument document = new XmlDocument();
            document.Load("UserData.xml");
            XmlElement root = document.DocumentElement;
            XmlElement userElement = document.CreateElement("user");
            if (document.SelectNodes("/Users/user[@id='" + id + "']").Count > 0)
            {
                MessageBox.Show("id重复！");
            }
            else
            {
                userElement.SetAttribute("id", id);
                XmlElement nameElement = document.CreateElement("name");
                nameElement.InnerText = name;

                XmlElement passwordElement = document.CreateElement("password");
                passwordElement.InnerText = password;
                userElement.AppendChild(nameElement);
                userElement.AppendChild(passwordElement);

                root.AppendChild(userElement);
                document.Save("UserData.xml");
                LoadUsers();
                MessageBox.Show("ok");
            }


        }

        //删除某个节点
        private void button3_Click(object sender, EventArgs e)
        {
            //====================================XDocument方法，用这个好================================================
            //string id = "002";
            //XDocument document = XDocument.Load("UserData.xml");
            //XElement userElement = document.Root.Elements("user").Single(element => element.Attribute("id").Value == id);
            //userElement.Remove();
            //document.Save("UserData.xml");

            //==================================XmlDocument方法，这里为了练习SelectNode(xpath)=========================
            XmlDocument document = new XmlDocument();
            document.Load("UserData.xml");
            if (listView1.SelectedItems.Count > 0)
            {
                //获取选中行的id
                string id = listView1.SelectedItems[0].SubItems[0].Text;

                //从xml中找到id等于用户选择的项的id的user标签
                XmlNode node = document.SelectSingleNode("/Users/user[@id='" + id + "']");
                if (node != null)
                {
                    //从文档的根节点开始删除当前选中的节点
                    document.DocumentElement.RemoveChild(node);
                    document.Save("UserData.xml");
                    LoadUsers();
                }
            }

        }


        //ListView的选中项改变事件
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem lv = listView1.SelectedItems[0];
                txtEditId.Text = lv.SubItems[0].Text;
                txtEditLoginId.Text = lv.SubItems[1].Text;
                txtEditPassword.Text = lv.SubItems[2].Text;
            }
        }

        //修改某个节点
        private void button2_Click(object sender, EventArgs e)
        {
            XmlDocument document = new XmlDocument();
            document.Load("UserData.xml");
            //根据用户选择的id,先在UserData.xml中找到对应的user节点
            XmlNode userNode = document.SelectSingleNode("/Users/user[@id='" + txtEditId.Text.Trim() + "']");
            userNode.SelectSingleNode("name").InnerText = txtEditLoginId.Text.Trim();
            userNode.SelectSingleNode("password").InnerText = txtEditPassword.Text.Trim();
            document.Save("UserData.xml");
            LoadUsers();
        }


        //验证用户登录
        private void button4_Click(object sender, EventArgs e)
        {
            string uid = txtLoginUserName.Text.Trim();
            string pwd = txtLoginUserPwd.Text;
            XmlDocument document = new XmlDocument();
            document.Load("Userdata.xml");
            XmlNode node = document.SelectSingleNode("/Users/user/name[.='" + uid + "']");   //name[.="guanghui"]找到所有值为guagnhui的name节点
            if (node != null)
            {
                if (node.NextSibling.InnerText == pwd)
                {
                    MessageBox.Show("登录成功！");
                }
                else
                {
                    MessageBox.Show("密码错误！");
                }
            }
            else
            {
                MessageBox.Show("用户名不存在！");
            }
        }
    }
}
