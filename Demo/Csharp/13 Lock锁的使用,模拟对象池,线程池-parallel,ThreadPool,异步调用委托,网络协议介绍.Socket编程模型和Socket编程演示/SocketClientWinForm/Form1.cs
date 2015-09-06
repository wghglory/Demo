using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace SocketClientWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Socket skClient = null;
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (skClient == null)
            {
                //1.创建Socket
                skClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //2.连接
                skClient.Connect(txtIP.Text.Trim(), int.Parse(txtPort.Text.Trim()));
                this.Text = "连接服务器成功！";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //向服务器发送数据。
            string msg = txtContent.Text.Trim();
            if (skClient != null)
            {
                byte[] buffers = Encoding.UTF8.GetBytes(msg);
                //返回值为已经发送的字节数。
                int r = skClient.Send(buffers);
                MessageBox.Show("发送数据成功！");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //在窗体关闭的时候设置当前Socket正常关闭
            if (skClient != null)
            {
                //skClient.Shutdown(SocketShutdown.Both);
                skClient.Shutdown(SocketShutdown.Send);
                skClient.Close();
            }
        }
    }
}
