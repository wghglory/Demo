using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _06把表中的数据绑定到一个控件上
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
