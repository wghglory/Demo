using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace WCFHost1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(UserInfoService));

            host.Open();

            ServiceHost host2 = new ServiceHost(typeof(RoleInfoService));

            host2.Open();


            Console.WriteLine("服务已启动，按任意键中止...");
            Console.ReadKey(true);
            host.Close();
        }
    }
}
