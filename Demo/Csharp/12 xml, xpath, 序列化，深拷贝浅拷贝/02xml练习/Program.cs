using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace _02xml练习
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 读取订单Xml文件

            XDocument document = XDocument.Load("orders.xml");
            XElement rootElement = document.Root;
            Console.WriteLine("订购人：{0}", rootElement.Element("CustomerName").Value);
            Console.WriteLine("订单编号：{0}", rootElement.Element("OrderNumber").Value);
            Console.WriteLine("订购商品明细信息：");
            foreach (var orderItem in rootElement.Element("Items").Elements("OrderItem"))
            {
                Console.WriteLine("商品名称：{0},订购数量：{1}", orderItem.Attribute("Name").Value, orderItem.Attribute("Count").Value);
            }
            Console.ReadKey();

            #endregion

            #region 解析 ytbank.xml 文件

            XDocument document = XDocument.Load("ytbank.xml");
            //获取根节点
            XElement rootElement = document.Root;
            //获取根节点下的所有的MSG节点
            foreach (XElement itemMSG in rootElement.Elements("MSG"))
            {
                //再获取每个MSG节点下的子节点
                foreach (XElement item in itemMSG.Elements())
                {
                    Console.WriteLine("{0}:{1}", item.Name, item.Attribute("val").Value);
                }
                Console.WriteLine("=============================================");

            }
            Console.ReadKey();

            #endregion
        }
    }
}
