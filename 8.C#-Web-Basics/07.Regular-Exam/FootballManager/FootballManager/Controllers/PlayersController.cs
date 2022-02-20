using FootballManager.Data;
using FootballManager.Data.Models;
using FootballManager.Services;
using FootballManager.ViewModels.Players;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Collections.Generic;
using System.Linq;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private readonly FootballManagerDbContext data;
        private readonly IValidator validator;

        public PlayersController(FootballManagerDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        public HttpResponse All()
        {
            if (!this.User.IsAuthenticated)
            {
                var errors = new List<string>()
                {
                    "Users must login to view player page."
                };

                return Error(errors);
            }


            var playersQuery = this.data
                .Players
                .AsQueryable()
                .ToList();

            var players = new List<PlayerListingViewModel>();

            foreach (var player in playersQuery)
            {
                var currentPlayer = new PlayerListingViewModel
                {
                    Id = player.Id,
                    FullName = player.FullName,
                    PlayerImage = player.ImageUrl,
                    PlayerTitle = player.Description,
                    ListGroup = player.Position,
                    SpeedStat = player.Speed,
                    EnduranceStat = player.Endurance
                };

                players.Add(currentPlayer);
            }

            return View(players);
        }

        public HttpResponse Add()
        {
            if (this.User.IsAuthenticated)
            {
                return View();
            }
            else
            {
                var errors = new List<string>()
                {
                    "Users must login to add a player."
                };

                return Error(errors);
            }
        }

        [HttpPost]
        public HttpResponse Add(CreatePlayerFormModel model)
        {
            var modelErrors = this.validator.ValidatePlayer(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            if (!this.User.IsAuthenticated)
            {
                var errors = new List<string>()
                {
                    "Users must login to add a player."
                };

                return Error(modelErrors);
            }

            var user = this.data
                .Users
                .Where(u => u.Id == this.User.Id)
                .FirstOrDefault();

            var player = new Player
            {
                FullName = model.FullName,
                ImageUrl = model.ImageURL,
                Position = model.Position,
                Speed = model.Speed,
                Endurance = model.Endurance,
                Description = model.Description
            };

            this.data.Players.Add(player);

            this.data.SaveChanges();

            var addedPlayer = this.data
                .Players
                .Where(p => p.FullName == player.FullName && p.ImageUrl == player.ImageUrl)
                .FirstOrDefault();

            var userPlayer = new UserPlayer
            {
                UserId = user.Id,
                PlayerId = addedPlayer.Id,
            };

            this.data.UserPlayers.Add(userPlayer);

            this.data.SaveChanges();

            return Redirect("/Players/All");
        }

        public HttpResponse AddToCollection(int playerId)
        {
            var player = this.data.Players.FirstOrDefault(p => p.Id == playerId);

            var user = this.data.Users.FirstOrDefault(u => u.Id == this.User.Id);

            var up = this
                .data
                .UserPlayers
                .FirstOrDefault(up => up.UserId == user.Id && up.PlayerId == player.Id);

            if (up != null)
            {
                return Redirect("/Players/All");
            }

            var userPlayer = new UserPlayer
            {
                UserId = user.Id,
                PlayerId = player.Id
            };

            this.data.UserPlayers.Add(userPlayer);

            this.data.SaveChanges();

            return Redirect("/Players/All");
        }

        public HttpResponse Collection()
        {
            if (!this.User.IsAuthenticated)
            {
                var errors = new List<string>()
                {
                    "Users must login to see their collection."
                };

                return Error(errors);
            }

            var user = this.data.Users.FirstOrDefault(u => u.Id == this.User.Id);

            var userPlayers = this.data
                .UserPlayers
                .Where(up => up.UserId == user.Id)
                .Select(up => up.PlayerId)
                .ToList();

            var players = new List<PlayerListingViewModel>();

            foreach (var playerId in userPlayers)
            {
                var currentPlayer = this.data
                    .Players
                    .ToList()
                    .Where(p => p.Id == playerId)
                    .FirstOrDefault();

                var addPlayer = new PlayerListingViewModel
                {
                    Id = currentPlayer.Id,
                    FullName = currentPlayer.FullName,
                    PlayerImage = currentPlayer.ImageUrl,
                    PlayerTitle = currentPlayer.Description,
                    ListGroup = currentPlayer.Position,
                    SpeedStat = currentPlayer.Speed,
                    EnduranceStat = currentPlayer.Endurance
                };

                players.Add(addPlayer);
            }

            return View(players);
        }

        public HttpResponse RemoveFromCollection(int playerId)
        {
            var player = this.data.Players.FirstOrDefault(p => p.Id == playerId);

            var user = this.data.Users.FirstOrDefault(u => u.Id == this.User.Id);

            var userPlayer = this.data
                .UserPlayers
                .FirstOrDefault(up => up.UserId == user.Id && up.PlayerId == player.Id);

            this.data.UserPlayers.Remove(userPlayer);

            this.data.SaveChanges();

            return Redirect("/Players/Collection");
        }
    }
}
