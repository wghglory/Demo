using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyNotepad.ExtInterface;

namespace MyNotepadd.ToUpperAddon
{
    public class MyNotepadChangeToUpper : IEditor
    {
        public string Name
        {
            get
            {
                return "转换字母大写";
            }

        }

        public void Run(System.Windows.Forms.TextBox txtBox)
        {
            //将插件中的文本变成大写。
            txtBox.Text = txtBox.Text.ToUpper();
        }
    }
}
