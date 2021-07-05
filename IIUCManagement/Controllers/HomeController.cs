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

        
        [HttpPost]
        //Student Entity Class er object banaisi student
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid == true)
            {
                db.Students.Add(student);
                //row insert hoise kina dekhar jonno int a niche.
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Data Inserted') </script>";
                    return RedirectToAction("Index");
                }

            }
            else
            {

                    ViewBag.InsertMessage = "<script>alert('Fail') </script>";
            }
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

    }
}