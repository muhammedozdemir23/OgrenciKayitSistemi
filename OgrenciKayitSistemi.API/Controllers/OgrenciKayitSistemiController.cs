using Microsoft.AspNetCore.Mvc;
using OgrenciKayitSistemi.Application.Abstractions.Services;
using OgrenciKayitSistemi.Application.DTOs.Params;

namespace OgrenciKayitSistemi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OgrenciKayitSistemiController : ControllerBase
    {
        private readonly IOgrenciKayitSistemiService ogrenciKayitSistemiService;

        public OgrenciKayitSistemiController(IOgrenciKayitSistemiService ogrenciKayitSistemiService)
        {
            this.ogrenciKayitSistemiService = ogrenciKayitSistemiService;
        }

        #region DersTablo İşlemleri
        [HttpPost("[Action]")]
        public async Task<IActionResult> DersListesiGetir()
        {
            try
            {
                var sonuc = await ogrenciKayitSistemiService.DersListesiGetir();
                return Ok(sonuc);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost("[Action]")]
        public async Task<IActionResult> DersEkle(DersEklePar p)
        {
            try
            {
                var sonuc = await ogrenciKayitSistemiService.DersEkle(p);
                return Ok(sonuc);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost("[Action]")]
        public async Task<IActionResult> DersGuncelle(DersGuncellePar p)
        {
            try
            {
                var sonuc = await ogrenciKayitSistemiService.DersGuncelle(p);
                return Ok(sonuc);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost("[Action]")]
        public async Task<IActionResult> DersSil(DersSilPar p)
        {
            try
            {
                var sonuc = await ogrenciKayitSistemiService.DersSil(p);
                return Ok(sonuc);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        #endregion


    }
}
