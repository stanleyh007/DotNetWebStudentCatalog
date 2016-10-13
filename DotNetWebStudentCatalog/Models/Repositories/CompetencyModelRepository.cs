using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetWebStudentCatalog.Models;
using DotNetWebStudentCatalog.Models.Entity;
using DotNetWebStudentCatalog.Models.Abstract;

namespace DotNetWebStudentCatalog.Models.Repositories
{
    public class CompetencyModelRepository : ICompetencyModelRepository
    {
     
        public ApplicationDbContext db = new ApplicationDbContext();

        public bool Delete(int? id)
        {
            if (id > 0)
            {
                CompetencyModel competencyModel = db.CompetencyModels.Find(id);
                db.CompetencyModels.Remove(competencyModel);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("This Id does not exist");
                return false;
            }
            db.SaveChanges();
            return true;
        }

        public CompetencyModel Details(int? id)
        {
            return db.CompetencyModels.Find(id);
        }

        public CompetencyModel Find(int? id)
        {
            return db.CompetencyModels.Find(id);
        }

        public List<CompetencyModel> GetAll()
        {
            return db.CompetencyModels.ToList();
        }

        public void InsertOrUpdate(CompetencyModel competencyModel)
        {
            if (competencyModel.CompetencyModelId <= 0)
            {
                db.CompetencyModels.Add(competencyModel);
            }
            else
            {
                db.Entry(competencyModel).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
        }
    }
}