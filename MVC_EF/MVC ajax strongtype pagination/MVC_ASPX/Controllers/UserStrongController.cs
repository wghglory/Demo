using MVC_ASPX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ASPX.Controllers
{
    public class UserStrongController : Controller
    {
        EFModelFirstEntities dbcontext = new EFModelFirstEntities();
        //
        // GET: /UserStrong/

        public ActionResult Index()
        {
            ViewData.Model = dbcontext.User.AsEnumerable();
            return View();
        }

        //
        // GET: /UserStrong/Details/5

        public ActionResult Details(int id)
        {
            User user = dbcontext.User.Find(id);
            //var user = dbContext.User.Where(u => u.Id == id).FirstOrDefault();
            if (user != null)
            {
                //ViewData["User"] = user;
                ViewData.Model = user;
            }
            return View();
        }

        //
        // GET: /UserStrong/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UserStrong/Create

        [HttpPost]
        public ActionResult Create(User user)
        {

            if (ModelState.IsValid == true)  //mvc后台校验
            {
                dbcontext.User.Add(user);
                dbcontext.SaveChanges();

            }
            return RedirectToAction("Index");

        }

        //
        // GET: /UserStrong/Edit/5

        public ActionResult Edit(int id)
        {
            ViewData.Model = dbcontext.User.Find(id);
            return View();
        }

        //
        // POST: /UserStrong/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                string name = collection["name"];
                string address = collection["address"];
                string phone = collection["phone"];
                int age = int.Parse(collection["age"]);
                User user = new User() { Id = id, Name = name, Address = address, Phone = phone, Age = age };
                dbcontext.Entry(user).State = System.Data.Entity.EntityState.Modified;
                dbcontext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /UserStrong/Delete/5

        public ActionResult Delete(int id)
        {
            //return View();

            //var user = dbcontext.User.Find(id);
            //dbcontext.User.Remove(user);

            User user_deleted = new User() { Id = id };
            dbcontext.Entry(user_deleted).State = System.Data.Entity.EntityState.Deleted;

            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        ////
        //// POST: /UserStrong/Delete/5

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
