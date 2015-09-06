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

namespace _02Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Socket _skClient;

        //Socket客户端
        private void button1_Click(object sender, EventArgs e)
        {
            //1.创建Socket
            if (_skClient == null)
            {
                _skClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //开始连接

                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(txtIP.Text.Trim()), int.Parse(txtPort.Text.Trim()));
                _skClient.Connect(endPoint);
                this.Text = "连接服务器成功！";

                //客户端启动一个线程不断执行Receive()方法接收服务器发来的消息
                ThreadPool.QueueUserWorkItem(new WaitCallback(x =>
                {
                    //循环不断接收服务器发来的消息
                    while (true)
                    {
                        byte[] buffers = new byte[1024 * 1024 * 2];
                        int len = _skClient.Receive(buffers);
                        //1.先获取到接收到的字节数组的第一个元素，判断服务器发来的数据的类型
                        if (buffers[0] == 0)
                        {
                            //表示发送的是文字
                            string msg = Encoding.UTF8.GetString(buffers, 1, len - 1);
                            txtContent.Invoke(new Action<string>(m =>
                            {
                                txtContent.AppendText("服务器向客户端发来消息：" + msg);
                            }), msg);
                        }
                        else if (buffers[0] == 1)
                        {
                            //表示闪屏
                            //调用客户端的闪屏方法
                            FlashWindow();
                        }
                        else if (buffers[0] == 2)
                        {
                            // 表示文件
                        }
                    }
                }));
            }
        }

        private void FlashWindow()
        {
            Random rdn = new Random();
            Point point = this.Location;
            //循环抖动
            for (int i = 0; i < 50; i++)
            {
                this.Location = new Point(point.X + rdn.Next(0, 10), point.Y + rdn.Next(0, 10));
                Thread.Sleep(20);
                this.Location = point;
                Thread.Sleep(20);
            }
        }

        //向客户端发送消息
        private void button2_Click(object sender, EventArgs e)
        {
            //1.获取用户输入的消息
            string userInput = txtContent.Text.Trim();
            if (_skClient != null)
            {
                byte[] buffers = Encoding.UTF8.GetBytes(userInput);
                _skClient.Send(buffers);
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_skClient != null)
            {
                _skClient.Shutdown(SocketShutdown.Both);
                _skClient.Close();
                _skClient.Dispose();
            }
        }
    }
}
