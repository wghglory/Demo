using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _02ConnectionStringBuilder类演示
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SqlConnectionStringBuilder connStrbuilder = new SqlConnectionStringBuilder();
            //connStrbuilder.DataSource = "steve-pc";
            //connStrbuilder.InitialCatalog = "itcast2013";
            //connStrbuilder.IntegratedSecurity = true;
            //connStrbuilder.Pooling = true;
            //MessageBox.Show(connStrbuilder.ConnectionString);

            SqlConnectionStringBuilder connStrbuilder = propertyGrid1.SelectedObject as SqlConnectionStringBuilder;
            MessageBox.Show(connStrbuilder.ConnectionString);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder connStrbuilder = new SqlConnectionStringBuilder();
            propertyGrid1.SelectedObject = connStrbuilder;
        }
    }
}
