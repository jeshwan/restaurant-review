using System.Text.Json.Serialization;

namespace Lib.models
{
    public class Review
    {
        private int _reviewId;
        private int _reviewerId;
        private string _comment;
        private Rating _rating;
        private DateTime _date;

        [JsonPropertyName("reviewId")]
        public int ReviewId
        {
            get { return _reviewId; }
            set { _reviewId = value; }
        }

        [JsonPropertyName("reviewerId")]
        public int ReviewerId
        {
            get { return _reviewerId; }
            set { _reviewerId = value; }
        }

        [JsonPropertyName("comment")]
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        [JsonPropertyName("rating")]
        public Rating Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }

        [JsonPropertyName("date")]
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public Review()
        {

        }

        public Review(int reviewId, int reviewerId, string comment, Rating rating)
        {
            _reviewId = reviewId;
            _reviewerId = reviewerId;
            _comment = comment;
            _rating = rating;
            _date = DateTime.Now;
        }

        public void PrintDetails(ref List<User> users)
        {
            Console.WriteLine($"Review ID: {_reviewId}");
            Console.WriteLine($"Reviewer ID: {_reviewerId}");

            User reviewer = users.Find(user => user.UserId == _reviewerId);
            Console.WriteLine($"Reviewer UserName: {reviewer.UserName}");

            Console.WriteLine($"Comment: {_comment}");
            Console.Write($"Rating: ");
            switch (_rating)
            {
                case Rating.Poor:
                    Console.WriteLine("Poor (1/5)");
                    break;
                case Rating.Fair:
                    Console.WriteLine("Fair (2/5)");
                    break;
                case Rating.Average:
                    Console.WriteLine("Average (3/5)");
                    break;
                case Rating.Good:
                    Console.WriteLine("Good (4/5)");
                    break;
                case Rating.Excellent:
                    Console.WriteLine("Excellent (5/5)");
                    break;
            }

            Console.WriteLine($"Date: {_date}");
            Console.WriteLine();
        }
    }
}
