using OgrenciKayitSistemi.Application.Abstractions.EfCore.Repositories;
using OgrenciKayitSistemi.Domain.Entities;
using OgrenciKayitSistemi.Persistence.EfCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciKayitSistemi.Persistence.EfCore.Repositories
{
    public class DersRepo : Repo<DersTablo, OgrenciKayitDbContext>, IDersRepo
    {
        public DersRepo(OgrenciKayitDbContext context) : base(context) { }
    }
}
