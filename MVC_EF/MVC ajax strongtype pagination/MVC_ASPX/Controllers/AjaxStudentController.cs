using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using MVC_ASPX.Ext;
using MVC_ASPX.Models;

namespace MVC_ASPX.Controllers
{
    public class AjaxStudentController : Controller
    {
        EFModelFirstEntities db = new EFModelFirstEntities();
 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadStudentJson()
        {
            int pageSize = Request["pageSize"] == null ? 8 : int.Parse(Request["pageSize"]);
            int pageIndex = Request["pageIndex"] == null ? 1 : int.Parse(Request["pageIndex"]);
            int totalCount = db.Student.Count();

            var allstudents = db.Student
                .OrderBy(s => s.Id)
                .Skip(pageSize*(pageIndex - 1))
                .Take(pageSize)
                .ToList();
            //因为学生表和课程表有关系，导航属性在被序列化时会来回在student/class转圈出错。
            //解决循环序列化方法，使用部分查询。

            var data = from u in allstudents
                select new {u.Id, u.Name, u.Age, u.Gender};

            string strNav = PageHelper.GetPageNavStr(pageSize, pageIndex, totalCount);


            var result = new {Data = data, NavStr = strNav};

            return Json(result, JsonRequestBehavior.AllowGet);

            //上面return json和下面一样
            //JavaScriptSerializer jss = new JavaScriptSerializer();
            //string str = jss.Serialize(result);
            //return Content(str);  //content() 返回字符串
        }

        public ActionResult GetStudentById(int id)
        {
            Student stu = db.Student.Find(id);
            var data = new {stu.Id, stu.Age, stu.Name, stu.Gender};
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Edit(Student stu)
        {
            db.Entry(stu).State = EntityState.Modified;
            db.SaveChanges();
            return Content("ok");
        }

      
        public ActionResult Delete(int id)
        {
            Student stu = db.Student.Find(id);
            db.Student.Remove(stu);
            db.SaveChanges();
            return Content("ok");
        }

        
    }
}
