using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeOnly
{
    public class CodeDbContext : DbContext //找到项目packages： \EF_ModelFirst\packages\EntityFramework.6.0.0\lib\net45，添加引用 
    //或者直接添加实体模型，再删除
    {
        public CodeDbContext()
            : base("name=CodeDbConn")  //在配置文件改，可以跨数据库

        {
            
        }

        public void InitDatabase()
        {
            if (!this.Database.Exists())
            {
                this.Database.CreateIfNotExists();
            }
        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmpOrder> EmpOrder { get; set; }

       
    }
}
