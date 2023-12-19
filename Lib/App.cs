using System.Runtime.InteropServices;
using Lib.models;

namespace Lib
{
    public class App
    {
        private User? _LoggedInUser = null;
        private List<User> _users = new List<User>();

        public App()
        {
        }

        public List<User> Users
        {
            get { return _users; }
            set {}
        }

        public User? LoggedInUser
        {
            get { return _LoggedInUser; }
            set { _LoggedInUser = value; }
        }

        public void PrintBanner()
        {
            Console.Clear();
            Console.WriteLine("Restaurant Review App\n");
        }

        public void PrintMenu()
        {
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Add new user");
            Console.WriteLine();

            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            PrintBanner();
            if (choice == 1) {
                Login();
            } else if (choice == 2) {
                AddUser();
            }
        }
        /// <summary>
        /// Logs in a user by prompting for a username and password.
        /// </summary>
        /// <remarks>
        /// This method continues to prompt for a username and password until a valid user is logged in.
        /// </remarks>
        private void Login()
        {
            while (_LoggedInUser == null)
            {
                // Find the user with the given username

                Console.Write("Enter username: ");
                string inputUserName = Console.ReadLine();


                Console.Write("Enter password: ");
                string inputPassword = Console.ReadLine();

                User? user = _users.Find(u => u.UserName == inputUserName);
                // Print the application banner
                PrintBanner();
                // Validate user credentials
                if (user != null && user.ValidateCredentials(inputUserName, inputPassword))
                {
                    _LoggedInUser = user;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Welcome, {_LoggedInUser.UserName}.\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid username or password. Please try again.\n");
                    Console.ResetColor();
                }
            }
        }
        /// <summary>
        /// Adds a new user based on user input for username, password, and role.
        /// </summary>
        /// <remarks>
        /// This method prompts the user for a username, password, and role (Regular or Admin).
        /// The user is added to the user collection, and a success message is displayed.
        /// </remarks>
        private void AddUser()
        {
            Console.Write("Enter username: ");
            string inputUserName = Console.ReadLine();

            Console.Write("Enter password: ");
            string inputPassword = Console.ReadLine();

            Console.Write("Enter role (Regular = 1, Admin = 2): ");
            Role inputRole = Role.Regular;
            if (int.TryParse(Console.ReadLine(), out int roleNum))
            {
                if (Enum.IsDefined(typeof(Role), roleNum))
                {
                    inputRole = (Role)roleNum;
                }
            }
            
            PrintBanner();
            if (inputRole == Role.Regular)
            {
                User user = new User(_users.Count(), inputUserName, inputPassword);
                _users.Add(user);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Regular user \"{user.UserName}\" added successfully.\n");
                Console.ResetColor();
            } else if (inputRole == Role.Admin)
            {
                // Create and add a new admin user
                Admin admin = new Admin(_users.Count(), inputUserName, inputPassword);
                _users.Add(admin);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Admin \"{admin.UserName}\" added successfully.\n");
                Console.ResetColor();
            }
            // Print the main menu

            PrintMenu();
        }
    }
}
