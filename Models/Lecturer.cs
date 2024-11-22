using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecturer_Monthly_Claims__ST10092086
{
    public class Lecturer: User
    {
        public string Username { get; set; }
        public ObservableCollection<Claim> Claims { get; set; }

        // Constructor that accepts username and password
        public Lecturer(string username, string password) : base()
        {
            Username = username;
            Password = password;  // Assuming Password is defined in User class
            Claims = ClaimRepository.Instance.AllClaims;
            Role = "Lecturer"; // Ensure Role is set correctly
        }

        public void SubmitClaim(Claim claim)
        {
            Claims.Add(claim);
        }
    }
}
