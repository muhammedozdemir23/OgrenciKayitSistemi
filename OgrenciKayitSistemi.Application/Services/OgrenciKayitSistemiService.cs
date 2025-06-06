using Microsoft.Extensions.Configuration;
using OgrenciKayitSistemi.Application.Abstractions;
using OgrenciKayitSistemi.Application.DTOs.Models;
using OgrenciKayitSistemi.Application.DTOs.Models.Ortak;
using OgrenciKayitSistemi.Application.DTOs.Params;
using OgrenciKayitSistemi.Domain.Abstractions.EfCore.UnitOfWork;
using OgrenciKayitSistemi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciKayitSistemi.Application.Services
{
    public class OgrenciKayitSistemiService : IOgrenciKayitSistemiService
    {
        private readonly IUnitOfWork unitOfWork;

        public OgrenciKayitSistemiService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #region DersTablo İşlemleri
        public async Task<ServiceResponse<List<DersListesiDto>?>> DersListesiGetir()
        {
            try
            {
                var dersListesi = unitOfWork._DersRepo.GetWhere(g => g.Tpasif == null).Select(s => new DersListesiDto()
                {
                    Id = s.Id,
                    Ad = s.Ad
                }).ToList();


                return new(true, "Başarılı", dersListesi);
            }
            catch (Exception ex)
            {
                return new(false, ex.Message, null);
            }
        }
        public async Task<ServiceResponse<string>> DersEkle(DersEklePar p)
        {
            try
            {
                if (p.DersAdi == null)
                    return new(true, "Ders Adı Boş Bırakılamaz!", null);

                DersTablo dersEkle = new DersTablo()
                {
                    Ad = p.DersAdi,
                    Taktif = DateTime.Now,
                };

                await unitOfWork._DersRepo.AddAsync(dersEkle);
                await unitOfWork.CommitAsync();


                return new(true, "Kayıt Başarılı", null);
            }
            catch (Exception ex)
            {
                return new(false, ex.Message, null);
            }
        }
        public async Task<ServiceResponse<string>> DersGuncelle(DersGuncellePar p)
        {
            try
            {
                if (p.DersId == null && p.DersAdi == null)
                    return new(true, "Alanlar Boş Bırakılamaz!", null);

                var guncellenecekDersGetir = unitOfWork._DersRepo.GetWhere(g => g.Tpasif == null && g.Id == p.DersId).FirstOrDefault();

                guncellenecekDersGetir.Ad = p.DersAdi;
                guncellenecekDersGetir.Taktif = DateTime.Now;
                unitOfWork._DersRepo.Update(guncellenecekDersGetir);
                await unitOfWork.CommitAsync();

                return new(true, "Güncelleme Başarılı", null);
            }
            catch (Exception ex)
            {
                return new(false, ex.Message, null);
            }
        }
        public async Task<ServiceResponse<string>> DersSil(DersSilPar p)
        {
            try
            {
                if (p.DersId == null)
                    return new(true, "Silme İşlemi Başarısız", null);

                var silinecekDersGetir = unitOfWork._DersRepo.GetWhere(g => g.Tpasif == null && g.Id == p.DersId).FirstOrDefault();

                silinecekDersGetir.Tpasif = DateTime.Now;
                unitOfWork._DersRepo.Update(silinecekDersGetir);
                await unitOfWork.CommitAsync();

                return new(true, "Silme İşlemi Başarılı", null);
            }
            catch (Exception ex)
            {
                return new(false, ex.Message, null);
            }
        }
        #endregion

        #region OgrenciTablo İşlemleri
        public async Task<ServiceResponse<List<OgrenciListesiDto>?>> OgrenciListesiGetir()
        {
            try
            {
                var ogrenciListesiGetir = unitOfWork._OgrenciRepo.GetWhere(g => g.Tpasif == null).Select(s => new OgrenciListesiDto
                {
                    Ad = s.Ad,
                    Soyad = s.Soyad,
                    SinifAdi = s.Sinif.Ad
                }).ToList();

                return new(true, "Başarılı", ogrenciListesiGetir);

            }
            catch (Exception ex)
            {
                return new(false, ex.Message, null);
            }
        }

        public async Task<ServiceResponse<string>> OgrenciEkle(OgrenciEklePar p)
        {
            try
            {
                if (p.sinifId == null || p.ogrenciAd == null || p.ogrenciSoyad == null)
                    return new(true, "Alanlar boş gönderilemez!", null);

                OgrenciTablo ogrenciEkle = new OgrenciTablo()
                {
                    Ad = p.ogrenciAd,
                    Soyad = p.ogrenciSoyad,
                    SinifId = p.sinifId,
                    Taktif = DateTime.Now,
                };

                await unitOfWork._OgrenciRepo.AddAsync(ogrenciEkle);
                await unitOfWork.CommitAsync();


                return new(true, "Kayıt Başarılı", null);
            }
            catch (Exception ex)
            {
                return new(false, ex.Message, null);
            }
        }

<<<<<<< HEAD
=======
        public async Task<ServiceResponse<string>> OgrenciGuncelle(OgrenciGuncellePar p){
            try
            {
                if (p.ogrenciAd == null || p.ogrenciSoyad == null || p.sinifId==null || p.ogrenciId)
                    return new(true, "Boş veri gönderilemez!", null);

                var guncellenecekOgrenciGetir = unitOfWork._OgrenciReposRepo.GetWhere(g => g.Tpasif == null && g.Id == p.ogrenciId).FirstOrDefault();

                guncellenecekOgrenciGetir.Ad = p.ogrenciAd;
                guncellenecekOgrenciGetir.Soyad = p.ogrenciSoyad;
                guncellenecekOgrenciGetir.SinifId = p.sinifId;
                guncellenecekOgrenciGetir.Taktif = DateTime.Now;
                unitOfWork._DersRepo.Update(guncellenecekOgrenciGetir);
                await unitOfWork.CommitAsync();

                return new(true, "Güncelleme Başarılı", null);
            }
            catch (Exception ex)
            {
                return new(false, ex.Message, null);
            }
        }

>>>>>>> 3b29d94 (ogrenci guncelle)

        #endregion


    }
}
