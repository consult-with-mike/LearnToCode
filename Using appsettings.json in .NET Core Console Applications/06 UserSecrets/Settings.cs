using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Environments
{
    public class Settings
    {
        public ConnectionStrings ConnectionStrings { get; set; }

        public Logging Logging { get; set; }

        public AppSettings AppSettings { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }

    public class ConnectionStrings
    {

    }

    public class Logging
    {
        public ConsoleSettings Console { get; set; }

        public bool IncludeScopes { get; set; }

        public class ConsoleSettings
        {
            public LogLevelSettings LogLevel { get; set; }

            public class LogLevelSettings
            {
                [JsonConverter(typeof(JsonStringEnumConverter))]
                public LogLevel Default { get; set; }

                [JsonConverter(typeof(JsonStringEnumConverter))]
                public LogLevel System { get; set; }

                [JsonConverter(typeof(JsonStringEnumConverter))]
                public LogLevel Microsoft { get; set; }
            }
        }
    }

    public class AppSettings
    {
        public string FirstSetting { get; set; }
    }
}
