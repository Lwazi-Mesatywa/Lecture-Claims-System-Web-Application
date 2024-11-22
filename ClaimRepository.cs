﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecturer_Monthly_Claims__ST10092086
{
    public class ClaimRepository
    {
        private static ClaimRepository _instance;
        private static readonly object _lock = new object();

        // ObservableCollection to hold all claims
        public ObservableCollection<Claim> AllClaims { get; private set; }

        // Private constructor to prevent instantiation from outside
        //using Singleton pattern to ensure the same copy of this Collection is made and used
        private ClaimRepository()
        {
            AllClaims = new ObservableCollection<Claim>();
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
            
        }
    }
}
