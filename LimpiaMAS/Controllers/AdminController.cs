using Microsoft.AspNetCore.Mvc;
using LimpiaMAS.Models;
using Newtonsoft.Json;

namespace LimpiaMAS.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            var objSession = HttpContext.Session.GetString("sUsuario");
            if (objSession != null)
            {
                //Deserializar
                var obj = JsonConvert.DeserializeObject<TbUser>(HttpContext.Session.GetString("sUsuario"));
                return View();
            }
            return View("~/Views/Limpia/login.cshtml");
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return View("~/Views/Limpia/login.cshtml");
        }
    }
}
