using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sc0802.Bll;
using Stu.Model;
using System.IO;
using DW = System.Drawing;
using Model;

public partial class GuanLi_AddNews : BasePage
{
    protected List<Aspx_Type> _listTypes;
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);

        //初始化下拉菜单
        LoadTypes();

        //判断是否回发
        if (Request["txtContent"] != null)
        {
            //表示回发过来的
            //提取用户请求的数据，并将其插入数据库中
            string title = Request["txtTitle"];
            string content = Request["txtContent"];
            string bigPath;
            string smallPath;
            HttpPostedFile file = Request.Files["imgFile"];
            UploadPic(file, out bigPath, out smallPath);

            //这个typeId就是被选中的option的value中的值。
            string typeId = Request["selectCategory"];

            //执行插入数据库操作
            InsertDb(title, content, bigPath, smallPath, typeId);

            Response.Redirect("NewsList.aspx");


        }
    }

    private void InsertDb(string title, string content, string bigPath, string smallPath, string typeId)
    {
        if (Session["UserInfo"] != null)
        {
            Aspx_User user = Session["UserInfo"] as Aspx_User;
            Aspx_NewsBll bll = new Aspx_NewsBll();
            Aspx_News model = new Aspx_News();
            model.NewsTitle = title;
            model.NewsAuthor = user.LoginId;
            model.NewsContent = content;
            model.NewsImage = bigPath;
            model.NewsIssueDate = DateTime.Now;
            model.NewsSmallImage = smallPath;
            model.NewsTypeId = int.Parse(typeId);
            bll.Add(model);
        }

    }

    private bool UploadPic(HttpPostedFile file, out string bigPath, out string smallPath)
    {
        bigPath = string.Empty;
        smallPath = string.Empty;

        //做一个类型校验
        string ext = Path.GetExtension(file.FileName);
        string filename = Path.GetFileName(file.FileName);
        if ((ext == ".jpg" || ext == ".bmp" || ext == ".png" || ext == ".gif" || ext == ".jpeg") && file.ContentType.StartsWith("image"))
        {
            //认为是一个合法的图片
            //创建缩略图
            //创建大图片
            using (DW.Image imgBig = DW.Image.FromStream(file.InputStream))
            {
                int bwidth = imgBig.Width;
                int bheight = imgBig.Height;
                //创建一个小图片
                using (DW.Image imgSmall = new DW.Bitmap(100, 100 * bheight / bwidth))
                {
                    using (DW.Graphics g = DW.Graphics.FromImage(imgSmall))
                    {
                        g.DrawImage(imgBig, 0, 0, imgSmall.Width, imgSmall.Height);
                    }

                    //把大图，小图都要保存到磁盘上

                    string bigFileName = Guid.NewGuid().ToString() + "_大图" + filename;
                    string smallFileName = Guid.NewGuid().ToString() + "_小图" + filename;
                    int hashcode = bigFileName.GetHashCode();
                    int dir1 = hashcode & 0xf;
                    int dir2 = (hashcode >> 4) & 0xf;


                    bigPath = "Upload/BigPic/" + dir1 + "/" + dir2;
                    smallPath = "Upload/SmallPic/" + dir1 + "/" + dir2;
                    string bigFilePath = Server.MapPath(bigPath);
                    string smallFilePath = Server.MapPath(smallPath);
                    //创建目录
                    Directory.CreateDirectory(bigFilePath);
                    Directory.CreateDirectory(smallFilePath);


                    bigPath = bigPath + "/" + bigFileName;
                    smallPath = smallPath + "/" + smallFileName;

                    //把图片保存到对应的目录下 
                    imgBig.Save(Path.Combine(bigFilePath, bigFileName));
                    imgSmall.Save(Path.Combine(smallFilePath, smallFileName));
                }
            }

            return true;
        }

        return false;
    }



    private void LoadTypes()
    {
        Aspx_TypeBll bll = new Aspx_TypeBll();
        _listTypes = bll.GetAllTypes();
    }
}