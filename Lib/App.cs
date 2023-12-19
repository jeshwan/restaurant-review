using System.Text.Json;
using System.Text.Json.Serialization;
using Lib.models;

namespace Lib
{
    public class App
    {
        private User? _loggedInUser = null;

        [JsonPropertyName("users")]
        private List<User> _users;

        [JsonPropertyName("restaurants")]
        private List<Restaurant> _restaurants;

        public App()
        {
            _users = LoadUsers();
            _restaurants = LoadRestaurants();

            // Console.ReadLine();

            PrintBanner();
            PrintMenu();
        }

        public List<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }

        public List<Restaurant> Restaurants
        {
            get { return _restaurants; }
            set { _restaurants = value; }
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
                    Console.WriteLine("2. Add restaurant review");
                    Console.WriteLine("3. View restarant details");
                    Console.WriteLine("4. View restarant reviews");
                    Console.WriteLine("5. Search restaurants");
                    Console.WriteLine("6. Log out");
                    Console.WriteLine();

                    Console.Write("Enter choice: ");
                    string choice = Console.ReadLine();

                    PrintUserBanner();
                    switch (choice)
                    {
                        case "1":
                            ListRestaurants();
                            break;
                        case "2":
                            AddReview();
                            break;
                        case "3":
                            ViewRestaurantDetails();
                            break;
                        case "4":
                            ViewRestaurantReviews();
                            break;
                        case "6":
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

            SaveUsers();
        }

        private void AddRestaurant()
        {
            Console.Write("Enter name: ");
            string inputName = Console.ReadLine();

            Console.Write("Enter cuisine: ");
            string inputCuisine = Console.ReadLine();

            Console.Write("Enter location: ");
            string inputLocation = Console.ReadLine();

            Restaurant restaurant = new Restaurant(_restaurants.Count(), inputName, inputCuisine, inputLocation);
            _restaurants.Add(restaurant);

            PrintUserBanner();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Restaurant \"{inputName}\" added successfully.\n");
            Console.ResetColor();

            SaveRestaurants();
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

        private void ListRestaurants()
        {
            PrintUserBanner();

            foreach (Restaurant restaurant in _restaurants)
            {
                Console.WriteLine(restaurant.Name);
            }

            Console.ReadLine();
            PrintUserBanner();
        }

        private void AddReview()
        {
            PrintUserBanner();

            Restaurant? restaurant = null;
            while (restaurant == null)
            {
                Console.Write("Enter restaurant id: ");
                string inputRestaurantId = Console.ReadLine();

                if (int.TryParse(inputRestaurantId, out int restaurantId))
                {
                    restaurant = _restaurants.Find(r => r.RestaurantId == restaurantId);
                    if (restaurant == null)
                    {
                        PrintUserBanner();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Restaurant ID \"{restaurantId}\" does not exist.\n");
                        Console.ResetColor();
                    }
                }
                else
                {
                    PrintUserBanner();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid restaurant ID. Please try again.\n");
                    Console.ResetColor();
                }
            }

            Console.Write("Enter comment: ");
            string inputComment = Console.ReadLine();

            Console.Write("Enter rating (Poor = 1, Fair = 2, Average = 3, Good = 4, Excellent = 5): ");
            Rating inputRating = Rating.Poor;
            if (int.TryParse(Console.ReadLine(), out int ratingNum))
            {
                if (Enum.IsDefined(typeof(Rating), ratingNum))
                {
                    inputRating = (Rating)ratingNum;
                }
            }

            Review review = new Review(restaurant.Reviews.Count(), _loggedInUser.UserId, inputComment, inputRating);
            restaurant.AddReview(review);

            PrintUserBanner();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Review added successfully.\n");
            Console.ResetColor();

            SaveRestaurants();
        }

        private void ViewRestaurantDetails()
        {
            PrintUserBanner();

            Restaurant? restaurant = null;
            while (restaurant == null)
            {
                Console.Write("Enter restaurant id: ");
                string inputRestaurantId = Console.ReadLine();

                if (int.TryParse(inputRestaurantId, out int restaurantId))
                {
                    restaurant = _restaurants.Find(r => r.RestaurantId == restaurantId);
                    if (restaurant == null)
                    {
                        PrintUserBanner();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Restaurant ID \"{restaurantId}\" does not exist.\n");
                        Console.ResetColor();
                    }
                }
                else
                {
                    PrintUserBanner();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid restaurant ID. Please try again.\n");
                    Console.ResetColor();
                }
            }

            Console.WriteLine();
            restaurant.PrintDetails();

            Console.ReadLine();
            PrintUserBanner();
        }
        private void ViewRestaurantReviews()
        {
            PrintUserBanner();

            Restaurant? restaurant = null;
            while (restaurant == null)
            {
                Console.Write("Enter restaurant id: ");
                string inputRestaurantId = Console.ReadLine();

                if (int.TryParse(inputRestaurantId, out int restaurantId))
                {
                    restaurant = _restaurants.Find(r => r.RestaurantId == restaurantId);
                    if (restaurant == null)
                    {
                        PrintUserBanner();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Restaurant ID \"{restaurantId}\" does not exist.\n");
                        Console.ResetColor();
                    }
                }
                else
                {
                    PrintUserBanner();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid restaurant ID. Please try again.\n");
                    Console.ResetColor();
                }
            }

            Console.WriteLine();
            restaurant.PrintReviews(ref _users);

            Console.ReadLine();
            PrintUserBanner();
        }

        private void LogOut()
        {
            _loggedInUser = null;
        }

        private void SaveUsers()
        {
            string json = JsonSerializer.Serialize(_users, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText("users.json", json);
        }

        private List<User> LoadUsers()
        {
            try
            {
                string json = File.ReadAllText("users.json");
                List<User> users = JsonSerializer.Deserialize<List<User>>(json);
                if (users == null)
                {
                    return new List<User>();
                } else
                {
                    return users;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while loading restaurants: {e.Message}");
                return new List<User>();
            }
        }

        private void SaveRestaurants()
        {
            string json = JsonSerializer.Serialize(_restaurants, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText("restaurants.json", json);
        }

        private List<Restaurant> LoadRestaurants()
        {
            try
            {
                string json = File.ReadAllText("restaurants.json");
                List<Restaurant> restaurants = JsonSerializer.Deserialize<List<Restaurant>>(json);
                if (restaurants == null)
                {
                    return new List<Restaurant>();
                } else
                {
                    return restaurants;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while loading restaurants: {e.Message}");
                return new List<Restaurant>();
            }
        }
    }
}
