using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeOnly
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建上下文, 小项目10个人用，可以using。大型不能这样
            using (CodeDbContext dbContext = new CodeDbContext())
            {
                Employee emp = new Employee() { Name = "guanghui" };

                dbContext.Employee.Add(emp);

                EmpOrder order1 = new EmpOrder() { OrderContent = "iphone6 plus" };
                dbContext.EmpOrder.Add(order1);

                EmpOrder order2 = new EmpOrder() { OrderContent = "samsung s6" };
                dbContext.EmpOrder.Add(order2);

                emp.EmpOrder.Add(order1);
                emp.EmpOrder.Add(order2);

                dbContext.SaveChanges();
            }


        }
    }
}
