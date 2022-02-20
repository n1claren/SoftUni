namespace FootballManager.Data
{
    public class DataConstants
    {
        public const int UserMinUsername = 5;
        public const int UserMaxUsername = 20;

        public const int UserMinPassword = 5;
        public const int UserMaxPassword = 20;

        public const int UserMinEmail = 10;
        public const int UserMaxEmail = 60;
        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public const int PlayerFullNameMin = 5;
        public const int PlayerFullNameMax = 80;

        public const int PlayerPositionMin = 5;
        public const int PlayerPositionMax = 20;

        public const byte PlayerSpeedMin = 0;
        public const byte PlayerSpeedMax = 10;

        public const byte PlayerEnduranceMin = 0;
        public const byte PlayerEnduranceMax = 10;

        public const int PlayerDescriptionMax = 200;
    }
}
