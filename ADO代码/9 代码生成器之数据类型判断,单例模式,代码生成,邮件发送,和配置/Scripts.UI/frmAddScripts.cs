using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Scripts.BLL;
using Scripts.Model;

namespace Scripts.UI
{
    public partial class frmAddScripts : Form
    {
        public frmAddScripts()
        {
            InitializeComponent();
        }
        public frmAddScripts(int pid, Action update)
            : this()
        {
            this._parentId = pid;
            this._updateTree = update;
        }

        //用来标记父类别Id的 变量
        private int _parentId;

        private Action _updateTree;

        private void button1_Click(object sender, EventArgs e)
        {
            //调用业务逻辑层实现增加数据
            T_ScriptsBll bll = new T_ScriptsBll();
            T_Scripts model = new T_Scripts();
            model.ScriptTitle = txtTitle.Text.Trim();
            model.ScriptMsg = txtMessage.Text.Trim();
            model.ScriptParentId = this._parentId;
            bll.AddScripts(model);
            if (_updateTree != null)
            {
                _updateTree();
            }
            this.Close();
        }
    }
}
