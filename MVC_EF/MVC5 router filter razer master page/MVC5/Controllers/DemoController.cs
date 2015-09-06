using System;
using System.IO;
using System.Web.Mvc;

namespace MVC5.Controllers
{
    public class DemoController : Controller
    {

        /// <summary>
        /// http://localhost:1847/Demo/ContentResultDemo
        /// </summary>
        /// <returns></returns>
        public ActionResult ContentResultDemo()
        {
            string contentString = "ContextResultDemo! ��鿴 Controllers/DemoController.cs�ļ�,���������������ActionResult���÷�.";
            return Content(contentString);//ContentResult
        }

        /// <summary>
        /// http://localhost:1847/Demo/EmptyResultDemo
        /// </summary>
        /// <returns></returns>
        public ActionResult EmptyResultDemo()
        {
            return new EmptyResult();
        }

        /// <summary>
        /// http://localhost:1847/Demo/FileContentResultDemo
        /// </summary>
        /// <returns></returns>
        public ActionResult FileContentResultDemo()
        {
            FileStream fs = new FileStream(Server.MapPath(@"/resource/Images/1.gif"), FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[Convert.ToInt32(fs.Length)];
            fs.Read(buffer, 0, Convert.ToInt32(fs.Length));
            return File(buffer, @"image/gif");
        }

        /// <summary>
        /// http://localhost:1847/Demo/FilePathResultDemo
        /// </summary>
        /// <returns></returns>
        public ActionResult FilePathResultDemo()
        {
            //���Խ�һ��jpg��ʽ��ͼ�����Ϊgif��ʽ
            return File(Server.MapPath(@"/resource/Images/2.jpg"), @"image/gif");
        }

        /// <summary>
        /// http://localhost:1847/Demo/FileStreamResultDemo
        /// </summary>
        /// <returns></returns>
        public ActionResult FileStreamResultDemo()
        {
            FileStream fs = new FileStream(Server.MapPath(@"/resource/Images/1.gif"), FileMode.Open, FileAccess.Read);
            return File(fs, @"image/gif");
        }

        /// <summary>
        /// http://localhost:1847/Demo/HttpUnauthorizedResultDemo
        /// </summary>
        /// <returns></returns>
        public ActionResult HttpUnauthorizedResultDemo()
        {
            return new HttpUnauthorizedResult();
        }

        /// <summary>
        /// http://localhost:1847/Demo/JavaScriptResultDemo
        /// </summary>
        /// <returns></returns>
        public ActionResult JavaScriptResultDemo()
        {
            return JavaScript(@"alert(""Test JavaScriptResultDemo!"")");
        }

        /// <summary>
        /// http://localhost:1847/Demo/JsonResultDemo
        /// </summary>
        /// <returns></returns>
        public ActionResult JsonResultDemo()
        {
            var tempObj = new { Controller = "DemoController", Action = "JsonResultDemo" };
            return Json(tempObj);
        }

        /// <summary>
        /// http://localhost:1847/Demo/RedirectResultDemo
        /// </summary>
        /// <returns></returns>
        public ActionResult RedirectResultDemo()
        {
            //����վ������ת�������վ��ʱ��Ҫ����http://

            return Redirect(@"http://localhost:1847/Demo/ContentResultDemo");
        }

        /// <summary>
        /// http://localhost:1847/Demo/RedirectToRouteResultDemo
        /// </summary>
        /// <returns></returns>
        public ActionResult RedirectToRouteResultDemo()
        {
            //������״
            return RedirectToAction(@"FileStreamResultDemo");
        }

        /// <summary>
        /// http://localhost:1847/Demo/PartialViewResultDemo
        /// </summary>
        /// <returns></returns>
        public ActionResult PartialViewResultDemo()
        {
            return PartialView();
        }

        /// <summary>
        /// http://localhost:1847/Demo/ViewResultDemo
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewResultDemo()
        {
            //���û�д���View����, Ĭ��Ѱ����Action������ͬ��Viewҳ��.
            return View();
        }

    }
}
