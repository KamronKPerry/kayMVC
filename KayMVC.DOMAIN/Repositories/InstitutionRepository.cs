using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using KayMVC.DATA;

namespace KayMVC.DOMAIN.Repositories
{
    public class InstitutionRepository : GenericRepository<Institution>
    {
        public InstitutionRepository(DbContext db) : base(db) { }
    }
}
