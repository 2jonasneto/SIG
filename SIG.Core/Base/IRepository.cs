using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SIG.Core.Base
{
    public interface IRepository<TEntity>:IDisposable where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetByQueryReturnIEnumerable(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetById(Guid id);

        Task Add(TEntity entity);
        Task Remove(Guid id);
        Task Update(TEntity entity);

        Task<int> SaveChanges();
        

    }
}
