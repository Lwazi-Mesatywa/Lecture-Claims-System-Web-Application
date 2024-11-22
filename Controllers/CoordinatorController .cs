using FluentValidation;
using Lecture_Claims_System_Web_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lecture_Claims_System_Web_Application.Controllers
{
    public class CoordinatorsController : Controller
    {
        private readonly IValidator<Claim> _claimValidator;

        public CoordinatorsController(IValidator<Claim> claimValidator)
        {
            _claimValidator = claimValidator; // Inject FluentValidation dependency
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new CoordinatorSettingsViewModel
            {
                MinHoursWorked = 10,
                MaxHourlyRate = 2000,  // Default value
                Claims = ClaimRepository.Instance.GetAllClaims() // Get all claims for the coordinator
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(CoordinatorSettingsViewModel model)
        {
            // Process claims based on the thresholds set by the coordinator
            var claimsToProcess = ClaimRepository.Instance.GetAllClaims()
                .Where(c => c.Status == "Pending")
                .ToList();

            // Create a new validator using the coordinator's settings
            var claimValidator = new ClaimValidator(model.MinHoursWorked, model.MaxHourlyRate);

            foreach (var claim in claimsToProcess)
            {
                // Validate each claim using FluentValidation with the coordinator's thresholds
                var validationResult = claimValidator.Validate(claim);

                if (validationResult.IsValid)
                {
                    // If valid, set claim status to Approved
                    claim.Status = "Approved";
                }
                else
                {
                    // If not valid, set claim status to Rejected
                    claim.Status = "Rejected";
                }

                // Update claim status in the repository
                ClaimRepository.Instance.UpdateClaim(claim);
            }

            // After processing, refresh the claims
            model.Claims = ClaimRepository.Instance.GetAllClaims();
            return View(model);
        }
    }
}


