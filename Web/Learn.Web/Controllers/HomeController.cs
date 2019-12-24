using Microsoft.AspNetCore.Mvc;

namespace Learn.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdminDesktop()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

    }
}