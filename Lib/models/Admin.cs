using Lib.models;
/// <summary>
/// Represents an administrator user in the system, inheriting from the User class.
/// </summary>
/// <remarks>
/// This class extends the functionality of the base User class to represent users with administrative privileges.
/// The role of an Admin user is set to Admin upon initialization.
/// </remarks>
public class Admin : User
{
    /// <summary>
    /// Initializes a new instance of the Admin class with the specified user ID, username, and password.
    /// The role is set to Admin.
    /// </summary>
    /// <param name="userId">The unique identifier for the administrator user.</param>
    /// <param name="userName">The username of the administrator user.</param>
    /// <param name="password">The password associated with the administrator user.</param>
    public Admin(int userId, string userName, string password) : base(userId, userName, password)
    {
        base.Role = Role.Admin;
    }

    /*
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
    */

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
