using Microsoft.AspNetCore.Mvc;
namespace DemoMVC.Controllers
{
public class ViewBagController :  Controller 
{
    public IActionResult Index()
    {
        ViewBag.Message = " Ví dụ truyền từ Controller sang View";
        return View();

    }
}
}
// FFHFJ