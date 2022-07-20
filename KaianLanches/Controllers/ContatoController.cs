using Microsoft.AspNetCore.Mvc;

namespace KaianLanches.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View(); 
        }
    }
}
