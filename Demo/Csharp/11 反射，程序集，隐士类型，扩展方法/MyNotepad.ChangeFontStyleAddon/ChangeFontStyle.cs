using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyNotepad.ExtInterface;

namespace MyNotepad.ChangeFontStyleAddon
{
    public class ChangeFontStyle : IEditor
    {
        public string Name
        {
            get { return "选择字体字号"; }
        }

        public void Run(System.Windows.Forms.TextBox txtBox)
        {
            frmFontStyle frm = new frmFontStyle(txtBox);
            frm.Show();
        }
    }
}
