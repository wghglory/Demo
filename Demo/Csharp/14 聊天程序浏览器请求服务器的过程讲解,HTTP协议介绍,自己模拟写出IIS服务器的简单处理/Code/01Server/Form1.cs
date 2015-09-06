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

namespace _01Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Socket _skConn;

        Dictionary<string, Socket> _dict = new Dictionary<string, Socket>();
        private void button1_Click(object sender, EventArgs e)
        {
            if (_skConn == null)
            {
                //1.创建一个Socket
                _skConn = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //2.绑定
                _skConn.Bind(new IPEndPoint(IPAddress.Parse(txtIP.Text.Trim()), int.Parse(txtPort.Text.Trim())));

                //3.开始监听
                _skConn.Listen(10);
                this.txtLog.Text = "启动监听...." + Environment.NewLine;

                //4.开启一个新线程不断接受用户的连接请求
                ThreadPool.QueueUserWorkItem(new WaitCallback(skObj =>
                {
                    Socket skConnP = skObj as Socket;
                    //通过循环不断接受用户的连接请求
                    while (true)
                    {
                        //阻塞线程，等待用户的连接请求
                        Socket skCommu = skConnP.Accept();
                        //获取客户端信息
                        string userinfo = skCommu.RemoteEndPoint.ToString();
                        txtLog.Invoke(new Action<string>(u =>
                        {
                            txtLog.AppendText("客户端【" + u + "】连接成功！" + Environment.NewLine);
                        }), userinfo);

                        listboxUserList.Invoke(new Action<string>(u =>
                        {
                            listboxUserList.Items.Add(u);
                        }), userinfo);
                        if (!_dict.ContainsKey(userinfo))
                        {
                            _dict.Add(userinfo, skCommu);
                        }

                        //再启动一个线程来循环接收用户发来的消息
                        ThreadPool.QueueUserWorkItem(new WaitCallback(skCommuObj =>
                        {
                            Socket skCommuP = skCommuObj as Socket;
                            while (true)
                            {
                                byte[] buffers = new byte[1024 * 1024 * 2];
                                int len = skCommuP.Receive(buffers);
                                if (len == 0)
                                {
                                    //当客户端退出以后，在log文本框中显示用户退出的信息
                                    txtLog.Invoke(new Action<string>(x =>
                                    {
                                        txtLog.AppendText("客户端【" + x + "】退出了。");
                                    }), skCommuP.RemoteEndPoint.ToString());

                                    //从ListBox中删除当前用户
                                    listboxUserList.Invoke(new Action<string>(x =>
                                    {
                                        listboxUserList.Items.Remove(x);
                                    }), skCommuP.RemoteEndPoint.ToString());

                                    //删除Dictionary中的内容
                                    _dict.Remove(skCommuP.RemoteEndPoint.ToString());

                                    break;
                                }
                                else
                                {
                                    string userMessage = Encoding.UTF8.GetString(buffers, 0, len);
                                    //把用户发来的消息显示到txtLog上。
                                    txtLog.Invoke(new Action<string, string>((msg, uinfo) =>
                                    {
                                        txtLog.AppendText("客户端【" + uinfo + "】发来消息：" + msg + Environment.NewLine);
                                    }), userMessage, skCommuP.RemoteEndPoint.ToString());
                                }

                            }

                        }), skCommu);

                    }
                }), _skConn);
            }

        }


        //服务器端向客户端发送消息
        private void button2_Click(object sender, EventArgs e)
        {
            //1. 判断listbox是否有选中的客户端
            if (listboxUserList.SelectedItem != null)
            {
                //2.如果有选中的客户端，则根据键在_dict中找到对应客户端的Socket，然后向该客户端发送消息
                Socket skClient = _dict[listboxUserList.SelectedItem.ToString()];
                string message = txtMsg.Text.Trim();
                //要发送的文字消息的byte数组
                byte[] buffers = Encoding.UTF8.GetBytes(message);

                //在把真正的内容发送之前，要在真正的数据前多加一个字节，用来作为标记：
                //0表示文字,1表示闪屏,2表示发送文件。


                //声明一个新的数据来存放加了标记的byte[]
                byte[] sendBuffers = new byte[buffers.Length + 1];
                sendBuffers[0] = 0;//设置第一个字节为0，表示要发送字符串
                Buffer.BlockCopy(buffers, 0, sendBuffers, 1, buffers.Length);

                //接下来再发送数据的时候就要发送sendBuffers数组了。
                skClient.Send(sendBuffers);

                //在Log文本框中显示服务器向客户端【xxxx】发送了：xxxxx消息。
                txtLog.AppendText("服务器向客户端【" + skClient.RemoteEndPoint.ToString() + "】发送了消息：" + message + Environment.NewLine);
            }
            else
            {
                MessageBox.Show("请先选择一个客户端。");
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //向客户端发送闪屏
        private void button3_Click(object sender, EventArgs e)
        {

            //1.先判断是否有选中的客户端
            if (listboxUserList.SelectedItem != null)
            {
                string clientInfo = listboxUserList.SelectedItem.ToString();
                //服务器向客户端发一个闪屏
                //服务器向客户端发送一个闪屏意思就是服务器只要向客户端发送一个byte字节，这个字节是1就可以了。
                byte[] buffers = new byte[1];
                buffers[0] = 1;
                _dict[clientInfo].Send(buffers);
                txtLog.AppendText("服务器向客户端【" + clientInfo + "】发送了一个闪屏。" + Environment.NewLine);
            }
        }
    }
}
