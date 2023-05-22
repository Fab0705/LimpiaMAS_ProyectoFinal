using Microsoft.AspNetCore.Mvc;

namespace LimpiaMAS.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
