namespace Lib.models
{
    public class Review
    {
        private int _reviewId;
        private int _reviewerId;
        private string _comment;
        private Rating _rating;
        private DateTime _date;

        public Review(int reviewId, int reviewerId, string comment, Rating rating)
        {
            _reviewId = reviewId;
            _reviewerId = reviewerId;
            _comment = comment;
            _rating = rating;
            _date = DateTime.Now;
        }
    }
}
