using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _02登录验证用户名是否存在以及密码是否正确
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
