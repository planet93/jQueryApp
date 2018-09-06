using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JqueryUIApp.Models;
using System.Web.Mvc;

namespace JqueryUIApp.Controllers
{
    public class HomeController : Controller
    {
        static List<Computer> comps = new List<Computer>();

        static HomeController()
        {
            comps.Add(new Computer { Id = 1, Model = "IBM PC", Year = 1981 });
            comps.Add(new Computer { Id = 2, Model = "Apple II", Year = 1977 });
            comps.Add(new Computer { Id = 3, Model = "Apple III", Year = 1980 });
            comps.Add(new Computer { Id = 4, Model = "Macintosh", Year = 1984 });
            comps.Add(new Computer { Id = 1, Model = "IBM PC", Year = 1981 });
            comps.Add(new Computer { Id = 2, Model = "Apple II", Year = 1977 });
            comps.Add(new Computer { Id = 3, Model = "Apple III", Year = 1980 });
            comps.Add(new Computer { Id = 4, Model = "Macintosh", Year = 1984 });
            comps.Add(new Computer { Id = 1, Model = "IBM PC", Year = 1981 });
            comps.Add(new Computer { Id = 2, Model = "Apple II", Year = 1977 });
            comps.Add(new Computer { Id = 3, Model = "Apple III", Year = 1980 });
            comps.Add(new Computer { Id = 4, Model = "Macintosh", Year = 1984 });
            comps.Add(new Computer { Id = 1, Model = "IBM PC", Year = 1981 });
            comps.Add(new Computer { Id = 2, Model = "Apple II", Year = 1977 });
            comps.Add(new Computer { Id = 3, Model = "Apple III", Year = 1980 });
            comps.Add(new Computer { Id = 4, Model = "Macintosh", Year = 1984 });
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SearchComputer(string term)
        {
            var models = comps.Where(a => a.Model.Contains(term)).Select(a => new { value = a.Model }).Distinct();
            return Json(models, JsonRequestBehavior.AllowGet);
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