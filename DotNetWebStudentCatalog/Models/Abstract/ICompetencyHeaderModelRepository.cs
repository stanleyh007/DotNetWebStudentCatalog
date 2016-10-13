using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetWebStudentCatalog.Models.Entity;

namespace DotNetWebStudentCatalog.Models.Abstract
{
    interface ICompetencyHeaderModelRepository
    {
        List<CompetencyHeaderModel> GetAll();
        CompetencyHeaderModel Find(int? id);
        void InsertOrUpdate(CompetencyHeaderModel competencyHeaderModel);
        Boolean Delete(int? id);
        CompetencyHeaderModel Details(int? id);
    }
}
