using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetWebStudentCatalog.Models.Entity;
using DotNetWebStudentCatalog.Models.Abstract;

namespace DotNetWebStudentCatalog.Models.Repositories
{
    public class CompetencyHeaderModelRepository : ICompetencyHeaderModelRepository
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        public bool Delete(int? id)
        {
            if (id > 0)
            {
                CompetencyHeaderModel competencyHeaderModel = db.CompetencyHeaderModels.Find(id);
                db.CompetencyHeaderModels.Remove(competencyHeaderModel);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("This Id does not exist");
                return false;
            }
            db.SaveChanges();
            return true;
        }

        public CompetencyHeaderModel Details(int? id)
        {
            return db.CompetencyHeaderModels.Find(id);
        }

        public CompetencyHeaderModel Find(int? id)
        {
            return db.CompetencyHeaderModels.Find(id);
        }

        public List<CompetencyHeaderModel> GetAll()
        {
            return db.CompetencyHeaderModels.ToList();
        }

        public void InsertOrUpdate(CompetencyHeaderModel competencyHeaderModel)
        {
            if (competencyHeaderModel.CompetencyHeaderModelId <= 0)
            {
                db.CompetencyHeaderModels.Add(competencyHeaderModel);
            }
            else
            {
                db.Entry(competencyHeaderModel).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
        }
    }
}