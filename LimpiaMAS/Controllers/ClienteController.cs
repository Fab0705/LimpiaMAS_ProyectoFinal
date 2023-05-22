using LimpiaMAS.Service;
using LimpiaMAS.Models;
using Microsoft.AspNetCore.Mvc;

namespace LimpiaMAS.Controllers
{
    public class ClienteController : Controller
    {
        private readonly iCliente _Cliente;
        public ClienteController(iCliente cliente)
        { 
            _Cliente = cliente;
        }
        public IActionResult Index()
        {
            return View(_Cliente.GetAllClientes());
        }
        [Route("Cliente/Eliminar/{Id}")]
        public IActionResult eliminar(string id) {
            _Cliente.Remove(id);
             return RedirectToAction("IndexACliente");
        }
        public IActionResult nuevo() 
        {
            return View();
        }
        public IActionResult gravar(TbCliente cliente) {
            _Cliente.Add(cliente);
            return RedirectToAction("IndexAClliente");
        }
        [Route("Cliente/Editar/{Id}")]
        public IActionResult Editar(string id) {
            return View(_Cliente.edit(id));
        }
        public IActionResult editarCliente(TbCliente cliente) {
            _Cliente.EditDatails(cliente);
            return RedirectToAction("IndexACliente");
        }
    }
}
