using FluentValidation;
using System.Security.Claims;

namespace Lecture_Claims_System_Web_Application
{
    public class ClaimValidator : AbstractValidator<Claim>
    {
        public ClaimValidator(double minHoursWorked, double maxHourlyRate)
        {
            // Validate hours worked based on coordinator's MinHoursWorked
            RuleFor(c => c.HoursWorked)
                .GreaterThanOrEqualTo(minHoursWorked).WithMessage($"Hours worked must be at least {minHoursWorked}.");

            // Validate hourly rate based on coordinator's MaxHourlyRate
            RuleFor(c => c.HourlyRate)
                .LessThanOrEqualTo(maxHourlyRate).WithMessage($"Hourly rate must not exceed {maxHourlyRate}.");

        }
        
    }
}
