using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace _01假的文件加密
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //byte.MaxValue
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //JiaMi(txtSource.Text.Trim(), txtTarget.Text.Trim());

            //LiGuanBin();

            WangYaNan();


        }

        private void WangYaNan()
        {
            using (FileStream read = new FileStream(txtSource.Text.Trim(), FileMode.Open, FileAccess.Read))
            {
                using (FileStream write = new FileStream(txtTarget.Text.Trim(), FileMode.Create, FileAccess.Write))
                {
                    byte[] bytes = new byte[1024 * 5];
                    int r = read.Read(bytes, 0, bytes.Length);
                    while (r > 0)
                    {
                        for (int i = 0; i < r; i++)
                        {
                            bytes[i] = Convert.ToByte(255 - Convert.ToInt32(bytes[i]));
                        }
                        write.Write(bytes, 0, r);
                        r = read.Read(bytes, 0, bytes.Length);
                    }
                }
            }
            MessageBox.Show("Oh,Yeah~!");
        }

        private void LiGuanBin()
        {
            using (FileStream fs = new FileStream(txtSource.Text.Trim(), FileMode.Open, FileAccess.Read))
            {
                using (FileStream nfs = new FileStream(txtTarget.Text.Trim(), FileMode.Create, FileAccess.Write))
                {
                    byte[] bytes = new byte[1024 * 1024 * 5];
                    int r = fs.Read(bytes, 0, bytes.Length);
                    while (r > 0)
                    {
                        for (int i = 0; i < r; i++)
                        {
                            bytes[i] = Convert.ToByte(255 - bytes[i]);
                        }
                        nfs.Write(bytes, 0, r);
                        r = 255 - fs.Read(bytes, 0, bytes.Length);
                    }
                }
            }
        }

        private void JiaMi(string source, string target)
        {
            //创建一个读取源文件的文件流
            using (FileStream fsRead = new FileStream(source, FileMode.Open))
            {
                //创建一个写入新文件的文件流
                using (FileStream fsWrite = new FileStream(target, FileMode.Create))
                {
                    byte[] bytes = new byte[1024 * 5];
                    int count = 0;
                    while ((count = fsRead.Read(bytes, 0, bytes.Length)) > 0)
                    {
                        //加密，加密其实就是先把byte[]中的字节内容先改变一下，然后在执行写入操作
                        for (int i = 0; i < count; i++)
                        {
                            bytes[i] = (byte)(byte.MaxValue - bytes[i]);
                        }

                        //拷贝，直接写拷贝代码
                        fsWrite.Write(bytes, 0, count);
                    }
                }
            }
            MessageBox.Show("拷贝完毕！");
        }
    }
}
