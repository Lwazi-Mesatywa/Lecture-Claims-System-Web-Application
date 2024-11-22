using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecturer_Monthly_Claims__ST10092086
{
    public class UserManager
    {
        private static HashSet<string> _usernames = new HashSet<string>();
        public static List<User> Users = new List<User>();

        // Coordinator static property
        public static Coordinator CurrentCoordinator = new Coordinator("Coord", "admin");

        public static bool RegisterUser(User user)
        {
            // Ensure the username is unique
            if (_usernames.Contains(user.Username))
            {
                return false;  // Username already exists
            }

            // Add username to HashSet and User to list
            _usernames.Add(user.Username);
            Users.Add(user);
            return true;
        }

        // Method to authenticate a user
        public static User AuthenticateUser(string username, string password)
        {
            // Find a user with matching credentials
            return Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        // Method to preload initial users for testing
        public static void PreloadUsers()
        {
            UserManager.RegisterUser(new Lecturer("lecturer1", "pass1"));
            UserManager.RegisterUser(new Lecturer("lecturer2", "pass2"));
            UserManager.RegisterUser(new Lecturer("lecturer3", "pass3"));
            UserManager.RegisterUser(new Coordinator("coordinator1", "coorpass"));
        }

        // Preload users
        public static void InitializeUsers()
        {
            // Create lecturers
            UserManager.RegisterUser(new Lecturer ("lecturer1", "password1"));
            UserManager.RegisterUser(new Lecturer ("lecturer2", "password2"));
            UserManager.RegisterUser(new Lecturer ("lecturer3", "password3"));

            // Create coordinator
            UserManager.RegisterUser(new Coordinator ("coordinator1", "passwordC"));
        }
    }
}
