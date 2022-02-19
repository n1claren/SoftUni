using SharedTrip.Models.Trips;
using SharedTrip.Models.Users;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SharedTrip.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < 5 || model.Username.Length > 20)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between 5 and 20 characters long.");
            }

            if (!Regex.IsMatch(model.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Password.Length < 6 || model.Password.Length > 20)
            {
                errors.Add("The provided password is not valid. It must be between 6 and 20 characters long.");
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

        public ICollection<string> ValidateTrip(CreateTripFormModel model)
        {
            var errors = new List<string>();

            if (model.Seats < 2)
            {
                errors.Add("Minimum seats required are 2.");
            }

            if (model.Seats > 6)
            {
                errors.Add("Maximum seats allowed are 6");
            }

            if (model.Description.Length > 80)
            {
                errors.Add("Trip description cannot exceed 80 symbols.");
            }

            return errors;
        }
    }
}
