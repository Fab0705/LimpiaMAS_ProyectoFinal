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

        public IActionResult new_limp(TbLimpiador obj, IFormFile FotoLimpiador)
        {
            // se selecciono algun archivo?
            if (FotoLimpiador != null && FotoLimpiador.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    FotoLimpiador.CopyTo(memoryStream);
                    byte[] fotoBytes = memoryStream.ToArray();
                    Console.WriteLine("Bytes: " + BitConverter.ToString(fotoBytes));
                    //asignamos la foto a nuestro modelo
                    obj.FotLimp = fotoBytes;
                }
            }
            _register.add_limp(obj);
            return RedirectToAction("login", "Limpia");
        }
    }
}
