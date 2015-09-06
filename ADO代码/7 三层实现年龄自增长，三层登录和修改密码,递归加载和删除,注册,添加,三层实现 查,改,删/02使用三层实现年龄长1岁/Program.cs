using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using _08使用三层实现年龄长1岁.UI;

namespace _08使用三层实现年龄长1岁
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
