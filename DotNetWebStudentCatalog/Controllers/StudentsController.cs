using DotNetWebStudentCatalog.Models.Entity;
using DotNetWebStudentCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetWebStudentCatalog.Models.Repositories;

namespace DotNetWebStudentCatalog.Controllers
{
    [Authorize(Roles = "admin")]
    public class StudentsController : Controller
    {
        private StudentRepository studentRepos = new StudentRepository();
        public StudentModel Find(int? id)
        {
            StudentModel student = studentRepos.Find(id);
            return student;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            //StudentModel student = db.Students.FirstOrDefault(a => a.LastName == "42");
            return View(studentRepos.GetAll());
        }

        public ActionResult WannaPlay()
        {
            ViewBag.Message = "No, I don't wanna play";
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentModel student)
        {
            if(ModelState.IsValid)
            {
                studentRepos.InsertOrUpdate(student);

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpNotFoundResult();
            }

            StudentModel student = studentRepos.Find(id);

            if (student == null)
            {
                return new HttpNotFoundResult();
            }

            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(StudentModel student)
        {
            if (ModelState.IsValid)
            {
                studentRepos.InsertOrUpdate(student);
                
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpNotFoundResult();
            }
            
            studentRepos.Delete(id);
            return RedirectToAction("Index"); 
        }
    } 
}