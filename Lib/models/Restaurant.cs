namespace Lib.models
{
    /// <summary>
    /// Represents a restaurant entity with basic details and a collection of reviews.
    /// </summary>
    /// <remarks>
    /// The Restaurant class includes properties for the restaurant's ID, name, cuisine type, location,
    /// and a list of reviews associated with the restaurant. It also provides a method to display basic details.
    /// </remarks>
    public class Restaurant
    {
        /// <summary>
        /// Gets or sets the unique identifier for the restaurant.
        /// </summary>
        /// <value>The identifier for the restaurant.</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name of the restaurant.
        /// </summary>
        /// <value>The name of the restaurant.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the cuisine type of the restaurant.
        /// </summary>
        /// <value>The cuisine type of the restaurant.</value>
        public string Cuisine { get; set; }
        /// <summary>
        /// Gets or sets the location of the restaurant.
        /// </summary>
        /// <value>The location of the restaurant.</value>
        public string Location { get; set; }
        /// <summary>
        /// Gets or sets the list of reviews associated with the restaurant.
        /// </summary>
        /// <value>The list of reviews associated with the restaurant.</value>
        public List<Review> Reviews { get; set; } = new List<Review>();
        /// <summary>
        /// Displays basic details of the restaurant, including the name and cuisine type.
        /// </summary>
        public void DisplayDetails()
        {
            Console.WriteLine("\nRestaurant Details:");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Cuisine Type: {Cuisine}");
        }
    }
}

