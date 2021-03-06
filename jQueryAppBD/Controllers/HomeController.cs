﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using jQueryAppBD.Models;
using Newtonsoft.Json;

namespace jQueryAppBD.Controllers
{
    public class HomeController : Controller
    {
        CompContext db = new CompContext();
        static List<Book> books = new List<Book>();
        public ActionResult Index()
        {
            return View(db.Computers);
        }

        public ActionResult BooksGrid()
        {
            return View();
        }
        public string GetData()
        {
            //books = db.Books.ToList();
            return JsonConvert.SerializeObject(db.Books.ToList());
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
            if(ModelState.IsValid)
            {
                db.Computers.Add(comp);
                db.SaveChanges();
                return PartialView("Success");
            }

            return PartialView(comp);
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