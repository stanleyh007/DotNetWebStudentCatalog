using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetWebStudentCatalog.Models.Entity
{
    public class CompetencyModel
    {
        public int CompetencyModelId { get; set; }
        public string name { get; set; }

        public int CompetencyHeaderModelId { get; set; }
        public virtual CompetencyHeaderModel competencyHeader { get; set; }
    }
}