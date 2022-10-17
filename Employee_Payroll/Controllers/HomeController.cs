using Microsoft.AspNetCore.Mvc;

namespace Employee_Payroll.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
