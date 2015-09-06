using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboSign.SelectedIndex = 0;
        }


        private void btnCal_Click(object sender, EventArgs e)
        {
            int num1 = int.Parse(txtNum1.Text.Trim());
            int num2 = Convert.ToInt32(txtNum2.Text.Trim());
            switch (cboSign.Text.Trim())
            {
                case "+":
                    lblResult.Text = (num1 + num2).ToString();
                    break;
                case "-":
                    lblResult.Text = (num1 - num2).ToString();
                    break;
                case "*":
                    lblResult.Text = (num1 * num2).ToString();
                    break;
                case "/":
                    lblResult.Text = (num1 / num2).ToString();
                    break;
                default:
                    lblResult.Text = "未知结果！";
                    break;
            }
        }
    }
}
