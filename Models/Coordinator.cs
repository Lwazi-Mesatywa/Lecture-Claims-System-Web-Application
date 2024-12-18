﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_Claims_System_Web_Application
{
    public class Coordinator: User
    {
        public HashSet<string> LecturerUsernames { get; set; }

        // Constructor
        public Coordinator(string username, string password)
        {
            Username = username;
            Password = password;
            Role = "Coordinator"; // Assign role
            LecturerUsernames = new HashSet<string>();
        }

        public bool RegisterLecturer(string username)
        {

            return LecturerUsernames.Add(username);
        }

        public void ApproveClaim(Claim claim)
        {
            claim.Status = "Approved";
        }

        public void RejectClaim(Claim claim)
        {
            claim.Status = "Rejected";
        }
    }
}
