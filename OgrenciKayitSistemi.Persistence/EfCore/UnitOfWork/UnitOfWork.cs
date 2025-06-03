using Microsoft.EntityFrameworkCore.Storage;
using OgrenciKayitSistemi.Domain.Abstractions.EfCore.Repositories;
using OgrenciKayitSistemi.Domain.Abstractions.EfCore.UnitOfWork;
using OgrenciKayitSistemi.Persistence.EfCore.Context;
using OgrenciKayitSistemi.Persistence.EfCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciKayitSistemi.Persistence.EfCore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected OgrenciKayitDbContext ogrenciKayitDbContext;
        private IDersRepo? DersRepo;
        private IOgrenciRepo? OgrenciRepo;

        public UnitOfWork(OgrenciKayitDbContext ogrenciKayitDbContext)
        {
            this.ogrenciKayitDbContext = ogrenciKayitDbContext;
        }

        public IDersRepo _DersRepo => DersRepo ??= new DersRepo(ogrenciKayitDbContext);
        public IOgrenciRepo _OgrenciRepo => OgrenciRepo ??= new OgrenciRepo(ogrenciKayitDbContext);

        public async Task<int> CommitAsync()
        {
            using (IDbContextTransaction transaction = ogrenciKayitDbContext.Database.BeginTransaction())
            {
                try
                {
                    int affectRow = await ogrenciKayitDbContext.SaveChangesAsync();
                    transaction.Commit();

                    return affectRow;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception($"Db save changes error {e.InnerException?.Message ?? e.Message}");
                }
            }
        }

        public void Dispose()
        {
            ogrenciKayitDbContext.Dispose();
        }
    }
}
