using Microsoft.AspNetCore.Mvc;

namespace Lecture_Claims_System_Web_Application.Controllers
{
    public class HRController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // Get all claims with the status of "Accepted"
            var acceptedClaims = ClaimRepository.Instance.AllClaims
                .Where(c => c.Status == "Accepted")
                .ToList();

            // Return the view with the accepted claims
            return View(acceptedClaims);
        }
    }
}
