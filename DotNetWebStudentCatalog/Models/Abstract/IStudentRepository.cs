using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetWebStudentCatalog.Models.Entity;

namespace DotNetWebStudentCatalog.Models.Abstract
{
    interface IStudentRepository
    {
        List<StudentModel> GetAll();
        StudentModel Find(int? id);
        void InsertOrUpdate(StudentModel student);
        Boolean Delete(int? id);
        List<StudentModel> Search(string search);
    }
}
