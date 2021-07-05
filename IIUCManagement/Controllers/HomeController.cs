using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IIUCManagement.Models;

namespace IIUCManagement.Controllers
{
    public class HomeController : Controller
    {
        SchoolContext db = new SchoolContext();
        public ActionResult Index()
        {
            
            var data = db.Students.ToList();
            
            return View(data);
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

        public ActionResult Create()
        {
            return View();
        }
    }
}