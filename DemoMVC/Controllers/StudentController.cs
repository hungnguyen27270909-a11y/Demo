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

        // Hiển thị danh sách
        public IActionResult Index()
        {
            var students = _context.Students.ToList();

            return View(students);
        }

        // Hiển thị form thêm mới
        public IActionResult Create()
        {
            return View();
        }

        // Nhận dữ liệu từ form và lưu vào DB
        [HttpPost]
        public IActionResult Create(Student student)
        {
            _context.Students.Add(student);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Hiển thị form sửa
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // Nhận dữ liệu từ form sửa và lưu vào DB
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            _context.Students.Update(student);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}