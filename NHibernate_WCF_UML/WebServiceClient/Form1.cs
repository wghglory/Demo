using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebServiceClient.DemoService;

namespace WebServiceClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DemoService.WebService1SoapClient  client =new WebService1SoapClient();
            var result = client.Add(3, 4);

            MessageBox.Show(result.ToString());
        }
    }
}
