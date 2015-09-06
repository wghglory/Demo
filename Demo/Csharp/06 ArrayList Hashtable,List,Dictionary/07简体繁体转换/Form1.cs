using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace _07简体繁体转换
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Dictionary<char, char> dict = new Dictionary<char, char>();

        private void Form1_Load(object sender, EventArgs e)
        {
            //加载简繁体字库到Dictionary集合中
            LoadZiFu();
        }

        private void LoadZiFu()
        {
            //1.读取文本文件
            string[] lines = File.ReadAllLines("简体-繁体.txt", Encoding.Default);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('=');
                dict.Add(parts[0][0], parts[1][0]);
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            //1.获取用户输入的简体
            string jianti = txtJianTi.Text.Trim();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < jianti.Length; i++)
            {
                if (dict.ContainsKey(jianti[i]))
                {
                    sb.Append(dict[jianti[i]]);
                }
                else
                {
                    sb.Append(jianti[i]);
                }

            }
            txtFanTi.Text = sb.ToString();
        }
    }
}
