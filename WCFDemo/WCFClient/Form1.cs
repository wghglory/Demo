using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IBLL;

namespace WCFClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //启动了host服务后：

        //若自己写client测试：
        //打开vs cmd，定位到client文件夹
        //cd C:\WCFDemo\WCFClient
        //svcutil http://localhost:8000/?wsdl /o:FirstServiceClient.cs
        //执行成功后，会在解决方案目录下生成两个文件：FirstServiceClient.cs 和output.config
        //中止Host项目的调试，回到Client项目，选择添加 现有项 ，然后选择这两个文件，添加后，将output.config重命名为App.config
        //Client项目中添加引用，选择System.ServiceModel

        UserServiceClient client = new UserServiceClient();
        private void button1_Click(object sender, EventArgs e)
        {
            
            UserInfo user = client.GetUser((this.textBox1.Text));
            MessageBox.Show(user.Name + "--" + user.Id);

            //2 copy output.config to app.config and modify: contract="IBLL.IUserService"
        }

        private void button2_Click(object sender, EventArgs e)
        {
            client.Show();
        }
    }
}
