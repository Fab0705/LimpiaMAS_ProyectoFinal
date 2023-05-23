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
        public IActionResult Index()
        {
            return View(_Limpiador.GetAllCleaners());
        }
        public IActionResult NewLimp()
        {
            return View();
        }
        public IActionResult grabar(TbLimpiador limp)
        {
            _Limpiador.add(limp);
            return RedirectToAction("Index");
        }
        [Route("Limpiador/Editar/{Id}")]
        public IActionResult Editar(string id) 
        {
            return View(_Limpiador.edit(id));
        }
        public IActionResult editarLimp(TbLimpiador limpiador) 
        {
            _Limpiador.EditDatails(limpiador);
            return RedirectToAction("Index");
        }
    }
}
