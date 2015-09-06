using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _01作业
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Dictionary<string, Person> dict = new Dictionary<string, Person>();

        private void button1_Click(object sender, EventArgs e)
        {
            //创建一个Person对象
            Person model = new Person(txtName.Text.Trim(), int.Parse(txtAge.Text.Trim()), txtEmail.Text.Trim(), txtId.Text.Trim());

            //将该对象加入到集合中。
            if (dict.ContainsKey(model.Id))
            {
                //如果集合中已经包含了该Id,则修改而不是增加
                dict[model.Id] = model;

                        //不好用。。。。修改一下ListBox中的值。
                        //Person currentPerson = listBox1.SelectedItem as Person;
                        //if (currentPerson != null)
                        //{
                        //    currentPerson.Name = model.Name;
                        //    currentPerson.Id = model.Id;
                        //    currentPerson.Age = model.Age;
                        //    currentPerson.Email = model.Email;
                        //}
                        //listBox1.Update();
                        //listBox1.SelectedItem = model;

                //这样可以直接改变ListBox上的显示文字
                listBox1.Items[listBox1.SelectedIndex] = model;
            }
            else
            {
                dict.Add(model.Id, model);
                //将对象加到集合中后，要让ListBox中显示该数据
                //其实就是向ListBox中也增加一条记录
                listBox1.Items.Add(model);
            }
            ClearTextBox();

        }

        private void ClearTextBox()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = string.Empty;
                }
            }
        }

        //点击退出按钮
        private void button2_Click(object sender, EventArgs e)
        {
            //ExitSave();
            //Console.ReadKey();
            this.Close();
        }

        private void ExitSave()
        {
            //1.将Dict集合中的内容保存到xml文件中
            //xml操作
            //1.创建一个XDocument对象
            XDocument document = new XDocument();
            //2.加入一个根节点
            XElement rootElement = new XElement("PersonList");
            document.Add(rootElement);
            //3.向根节点中增加Person节点,需要遍历dict集合
            foreach (KeyValuePair<string, Person> item in dict)
            {
                //4.创建一个Person节点
                XElement personElement = new XElement("Person");
                personElement.SetElementValue("Id", item.Value.Id);
                personElement.SetElementValue("Name", item.Value.Name);
                personElement.SetElementValue("Age", item.Value.Age);
                personElement.SetElementValue("Email", item.Value.Email);


                //将Person节点加到根节点下
                rootElement.Add(personElement);
            }

            //5.将xml对象写入到文件中。
            document.Save("PersonList.xml");

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExitSave();
            //e.Cancel = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //将磁盘上的xml文件读取出来存到dict集合当中并且初始化Listbox中的数据
            XDocument document = XDocument.Load("PersonList.xml");
            //获取根节点
            XElement rootElement = document.Root;

            //遍历根节点下的所有子节点
            foreach (XElement item in rootElement.Elements("Person"))
            {
                //创建Person对象

                string id = item.Element("Id").Value;
                string name = item.Element("Name").Value;
                string age = item.Element("Age").Value;
                string email = item.Element("Email").Value;
                Person model = new Person(name, int.Parse(age), email, id);
                if (!dict.ContainsKey(model.Id))
                {
                    dict.Add(model.Id, model);
                    //同时把数据也加载到ListBox中。
                    listBox1.Items.Add(model);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取当前被选中的项
            if (listBox1.SelectedItem != null)
            {
                Person p = listBox1.SelectedItem as Person;
                if (p != null)
                {
                    txtId.Text = p.Id;
                    txtName.Text = p.Name;
                    txtAge.Text = p.Age.ToString();
                    txtEmail.Text = p.Email;
                }
            }
        }

    }
}
