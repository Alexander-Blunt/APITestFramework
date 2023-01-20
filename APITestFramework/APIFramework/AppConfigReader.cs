using System.Configuration;
using static System.Net.WebRequestMethods;

namespace APIFramework;

public static class AppConfigReader
{
    public static readonly string BaseUrl = ConfigurationManager.AppSettings["base_url"];
}
