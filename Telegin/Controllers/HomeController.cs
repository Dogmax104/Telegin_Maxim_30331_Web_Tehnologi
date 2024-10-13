using Microsoft.AspNetCore.Mvc;

namespace Telegin.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
