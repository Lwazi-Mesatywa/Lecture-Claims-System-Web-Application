using Lecture_Claims_System_Web_Application;

namespace Lecture_Claims_System_Web_Application.Models
{
    public class CoordinatorSettingsViewModel
    {
        public double MinHoursWorked { get; set; } // Minimum hours for automatic approval
        public double MaxHourlyRate { get; set; } // Maximum hourly rate for automatic approval
        public IEnumerable<Claim> Claims { get; set; } // Claims to display
    }

}
