using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OgrenciKayitSistemi.Application.Abstractions.EfCore.Repositories;
using OgrenciKayitSistemi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciKayitSistemi.Persistence.EfCore.Repositories
{
    public class Repo<TEntity, TDbContext> : IRepo<TEntity, TDbContext>
        where TEntity : BaseEntity
        where TDbContext : DbContext
    {
        protected readonly TDbContext context;

        public Repo(TDbContext context)
        {
            this.context = context;
        }

        public DbSet<TEntity> Table => context.Set<TEntity>();

        #region Query
        public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> where, bool AsNoTracking = true)
        {
            return AsNoTracking ? Table.AsNoTracking().Where(where) : Table.Where(where);
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> where, bool AsNoTracking = true)
        {
            return AsNoTracking ? await Table.AsNoTracking().FirstOrDefaultAsync(where) : await Table.FirstOrDefaultAsync(where);
        }
        #endregion

        #region Command
        public async Task<bool> AddAsync(TEntity data)
        {
            EntityEntry<TEntity> entityEntry = await Table.AddAsync(data);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddAsync(List<TEntity> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public bool Update(TEntity data)
        {
            EntityEntry<TEntity> entityEntry = Table.Update(data);
            return entityEntry.State == EntityState.Modified;
        }

        public bool Update(List<TEntity> datas)
        {
            Table.UpdateRange(datas);
            return true;
        }

        public bool Delete(TEntity data)
        {
            EntityEntry<TEntity> entityEntry = Table.Remove(data);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool Delete(List<TEntity> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }
        #endregion
    }
}
