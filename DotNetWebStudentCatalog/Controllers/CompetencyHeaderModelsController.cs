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
    public class CompetencyHeaderModelsController : Controller
    {
        private CompetencyHeaderModelRepository competencyHeaderModelRepos = new CompetencyHeaderModelRepository();

        public CompetencyHeaderModel Find(int? id)
        {
            CompetencyHeaderModel competencyHeaderModel = competencyHeaderModelRepos.Find(id);
            return competencyHeaderModel;
        }

        // GET: CompetencyHeaderModels
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(competencyHeaderModelRepos.GetAll());
        }

        // GET: CompetencyHeaderModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CompetencyHeaderModel competencyHeaderModel = competencyHeaderModelRepos.Details(id);

            if (competencyHeaderModel == null)
            {
                return HttpNotFound();
            }

            return View(competencyHeaderModel);
        }

        // GET: CompetencyHeaderModels/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompetencyHeaderModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "CompetencyHeaderModelId,name")] CompetencyHeaderModel competencyHeaderModel)
        {
            if (ModelState.IsValid)
            {
                competencyHeaderModelRepos.InsertOrUpdate(competencyHeaderModel);
                return RedirectToAction("Index");
            }

            return View(competencyHeaderModel);
        }

        // GET: CompetencyHeaderModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CompetencyHeaderModel competencyHeaderModel = competencyHeaderModelRepos.Find(id);

            if (competencyHeaderModel == null)
            {
                return HttpNotFound();
            }

            return View(competencyHeaderModel);
        }

        // POST: CompetencyHeaderModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompetencyHeaderModelId,name")] CompetencyHeaderModel competencyHeaderModel)
        {
            if (ModelState.IsValid)
            {
                competencyHeaderModelRepos.InsertOrUpdate(competencyHeaderModel);
                return RedirectToAction("Index");
            }

            return View(competencyHeaderModel);
        }

        // GET: CompetencyHeaderModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CompetencyHeaderModel competencyHeaderModel = competencyHeaderModelRepos.Find(id);

            if (competencyHeaderModel == null)
            {
                return HttpNotFound();
            }

            return View(competencyHeaderModel);
        }

        // POST: CompetencyHeaderModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            competencyHeaderModelRepos.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                competencyHeaderModelRepos.db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
