using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetWebStudentCatalog.Models.Repositories
{
    public class DbContextRepository
    {
        public ApplicationDbContext db = new ApplicationDbContext();
    }
}