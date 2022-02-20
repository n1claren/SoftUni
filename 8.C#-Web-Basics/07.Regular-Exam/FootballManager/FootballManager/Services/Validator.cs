using FootballManager.ViewModels.Players;
using FootballManager.ViewModels.Users;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using static FootballManager.Data.DataConstants;

namespace FootballManager.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidatePlayer(CreatePlayerFormModel model)
        {
            var errors = new List<string>();

            if (model.FullName.Length < PlayerFullNameMin || model.FullName.Length > PlayerFullNameMax)
            {
                errors.Add($"Name {model.FullName} must be between {PlayerFullNameMin} and {PlayerFullNameMax} characters.");
            }

            if (model.Position.Length < PlayerPositionMin || model.Position.Length > PlayerPositionMax)
            {
                errors.Add($"Position {model.Position} must be between {PlayerPositionMin} and {PlayerPositionMax} characters.");
            }

            if (model.Speed < PlayerSpeedMin || model.Speed > PlayerSpeedMax)
            {
                errors.Add($"Player speed value must be between {PlayerSpeedMin} and {PlayerSpeedMax}.");
            }

            if (model.Endurance < PlayerEnduranceMin || model.Endurance > PlayerEnduranceMax)
            {
                errors.Add($"Player endurance value must be between {PlayerEnduranceMin} and {PlayerEnduranceMax}.");
            }

            if (model.Description.Length > PlayerDescriptionMax)
            {
                errors.Add($"Player description cannot exceed {PlayerDescriptionMax} characters.");
            }

            return errors;
        }

        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UserMinUsername || model.Username.Length > UserMaxUsername)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between {UserMinUsername} and {UserMaxUsername} characters long.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Email.Length < UserMinEmail || model.Email.Length > UserMaxEmail)
            {
                errors.Add($"Email '{model.Email}' is not valid. It must be between {UserMinEmail} and {UserMaxEmail} characters long.");
            }

            if (model.Password.Length < UserMinPassword || model.Password.Length > UserMaxPassword)
            {
                errors.Add($"The provided password is not valid. It must be between {UserMinPassword} and {UserMaxPassword} characters long.");
            }

            if (model.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and its confirmation are different.");
            }

            return errors;
        }
    }
}
