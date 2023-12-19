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
        private string _openingTime;
        private string _closingTime;
        private string _foodCategory;

        public Restaurant()
        {

        }

        public Restaurant(int restaurantId, string name, string cuisine, string location, string openingTime, string closingTime, string foodCategory)
        {
            /// <summary>
            /// Initializes the properties of a <see cref="Restaurant"/> object with the provided values.
            /// </summary>
            /// <param name="restaurantId">The ID of the restaurant.</param>
            /// <param name="name">The name of the restaurant.</param>
            /// <param name="cuisine">The cuisine type of the restaurant.</param>
            /// <param name="location">The location of the restaurant.</param>
            /// <param name="openingTime">The opening time of the restaurant.</param>
            /// <param name="closingTime">The closing time of the restaurant.</param>
            /// <param name="foodCategory">The food category of the restaurant.</param>
            /// <remarks>
            /// This code snippet involves the initialization of various properties of a <see cref="Restaurant"/> object:
            /// - <see cref="_restaurantId"/>: The ID of the restaurant.
            /// - <see cref="_name"/>: The name of the restaurant.
            /// - <see cref="_cuisine"/>: The cuisine type of the restaurant.
            /// - <see cref="_location"/>: The location of the restaurant.
            /// - <see cref="_reviews"/>: A new list of reviews is assigned.
            /// - <see cref="_openingTime"/>: The opening time of the restaurant.
            /// - <see cref="_closingTime"/>: The closing time of the restaurant.
            /// - <see cref="_foodCategory"/>: The food category of the restaurant.
            /// </remarks>
            _restaurantId = restaurantId;
            _name = name;
            _cuisine = cuisine;
            _location = location;
            _reviews = new List<Review>();
            _openingTime =  openingTime;
            _closingTime = closingTime;
            _foodCategory = foodCategory;
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

        [JsonPropertyName("openingTime")]
        public string OpeningTime
        {
            get { return _openingTime; }
            set { _openingTime = value; }
        }

        [JsonPropertyName("closingTime")]
        public string closingtime
        {
            get { return _closingTime; }
            set { _closingTime = value; }
        }

        [JsonPropertyName("Food Category")]
        public string foodCategory
        {
            get { return _foodCategory; }
            set { _foodCategory = value; }
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
            Console.WriteLine($"Opening Time: {_openingTime}");
            Console.WriteLine($"Closing Time: {_closingTime}");
            Console.WriteLine($"Menu: {_foodCategory}");

            /// <summary>
            /// Prints the details of the restaurant, including its name, cuisine, location, opening time, closing time, and menu.
            /// </summary>
            /// <remarks>
            /// This code snippet involves the following steps:
            /// 1. Prints the name of the restaurant using <see cref="Console.WriteLine"/>.
            /// 2. Prints the cuisine type of the restaurant using <see cref="Console.WriteLine"/>.
            /// 3. Prints the location of the restaurant using <see cref="Console.WriteLine"/>.
            /// 4. Prints the opening time of the restaurant using <see cref="Console.WriteLine"/>.
            /// 5. Prints the closing time of the restaurant using <see cref="Console.WriteLine"/>.
            /// 6. Prints the menu or food category of the restaurant using <see cref="Console.WriteLine"/>.
            /// </remarks>

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

