using System.Runtime.InteropServices;
using Lib.models;

namespace Lib
{
    public class App
    {
        private User? _loggedInUser = null;
        private List<User> _users = new List<User>();

        public App()
        {
        }

        public List<User> Users
        {
            get { return _users; }
            set { }
        }

        public User? LoggedInUser
        {
            get { return _loggedInUser; }
            set { _loggedInUser = value; }
        }

        public void PrintBanner()
        {
            Console.Clear();
            Console.WriteLine("Restaurant Review App\n");
        }

        public void PrintMenu()
        {
            while (_loggedInUser == null)
            {
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Add new user");
                Console.WriteLine();

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                PrintBanner();
                switch(choice)
                {
                    case "1":
                        Login();
                        break;
                    case "2":
                        AddUser();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Please try again.\n");
                        Console.ResetColor();
                        break;
                }
            }
        }

        private void Login()
        {
            while (_loggedInUser == null)
            {
                Console.Write("Enter username: ");
                string inputUserName = Console.ReadLine();

                Console.Write("Enter password: ");
                string inputPassword = Console.ReadLine();

                User? user = _users.Find(u => u.UserName == inputUserName);

                PrintBanner();
                if (user != null && user.ValidateCredentials(inputUserName, inputPassword))
                {
                    _loggedInUser = user;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Welcome, {_loggedInUser.UserName}.\n");
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
            User user = new User(_users.Count(), inputUserName, inputPassword, inputRole);
            _users.Add(user);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{(inputRole == Role.Regular ? "Regular user" : "Admin")} \"{user.UserName}\" added successfully.\n");
            Console.ResetColor();
        }
    }
}
