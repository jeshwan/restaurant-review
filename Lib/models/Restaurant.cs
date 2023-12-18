namespace Lib.models
{
    public class Restaurant
    {
        private int _restaurantId { get; set; }
        private string _name { get; set; }
        private string _cuisine { get; set; }
        private string _location { get; set; }
        private List<Review> _reviews { get; set; } = new List<Review>();

        public Restaurant(int restaurantId, string name, string cuisine, string location)
        {
            _restaurantId = restaurantId;
            _name = name;
            _cuisine = cuisine;
            _location = location;
            _reviews = new List<Review>();
        }

        public void DisplayDetails()
        {
            Console.WriteLine("\nRestaurant Details:");
            Console.WriteLine($"Restaurant ID: {_restaurantId}");
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine($"Cuisine: {_cuisine}");
            Console.WriteLine($"Location: {_location}");
        }
    }
}

