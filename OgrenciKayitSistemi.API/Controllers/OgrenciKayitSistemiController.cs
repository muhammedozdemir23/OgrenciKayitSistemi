using Microsoft.AspNetCore.Mvc;
using OgrenciKayitSistemi.Application.Abstractions;
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

        #region OgrenciTablo İşlemleri
        [HttpPost("[Action]")]
        public async Task<IActionResult> OgrenciListesiGetir()
        {
            try
            {
                var sonuc = await ogrenciKayitSistemiService.OgrenciListesiGetir();
                return Ok(sonuc);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost("[Action]")]
        public async Task<IActionResult> OgrenciEkle(OgrenciEklePar p)
        {
            try
            {
                var sonuc = await ogrenciKayitSistemiService.OgrenciEkle(p);
                return Ok(sonuc);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost("[Action]")]
        public async Task<IActionResult> OgrenciGuncelle(OgrenciGuncellePar p)
        {
            try
            {
                var sonuc = await ogrenciKayitSistemiService.OgrenciGuncelle();
                return Ok(sonuc);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost("[Action]")]
        public async Task<IActionResult> OgrenciSil(OgrenciSilPar p)
        {
            try
            {
                var sonuc = await ogrenciKayitSistemiService.OgrenciSil();
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
