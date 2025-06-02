using Microsoft.EntityFrameworkCore;
using OgrenciKayitSistemi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciKayitSistemi.Domain.Abstractions.EfCore.Repositories
{
    public interface IRepo<TEntity, TDbContext>
        where TEntity : BaseEntity
        where TDbContext : DbContext
    {
        DbSet<TEntity> Table { get; }

        #region Query
        IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> where, bool AsNoTracking = true);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where, bool AsNoTracking = true);
        #endregion

        #region Command
        Task<bool> AddAsync(TEntity data);
        Task<bool> AddAsync(List<TEntity> datas);
        bool Update(TEntity data);
        bool Update(List<TEntity> datas);
        bool Delete(TEntity data);
        bool Delete(List<TEntity> datas);
        #endregion
    }
}
