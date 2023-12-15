using Lib.models;

namespace Lib
{
    
    public class App
    {
        public List<User> users = new List<User>();
        private bool loggedIn = false;

        public App()
        {
            User user1 = new User();
            user1.Id = 0;
            user1.UserName = "a";
            user1.Password = "b";
            user1.Role = "Regular";
            users.Add(user1);
        }

        public void PrintBanner()
        {
            Console.WriteLine("Restaurant Review App\n");
        }

        public void Login()
        {
 while (!loggedIn)
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

User? user = users.Find(u => u.UserName == username && u.Password == password);
                    if (user == null)
                {
                    Console.WriteLine($"User \"{username}\" cannot be found!");
                } else if (user.ValidateCredentials(username, password))
            {
                Console.WriteLine("Login successful! Welcome, " + username + ".");
                loggedIn = true;
            }
            else
            {
                Console.WriteLine("Invalid username or password. Please try again.");
            }
        }
        }
    }
}
