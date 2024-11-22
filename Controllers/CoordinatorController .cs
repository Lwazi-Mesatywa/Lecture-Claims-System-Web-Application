using Microsoft.AspNetCore.Mvc;

namespace Lecture_Claims_System_Web_Application.Controllers
{
    public class CoordinatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
