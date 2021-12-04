namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.Linq;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static object XmlConverter { get; private set; }

        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context
                .Theatres
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count() >= 20)
                .ToList()
                .Select(t => new TheatreExportModel
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                                    .Where(t => t.RowNumber <= 5)
                                    .ToList()
                                    .Sum(t => t.Price),
                    Tickets = t.Tickets
                               .Where(x => x.RowNumber <= 5)
                               .ToList()
                               .Select(t => new TicketExportModel
                               {
                                   Price = t.Price,
                                   RowNumber = t.RowNumber
                               })
                               .OrderByDescending(x => x.Price)
                               .ToList()
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToList();

            var result = JsonConvert.SerializeObject(theatres, Formatting.Indented);

            return result;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context
                 .Plays
                 .Where(x => x.Rating <= rating)
                 .ToList()
                 .Select(x => new PlayExportModel
                 {
                     Title = x.Title,
                     Duration = x.Duration.ToString("c", CultureInfo.InvariantCulture),
                     Rating = x.Rating == 0 ? "Premier" : x.Rating.ToString(),
                     Genre = x.Genre.ToString(),
                     Actors = x.Casts
                            .Where(x => x.IsMainCharacter)
                            .Select(a => new ActorExportModel()
                            {
                             FullName = a.FullName,
                             MainCharacter = $"Plays main character in '{x.Title}'."
                            })
                         .OrderByDescending(a => a.FullName)
                         .ToList()
                 })
                 .OrderBy(p => p.Title)
                 .ThenByDescending(p => p.Genre)
                 .ToList();

            var xml = XMLConverter.Serialize(plays, "Plays");

            return xml;
        }
    }
}
