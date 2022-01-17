using BasicWebServer.Server;
using BasicWebServer.Server.Common;
using BasicWebServer.Server.Responses;

void Main() => new HttpServer(routes => routes
                 .MapGet("/", new TextResponse("Hello from the server!"))
                 .MapGet("/Redirect", new RedirectResponse("https://softuni.org"))
                 .MapGet("/HTML", new HtmlResponse(Constants.HtmlForm))
                 .MapPost("/HTML", new TextResponse("", Constants.AddFormDataAction)))
              .Start();

Main();