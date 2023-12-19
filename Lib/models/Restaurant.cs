using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lib.models
{
    public class Restaurant
    {
        private int _restaurantId;
        private string _name;
        private string _cuisine;
        private string _location;
        private List<Review> _reviews = new List<Review>();

        public Restaurant()
        {

        }

        public Restaurant(int restaurantId, string name, string cuisine, string location)
        {
            _restaurantId = restaurantId;
            _name = name;
            _cuisine = cuisine;
            _location = location;
            _reviews = new List<Review>();
        }

        [JsonPropertyName("restaurantId")]
        public int RestaurantId
        {
            get { return _restaurantId; }
            set { _restaurantId = value; }
        }

        [JsonPropertyName("name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [JsonPropertyName("cuisine")]
        public string Cuisine
        {
            get { return _cuisine; }
            set { _cuisine = value; }
        }

        [JsonPropertyName("location")]
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        [JsonPropertyName("reviews")]
        public List<Review> Reviews
        {
            get { return _reviews; }
            set { _reviews = value; }
        }

        public void AddReview(Review review)
        {
            Reviews.Add(review);
        }

        public void PrintDetails()
        {
            Console.WriteLine("Restaurant Details:");
            // Console.WriteLine($"Restaurant ID: {_restaurantId}");
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine($"Cuisine: {_cuisine}");
            Console.WriteLine($"Location: {_location}");
        }

        public void PrintReviews(ref List<User> users)
        {
            Console.WriteLine("Restaurant Reviews:");
            foreach (Review review in Reviews)
            {
                review.PrintDetails(ref users);
            }
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}

