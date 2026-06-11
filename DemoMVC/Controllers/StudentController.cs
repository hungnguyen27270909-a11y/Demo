using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Student student)
        {
            ViewBag.Message =
                $"Mã SV: {student.StudentCode} - Họ tên: {student.FullName}";

            return View();
        }
    }
}