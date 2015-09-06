using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Scripts.Model;
using Scripts.BLL;

namespace Scripts.UI
{
    public partial class frmEdit : Form
    {
        public frmEdit()
        {
            InitializeComponent();
        }
        public frmEdit(int sid, string name, string msg)
            : this()
        {
            this.txtTitle.Text = name;
            this.txtMessage.Text = msg;
            this._scriptId = sid;

        }
        private int _scriptId;

        //确定修改
        private void button1_Click(object sender, EventArgs e)
        {

            //1.采集数据
            T_Scripts model = new T_Scripts();
            model.ScriptId = _scriptId;
            model.ScriptTitle = txtTitle.Text.Trim();
            model.ScriptMsg = txtMessage.Text.Trim();

            //2.调用业务逻辑层实现更新
            T_ScriptsBll bll = new T_ScriptsBll();
            bll.UpdateScript(model);

            //3.设置DialogResult结果
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            this._title = model.ScriptTitle;
            this._message = model.ScriptMsg;
            //4关闭窗口
            this.Close();
        }

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
        }

        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
        }


        //取消
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
