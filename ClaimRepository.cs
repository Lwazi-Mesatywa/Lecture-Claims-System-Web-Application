using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_Claims_System_Web_Application
{
    public class ClaimRepository
    {
        private static ClaimRepository _instance;
        private static readonly object _lock = new object();

        // ObservableCollection to hold all claims
        public List<Claim> AllClaims { get; private set; }

        // Private constructor to prevent instantiation from outside
        //using Singleton pattern to ensure the same copy of this Collection is made and used
        private ClaimRepository()
        {
            AllClaims = new List<Claim>();
        }

        // Public method to access the instance
        public static ClaimRepository Instance
        {
            get
            {
                lock (_lock)
                {
                    // Create a new instance if it doesn't exist
                    if (_instance == null)
                    {
                        _instance = new ClaimRepository();
                    }
                    return _instance;
                }
            }
        }

        // Method to add a claim
        public void AddClaim(Claim claim)
        {
            AllClaims.Add(claim);
        }

        // Method to remove a claim
        public void RemoveClaim(Claim claim)
        {
            AllClaims.Remove(claim);
        }

        public void PreloadClaims()
        {
            
            {
                AllClaims = new List<Claim>
                {
                 new Claim("lecturer1", DateTime.Now, 20, 30, 600, "Pending", false, null, "No attachment"),
                new Claim("lecturer2", DateTime.Now, 25, 35, 875, "Pending", false, null, "No attachment"),
                new Claim("lecturer3", DateTime.Now, 30, 40, 1200, "Pending", false, null, "No attachment")
                };
            }
        }

        public List<Claim> GetAllClaims()
        {
            return AllClaims;
        }


        public bool UpdateClaim(Claim updatedClaim)
        {
            // Find the claim by its unique identifier (e.g., Id)
            var existingClaim = AllClaims.FirstOrDefault(c => c.Id == updatedClaim.Id);
            if (existingClaim == null)
            {
                return false; // Claim not found
            }

            // Update fields
            existingClaim.LecturerUsername = updatedClaim.LecturerUsername;
            existingClaim.ClaimDate = updatedClaim.ClaimDate;
            existingClaim.Amount = updatedClaim.Amount;
            existingClaim.Status = updatedClaim.Status;
            existingClaim.HasFileAttachment = updatedClaim.HasFileAttachment;
            existingClaim.FileAttachment = updatedClaim.FileAttachment;
            existingClaim.Notes = updatedClaim.Notes;
            existingClaim.HoursWorked = updatedClaim.HoursWorked;
            existingClaim.HourlyRate = updatedClaim.HourlyRate;

            return true; // Update successful
        }
    }
}
