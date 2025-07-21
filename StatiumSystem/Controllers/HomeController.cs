
using Microsoft.AspNetCore.Mvc;

namespace StatiumSystem.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }
    }
}
