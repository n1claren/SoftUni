namespace VaporStore.DataProcessor
{
	using System;
	using Data;
	using System.Linq;
    using Newtonsoft.Json;

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
			
		}
	}
}