using Microsoft.EntityFrameworkCore;
using SIG.Core.Base;
using SIG.Core.Domain;
using SIG.Core.Domain.Interfaces;
using SIG.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SIG.Data.Respositories
{
    public class LocacityRepository : Repository<Locacity>, ILocacityRepository
    {
        public LocacityRepository(SigDBContext db) : base(db)
        {
          

        }
        public async Task<IEnumerable<Locacity>> GetAllWithArea(Expression<Func<Locacity, bool>> expression)
        {
            return await Db.Locacities.Include(x=>x.ActingArea).AsNoTracking().Where(expression).ToListAsync();
        }
    }
}
