using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using System.Reflection;
using Autofac.Integration.Mvc;
using BeiDream.Service.Account;
using BeiDream.Framework.Data;
using BeiDream.UI.ViewModel.AutoMapper;
using BeiDream.Framework.CacheStorage;

namespace BeiDream
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutofacMvcRegister();
            AutoMapperConfiguration.Configure();
        }
        private static void AutofacMvcRegister()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(DbContextBase<>)).As(typeof(IDataRepository<>));
            Type baseType = typeof(IDependency);
            Assembly[] assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies()
                .Select(Assembly.Load).ToArray();
            assemblies = assemblies.Union(new[] { Assembly.GetExecutingAssembly() }).ToArray();
            builder.RegisterAssemblyTypes(assemblies)
                .Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract)
                .AsImplementedInterfaces().InstancePerLifetimeScope();//InstancePerLifetimeScope 保证生命周期基于请求

            //无效
            //builder.RegisterType<DefaultCacheAdapter>().PropertiesAutowired().As<ICacheStorage>();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterFilterProvider();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}