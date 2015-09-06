using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EF_ModelFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 增加，一对多关系处理

            //第一步：创建访问数据库的统一入口。创建EF的上下文。
            DataModelContainer dbContext = new DataModelContainer();

            ////第二步：操作实体
            //User user1 = new User();
            //user1.Name = "wangdong";
            //user1.Phone = "1729477";
            //user1.Address = "china";

            ////第三步：告诉上下文咱们对实体做添加操作
            //dbContext.User.Add(user1);    //User表增加user1

            //Order order1 = new Order();
            //order1.OrderTime = DateTime.Now;
            //dbContext.Entry(order1).State = System.Data.Entity.EntityState.Added;

            //Order order2 = new Order();
            //order2.OrderTime = DateTime.Now.AddDays(-6);
            //dbContext.Entry(order2).State = EntityState.Added; //order2标记为增加

            ////处理关系：从order出发
            //order1.UserId = user1.Id;  //method 1 to add association
            //order2.User = user1;   //method 2： use navigation property to add association

            ////第四步：告诉上下文去保存
            //dbContext.SaveChanges();   //不能一次操作2次user/order

            ////============================================================ 
            //User user2 = new User();
            //user2.Name = "suixiulan";
            //user2.Phone = "231818511";
            //user2.Address = "changxingjie";
            //dbContext.Entry(user2).State = EntityState.Added;

            //Order order3 = new Order();
            //order3.OrderTime = DateTime.Now.AddDays(6);
            //dbContext.Entry(order3).State = EntityState.Added;

            //Order order4 = new Order();
            //order4.OrderTime = DateTime.Now.AddDays(12);
            //dbContext.Order.Add(order4);

            ////从user出发添加关系: 利用导航属性
            //user2.Order.Add(order3);
            //user2.Order.Add(order4);

            //dbContext.SaveChanges();

            #endregion

            #region 多对多关系

            //Student stu1 = new Student();
            //stu1.Name = "GUANGHUI";
            //dbContext.Student.Add(stu1);

            //Student stu2 = new Student();
            //stu2.Name = "yuhan";
            //dbContext.Student.Add(stu2);

            //Class c1 = new Class();
            //c1.Name = "c#";
            //dbContext.Class.Add(c1);

            //Class c2 = new Class();
            //c2.Name = "jquery";
            //dbContext.Class.Add(c2);

            //Class c3 = new Class();
            //c3.Name = "asp.net";
            //dbContext.Class.Add(c3);

            ////处理关系
            //stu1.Class.Add(c1);
            //stu1.Class.Add(c2);

            //stu2.Class.Add(c2);
            //stu2.Class.Add(c3);

            //dbContext.SaveChanges();

            #endregion

            #region 修改、删除
            ////An unhandled exception of type 'System.Data.Entity.Infrastructure.DbUpdateException' occurred in EntityFramework.dll
            ////note:由于foreign key限制，可以修改数据库table，右击design,右击关系，delete rule cascade. 
            //User user_delete = new User();
            //user_delete.Id = 1;
            //dbContext.Entry(user_delete).State = EntityState.Deleted;
            //dbContext.SaveChanges();

            ////如果是自己创建的实体想要删除，用EntityState.Deleted.
            ////查询出来的实体想要删除可以用下面remove。查询出来是EntityState.Unchanged
            ////查询出来的实体（默认就被EF跟踪），直接修改属性，Savechanges自动把实体更新数据库
            //User itemToRemove = dbContext.User.SingleOrDefault(x => x.Id == 2);
            //User lambdaRemove = dbContext.User.Remove(itemToRemove);
            //dbContext.SaveChanges();




            ////注意如果要更新部分fields,如name, address. phone不更新,但是要随便赋值。。。
            //User user_edit = new User() { Id = 2, Name = "yuhan", Address = "miami2", Phone = "213123" };
            //using (var dbcontext = new DataModelContainer())
            //{
            //    dbcontext.User.Attach(user_edit);

            //    dbcontext.Entry(user_edit).Property(e => e.Name).IsModified = true;
            //    dbcontext.Entry(user_edit).Property(e => e.Address).IsModified = true;

            //    dbcontext.SaveChanges();
            //}

            ////更新全部
            //User user_edit = new User() { Id = 2, Name = "yuhan", Address = "miami", Phone = "7873427" };
            //dbContext.Entry(user_edit).State = EntityState.Modified;
            //dbContext.SaveChanges();

            #endregion

            #region 简单查询，延迟加载

            //延迟加载，只有遍历的时候才查询数据。
            //数据库过滤后放到内存中
            IQueryable<Order> data = from o in dbContext.Order
                                     where o.Id < 10
                                     select o;
            //var data2 = new List<Order>();
            //foreach (var o in dbContext.Order)
            //{
            //    if(o.Id<10)
            //    {
            //        data2.Add(o);
            //    }
            //}

            foreach (var o in data)
            {
                Console.WriteLine(o.Id + "====" + o.OrderTime);
            }

            Console.ReadKey();

            #endregion

            //第一种延迟加载：IQueryable集合 用到的时候才去真正的加载数据。
            //第二种延迟加载：有导航属性的。在使用导航属性的时候，不需要先查询，直接用就行了。
            //EF会自动的判断导航属性里面是否有值。如果有值那么直接返回，没有那就帮助我们去查询。

            #region Join复杂查询，分页。ef不需要join就能实现
            //用了导航属性就不需要查询Order了。
            var userinfos = (from u in dbContext.User
                             where u.Id < 100
                             orderby u.Id descending
                             select u).Skip(5 * (2 - 1)).Take(5).ToList();//如果没有数据，那么返回的集合的Count属性是0.

            foreach (var u in userinfos)
            {
                foreach (var o in u.Order)
                {
                    Console.WriteLine(u.Name + "===" + u.Phone + "===" + o.OrderTime);
                }
            }

            Console.ReadKey();

            #endregion

            #region lambda查询, 分页
           
            User lambdaFind = dbContext.User.Find(2);  //params 多个id联合主键。一般不用联合主键
            //EF5.0之后做了优化：如果数据已经查询过，而且在EF上下文的内存里，那么直接从内存中返回数据，如果内存没有再去数据库查询。


            //var list = new List<int>() { 2, 6, 6, 8, 9 };
            //list.Where(x => x > 6); //委托传进where后，遍历集合，把每个元素调用委托传到第一个参数，如果委托返回true就选择出来，最后返回集合。
            var lambdaWhere = dbContext.User.Where(u => u.Id < 10)
                               .OrderBy(u => u.Id)
                               .Skip(5)
                               .Take(5);

            #endregion

        }
    }
}
