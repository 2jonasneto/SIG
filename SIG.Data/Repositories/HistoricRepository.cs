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
    public class HistoricRepository : Repository<Historic>, IHistoricRepository
    {
        public HistoricRepository(SigDBContext db) : base(db)
        {
        }
    }
}
