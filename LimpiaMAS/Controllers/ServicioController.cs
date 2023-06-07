//using AspNetCore;
using LimpiaMAS.Models;
using LimpiaMAS.Service;
using Microsoft.AspNetCore.Mvc;

namespace LimpiaMAS.Controllers
{
    public class ServicioController : Controller
    {
        private readonly iLimpiador _limpiador;
        public ServicioController(iLimpiador limpiador)
        {
            _limpiador = limpiador;
        }
        public IActionResult Index()
        {
            return View(_limpiador.GetAllCleaners());
        }

        public IActionResult Carrito()
        {
            return View();
        }
    }
}
