namespace VaporStore.DataProcessor
{
	using System;
	using Data;
	using System.Linq;
    using Newtonsoft.Json;
    using System.Text;
    using VaporStore.DataProcessor.Dto.Export;
    using VaporStore.Data.Models.Enums;
    using System.Globalization;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
            var genres = context
               .Genres
               .Where(g => genreNames.Contains(g.Name))
               .ToList()
               .Select(g => new
               {
                   Id = g.Id,
                   Genre = g.Name,
                   Games = g.Games.Where(gm => gm.Purchases.Count > 0)
                   .ToList()
                   .Select(gm => new 
                   {
                       Id = gm.Id,
                       Title = gm.Name,
                       Developer = gm.Developer.Name,
                       Tags = string.Join(", ", gm.GameTags.Select(gt => gt.Tag.Name)),
                       Players = gm.Purchases.Count()
                   })
                   .OrderByDescending(gm => gm.Players)
                   .ThenBy(gm => gm.Id)
                   .ToList(),
                   TotalPlayers = g.Games.Select(gm => gm.Purchases.Count).Sum()
               })
               .OrderByDescending(g => g.TotalPlayers)
               .ThenBy(g => g.Id)
               .ToList();

            string resultJson = JsonConvert.SerializeObject(genres, Formatting.Indented);

            return resultJson;
        }

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
            var purchaseType = Enum.Parse<PurchaseType>(storeType);

            var users = context.Users
                .Where(u => u.Cards.Any(c => c.Purchases.Count > 0))
                .ToList()
                .Select(u => new UserOutputModel()
                {
                    Username = u.Username,
                    Purchases = context
                                    .Purchases
                                    .Where(p => p.Card.User.Username == u.Username && p.Type == purchaseType)
                                    .OrderBy(p => p.Date)
                                    .ToList()
                    .Select(p => new PurchaseOutputModel()
                    {
                        Card = p.Card.Number,
                        Cvc = p.Card.Cvc,
                        Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Game = new GameOutputModel()
                        {
                            Title = p.Game.Name,
                            Genre = p.Game.Genre.Name,
                            Price = p.Game.Price
                        }
                    })
                    .ToList(),
                    TotalSpent = context
                                .Purchases
                                .Where(p => p.Card.User.Username == u.Username &&
                                p.Type == purchaseType)
                    .ToList()
                    .Sum(p => p.Game.Price)
                })
                .Where(u => u.Purchases.Count > 0)
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToList();

            var result = XMLConverter.Serialize(users, "Users");

            return result;
		}
	}
}