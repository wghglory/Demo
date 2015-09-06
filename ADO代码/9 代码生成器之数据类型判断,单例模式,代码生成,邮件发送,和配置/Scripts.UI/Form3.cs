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
    public partial class Form3 : Form
    {
        private Form3()
        {
            InitializeComponent();
        }

        private static Form3 _f3;

        public static Form3 CreateForm()
        {
            if (_f3 == null || _f3.IsDisposed)
            {
                _f3 = new Form3();
            }
            return _f3;
        }
    }
}
