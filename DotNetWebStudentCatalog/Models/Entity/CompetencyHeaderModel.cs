using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetWebStudentCatalog.Models.Entity
{
    public class CompetencyHeaderModel
    {
        public int CompetencyHeaderModelId { get; set; }
        public string name { get; set; }

        public virtual ICollection<CompetencyModel> competencies { get; set; }
    }
}