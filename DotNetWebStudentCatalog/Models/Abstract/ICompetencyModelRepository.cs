using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetWebStudentCatalog.Models.Entity;

namespace DotNetWebStudentCatalog.Models.Abstract
{
    interface ICompetencyModelRepository
    {
        List<CompetencyModel> GetAll();
        CompetencyModel Find(int? id);
        void InsertOrUpdate(CompetencyModel competencyModel);
        Boolean Delete(int? id);
        CompetencyModel Details(int? id);
    }
}
