using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MVC_ASPX.Controllers
{
    public class AjaxMvcDemoController : Controller
    {
        //
        // GET: /AjaxMvcDemo/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetTime()
        {
            Thread.Sleep(1500);
            return Content(DateTime.Now.ToString());
        }
    }
}
