using Lib.models;

namespace Lib
{

    public class App
    {
        public List<User> users = new List<User>();

        public App()
        {
            User user1 = new User(0, "a", "b", Role.Regular);
            User user2 = new User(0, "b", "c", Role.Admin);

            users.Add(user1);
            users.Add(user2);
        }

        public void PrintBanner()
        {
            Console.WriteLine("Restaurant Review App\n");
        }

        public bool PromptLogin()
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            User? user = users.Find(u => u.Username == username);
            if (user == null)
            {
                Console.WriteLine($"Username \"{username}\" cannot be found! Please try again.\n");
                return false;
            }
            else if (user.ValidateCredentials(username, password))
            {
                Console.WriteLine($"Login successful! Welcome, {username}.\n");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid username or password. Please try again.\n");
                return false;
            }
        }
    }
}
