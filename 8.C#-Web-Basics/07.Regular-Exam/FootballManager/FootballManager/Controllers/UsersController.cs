using FootballManager.Data;
using FootballManager.Data.Models;
using FootballManager.Services;
using FootballManager.ViewModels.Users;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Collections.Generic;
using System.Linq;

namespace FootballManager.Controllers
{
    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;
        private readonly FootballManagerDbContext data;

        public UsersController(
            IValidator validator,
            IPasswordHasher passwordHasher,
            FootballManagerDbContext data)
        {
            this.validator = validator;
            this.passwordHasher = passwordHasher;
            this.data = data;
        }

        public HttpResponse Register() => View();

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel model)
        {
            var modelErrors = this.validator.ValidateUser(model);

            if (this.data.Users.Any(u => u.Username == model.Username))
            {
                modelErrors.Add($"User with '{model.Username}' username already exists.");
            }

            if (this.data.Users.Any(u => u.Email == model.Email))
            {
                modelErrors.Add($"User with '{model.Email}' e-mail already exists.");
            }

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var user = new User
            {
                Username = model.Username,
                Password = this.passwordHasher.HashPassword(model.Password),
                Email = model.Email
            };

            data.Users.Add(user);

            data.SaveChanges();

            return Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            if (this.User.IsAuthenticated)
            {
                var errors = new List<string>()
                {
                    "You are already logged in."
                };

                return Error(errors);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public HttpResponse Login(LoginUserFormModel model)
        {
            var hashedPassword = this.passwordHasher.HashPassword(model.Password);

            var userId = this.data
                .Users
                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            if (userId == null)
            {
                var errors = new List<string>()
                {
                    "Invalid username or password."
                };

                return Error(errors);
            }

            this.SignIn(userId);

            return Redirect("/Players/All");
        }

        public HttpResponse Logout()
        {
            if (!this.User.IsAuthenticated)
            {
                var errors = new List<string>()
                {
                    "You are not logged in. You cant log-out."
                };

                return Error(errors);
            }
           
            this.SignOut();

            return Redirect("/");
        }
    }
}
