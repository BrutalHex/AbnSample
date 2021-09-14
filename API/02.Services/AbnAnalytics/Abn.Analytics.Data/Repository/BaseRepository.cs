using Abn.Framework.Core.Domain;
using Abn.Framework.Core.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Abn.Analytics.Data.Repository
{
    public class BaseRepository<TEntity,TId>: IRepository<TEntity, TId> where TEntity : BaseEntity<TId>
    {
        protected DbContext DbContext;
        public BaseRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }
        protected DbSet<TEntity> Table => DbContext.Set<TEntity>();

        public virtual async Task<int> CountAsync()
        {
            return await Table.CountAsync();
        }
        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.CountAsync(predicate);
        }

        public virtual IQueryable<TEntity> FindAll()
        {
            return Table.AsQueryable();
        }



        public virtual IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return Table.AsQueryable().Where(predicate).AsQueryable();
        }

        public virtual async Task<TEntity> FindAsync(TId id)
        {
            return await Table.FindAsync(id);
        }

        public virtual IQueryable<TEntity> FindById(TId id)
        {
            var res = Table.Find(id);

            return (new List<TEntity>() { res }).AsQueryable();
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.FirstOrDefaultAsync(predicate);
        }
        public virtual async Task<long> LongCountAsync()
        {
            return await Table.LongCountAsync();
        }
        public virtual async Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.LongCountAsync(predicate);
        }
        public virtual async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.SingleOrDefaultAsync(predicate);
        }
        public virtual async Task AddAsync(TEntity entity)
        {
            await Table.AddAsync(entity);


        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        public virtual async Task RemoveAsync(TEntity entity)
        {
            Table.Remove(entity);
            await Task.CompletedTask;
        }

        public virtual async Task RemoveAsync(TId id)
        {
            var entity = Table.Local.FirstOrDefault(x => x.Id.Equals(id));
            entity ??= await FindAsync(id);
            await RemoveAsync(entity);
        }
        public virtual void Remove(TEntity entity)
        {
            Table.Remove(entity);
        }

        public virtual async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            Table.RemoveRange(entities);
            await Task.CompletedTask;
        }
        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            Table.RemoveRange(entities);
        }

        public virtual async Task RemoveRangeAsync(IEnumerable<TId> ids)
        {
            var entites = Table.Where(x => ids.Contains(x.Id));
            await RemoveRangeAsync(entites);
        }


        public virtual async Task UpdateAsync(TEntity entity)
        {
            DbContext.Entry<TEntity>(entity).State = EntityState.Modified;
            Table.Update(entity);

            await Task.CompletedTask;
        }
        public virtual async Task DetachEntity(TEntity entity)
        {
            DbContext.Entry<TEntity>(entity).State = EntityState.Detached;
            await Task.CompletedTask;
        }
    }
}
