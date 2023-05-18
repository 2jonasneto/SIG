using SIG.Core.Domain;
using SIG.Core.Domain.Interfaces;
using SIG.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG.Data.Respositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(SigDBContext db) : base(db)
        {
        }
    }
}
