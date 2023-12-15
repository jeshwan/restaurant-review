namespace Lib.models
{
    public class User
    {
        static void Main() 
        {
            Restaurant restaurant = new Restaurant();

            Console.WriteLine("Welcome to the Restaurant Details App!");

            while(true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Display Restaurant Details");
                Console.WriteLine("2. Exit");

                Console.Write("Enter your choice (1 or 2): ");
                string choice = Console.ReadLine();

                switch (choice) 
                {
                    case "1":
                        DisplayRestaurantDetails(restaurant);
                        break;
                    case "2":
                        Console.WriteLine("Exiting the application. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }

        static void DisplayRestaurantDetails(Restaurant restaurant)
        {
            Console.WriteLine("\nRestaurant Details:");
            Console.WriteLine($"Name: {restaurant.Name}");
            Console.WriteLine($"Cuisine Type: {restaurant.CuisineType}");
            Console.WriteLine($"Rating: {restaurant.Rating}/5");
        }
    }

    class Restaurant
    {
        public string Name { get; } = "Sample Restaurant";
        public string CuisineType { get; } = "Italian";
        public int Rating { get; } = 4;
    }
}
