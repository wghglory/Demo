using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using _01三层.UI;

namespace _01三层
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
            Application.Run(new Form4());
        }
    }
}
