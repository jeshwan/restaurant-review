namespace Lib.models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int RestaurantId { get; set; }
        public int ReviewerId { get; set; }
        public string Comment { get; set; }
        public Rating Rating { get; set; }
        public DateTime Date { get; set; }
    }
}
}
