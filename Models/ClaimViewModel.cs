using System.ComponentModel.DataAnnotations;

namespace Lecture_Claims_System_Web_Application.Models
{
    public class ClaimViewModel
    {
        [Required]
        [Range(1, 1000)]
        public double HoursWorked { get; set; }

        [Required]
        [Range(1, 1000)]
        public double HourlyRate { get; set; }

        public string Notes { get; set; }

        public IFormFile FileAttachment { get; set; }
    }
}
