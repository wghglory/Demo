using MVC_ASPX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ASPX.Controllers
{
    public class StudentController : Controller
    {
        EFModelFirstEntities dbcontext = new EFModelFirstEntities();
        public ActionResult Index()
        {
            //ViewData.Model = dbcontext.Student.AsEnumerable();
            //return View();

            int pageIndex = Request["pageIndex"] == null ? 1 : int.Parse(Request["pageIndex"]);
            int pageSize = Request["pageSize"] == null ? 8 : int.Parse(Request["pageSize"]);
            ViewBag.pageSize = pageSize;
            ViewBag.pageIndex = pageIndex;  
            ViewBag.totalCount = dbcontext.Student.Count();

            ViewData.Model = dbcontext.Student
                .OrderBy(u => u.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize).ToList();

            return View("IndexPageList");
        }

        //
        // GET: /Student/Details/5

        public ActionResult Details(int id)
        {
            Student stu = dbcontext.Student.Find(id);
            if(stu!=null)
            {
                ViewData.Model = stu;
            }
            return View();
        }

        //
        // GET: /Student/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Student/Create

        [HttpPost]
        public ActionResult Create(Student stu)
        {
            try
            {
                dbcontext.Student.Add(new Student() { Age = stu.Age, Name = stu.Name, Gender = stu.Gender });
                dbcontext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Student/Edit/5

        public ActionResult Edit(int id)
        {
            Student stu = dbcontext.Student.Find(id);
            if(stu!=null)
            {
                ViewData.Model = stu;
            }
            return View();
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Student stu)
        {
            try
            {
                Student s = new Student() { Name = stu.Name, Gender = stu.Gender, Age = stu.Age, Id = stu.Id };
                dbcontext.Entry(s).State = System.Data.Entity.EntityState.Modified;
                dbcontext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Student/Delete/5

        public ActionResult Delete(int id)
        {
            Student stu = dbcontext.Student.Find(id);
            dbcontext.Entry(stu).State = System.Data.Entity.EntityState.Deleted;
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        ////
        //// POST: /Student/Delete/5

        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
