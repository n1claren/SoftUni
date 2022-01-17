using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Common
{
    // Those are supposed to be inside the StartUp class, but i dont have it in VS2022
    // so this is my work around for educational purposes only
    // i know its probably a bad practice
    public class Constants
    {
        public const string HtmlForm = @"<form action='/HTML' method='POST'>
   Name: <input type='text' name='Name'/>
   Age: <input type='number' name ='Age'/>
<input type='submit' value ='Save' />
</form>";

        public static void AddFormDataAction(Request request, Response response)
        {
            response.Body = "";

            foreach (var (key, value) in request.Form)
            {
                response.Body += $"{key} - {value}";
                response.Body += Environment.NewLine;
            }
        }
    }
}
