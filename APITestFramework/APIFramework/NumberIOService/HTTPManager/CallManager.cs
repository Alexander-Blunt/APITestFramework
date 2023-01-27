using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;

namespace APIFramework;

public class CallManager
{
    private readonly HttpClient _client;
    public HttpResponseHeaders ResponseHeaders { get; set; }
    public string ResponseContent { get; set; }

    public CallManager()
    {
        _client = new HttpClient();
    }
    
    public async Task MakeRequestAsync(string input)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, AppConfigReader.BaseUrl +input);
        var response = await _client.SendAsync(request);
        ResponseHeaders = response.Headers;
        ResponseContent = response.Content.ToString();
    }
}
