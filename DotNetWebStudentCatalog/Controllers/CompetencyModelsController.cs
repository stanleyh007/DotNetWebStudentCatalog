using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DotNetWebStudentCatalog.Models;
using DotNetWebStudentCatalog.Models.Entity;
using DotNetWebStudentCatalog.Models.Repositories;

namespace DotNetWebStudentCatalog.Controllers
{
    [Authorize(Roles = "admin")]
    public class CompetencyModelsController : Controller
    {
        private CompetencyModelRepository competencyModelRepos = new CompetencyModelRepository();
        
        public CompetencyModel Find(int? id)
        {
            CompetencyModel competencyModel = competencyModelRepos.Find(id);
            return competencyModel;
        }

        // GET: CompetencyModels
        [AllowAnonymous]
        public ActionResult Index()
        {        
            return View(competencyModelRepos.GetAll());
        }

        // GET: CompetencyModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CompetencyModel competencyModel =  competencyModelRepos.Details(id);
            
            if (competencyModel == null)
            {
                return HttpNotFound();
            }
            
            return View(competencyModel);
        }

        // GET: CompetencyModels/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.CompetencyHeaderModelId = new SelectList(competencyModelRepos.db.CompetencyHeaderModels, "CompetencyHeaderModelId", "name");
            return View();
        }

        // POST: CompetencyModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "CompetencyModelId,name,CompetencyHeaderModelId")] CompetencyModel competencyModel)
        {
            if (ModelState.IsValid)
            {
                competencyModelRepos.InsertOrUpdate(competencyModel);
                return RedirectToAction("Index");
            }

            ViewBag.CompetencyHeaderModelId = new SelectList(competencyModelRepos.db.CompetencyHeaderModels, "CompetencyHeaderModelId", "name", competencyModel.CompetencyHeaderModelId);
            return View(competencyModel);
        }

        // GET: CompetencyModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CompetencyModel competencyModel = competencyModelRepos.Find(id);

            if (competencyModel == null)
            {
                return HttpNotFound();
            }

            ViewBag.CompetencyHeaderModelId = new SelectList(competencyModelRepos.db.CompetencyHeaderModels, "CompetencyHeaderModelId", "name", competencyModel.CompetencyHeaderModelId);
            return View(competencyModel);
        }

        // POST: CompetencyModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompetencyModelId,name,CompetencyHeaderModelId")] CompetencyModel competencyModel)
        {
            if (ModelState.IsValid)
            {
                competencyModelRepos.InsertOrUpdate(competencyModel);
                return RedirectToAction("Index");
            }

            ViewBag.CompetencyHeaderModelId = new SelectList(competencyModelRepos.db.CompetencyHeaderModels, "CompetencyHeaderModelId", "name", competencyModel.CompetencyHeaderModelId);
            return View(competencyModel);
        }

        // GET: CompetencyModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CompetencyModel competencyModel = competencyModelRepos.Find(id);

            if (competencyModel == null)
            {
                return HttpNotFound();
            }
            return View(competencyModel);
        }

        // POST: CompetencyModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            competencyModelRepos.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                competencyModelRepos.db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
