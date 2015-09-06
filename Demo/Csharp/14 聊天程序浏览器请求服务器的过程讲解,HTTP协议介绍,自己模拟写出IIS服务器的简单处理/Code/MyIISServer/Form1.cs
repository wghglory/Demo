using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace MyIISServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Socket skConn = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(txtIP.Text.Trim()), int.Parse(txtPort.Text.Trim()));
            skConn.Bind(endPoint);
            skConn.Listen(10);
            lblServerState.Text = "已启动...";
            lblServerState.ForeColor = Color.Green;

            //使用线程池接受用户的连接
            ThreadPool.QueueUserWorkItem(new WaitCallback((skConnObj) =>
            {
                //socket1表示的是当前监听客户端连接的socket
                Socket socket1 = skConnObj as Socket;
                while (true)
                {
                    //接受用户的连接请求
                    Socket skCommu = socket1.Accept();
                    //获取当前客户端请求的报文（接收用户发送过来的数据）
                    //这里要接收用户发来的信息,由于这里只接收用户的一次发送请求所以不需要循环
                    byte[] buffers = new byte[1024 * 1024 * 2];
                    int len = skCommu.Receive(buffers);
                    //把接收到的用户的http报文转换为字符串
                    string httpMessage = Encoding.UTF8.GetString(buffers, 0, len);
                    txtLog.AppendText(httpMessage + "$$$$$zxh$$$$");

                    //调用该方法对请求进行处理
                    ProcessRequest(httpMessage, skCommu);
                }

            }), skConn);
        }
        //处理客户端请求
        private void ProcessRequest(string httpMessage, Socket skCommu)
        {
            //throw new NotImplementedException();
            //1.把用户请求的报文进行封装
            //把用户请求的报文传递到HttpContext对象中，由该对象进行解析
            HttpContext context = new HttpContext(httpMessage);

            //2.处理请求
            //创建一个HttpApplication对象
            HttpApplication application = new HttpApplication();
            application.ProcessRequest(context);


            //3.返回响应
            skCommu.Send(context.Response.ResponseHeader);
            skCommu.Send(context.Response.ResponseBody);
            skCommu.Shutdown(SocketShutdown.Both);
            skCommu.Close();
            skCommu.Dispose();
        }
    }
}
