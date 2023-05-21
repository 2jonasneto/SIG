using SIG.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SIG.Core.Domain.Interfaces
{
    public interface ILocacityRepository:IRepository<Locacity>
    {
        Task<IEnumerable<Locacity>> GetAllWithArea(Expression<Func<Locacity, bool>> expression);
    }
}
