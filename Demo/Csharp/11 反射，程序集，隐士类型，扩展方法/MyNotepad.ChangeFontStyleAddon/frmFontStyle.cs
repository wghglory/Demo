using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyNotepad.ChangeFontStyleAddon
{
    public partial class frmFontStyle : Form
    {
        public frmFontStyle()
        {
            InitializeComponent();
        }
        public frmFontStyle(TextBox txtBox)
            : this()
        {
            this._txtBox = txtBox;
        }

        private TextBox _txtBox;

        private void frmFontStyle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _txtBox.Font = new Font(comboBox2.Text.Trim(), float.Parse(comboBox1.Text.Trim()));
            this.Close();
        }
    }
}
