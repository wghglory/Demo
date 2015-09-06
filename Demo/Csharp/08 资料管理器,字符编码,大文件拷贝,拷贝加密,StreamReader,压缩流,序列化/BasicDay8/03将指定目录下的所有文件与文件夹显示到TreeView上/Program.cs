using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _03将指定目录下的所有文件与文件夹显示到TreeView上
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
