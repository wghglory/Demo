using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace Scripts.UI
{
    public partial class frm通过程序实现发邮件 : Form
    {
        public frm通过程序实现发邮件()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1.创建邮件
            MailMessage mail = new MailMessage();
            mail.Subject = "黄林问你吃了吗？";
            mail.Body = "吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？";
            mail.From = new MailAddress("hl@163.com", "黄林");
            mail.To.Add(new MailAddress("dl@163.com", "杜磊"));
            //mail.CC.Add();将邮件抄送给某人
            mail.SubjectEncoding = Encoding.UTF8;
            mail.BodyEncoding = Encoding.UTF8;

            //2.发送邮件(smtp.163.com) 
            SmtpClient smtp = new SmtpClient("localhost", 25);
            smtp.Credentials = new NetworkCredential("hl", "hl123");
            smtp.Send(mail);
            MessageBox.Show("ok");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region 1
            //1.创建邮件
            //MailMessage mail = new MailMessage();
            //mail.Subject = "黄林问你吃了吗？";
            //mail.Body = "<font color='red' size='7' face='华文行楷'>吃了没</font>？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？";
            //mail.IsBodyHtml = true;
            //mail.From = new MailAddress("hl@163.com", "黄林");
            //mail.To.Add(new MailAddress("dl@163.com", "杜磊"));
            ////mail.CC.Add();将邮件抄送给某人
            //mail.SubjectEncoding = Encoding.UTF8;
            //mail.BodyEncoding = Encoding.UTF8;

            ////2.发送邮件
            //SmtpClient smtp = new SmtpClient("localhost", 25);
            //smtp.Credentials = new NetworkCredential("hl", "hl123");
            //smtp.Send(mail);
            //MessageBox.Show("ok");

            #endregion


            #region 2

            //1.创建邮件
            MailMessage mail = new MailMessage();
            mail.Subject = "黄林问你吃了吗？";
            mail.Body = "你长的真委婉！满分500分。";
            //=============带html的邮件============
            AlternateView htmlBody =
          AlternateView.CreateAlternateViewFromString("<font color='red' size='7'>你的长相经过专业机构评测得分为：98分！！！！</font>", null, "text/html");


            mail.AlternateViews.Add(htmlBody);
            //======================================
            mail.From = new MailAddress("hl@163.com", "黄林");
            mail.To.Add(new MailAddress("dl@163.com", "杜磊"));
            //mail.CC.Add();将邮件抄送给某人
            mail.SubjectEncoding = Encoding.UTF8;
            mail.BodyEncoding = Encoding.UTF8;

            //2.发送邮件
            SmtpClient smtp = new SmtpClient("localhost", 25);
            smtp.Credentials = new NetworkCredential("hl", "hl123");
            smtp.Send(mail);
            MessageBox.Show("ok");

            #endregion

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //1.创建邮件
            MailMessage mail = new MailMessage();
            mail.Subject = "黄林问你吃了吗？";
            mail.Body = "你长的真委婉！满分500分。";
            //=============带html的邮件============
            AlternateView htmlBody =
          AlternateView.CreateAlternateViewFromString("<font color='red' size='7'>你的长相经过专业机构评测得分为：98分！！！！</font>您的头像：<img src='cid:meinv' alt='帅锅' title='帅锅一枚'/>", null, "text/html");


            //把图片作为LinkedResource加到邮件中
            LinkedResource lr = new LinkedResource(@"1.jpg", "image/gif");            lr.ContentId ="meinv";
            htmlBody.LinkedResources.Add(lr);


            mail.AlternateViews.Add(htmlBody);
            //======================================
            mail.From = new MailAddress("hl@163.com", "黄林");
            mail.To.Add(new MailAddress("dl@163.com", "杜磊"));
            //mail.CC.Add();将邮件抄送给某人
            mail.SubjectEncoding = Encoding.UTF8;
            mail.BodyEncoding = Encoding.UTF8;

            //2.发送邮件
            SmtpClient smtp = new SmtpClient("localhost", 25);
            smtp.Credentials = new NetworkCredential("hl", "hl123");
            smtp.Send(mail);
            MessageBox.Show("ok");
        }


        //发送带附件的邮件
        private void button4_Click(object sender, EventArgs e)
        {
            //1.创建附件
            Attachment a1 = new Attachment("1.jpg");
            Attachment a2 = new Attachment("SqlHelper.cs");
            Attachment a3 = new Attachment("世界名著语录.jpg");
            //1.创建邮件
            MailMessage mail = new MailMessage();
            mail.Subject = "黄林问你吃了吗？";
            mail.Body = "吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？吃了没？";
            //增加附件
            mail.Attachments.Add(a1);
            mail.Attachments.Add(a2);
            mail.Attachments.Add(a3);
            mail.From = new MailAddress("hl@163.com", "黄林");
            mail.To.Add(new MailAddress("dl@163.com", "杜磊"));
            //mail.CC.Add();将邮件抄送给某人
            mail.SubjectEncoding = Encoding.UTF8;
            mail.BodyEncoding = Encoding.UTF8;

            //2.发送邮件
            SmtpClient smtp = new SmtpClient("localhost", 25);
            smtp.Credentials = new NetworkCredential("hl", "hl123");
            smtp.Send(mail);
            MessageBox.Show("ok");
        }
    }
}
