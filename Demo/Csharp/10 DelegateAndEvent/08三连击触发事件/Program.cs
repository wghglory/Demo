﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _08三连击触发事件
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
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
