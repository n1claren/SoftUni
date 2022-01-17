﻿using BasicWebServer.Server;
using BasicWebServer.Server.Responses;

void Main() => new HttpServer(routes => routes
                 .MapGet("/", new TextResponse("Hello from the server!"))
                 .MapGet("/HTML", new HtmlResponse("<h1>HTML response</h1>"))
                 .MapGet("/Redirect", new RedirectResponse("https://softuni.org")))
              .Start();

Main();