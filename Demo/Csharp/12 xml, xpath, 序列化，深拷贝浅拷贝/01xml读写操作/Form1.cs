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

namespace _01xml读写操作
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //======================================读取Xml文件====================================
        private void button1_Click(object sender, EventArgs e)
        {
            #region method 1: 通过XmlDocument将xml递归加载到TreeView上

            //1.加载Xml文件到对象
            XmlDocument document = new XmlDocument();
            //将xml文件加载到dom对象上
            document.Load("rss_sportslq.xml");
            //获得xml的根节点（根元素）
            XmlElement rootElement = document.DocumentElement;
            //先把xml的根元素加载到TreeView上
            TreeNode rootNode = treeView1.Nodes.Add(rootElement.Name);

            //实现递归将xml加载到TreeView中
            LoadToTreeByXmlDocument(rootElement, rootNode.Nodes);


            #endregion

            #region method 2: 通过XDocument将xml文件递归加载到TreeView上
            //1.读取xml文件(XDocument)
            //1.加载xml文件
            XDocument document = XDocument.Load("rss_sportslq.xml");
            //2,先获取根节点
            XElement rootElement = document.Root;

            //3.将xml的根元素加载到TreeView的根节点上
            TreeNode rootNode = treeView1.Nodes.Add(rootElement.Name.ToString());

            //4.递归加载
            LoadToTreeByXDocument(rootElement, rootNode.Nodes);

            #endregion  
        }

        private void LoadToTreeByXmlDocument(XmlElement rootElement, TreeNodeCollection treeNodeCollection)
        {
            //循环rootElement下的所有子元素加载到treeNodeCollection集合中
            foreach (XmlNode item in rootElement.ChildNodes)
            {
                //在继续之前需要判断一下当前节点是什么类型的节点
                if (item.NodeType == XmlNodeType.Element)
                {
                    //如果当前节点是一个“元素”节点，则把当前节点加载到TreeView上
                    TreeNode node = treeNodeCollection.Add(item.Name);
                    //递归调用
                    LoadToTreeByXmlDocument((XmlElement)item, node.Nodes);
                }
                else if (item.NodeType == XmlNodeType.Text | item.NodeType == XmlNodeType.CDATA)
                {
                    treeNodeCollection.Add(item.InnerText);
                }
            }

        }
        
        private void LoadToTreeByXDocument(XElement rootElement, TreeNodeCollection treeNodeCollection)
        {
            //获取根元素rootElement下的所有的子元素
            //rootElement.Elements();
            //遍历rootElement下的所有的子元素（直接子元素）
            foreach (XElement item in rootElement.Elements())
            {
                if (item.Elements().Count() == 0)
                {
                    treeNodeCollection.Add(item.Name.ToString()).Nodes.Add(item.Value);
                }
                else
                {
                    //将当前子元素加载到TreeView的节点集合中
                    TreeNode node = treeNodeCollection.Add(item.Name.ToString());
                    LoadToTreeByXDocument(item, node.Nodes);
                }
            }

        }



        //=====================================写入xml文件===========================================
        private void button2_Click(object sender, EventArgs e)
        {
            #region 通过编程方式实现xml写入
            //1.在内存中构建一个Dom对象
            XmlDocument xmlDoc = new XmlDocument();
            //增加了一个文档说明
            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes");
            xmlDoc.AppendChild(xmlDeclaration);

            //为文档增加一个根元素
            //2.1创建一个根元素
            XmlElement rootElement = xmlDoc.CreateElement("school");
            xmlDoc.AppendChild(rootElement);

            //3.为根元素里面增加子元素,接下来增加元素都要将子元素增加到rootElement元素下
            XmlElement xmlClassElement = xmlDoc.CreateElement("class");

            XmlAttribute attr = xmlDoc.CreateAttribute("id");
            attr.Value = "c01";
            //为class元素增加一个名字叫id的属性
            xmlClassElement.Attributes.Append(attr);

            rootElement.AppendChild(xmlClassElement);


            //4.为class元素下创建一个student节点
            XmlElement xmlStudentElement = xmlDoc.CreateElement("student");
            XmlAttribute attrSid = xmlDoc.CreateAttribute("sid");
            attrSid.Value = "s011";
            xmlStudentElement.Attributes.Append(attrSid);

            xmlClassElement.AppendChild(xmlStudentElement);


            XmlElement xmlNameElement = xmlDoc.CreateElement("name");
            xmlNameElement.InnerText = "黄林";
            //5.向Student节点下增加一个name节点和一个age节点
            xmlStudentElement.AppendChild(xmlNameElement);

            XmlElement xmlAgeElement = xmlDoc.CreateElement("age");
            xmlAgeElement.InnerText = "18";
            xmlStudentElement.AppendChild(xmlAgeElement);

            //2.将该Dom对象写入到xml文件中
            xmlDoc.Save("school.xml");
            MessageBox.Show("ok");

            #endregion

            #region method 1: XmlDocument类，标准的Dom方式。把List集合中的内容写入到一个xml文件中,通过XmlDocument方式写入Xml文件


            List<Person> list = new List<Person>();
            list.Add(new Person() { Name = "黄林", Age = 19, Email = "hl@yahoo.com" });
            list.Add(new Person() { Name = "许正龙", Age = 29, Email = "xzl@yahoo.com" });
            list.Add(new Person() { Name = "何红卫", Age = 39, Email = "hhw@yahoo.com" });
            list.Add(new Person() { Name = "杨硕", Age = 9, Email = "ys@yahoo.com" });


            //1.创建一个Dom对象
            XmlDocument xDoc = new XmlDocument();
            //2.编写文档定义
            XmlDeclaration xmlDec = xDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xDoc.AppendChild(xmlDec);

            //3.编写一个根节点
            XmlElement xmlRoot = xDoc.CreateElement("List");
            xDoc.AppendChild(xmlRoot);

            #region 循环增加子元素Person
            //4.循环创建Person节点
            for (int i = 0; i < list.Count; i++)
            {
                //4.1创建一个Person元素
                XmlElement xmlPerson = xDoc.CreateElement("Person");
                XmlAttribute xmlAttrId = xDoc.CreateAttribute("id");
                xmlAttrId.Value = (i + 1).ToString();
                //将属性增加到Person节点中
                xmlPerson.Attributes.Append(xmlAttrId);

                //4.2在这里向Person节点下增加子节点
                //创建Name
                XmlElement xmlName = xDoc.CreateElement("Name");
                xmlName.InnerText = list[i].Name;
                xmlPerson.AppendChild(xmlName);

                //创建Age
                XmlElement xmlAge = xDoc.CreateElement("Age");
                xmlAge.InnerText = list[i].Age.ToString();
                xmlPerson.AppendChild(xmlAge);

                //创建一个Email节点

                XmlElement xmlEmail = xDoc.CreateElement("Email");
                xmlEmail.InnerText = list[i].Email;
                xmlPerson.AppendChild(xmlEmail);

                //最后把Person加到根节点下
                xmlRoot.AppendChild(xmlPerson);

            }

            #endregion

            //5.将xmlDocument对象写入到文件中
            xDoc.Save("List.xml");

            MessageBox.Show("ok");

            #endregion

            #region prefer method 2：通过XDocument方式写入Xml文件 

            List<Person> list = new List<Person>();
            list.Add(new Person() { Name = "黄林", Age = 19, Email = "hl@yahoo.com" });
            list.Add(new Person() { Name = "许正龙", Age = 29, Email = "xzl@yahoo.com" });
            list.Add(new Person() { Name = "何红卫", Age = 39, Email = "hhw@yahoo.com" });
            list.Add(new Person() { Name = "杨硕", Age = 9, Email = "ys@yahoo.com" });

            //1.创建一个Dom对象
            XDocument xDoc = new XDocument();
            XDeclaration xDec = new XDeclaration("1.0", "utf-8", "no");

            //======================================================
            //设置xml的文档定义
            xDoc.Declaration = xDec;
            //======================================================


            //2.创建根节点
            XElement rootElement = new XElement("List");
            xDoc.Add(rootElement);


            //3.循环List集合创建Person节点
            for (int i = 0; i < list.Count; i++)
            {
                //为每个Person对象创建一个Person元素
                XElement xElementPerson = new XElement("Person");
                xElementPerson.SetAttributeValue("id", (i + 1).ToString());

                xElementPerson.SetElementValue("Name", list[i].Name);
                xElementPerson.SetElementValue("Age", list[i].Age);
                xElementPerson.SetElementValue("Email", list[i].Email);
                rootElement.Add(xElementPerson);
            }

            //4.保存到文件
            xDoc.Save("ListNew.xml");
            MessageBox.Show("ok");


            #endregion

        }





        //===================================获取Xml中的某个节点, 看XPath，百度云网盘搜索=====================================
        private void button3_Click(object sender, EventArgs e)
        {
            //参见03Xpath演示

            #region method 1: 通过XmlDocument快速搜索节点

            //XmlDocument
            XmlDocument document = new XmlDocument();
            //加载Xml文件
            document.Load("rss_sportslq.xml");

            //document.DocumentElement.ChildNodes[0]
            //document.GetElementsByTagName("channel");
            XmlNodeList nodeList = document.GetElementsByTagName("item");
            foreach (XmlNode item in nodeList)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine(nodeList.Count);

            //注意：这里的GetElementById()需要有对应的[文档定义]来支持。
            //XmlElement element = document.GetElementById("I8");
            //Console.WriteLine(element.Name);
            //Console.WriteLine(element.FirstChild.InnerText);

            document.SelectNodes(""); //需要传递xpath表达式（路径表达式）
            #endregion

            #region prefer method 2: 通过XDocument实现快速搜索某个（些）节点
            XDocument document = XDocument.Load("rss_sportslq.xml");

            XElement rootElement = document.Root;
            IEnumerable<XElement> ie = rootElement.Descendants("item").Where(x => Convert.ToInt32(x.Attribute("id").Value) > 10);
            foreach (var item in ie)
            {
                Console.WriteLine(item.Attribute("id").Value);
            }

            rootElement.Descendants("item").Select(x => Convert.ToInt32(x.Attribute("id").Value) > 10);
            #endregion

        }
    }


    public class Person
    {
        public string Name
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }

    }
}
