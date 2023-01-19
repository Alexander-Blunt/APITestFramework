using System.Configuration;

namespace APIFramework;

internal class AppConfigReader
{
    public static readonly string BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];
}
