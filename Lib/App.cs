﻿using Lib.models;

namespace Lib
{
    public class App
    {
        private User? _LoggedInUser = null;
        private List<User> _users = new List<User>();

        public App()
        {
            PrintBanner();

            User user1 = new User(0, "a", "b", Role.Regular);
            User user2 = new User(0, "b", "c", Role.Admin);

            _users.Add(user1);
            _users.Add(user2);
        }

        public List<User> Users
        {
            get { return _users; }
            set { }
        }

        public void PrintBanner()
        {
            Console.Clear();
            Console.WriteLine("Restaurant Review App\n");
        }

        public void PrintLoginBanner()
        {
            if (_LoggedInUser == null) return;

            PrintBanner();
            Console.WriteLine($"Welcome, {_LoggedInUser.UserName}.\n");
        }

        public void PromptLogin()
        {
            while (_LoggedInUser == null)
            {
                Console.Write("Enter your username: ");
                string username = Console.ReadLine();

                Console.Write("Enter your password: ");
                string password = Console.ReadLine();

                User? user = _users.Find(u => u.UserName == username);
                if (user == null)
                {
                    Console.WriteLine($"Username \"{username}\" cannot be found! Please try again.\n");
                }
                else if (user.ValidateCredentials(username, password))
                {
                    _LoggedInUser = user;
                }
                else
                {
                    Console.WriteLine("Invalid username or password. Please try again.\n");
                }
            }

            PrintLoginBanner();
        }
    }
}
