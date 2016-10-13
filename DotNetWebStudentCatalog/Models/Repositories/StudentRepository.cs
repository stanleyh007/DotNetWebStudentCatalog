using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetWebStudentCatalog.Models.Entity;
using DotNetWebStudentCatalog.Models.Abstract;

namespace DotNetWebStudentCatalog.Models.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public bool Delete(int? id)
        {
            if (id > 0)
            {
                StudentModel student = db.Students.Find(id);
                db.Students.Remove(student);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("This Id does not exist");
                return false;
            }
            db.SaveChanges();
            return true;
        }

        public StudentModel Find(int? id)
        {
            return db.Students.Find(id);
        }

        public List<StudentModel> GetAll()
        {
            return db.Students.ToList();
        }

        public void InsertOrUpdate(StudentModel student)
        {
            if (student.StudentModelId <= 0)
            {
                db.Students.Add(student);   
            }
            else
            {
                db.Entry(student).State = System.Data.Entity.EntityState.Modified; 
            }
            db.SaveChanges();
        }

        public List<StudentModel> Search(string search)
        {
            throw new NotImplementedException();
        }
    }
}