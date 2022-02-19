using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Data.Models;
using SharedTrip.Models.Trips;
using SharedTrip.Services;
using System.Collections.Generic;
using System.Linq;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public TripsController(ApplicationDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        public HttpResponse All()
        {
            var tripsQuery = this.data
                .Trips
                .AsQueryable()
                .ToList();

            var trips = new List<TripsListingViewModel>();

            foreach (var trip in tripsQuery)
            {
                var goingUsers = this.data
                    .UsersTrips
                    .Where(ut => ut.TripId == trip.Id)
                    .Select(ut => ut.UserId)
                    .ToList();

                var currentTrip = new TripsListingViewModel
                {
                    Id = trip.Id,
                    StartPoint = trip.StartPoint,
                    EndPoint = trip.EndPoint,
                    DepartureTime = trip.DepartureTime.ToLocalTime(),
                    Seats = trip.Seats - goingUsers.Count()
                };

                trips.Add(currentTrip);
            }

            //var trips = tripsQuery
            //    .Select(t => new TripsListingViewModel
            //    {
            //        Id = t.Id,
            //        StartPoint = t.StartPoint,
            //        EndPoint = t.EndPoint,
            //        DepartureTime = t.DepartureTime.ToLocalTime(),
            //        Seats = t.Seats
            //    })
            //    .ToList();

            return View(trips);
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
                    "Users must login to add a trip."
                };

                return Error(errors);
            }
        }

        [HttpPost]
        public HttpResponse Add(CreateTripFormModel model)
        {
            var modelErrors = this.validator.ValidateTrip(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            if (!this.User.IsAuthenticated)
            {
                var errors = new List<string>()
                {
                    "Users",
                    "must",
                    "login",
                    "to",
                    "add",
                    "a",
                    "trip"
                };

                return Error(modelErrors);
            }

            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = model.DepartureTime,
                Seats = model.Seats,
                Description = model.Description,
                ImagePath = model.ImagePath,
            };

            this.data.Trips.Add(trip);

            this.data.SaveChanges();

            return Redirect("/Trips/All");
        }

        public HttpResponse Details(string tripId)
        {
            var trip = this.data.Trips.FirstOrDefault(t => t.Id == tripId);

            var goingUsers = this.data
                .UsersTrips
                .Where(ut => ut.TripId == trip.Id)
                .Select(ut => ut.UserId)
                .ToList();

            int availableSeats = trip.Seats - goingUsers.Count();

            var tripDetails = new TripDetailsViewModel
            {
                Id = trip.Id,
                StartPoint = trip.StartPoint,
                EndPoint = trip.EndPoint,
                DepartureTime = trip.DepartureTime.ToLocalTime(),
                Description = trip.Description,
                Seats = availableSeats,
                ImagePath = trip.ImagePath
            };

            return View(tripDetails);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            var user = this.data
                .Users
                .Where(u => u.Id == this.User.Id)
                .FirstOrDefault();

            var trip = this.data
                .Trips
                .Where(t => t.Id == tripId)
                .FirstOrDefault();

            var goingUsers = this.data
                .UsersTrips
                .Where(ut => ut.TripId == trip.Id)
                .Select(ut => ut.UserId)
                .ToList();

            if (goingUsers.Any())
            {
                foreach (var userId in goingUsers)
                {
                    if (user.Id == userId)
                    {
                        return Redirect($"/Trips/Details?tripId={trip.Id}");
                    }
                }
            }

            var userTrip = new UserTrip
            {
                TripId = trip.Id,
                UserId = user.Id
            };

            this.data.UsersTrips.Add(userTrip);

            this.data.SaveChanges();

            return Redirect("/Trips/All");
        }
    }
}
