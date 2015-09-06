using MVC_ASPX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ASPX.Controllers
{
    public class UserController : Controller
    {
        EFModelFirstEntities dbcontext = new EFModelFirstEntities();

        public ActionResult Index()
        {
            ViewData["User"] = dbcontext.User.ToList();
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(FormCollection collection)
        {
            string name = Request["name"];
            string phone = collection["phone"];
            string address = collection["address"];

            dbcontext.User.Add(new User() { Name = name, Phone = phone, Address = address });
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int? id)
        {
            ViewData["User"] = dbcontext.User.Find(id.Value);
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            //var user = dbcontext.User.Find(id.Value);
            var user = dbcontext.User.Where(u => u.Id == id.Value).FirstOrDefault();
            if (user != null)
            {
                //ViewData["User"] = user;
                ViewData.Model = user;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(User user) //自动装配！！！
        {
            dbcontext.Entry(user).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            User user = dbcontext.User.Find(id.Value);
            if(user!=null)
            {
                dbcontext.User.Remove(user);
                dbcontext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
