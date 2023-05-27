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
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
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
            var rs = await DbSet.FindAsync(id);
            return  rs;
        }

        public virtual async Task<IEnumerable<TEntity>> GetByQueryReturnIEnumerable(Expression<Func<TEntity, bool>> expression)
        {
            var t = DbSet.Where(expression).AsNoTracking();
            return await t.ToListAsync();
        }

       
        public async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public async Task Remove(Guid id)
        {
            var entity = DbSet.Find(id);

            if (entity == null) return;
            else DbSet.Remove(entity);
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
