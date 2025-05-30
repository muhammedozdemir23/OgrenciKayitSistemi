using Microsoft.AspNetCore.Mvc;

namespace OgrenciKayitSistemi.API.Controllers
{
    public class OgrenciKayitSistemiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
