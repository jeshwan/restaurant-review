public class Admin
{
    public int AdminId { get; set; }
    public string Name { get; set; }

    public Admin()
    {
    }

    public void AddUser(string userName)
    {
        if (string.IsNullOrEmpty(userName))
        {
            Console.WriteLine("User name cannot be null or empty.");
            return;
        }

        // int userId = usersDatabase.Count + 1;
        // usersDatabase.Add(new User { UserId = userId, UserName = userName });
        // Console.WriteLine($"User '{userName}' with ID {userId} added successfully.");
    }

    /*
    public User SearchUser(string userName)
    {
        return usersDatabase.FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
    }
    */

    /*
    public void AddReview(int userId, int rating, string comment)
    {
        if (rating < 1 || rating > 5)
        {
            Console.WriteLine("Rating must be between 1 and 5.");
            return;
        }

        int reviewId = reviewsDatabase.Count + 1;
        reviewsDatabase.Add(new Review { ReviewId = reviewId, Rating = rating, Comment = comment });
        Console.WriteLine($"Review with ID {reviewId} added successfully.");
    }
    */
}
