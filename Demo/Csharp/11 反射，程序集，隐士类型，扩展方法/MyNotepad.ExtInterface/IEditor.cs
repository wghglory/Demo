using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyNotepad.ExtInterface
{
    public interface IEditor
    {
        /// <summary>
        /// 这个属性表示，当前插件的名称
        /// </summary>
        string Name
        {
            get;
        }


        /// <summary>
        /// 运行该插件的功能。
        /// </summary>
        void Run(TextBox txtBox);
    }
}
