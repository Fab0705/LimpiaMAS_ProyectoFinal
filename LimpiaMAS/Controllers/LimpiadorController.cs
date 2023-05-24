using LimpiaMAS.Models;
using LimpiaMAS.Service;
using Microsoft.AspNetCore.Mvc;


namespace LimpiaMAS.Controllers
{
    public class LimpiadorController : Controller
    {
        private readonly iLimpiador _Limpiador;
        public LimpiadorController(iLimpiador Limpiador)
        {
            _Limpiador = Limpiador;
        }
        public IActionResult IndexLimpiador()
        {
            return View(_Limpiador.GetAllCleaners());
        }
        public IActionResult NewLimp()
        {
            return View();
        }
        public IActionResult grabar(TbLimpiador limp, IFormFile? FotoLimpiador)
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
                    limp.FotLimp = fotoBytes;
                }
            }
            _Limpiador.add(limp);
            return RedirectToAction("IndexLimpiador");
        }


        [Route("Limpiador/Editar/{Id}")]
        public IActionResult Editar(string id) 
        {
            return View(_Limpiador.edit(id));
        }
        public IActionResult editarLimp(TbLimpiador limpiador, IFormFile? FotoLimpiador) 
        {
            /*if (FotoLimpiador != null && FotoLimpiador.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    FotoLimpiador.CopyTo(memoryStream);
                    byte[] fotoBytes = memoryStream.ToArray();
                    Console.WriteLine("Bytes: " + BitConverter.ToString(fotoBytes));
                    //asignamos la foto a nuestro modelo
                    limpiador.FotLimp = fotoBytes;
                }
            }*/
            _Limpiador.EditDatails(limpiador);
            return RedirectToAction("IndexLimpiador");
        }
        [Route("Limpiador/Eliminar/{Id}")]
        public IActionResult eliminar(string id)
        {
            _Limpiador.remove(id);
            return RedirectToAction("IndexLimpiador");
        }
        public IActionResult returnIndexAdmin()
        {
            return View("~/Views/Admin/Index.cshtml");
        }
    }
}
