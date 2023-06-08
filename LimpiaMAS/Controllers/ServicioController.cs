//using AspNetCore;
using LimpiaMAS.Models;
using LimpiaMAS.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LimpiaMAS.Controllers
{
    public class ServicioController : Controller
    {
        private readonly iLimpiador _limpiador;
        private readonly iCliente _cliente;
        public ServicioController(iLimpiador limpiador, iCliente cliente)
        {
            _limpiador = limpiador;
            _cliente = cliente;
        }
        public IActionResult Index()
        {
            return View(_limpiador.GetAllCleaners());
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login", "Limpia");
        }

        public IActionResult Carrito()
        {            
            var objSession = HttpContext.Session.GetString("sUsuario");
            if (objSession != null)
            {
                //Deserializar
                TbUser usuario = JsonConvert.DeserializeObject<TbUser>(objSession);
                TbUser usr = _cliente.getUser(usuario.Usr, usuario.Pwd);

                if (_cliente.SearchCli(usr.Usr, usr.Pwd) == false)
                {
                    return RedirectToAction("FormCliente", "Cliente");
                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("Login", "Limpia");
        }
    }
}
