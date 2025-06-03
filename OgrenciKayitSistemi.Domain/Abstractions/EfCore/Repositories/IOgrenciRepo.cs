using OgrenciKayitSistemi.Domain.Abstractions.EfCore.Context;
using OgrenciKayitSistemi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciKayitSistemi.Domain.Abstractions.EfCore.Repositories
{
    public interface IOgrenciRepo : IRepo<OgrenciTablo,BaseOgrenciKayitDbContext>
    {
    }
}
