using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.International.Converters.PinYinConverter;
using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;

namespace _03把给定的汉字转换为拼音
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sbPy = new StringBuilder();
            //1.获取用户的输入
            string input = textBox1.Text.Trim();
            //获取字符串中的每个字符
            for (int i = 0; i < input.Length; i++)
            {
                Char ch = input[i];
                ChineseChar cnChar = new ChineseChar(ch);
                if (cnChar.PinyinCount > 0)
                {
                    sbPy.Append(cnChar.Pinyins[0].Remove(cnChar.Pinyins[0].Length - 1));
                }
                //foreach (string py in cnChar.Pinyins)
                //{
                //    sbPy.AppendLine(py);
                //}
            }
            textBox2.Text = sbPy.ToString();
            //textBox2.Text = sbPy.ToString() + "\r\n结束";
            //
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = ChineseConverter.Convert(textBox1.Text.Trim(), ChineseConversionDirection.SimplifiedToTraditional);
        }
    }
}
