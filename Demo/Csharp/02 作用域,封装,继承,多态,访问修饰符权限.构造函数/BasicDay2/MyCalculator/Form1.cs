using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int n1 = Convert.ToInt32(txtNum1.Text.Trim());
            int n2 = Convert.ToInt32(txtNum2.Text.Trim());

            Calculator cal = new Calculator(n1, n2);
            switch (cboSign.Text.Trim())
            {
                case "+":
                    lblResult.Text = cal.Add().ToString();
                    break;
            }

        }
    }
}
