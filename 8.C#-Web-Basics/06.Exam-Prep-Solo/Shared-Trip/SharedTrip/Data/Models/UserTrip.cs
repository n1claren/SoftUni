namespace SharedTrip.Data.Models
{
    public class UserTrip
    {
        public string UserId { get; init; }

        public User User { get; set; }

        public string TripId { get; set; }

        public Trip Trip { get; set; }
    }
}
