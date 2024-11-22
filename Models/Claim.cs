using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_Claims_System_Web_Application
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
        public string Status { get; set; } // Pending, Approved, Rejected
        public bool HasFileAttachment { get; set; }

        public DateTime ClaimDate { get; set; } = DateTime.Now;

        public byte[] FileAttachment { get; set; }

        // Parameterless constructor for object initializers
        public Claim() { }

        public Claim(string lecturerUsername, DateTime claimDate, double hoursWorked, double hourlyRate, double amount, string status, bool hasFileAttachment, byte[] fileContent, string notes)
        {
            LecturerUsername = lecturerUsername;
            ClaimDate = claimDate;
            HoursWorked = hoursWorked;
            HourlyRate = hourlyRate;
            Amount = amount;
            Status = status;
            HasFileAttachment = hasFileAttachment;
            FileAttachment = fileContent;
            Notes = notes;
        }
    }
}
