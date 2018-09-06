using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using jQueryAppBD.Models;

namespace jQueryAppBD.Controllers
{
    public class HomeController : Controller
    {
        CompContext db = new CompContext();
        public ActionResult Index()
        {
            return View(db.Computers);
        }

        public ActionResult Details(int id)
        {
            Computer comp = db.Computers.Find(id);
            if(comp != null)
            {
                return PartialView("Details", comp);
            }
            return View("Index");
        }
        //Добавление
        public ActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (Computer comp)
        {
            db.Computers.Add(comp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Редактирование
        public ActionResult Edit(int id)
        {
            Computer comp = db.Computers.Find(id);
            if(comp != null)
            {
                return PartialView("Edit", comp);
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Computer comp)
        {
            db.Entry(comp).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Computer comp = db.Computers.Find(id);
            if (comp != null)
            {
                return PartialView("Delete", comp);
            }
            return View("Index");
        }

        //Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteRecord(int id)
        {
            Computer comp = db.Computers.Find(id);
            if(comp != null)
            {
                db.Computers.Remove(comp);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}