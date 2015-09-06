using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using System.Configuration;
using MongoDB.Driver.Builders;

namespace MongoDbDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = ConfigurationManager.AppSettings["MongoServerSettings"];//获取连接字符串

            MongoServer _server = MongoServer.Create(connStr);//创建mongodb服务对应的对象

            MongoDatabase _db = _server.GetDatabase("TEST");//获取数据库，如果没有，会自动创建一个

            var collectionName = typeof(Customer).Name;//指定集合的名字 

            var collection = _db.GetCollection<Customer>(collectionName);//获取集合，如果集合不存在，那么直接创建一个

            //var demoShit = _db.GetCollection<Customer>("DemoShit");//获取集合，如果集合不存
            //demoShit.Insert(new Customer());


            #region 添加实体

            ////collection.RemoveAll();

            //for (int i = 0; i < 100; i++)
            //{
            //    Customer customer = new Customer();//创建实体
            //    customer.CusId = i;
            //    customer.Name = "shit" + i;
            //    customer.Subtime = DateTime.Now;

            //    customer.Demo = "ddd";
            //    if (i == 10)
            //    {
            //        customer.Demo = "sssss";
            //    }

            //    customer.Shit = DateTime.Now.ToString();
            //    customer.Date = DateTime.Now.ToString();

            //    Order order1 = new Order();
            //    order1.Content = DateTime.Now.ToString();
            //    order1.OrderId = i;
            //    customer.Orders = new List<Order>();
            //    customer.Orders.Add(order1);

            //    Order order2 = new Order();
            //    order2.Content = DateTime.Now.ToString();
            //    order2.OrderId = i;
            //    customer.Orders.Add(order2);
            //    collection.Insert(customer);//将数据插入到 集合里面去
            //}


            //Console.WriteLine(collection.Count());//打印有多少条数据

            //Console.ReadKey();
            #endregion

            #region 修改

            //批量修改  collection.Update();
            //修改一个实体 .Save(entity);

            //查询 FindAll();
            var cus = collection.FindOneAs<Customer>(Query.And(Query.EQ("Demo", "ddd"), Query.GT("CusId", 0)));

            //var data = collection.Find();

            cus.Demo2 = "shihhhhhhhhhhhhhhhhhhhhhhh";
            collection.Save(cus);

            #endregion

            #region 批量删除

            //collection.Remove(Query.GT("CusId", 50));
            #endregion


            //collection.Save();
            //规约模式。
            //collection.Remove( Query.Or(Query.EQ("Demo", "sssss"),Query.EQ("sss","dddd")));

            //collection.Remove(Query.GTE("CusId", 50));

            #region 查询全部
            //var temp = collection.FindAll();//查询全部
            //foreach (var customer1 in temp)
            //{
            //    Console.WriteLine(customer1.Id + "--" + customer1.CusId + "-----" + customer1.Subtime.ToString());
            //}
            #endregion

            #region 条件查询

            ////条件查询
            //var temp = collection.Find(Query.And(Query.EQ("Demo", "sssss"), Query.GT("CusId", 3)));

            //foreach (var customer in temp)
            //{
            //    Console.WriteLine(customer.CusId + "  " + customer.Name);
            //} 
            #endregion

            #region 查询demo

            ////查询demo
            ////var queryDemoData = collection.FindOneById()
            //var queryDemoData = collection.Find(Query.EQ("CusId", 3));
            ////查询使用静态类 Query所在命名空间：using MongoDB.Driver.Builders;
            //foreach (var cus in queryDemoData)
            //{
            //    Console.WriteLine(cus.Name);
            //}

            #endregion

            Console.ReadKey();
        }
    }
}
