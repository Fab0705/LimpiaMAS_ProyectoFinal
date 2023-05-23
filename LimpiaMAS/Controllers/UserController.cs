using LimpiaMAS.Models;
using LimpiaMAS.Service;
using Microsoft.AspNetCore.Mvc;

namespace LimpiaMAS.Controllers
{
    public class UserController : Controller
    {
        private readonly iUsuario _usuario;
        public UserController(iUsuario usuario)
        {
            _usuario = usuario;
        }

        public IActionResult IndexUser()
        {
            return View(_usuario.GetAllUsers());
        }

        public IActionResult Nuevo()
        {
            return View();
        }

        public IActionResult grabar(TbUser user)
        {
            _usuario.add(user);
            return RedirectToAction("IndexUser");
        }
    }
}
