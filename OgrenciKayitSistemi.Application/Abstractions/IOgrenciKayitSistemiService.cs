using OgrenciKayitSistemi.Application.DTOs.Models;
using OgrenciKayitSistemi.Application.DTOs.Models.Ortak;
using OgrenciKayitSistemi.Application.DTOs.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciKayitSistemi.Application.Abstractions
{
    public interface IOgrenciKayitSistemiService
    {
        #region DersTablo İşlemleri
        Task<ServiceResponse<List<DersListesiDto>?>> DersListesiGetir();
        Task<ServiceResponse<string>> DersEkle(DersEklePar p);
        Task<ServiceResponse<string>> DersGuncelle(DersGuncellePar p);
        Task<ServiceResponse<string>> DersSil(DersSilPar p);
        #endregion

        #region OgrenciTablo İşlemleri
        Task<ServiceResponse<List<OgrenciListesiDto>?>> OgrenciListesiGetir();
        Task<ServiceResponse<string>> OgrenciEkle(OgrenciEklePar p);
        Task<ServiceResponse<string>> OgrenciGuncelle(OgrenciGuncellePar p);
        Task<ServiceResponse<string>> OgrenciSil(OgrenciSilPar p);
        #endregion
    }
}
