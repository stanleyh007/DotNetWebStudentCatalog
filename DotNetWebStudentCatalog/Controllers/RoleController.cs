using DotNetWebStudentCatalog.Models;
using DotNetWebStudentCatalog.Models.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetWebStudentCatalog.Controllers
{
    public class RoleController : Controller
    {
        private DbContextRepository dbContextRepos = new DbContextRepository();

        public RoleController()
        {

        }

        // GET: Role
        public ActionResult Index()
        {
            var Roles = dbContextRepos.db.Roles.ToList();
            return View(Roles);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }
        
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            dbContextRepos.db.Roles.Add(Role);
            dbContextRepos.db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}