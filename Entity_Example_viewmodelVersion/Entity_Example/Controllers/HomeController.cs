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
            return View(db.tbl_People.Select(p => new PersonViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                email = p.email,
                website = p.website,
                CarName = p.PersonCar.CarName,
                CarPlak = p.PersonCar.CarPlak

            })); 
        }

        public ActionResult detail(int id)
        {
            return View(db.tbl_People.Where(p=>p.Id==id).Select(p => new PersonViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                email = p.email,
                website = p.website,
                CarName = p.PersonCar.CarName,
                CarPlak = p.PersonCar.CarPlak

            }).First());
        }

        [HttpGet]
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(PersonViewModel person)
        {
            tbl_People p = new tbl_People()
            {
                Name = person.Name,
                email = person.email,
                website = person.website
            };
            db.tbl_People.Add(p);

            PersonCar pc = new PersonCar()
            {
                PersonID = p.Id,
                CarName = person.CarName,
                CarPlak = person.CarPlak
            };
            db.PersonCar.Add(pc);
            db.SaveChanges();
            return RedirectToAction("index");
      

        }

        public ActionResult edit(int id)
        {
            return View(db.tbl_People.Where(p => p.Id == id).Select(p => new PersonViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                email = p.email,
                website = p.website,
                CarName = p.PersonCar.CarName,
                CarPlak = p.PersonCar.CarPlak

            }).First());
        }
        [HttpPost]
        public ActionResult edit(PersonViewModel person)
        {
            var p = db.tbl_People.Find(person.Id);
            p.Name = person.Name;
            p.email = person.email;
            p.website = person.website;

            var car = db.PersonCar.Find(person.Id);
            car.CarName = person.CarName;
            car.CarPlak = person.CarPlak;
            
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult delete(int id)
        {
            var p = db.tbl_People.Find(id);
            var car = db.PersonCar.Find(id);
            db.PersonCar.Remove(car);
            db.tbl_People.Remove(p);
            db.SaveChanges();
            return RedirectToAction("index");

        }

    }
}