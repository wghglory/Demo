using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace SocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.创建一个Socket对象(这个Socket只是负责服务器监听的。)
            Socket skConnection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //"目标服务器积极拒绝。"
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("192.168.1.100"), 9999);
            //2.绑定Bind();
            skConnection.Bind(ipEndPoint);
            //3.开始监听
            skConnection.Listen(10);
            Console.WriteLine("服务器启动了监听......");




            while (true)
            {
                //4.当有客户端连接到服务器后，对客户端的连接进行处理。
                Socket skCommunication = skConnection.Accept();
                //处理
                //1.显示客户端的信息
                Console.WriteLine("有客户端连接：客户端信息是：{0}", skCommunication.RemoteEndPoint.ToString());
                //启动该线程用来处理客户端不断发来的消息，用单独线程来执行
                //while-true循环，防止阻塞主线程。主线程要继续执行调用Accept()的方法，来接收其他的客户端连接。
                #region 启动线程来处理客户端发来的消息
                Thread t = new Thread(new ThreadStart(() =>
                {
                    //通过循环来不断接收客户端的消息
                    while (true)
                    {
                        byte[] buffers = new byte[1024 * 1024 * 1];
                        //5.准备接收客户端发来的消息：
                        //返回值表示实际接收到的字节数
                        int r = skCommunication.Receive(buffers);
                        if (r > 0)
                        {
                            //把接收到的消息转换为字符串：
                            string msg = Encoding.UTF8.GetString(buffers, 0, r);
                            Console.WriteLine("客户端【{0}】发来消息：{1}", skCommunication.RemoteEndPoint.ToString(), msg);
                        }
                        else
                        {
                            Console.WriteLine("客户端【{0}】退出了。", skCommunication.RemoteEndPoint.ToString());
                            break;
                        }
                    }
                }));
                t.IsBackground = true;
                t.Start();
                #endregion    
            }
            Console.ReadKey();
            // Console.ReadKey();
        }
    }
}
