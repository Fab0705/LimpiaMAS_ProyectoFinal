using LimpiaMAS.Models;
using LimpiaMAS.Service;
using Microsoft.AspNetCore.Mvc;

namespace LimpiaMAS.Controllers
{
    public class RegisterController : Controller
    {
        private readonly iRegister _register;
        public RegisterController(iRegister register)
        {
            _register = register;
        }

        public IActionResult new_usr(TbUser obj)
        {
            _register.add_usr(obj);
            return RedirectToAction("login", "Limpia");
        }
    }
}
