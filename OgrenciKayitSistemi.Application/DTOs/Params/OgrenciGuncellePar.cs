using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciKayitSistemi.Application.DTOs.Params
{
    public class OgrenciGuncellePar
    {
        public long ogrenciId { get; set; }

        public long sinifId { get; set; }

        public string ogrenciAd { get; set; }

        public string ogrenciSoyad { get; set; }
    }
}
