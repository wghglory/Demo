using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace _06文件加密
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string source = textBox1.Text.Trim();
            string target = textBox2.Text.Trim();
            JiaMi(source, target);
            MessageBox.Show("ok");
        }

        private void JiaMi(string source, string target)
        {
            using (FileStream fsRead = new FileStream(source, FileMode.Open))
            {
                using (FileStream fsWrite = new FileStream(target, FileMode.Create))
                {
                    byte[] buffer = new byte[1024 * 1024 * 2];
                    int r;
                    while ((r = fsRead.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        //============加密====================
                        for (int i = 0; i < r; i++)
                        {
                            buffer[i] = (byte)(byte.MaxValue - buffer[i]);
                        }
                        //============加密====================

                        fsWrite.Write(buffer, 0, r);
                    }
                }
            }
        }
    }
}
