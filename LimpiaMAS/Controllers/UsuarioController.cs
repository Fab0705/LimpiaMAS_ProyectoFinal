using LimpiaMAS.Service;
using Microsoft.AspNetCore.Mvc;

namespace LimpiaMAS.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login", "Limpia");
        }
    }
}
