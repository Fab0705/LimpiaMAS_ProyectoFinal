using LimpiaMAS.Models;
using LimpiaMAS.Service;
using Microsoft.AspNetCore.Mvc;

namespace LimpiaMAS.Controllers
{
    public class LoginController : Controller
    {
        private readonly iLogeo _logeo;
        public LoginController(iLogeo logeo) 
        { 
            _logeo = logeo;
        }

        public IActionResult Logeo(TbUser obj)
        {
            if (_logeo.LoginComparision(obj) == 1)
            {
                //Crear variable de sesion
                //HttpContext.Session.SetString("sUsuario",);
                return View("~/Views/Usuario/Index.cshtml");
            }
            else if(_logeo.LoginComparision(obj) == 2)
            {
                return View("~/Views/Admin/Index.cshtml");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
