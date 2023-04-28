using Microsoft.EntityFrameworkCore;
using SIG.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SIG.Data.Base
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity,new()
    {
        protected readonly SigDBContext Db;
        protected readonly DbSet<TEntity> DbSet;
        public Repository(SigDBContext db)
        {
            Db = db;
            DbSet =  db.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.AsNoTracking().ToListAsync();
         }
        
        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetByQueryReturnIEnumerable(Expression<Func<TEntity, bool>> expression)
        {
            return await DbSet.AsNoTracking().Where(expression).ToListAsync();
        }

       
        public async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public async Task Remove(Guid id)
        {
           DbSet.Remove(new TEntity { Id=id});
            await SaveChanges();
        }

        public async Task Update(TEntity entity)
        {
           DbSet.Update(entity);
            await SaveChanges();
        }
        public void Dispose()
        {
            Db?.Dispose();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
    }
}
