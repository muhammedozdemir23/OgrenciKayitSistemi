using OgrenciKayitSistemi.Domain.Abstractions.EfCore.Repositories;
using OgrenciKayitSistemi.Domain.Entities;
using OgrenciKayitSistemi.Persistence.EfCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciKayitSistemi.Persistence.EfCore.Repositories
{
    public class OgrenciRepo : Repo<OgrenciTablo,OgrenciKayitDbContext>, IOgrenciRepo
    {
        public OgrenciRepo(OgrenciKayitDbContext context) :base(context) { }
    }
}
