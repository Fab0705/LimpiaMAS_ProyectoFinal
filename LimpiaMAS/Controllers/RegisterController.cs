using LimpiaMAS.Models;
using LimpiaMAS.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        public IActionResult new_limp(TbLimpiador obj, IFormFile? FotoLimpiador)
        {
            // se selecciono algun archivo?
            if (FotoLimpiador != null && FotoLimpiador.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    FotoLimpiador.CopyTo(memoryStream);
                    byte[] fotoBytes = memoryStream.ToArray();
                    //asignamos la foto a nuestro modelo
                    obj.FotLimp = fotoBytes;
                }
            }
            else
            {
                Console.WriteLine("NO HAY FOTO");
            }
            /*datos para que me deje ingresar limpiador
            obj.Usr = "mongo";
            obj.Pwd = "db";*/
            obj.ServLimp = JsonConvert.SerializeObject(obj.ServiciosAJSON);
            _register.add_limp(obj);
            return RedirectToAction("login", "Limpia");
        }
    }
}
