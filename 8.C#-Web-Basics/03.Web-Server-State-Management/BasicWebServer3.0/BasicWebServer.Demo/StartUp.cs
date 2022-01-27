using BasicWebServer.Server;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;
using System.Text;
using System.Web;

namespace BasicWebServer.Demo
{
    public class StartUp
    {
        public const string HtmlForm = @"<form action='/HTML' method='POST'>
   Name: <input type='text' name='Name'/>
   Age: <input type='number' name ='Age'/>
<input type='submit' value ='Save' />
</form>";

        private const string DownloadForm = @"<form action='/Content' method='POST'>
   <input type='submit' value ='Download Sites Content' /> 
</form>";

        private const string FileName = "content.txt";

        public static async Task Main()
        {
            await DownloadSitesAsTextFiles(FileName,
                new string[] { "https://judge.softuni.org", "https://softuni.org" });

            var server = new HttpServer(routes => routes
                 .MapGet("/", new TextResponse("Hello from the server!"))
                 .MapGet("/Redirect", new RedirectResponse("https://softuni.org"))
                 .MapGet("/HTML", new HtmlResponse(HtmlForm))
                 .MapPost("/HTML", new TextResponse("", AddFormDataAction))
                 .MapGet("/Content", new HtmlResponse(DownloadForm))
                 .MapPost("/Content", new TextFileResponse(FileName))
                 .MapGet("/Cookies", new HtmlResponse("", AddCookieAction))
                 .MapGet("/Session", new TextResponse("", DisplaySessionInformation)));

            await server.Start();
        }

        public static void AddFormDataAction(Request request, Response response)
        {
            response.Body = "";

            foreach (var (key, value) in request.Form)
            {
                response.Body += $"{key} - {value}";
                response.Body += Environment.NewLine;
            }
        }

        private static void AddCookieAction(Request request, Response response)
        {
            var requestHasCookies = request.Cookies.Any(c => c.Name != Session.SessionCookieName);

            var bodyText = "";

            if (requestHasCookies)
            {
                var cookieText = new StringBuilder();

                cookieText.AppendLine("<h1>Cookies</h1>");

                cookieText.Append("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

                foreach (var cookie in request.Cookies)
                {
                    cookieText.Append("<tr>");
                    cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
                    cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");
                    cookieText.Append("</tr>");
                }

                cookieText.Append("</table>");

                bodyText = cookieText.ToString();
            }
            else
            {
                bodyText = "<h1>Cookies set!</h1>";
            }

            if (!requestHasCookies)
            {
                response.Cookies.Add("testCookie_1", "testCookie_1_Value");
                response.Cookies.Add("testCookie_2", "testCookie_2_Value");
            }
        }

        private static async Task<string> DownloadWebSiteContent(string url)
        {
            var httpClient = new HttpClient();

            using (httpClient)
            {
                var response = await httpClient.GetAsync(url);

                var html = await response.Content.ReadAsStringAsync();

                return html.Substring(0, 2000);
            }
        }

        private static void DisplaySessionInformation(Request request, Response response)
        {
            var sessionsExists = request.Session.ContainsKey(Session.SessionCurrentDateKey);

            var bodyText = "";

            if (sessionsExists)
            {
                var currentDate = request.Session[Session.SessionCurrentDateKey];
                bodyText = $"Stored date: {currentDate}!";
            }
            else
            {
                bodyText = "Current date stored!";
            }

            response.Body = "";
            response.Body += bodyText;
        }

        private static async Task DownloadSitesAsTextFiles(string fileName, string[] urls)
        {
            var downloads = new List<Task<string>>();

            foreach (var url in urls)
            {
                downloads.Add(DownloadWebSiteContent(url));
            }

            var responses = await Task.WhenAll(downloads);

            var responsesString = string.Join(Environment.NewLine + new string('-', 100), responses);

            await File.WriteAllTextAsync(fileName, responsesString);
        }
    }
}