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
            string contentString = "ContextResultDemo! 请查看 Controllers/DemoController.cs文件,里面包含所有类型ActionResult的用法.";
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
            //可以将一个jpg格式的图像输出为gif格式
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
            //当网站里面跳转到别的网站的时候要加上http://

            return Redirect(@"http://localhost:1847/Demo/ContentResultDemo");
        }

        /// <summary>
        /// http://localhost:1847/Demo/RedirectToRouteResultDemo
        /// </summary>
        /// <returns></returns>
        public ActionResult RedirectToRouteResultDemo()
        {
            //内网条状
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
            //如果没有传入View名称, 默认寻找与Action名称相同的View页面.
            return View();
        }

    }
}
