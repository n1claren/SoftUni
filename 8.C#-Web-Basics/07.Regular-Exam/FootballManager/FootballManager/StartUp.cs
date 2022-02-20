using MyWebServer;
using FootballManager.Data;
using System.Threading.Tasks;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;
using Microsoft.EntityFrameworkCore;
using FootballManager.Services;

// https://www.youtube.com/watch?v=VDmOZFvDQl0

namespace FootballManager
{
    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                .Add<FootballManagerDbContext>()
                .Add<IViewEngine, CompilationViewEngine>()
                .Add<IPasswordHasher, PasswordHasher>()
                .Add<IValidator, Validator>())
                .WithConfiguration<FootballManagerDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
