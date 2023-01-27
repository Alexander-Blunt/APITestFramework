using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;

namespace APIFramework;

public class CallManager
{
    private readonly HttpClient _client;
    public HttpResponseHeaders responseHeader { get; set; }
    public HttpContent responseContent { get; set; }

    public CallManager()
    {
        _client = new HttpClient();
    }

    public async void MakeRequestAsync(string input)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"AppConfigReader.BaseUrl{input}");
        var response = await _client.SendAsync(request);
        responseHeader = response.Headers;
        responseContent = response.Content;
    }
}
