using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace WCFHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //2. start service

            ////创建一个服务
            //using (ServiceHost host = new ServiceHost(typeof(UserService)))
            //{
            //    host.Open();
            //    Console.WriteLine("服务已启动，按任意键中止...");
            //    Console.ReadKey(true);
            //    host.Close();
            //}

            ServiceHost host1 = new ServiceHost(typeof(UserService));

            host1.Open();

            ServiceHost host2 = new ServiceHost(typeof(RoleService));

            host2.Open();


            Console.WriteLine("服务已启动，按任意键中止...");
            Console.ReadKey(true);
            host1.Close();
            host2.Close();

            //3. config 去配置

            //4. 管理员身份去bin把exe打开。
            //5. 测试服务是否启动。C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\wfctestclient.exe 管理员打开。add service: http://localhost:8000 from config


            //用testclient最方便。免得自己写了
        }
    }
}
