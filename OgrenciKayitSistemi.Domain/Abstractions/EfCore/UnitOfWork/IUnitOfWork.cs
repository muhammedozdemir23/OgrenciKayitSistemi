using OgrenciKayitSistemi.Domain.Abstractions.EfCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciKayitSistemi.Domain.Abstractions.EfCore.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IDersRepo _DersRepo { get; }



        Task<int> CommitAsync();
    }
}
