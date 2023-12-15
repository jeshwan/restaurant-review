using Lib.models;

namespace UI 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Restaurant Review App");
 
            // Initialize the RestaurantReviewManager from the class library
            var manager = new RestaurantReviewLib.RestaurantReviewManager();
 
            // Example usage
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
 
            // Add user, restaurant, and review
            manager.AddUser(user);
            manager.AddRestaurant(restaurant);
            manager.AddReview(review.RestaurantId, review.ReviewerId, review.Comment, review.Rating);
 
            // Display restaurant information and reviews
            Console.WriteLine($"Restaurant: {restaurant.Name}");
            Console.WriteLine($"Cuisine: {restaurant.Cuisine}");
            Console.WriteLine($"Location: {restaurant.Location}");
 
            Console.WriteLine("\nReviews:");
            foreach (var r in manager.GetRestaurantById(restaurant.RestaurantId)?.Reviews ?? new System.Collections.Generic.List<RestaurantReviewLib.Review>())
            {
                Console.WriteLine($"- {manager.GetUserById(r.ReviewerId)?.Username} rated it as {r.Rating} on {r.Date.ToShortDateString()}: {r.Comment}");
            }
 
            // Save data before exiting the program
            manager.SaveData();
        }
    }
}
