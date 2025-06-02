using Microsoft.Extensions.Configuration;
using OgrenciKayitSistemi.Application.Abstractions;
using OgrenciKayitSistemi.Application.Abstractions.EfCore.UnitOfWork;
using OgrenciKayitSistemi.Application.DTOs.Models;
using OgrenciKayitSistemi.Application.DTOs.Models.Ortak;
using OgrenciKayitSistemi.Application.DTOs.Params;
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
        private readonly IConfiguration Configuration;

        public OgrenciKayitSistemiService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            Configuration = configuration;
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


    }
}
