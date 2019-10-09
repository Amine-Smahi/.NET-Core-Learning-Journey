using System.Diagnostics;
using EmployeeManagement.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
