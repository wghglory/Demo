using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCScaffold_EFCodeFirst.Models
{
    public class MVCScaffoldEFCodeFirstContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<MVCScaffold_EFCodeFirst.Models.MVCScaffoldEFCodeFirstContext>());

        public DbSet<MVCScaffold_EFCodeFirst.Models.City> Cities { get; set; }

        public DbSet<MVCScaffold_EFCodeFirst.Models.Employee> Employees { get; set; }
    }
}