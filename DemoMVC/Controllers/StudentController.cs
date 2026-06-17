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

        // 🔹 Hiển thị danh sách
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        // 🔹 Hiển thị form Create
        public IActionResult Create()
        {
            return View();
        }

        // 🔹 Xử lý Create (VALIDATION BUỔI 7)
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // 🔹 Hiển thị form Edit
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // 🔹 Xử lý Edit (VALIDATION BUỔI 7)
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // 🔹 Hiển thị form Delete
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // 🔹 Xác nhận Delete
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}