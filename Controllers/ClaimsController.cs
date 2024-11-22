using Lecture_Claims_System_Web_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Lecture_Claims_System_Web_Application;

namespace Lecture_Claims_System_Web_Application.Controllers
{
    public class ClaimsController : Controller
    {
        // GET: ClaimsController
        private static List<Claim> _claims = new List<Claim>();

        [HttpGet]
        public IActionResult SubmitClaim()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitClaim(ClaimViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Calculate claim amount
                double claimAmount = model.HoursWorked * model.HourlyRate;

                // Convert file to byte array if uploaded
                byte[] fileContent = null;
                if (model.FileAttachment != null)
                {
                    using (var stream = model.FileAttachment.OpenReadStream())
                    {
                        using (var memoryStream = new System.IO.MemoryStream())
                        {
                            stream.CopyTo(memoryStream);
                            fileContent = memoryStream.ToArray();
                        }
                    }
                }

                // Create a new claim and add it to the list
                Claim newClaim = new Claim
                {
                    LecturerUsername = "lecturer1",
                    HoursWorked = model.HoursWorked,
                    HourlyRate = model.HourlyRate,
                    Amount = claimAmount,
                    Notes = model.Notes,
                    FileAttachment = fileContent,
                    ClaimDate = DateTime.Now
                };

                _claims.Add(newClaim);

                return RedirectToAction("ViewClaims");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult DownloadAttachment(int id)
        {
            var claim = _claims.FirstOrDefault(c => c.Id == id);
            if (claim != null && claim.FileAttachment != null)
            {
                return File(claim.FileAttachment, "application/octet-stream", "attachment");
            }

            return NotFound("File not found.");
        }


        [HttpGet]
        public IActionResult ViewClaims()
        {
            return View(_claims);
        }
    }
}
