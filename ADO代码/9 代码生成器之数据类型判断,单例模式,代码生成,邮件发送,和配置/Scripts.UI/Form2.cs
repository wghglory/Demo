using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Scripts.UI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Form3 f3 = null;
        private void button1_Click(object sender, EventArgs e)
        {
      
            #region 1
            //Form3 f3 = new Form3();
            //// f3.Show();
            //f3.ShowDialog();
            #endregion

            //if (f3 == null || f3.IsDisposed)
            //{
            //    f3 = new Form3();
            //    f3.Show();
            //}
            //else
            //{
            //    f3.Show();
            //}
            Form3 f3 = Form3.CreateForm();
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = Form3.CreateForm();
            f3.Show();
        }
    }
}
