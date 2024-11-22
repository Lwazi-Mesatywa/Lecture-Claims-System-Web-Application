using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecturer_Monthly_Claims__ST10092086
{
    public class Claim
    {
        public int Id { get; set; }

        [Required]
        public string LecturerUsername { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Hours worked must be between 1 and 1000.")]
        public double HoursWorked { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Hourly rate must be between 1 and 1000.")]
        public double HourlyRate { get; set; }

        [Required]
        public double Amount { get; set; }

        public string Notes { get; set; }

        public DateTime ClaimDate { get; set; } = DateTime.Now;

        public byte[] FileAttachment { get; set; }
    }
}
