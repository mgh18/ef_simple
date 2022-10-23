using Entity_Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Entity_Example.Controllers
{
    public class HomeController : Controller
    {
        EF_DBEntities1 db = new EF_DBEntities();


        // GET: Home
        public ActionResult Index()
        {
            return View(db.tbl_People.ToList());
        }

        public ActionResult detail(int id)
        {
            return View(db.tbl_People.Find(id));
        }

        [HttpGet]
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(tbl_People person)
        {
            db.tbl_People.Add(person);
            db.SaveChanges();
            return RedirectToAction("index");

        }

        public ActionResult edit(int id)
        {
            return View(db.tbl_People.Find(id));
        }
        [HttpPost]
        public ActionResult edit(tbl_People person)
        {
            var p = db.tbl_People.Find(person.Id);
            p.Name = person.Name;
            p.email = person.email;
            p.website = person.website;
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult delete(int id)
        {
            var p = db.tbl_People.Find(id);
            db.tbl_People.Remove(p);
            db.SaveChanges();
            return RedirectToAction("index");

        }

    }
}