using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;
using DemoMVC.Data; 
using System.Linq;



namespace DemoMVC.Controllers
{
    public class StudentController : Controller

    {
        private readonly ApplicationDbContext _context;

public StudentController(ApplicationDbContext context)
{
    _context = context;
}
        public IActionResult Index()
        {
                var students = _context.Students.ToList();

                 return View(students);

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