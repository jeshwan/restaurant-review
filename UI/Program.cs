using Lib;

namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            App app = new App();
            app.PrintBanner();
            app.PromptLogin();

            while (app.LoggedInUser == null)
            {
                app.LoggedInUser = app.PromptLogin();
            }
            app.PrintLoginBanner();

            /*
            while(true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("0. Display Restaurant Details");
                Console.WriteLine("1. Exit");

                Console.Write("Enter your choice (0 or 2): ");
                string choice = Console.ReadLine();

                switch (choice) 
                {
                    case "0":
                        // DisplayRestaurantDetails(restaurant);
                        break;
                    case "1":
                        Console.WriteLine("Exiting the application. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
            */


            // Initialize the RestaurantReviewManager from the class library
            /*
            var manager = new RestaurantReviewLib.RestaurantReviewManager();
 
            var user = new RestaurantReviewLib.User { Username = "user1", Password = "password123" };
            var restaurant = new RestaurantReviewLib.Restaurant
            {
                Name = "Delicious Bites",
                Cuisine = "Italian",
                Location = "123 Main Street"
            };
            var review = new RestaurantReviewLib.Review
            {
                RestaurantId = restaurant.RestaurantId,
                ReviewerId = user.UserId,
                Comment = "Great food and service!",
                Rating = RestaurantReviewLib.Rating.Excellent,
                Date = DateTime.Now
            };
 
            manager.AddUser(user);
            manager.AddRestaurant(restaurant);
            manager.AddReview(review.RestaurantId, review.ReviewerId, review.Comment, review.Rating);
 
            Console.WriteLine($"Restaurant: {restaurant.Name}");
            Console.WriteLine($"Cuisine: {restaurant.Cuisine}");
            Console.WriteLine($"Location: {restaurant.Location}");
 
            Console.WriteLine("\nReviews:");
            foreach (var r in manager.GetRestaurantById(restaurant.RestaurantId)?.Reviews ?? new System.Collections.Generic.List<RestaurantReviewLib.Review>())
            {
                Console.WriteLine($"- {manager.GetUserById(r.ReviewerId)?.Username} rated it as {r.Rating} on {r.Date.ToShortDateString()}: {r.Comment}");
            }
 
            manager.SaveData();
            */
        }
    }
}