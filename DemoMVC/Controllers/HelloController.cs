using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string fullName)
        {
            ViewBag.Message = "Xin chào " + fullName;
            return View();
        }
    }
}

