namespace Lib.models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cuisine { get; set; }
        public string Location { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();

        public void DisplayDetails()
        {
            Console.WriteLine("\nRestaurant Details:");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Cuisine Type: {Cuisine}");
        }
    }
}

