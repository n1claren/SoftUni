namespace FootballManager.Data.Models
{
    public class UserPlayer
    {
        public string UserId { get; init; }

        public User User { get; init; }

        public int PlayerId { get; init; }

        public Player Player { get; init; }
    }
}