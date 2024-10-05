using System.Text.Json;

namespace Sawmill.Core
{
    public class EmailStrings
    {
        public string From;
        public string To;
        public string Password;
        public string Client;
        public string Port;
        

        public  EmailStrings() {
             string jsonString = File.ReadAllText("appsettings.json");

             JsonDocument doc = JsonDocument.Parse(jsonString);

             JsonElement settings = doc.RootElement.GetProperty("EmailSettings");
           
            From = settings.GetProperty("from").GetString() ?? "Помилка відправки листа";

            To = settings.GetProperty("to").GetString() ?? "Помилка відправки листа";

            Password = settings.GetProperty("password").GetString() ?? "Помилка відправки листа";

            Client = settings.GetProperty("client").GetString() ?? "Помилка відправки листа";

            Port = settings.GetProperty("port").GetString() ?? "Помилка відправки листа";
           
        }
    }
}
