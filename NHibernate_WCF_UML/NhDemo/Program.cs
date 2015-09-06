using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;

namespace NhDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建Nh的工厂
            ISessionFactory sessionFactory =
            new Configuration().Configure().BuildSessionFactory();

            var session = sessionFactory.OpenSession();//相当于 EF：DbContexst

            //操作数据库
            //开启事物
            var trans = session.BeginTransaction();//开始事务

            RoleInfo roleInfo =new RoleInfo();
            //roleInfo.ModifiedOn = DateTime.Now;
            //roleInfo.SubTime = DateTime.Now;
            roleInfo.RoleName = "小样爱洗222222222脚2";
            //roleInfo.DelFlag = 0;
            roleInfo.ID = 13;

            //session.Update(roleInfo);
            //session.SaveOrUpdate(roleInfo);
            //session.Delete(roleInfo);

            trans.Commit();//提交事务  Ef：SaveChanges（）


            //session.CreateSQLQuery()
            
            //获取单个实体
            var temp = session.Get<RoleInfo>(10);

            //session.QueryOver();

            var data = session.Query<RoleInfo>().Where(r => r.ID > 5).ToList();
            foreach (var info in data)
            {
                Console.WriteLine(info.RoleName + "    " + info.ID);
            }

            



            Console.WriteLine("ok....");
            Console.ReadKey();
        }
    }
}
