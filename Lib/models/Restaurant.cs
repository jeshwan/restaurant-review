﻿namespace Lib.models
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

        public int RestaurantId
        {
            get { return _restaurantId; }
            set { }
        }

        public string Name
        {
            get { return _name; }
            set { }
        }

        public string Cuisine
        {
            get { return _cuisine; }
            set { }
        }

        public string Location
        {
            get { return _location; }
            set { }
        }

        public List<Review> Reviews
        {
            get { return _reviews; }
            set { }
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
    }
}

