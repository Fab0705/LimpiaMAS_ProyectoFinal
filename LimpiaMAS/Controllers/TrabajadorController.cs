using LimpiaMAS.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LimpiaMAS.Controllers
{
    public class TrabajadorController : Controller
    {
        public IActionResult FormTrabajador()
        {
            var objSession = HttpContext.Session.GetString("sUsuario");
            if (objSession != null)
            {
                //Deserializar
                var obj1 = JsonConvert.DeserializeObject<TbUser>(HttpContext.Session.GetString("sUsuario"));
                return View();
            }
            return RedirectToAction("login", "Limpia");
        }
    }
}
