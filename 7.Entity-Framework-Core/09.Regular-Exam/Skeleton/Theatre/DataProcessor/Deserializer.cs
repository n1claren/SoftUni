namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var plays = new List<Play>();

            var importPlays = XMLConverter.Deserializer<PlayInputModel>(xmlString, "Plays");

            foreach (var importPlay in importPlays)
            {
                bool isValidGenre = Enum.TryParse(typeof(Genre), importPlay.Genre, out var verifiedGenre);

                var isValidDuration = TimeSpan.TryParseExact(importPlay.Duration, "c", CultureInfo.InvariantCulture, out TimeSpan verifiedTimeSpan);

                if (!IsValid(importPlay) ||
                    isValidDuration == false ||
                    isValidGenre == false ||
                    verifiedTimeSpan.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var currentPlay = new Play
                {
                    Title = importPlay.Title,
                    Duration = verifiedTimeSpan,
                    Rating = importPlay.Rating,
                    Genre = (Genre)verifiedGenre,
                    Description = importPlay.Descripton,
                    Screenwriter = importPlay.Screenwriter
                };

                plays.Add(currentPlay);

                sb.AppendLine(string.Format(SuccessfulImportPlay, currentPlay.Title, currentPlay.Genre, currentPlay.Rating));
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var casts = new List<Cast>();

            var importCasts = XMLConverter.Deserializer<CastInputModel>(xmlString, "Casts");

            foreach (var importCast in importCasts)
            {
                // no one asked for checking this !!!
                //var playIds = context
                //    .Plays
                //    .Select(p => p.Id)
                //    .ToList();

                if (!IsValid(importCast)) // || playIds.Contains(importCast.PlayId)) NO!!!
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var currentCast = new Cast
                {
                    FullName = importCast.FullName,
                    IsMainCharacter = importCast.IsMainCharacter,
                    PhoneNumber = importCast.PhoneNumber,
                    PlayId = importCast.PlayId
                };

                casts.Add(currentCast);

                sb.AppendLine(string.Format(SuccessfulImportActor, currentCast.FullName, currentCast.IsMainCharacter ? "main" : "lesser"));
            }

            context.Casts.AddRange(casts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var theatres = new List<Theatre>();

            var importTT = JsonConvert.DeserializeObject<List<TheatreInputModel>>(jsonString);

            foreach (var theatreImport in importTT)
            {
                if (!IsValid(theatreImport))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var theatre = new Theatre()
                {
                    Name = theatreImport.Name,
                    Director = theatreImport.Director,
                    NumberOfHalls = theatreImport.NumberOfHalls,
                    Tickets = new List<Ticket>()
                };

                foreach (var ticket in theatreImport.Tickets)
                {
                    if (!IsValid(ticket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    theatre.Tickets.Add(new Ticket()
                    {
                        Price = ticket.Price,
                        RowNumber = ticket.RowNumber,
                        PlayId = ticket.PlayId,
                        TheatreId = theatre.Id,
                        Theatre = theatre
                    });
                }

                theatres.Add(theatre);

                sb.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count()));
            }

            context.Theatres.AddRange(theatres);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
