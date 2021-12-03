namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public const string ERROR_MESSAGE = "Invalid Data";

		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			var sb = new StringBuilder();

			var games = new List<Game>();
			var developers = new List<Developer>();
			var genres = new List<Genre>();
			var tags = new List<Tag>();

			var importGames = JsonConvert.DeserializeObject<IEnumerable<GameInputModel>>(jsonString);

            foreach (var importGame in importGames)
            {
				if (!IsValid(importGame))
                {
					sb.AppendLine(ERROR_MESSAGE);
					continue;
                }

				bool isValidReleaseDate = DateTime.TryParseExact(importGame.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);

				if (!isValidReleaseDate) 
				{
					sb.AppendLine(ERROR_MESSAGE);
					continue;
				}

				if (importGame.Tags.Length == 0)
                {
					sb.AppendLine(ERROR_MESSAGE);
					continue;
				}

				var currentGame = new Game
				{
					Name = importGame.Name,
					Price = importGame.Price,
					ReleaseDate = releaseDate
				};

				var currentDev = developers.FirstOrDefault(d => d.Name == importGame.Developer);

				if (currentDev == null)
                {
					currentDev = new Developer
					{
						Name = importGame.Developer
					};

					developers.Add(currentDev);
                }

				currentGame.Developer = currentDev;

				var currentGenre = genres.FirstOrDefault(g => g.Name == importGame.Genre);

				if (currentGenre == null)
                {
					currentGenre = new Genre
					{
						Name = importGame.Genre
					};

					genres.Add(currentGenre);
                }

				currentGame.Genre = currentGenre;

                foreach (var tag in importGame.Tags)
                {
					if (string.IsNullOrEmpty(tag))
                    {
						continue;
                    }

					var currentTag = tags.FirstOrDefault(t => t.Name == tag);

					if (currentTag == null)
                    {
						currentTag = new Tag
						{
							Name = tag
						};

						tags.Add(currentTag);
                    }

					currentGame.GameTags.Add(new GameTag
					{
						Tag = currentTag,
						Game = currentGame
					});
                }

				games.Add(currentGame);
				sb.AppendLine($"Added {currentGame.Name} ({currentGame.Genre.Name}) with {currentGame.GameTags.Count()} tags");
			}

			context.Games.AddRange(games);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			var sb = new StringBuilder();

			var users = new List<User>();

			var importUsers = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(jsonString);

			foreach (var importUser in importUsers)
			{
				if (!IsValid(importUser) || importUser.Cards.Count() == 0)
				{
					sb.AppendLine(ERROR_MESSAGE);
					continue;
				}

				bool cardsValid = true;
				var cards = new List<Card>();

				foreach (var card in importUser.Cards)
				{
					bool validCardType = Enum.TryParse(typeof(CardType), card.Type, out var cardType);

					if (!IsValid(card) || validCardType == false)
					{
						cardsValid = false;
						break;
					}

					var currentCard = new Card
					{
						Number = card.Number,
						Cvc = card.CVC,
						Type = (CardType)cardType
					};

					cards.Add(currentCard);
				}

				if (cardsValid == false)
                {
					sb.AppendLine(ERROR_MESSAGE);
					continue;
				}

				var currentUser = new User
				{
					FullName = importUser.FullName,
					Username = importUser.Username,
					Email = importUser.Email,
					Age = importUser.Age,
					Cards = cards
				};

				users.Add(currentUser);

				sb.AppendLine($"Imported {currentUser.Username} with {currentUser.Cards.Count()} cards");
            }

			context.Users.AddRange(users);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			var sb = new StringBuilder();

			var purchases = new List<Purchase>();

			var importPurchases = XMLConverter.Deserializer<PurchaseInputModel>(xmlString, "Purchases");

            foreach (var importPurchase in importPurchases)
            {
				bool isDateValid = DateTime.TryParseExact(importPurchase.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validDate);

				bool isValidPurchase = Enum.TryParse(typeof(PurchaseType), importPurchase.Type, out var validPurchase);

				var card = context.Cards.FirstOrDefault(c => c.Number == importPurchase.Card);

				var game = context.Games.FirstOrDefault(g => g.Name == importPurchase.Game);

				if (!IsValid(importPurchase) || 
					isDateValid == false || 
					isValidPurchase == false ||
					card == null ||
					game == null)
                {
					sb.AppendLine(ERROR_MESSAGE);
					continue;
				}

				var currentPurchase = new Purchase
				{
					Game = game,
					Type = (PurchaseType)validPurchase,
					ProductKey = importPurchase.ProductKey,
					Card = card,
					Date = validDate
				};

				purchases.Add(currentPurchase);

				sb.AppendLine($"Imported {currentPurchase.Game.Name} for {currentPurchase.Card.User.Username}");
            }

			context.Purchases.AddRange(purchases);
			context.SaveChanges();

			return sb.ToString().Trim();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}