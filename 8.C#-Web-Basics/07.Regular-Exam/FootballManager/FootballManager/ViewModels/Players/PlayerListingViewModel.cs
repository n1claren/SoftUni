namespace FootballManager.ViewModels.Players
{
    public class PlayerListingViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string PlayerImage { get; set; }

        public string PlayerTitle { get; set; }

        public string ListGroup { get; set; }

        public byte SpeedStat { get; set; }

        public byte EnduranceStat { get; set; }
    }
}
