﻿using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Interfaces
{
    public interface IRoutingTable
    {
        IRoutingTable Map(string url, Method method, Response response);

        IRoutingTable MapGet(string url, Response response);

        IRoutingTable MapPost(string url, Response response);
    }
}
