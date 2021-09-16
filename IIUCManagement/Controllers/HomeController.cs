using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IIUCManagement.Models;

namespace IIUCManagement.Controllers
{
    public class HomeController : Controller
    {
        SchoolContext db = new SchoolContext();
        public ActionResult Index(string searchBy,string search)
        {
            if (searchBy == "ID")
            {
                return View(db.Students.Where(x => x.StudentId.ToString() == search || search == null).ToList());
            }
            else
            { 
                return View(db.Students.Where(x => x.StudentName.StartsWith(search) || search == null).ToList());
            }


            //var data = db.Students.ToList();
            
            //return View(data);
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
        public ActionResult Edit(int id)
        {
            var row = db.Students.Where(model => model.StudentId == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(student).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["UpdateMessage"] = "<script>alert('Data Updated') </script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.UpdateMessage = "<script>alert('Fail') </script>";
                }
            }

            return View();
        }
    //    https://www.geeksforgeeks.org/basic-crud-create-read-update-delete-in-asp-net-mvc-using-c-sharp-and-entity-framework/
    }
}