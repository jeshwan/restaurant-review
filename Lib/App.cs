using Lib.models;

namespace Lib
{
    public class App
    {
        private User? _loggedInUser = null;
        private List<User> _users = new List<User>();
        private List<Restaurant> _restaurants = new List<Restaurant>();

        public App()
        {
            PrintBanner();
            PrintMenu();
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
                Console.WriteLine("2. Create an account");
                Console.WriteLine();

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                PrintBanner();
                switch (choice)
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

        private void PrintUserBanner()
        {
            PrintBanner();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Welcome, {_loggedInUser.UserName}.\n");
            Console.ResetColor();
        }

        public void PrintUserMenu()
        {
            PrintUserBanner();
            while (_loggedInUser != null)
            {
                if (_loggedInUser.Role == Role.Regular)
                {
                    Console.WriteLine("1. List restaurants");
                    Console.WriteLine("2. ");
                    Console.WriteLine("3. Log out");
                    Console.WriteLine();

                    Console.Write("Enter choice: ");
                    string choice = Console.ReadLine();

                    PrintUserBanner();
                    switch (choice)
                    {
                        case "1":
                            break;
                        case "2":
                            break;
                        case "3":
                            LogOut();
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid choice. Please try again.\n");
                            Console.ResetColor();
                            break;
                    }
                }
                else if (_loggedInUser.Role == Role.Admin)
                {
                    Console.WriteLine("1. Add restaurant");
                    Console.WriteLine("2. Search users");
                    Console.WriteLine("3. Log out");
                    Console.WriteLine();

                    Console.Write("Enter choice: ");
                    string choice = Console.ReadLine();

                    PrintUserBanner();
                    switch (choice)
                    {
                        case "1":
                            AddRestaurant();
                            break;
                        case "2":
                            SearchUsers();
                            break;
                        case "3":
                            LogOut();
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid choice. Please try again.\n");
                            Console.ResetColor();
                            break;
                    }
                }
            }

            PrintBanner();
            PrintMenu();
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
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid username or password. Please try again.\n");
                    Console.ResetColor();
                }
            }

            PrintUserMenu();
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

        private void AddRestaurant()
        {
            Console.Write("Enter name: ");
            string inputName = Console.ReadLine();

            Console.Write("Enter cuisine: ");
            string inputCuisine = Console.ReadLine();

            Console.Write("Enter location: ");
            string inputLocation = Console.ReadLine();

            PrintBanner();
            Restaurant restaurant = new Restaurant(_restaurants.Count(), inputName, inputCuisine, inputLocation);
            _restaurants.Add(restaurant);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Restaurant \"{inputName}\" added successfully.\n");
            Console.ResetColor();
        }

        private void SearchUsers()
        {
            PrintUserBanner();

            Console.Write("Enter username: ");
            string inputUserName = Console.ReadLine();
            Console.WriteLine();

            IEnumerable<User> filteredUsers = _users.Where(user => user.UserName.Contains(inputUserName));
            foreach (User user in filteredUsers)
            {
                Console.WriteLine(user.UserName);
            }

            Console.ReadLine();
            PrintUserBanner();
        }

        private void LogOut()
        {
            _loggedInUser = null;
        }
    }
}
