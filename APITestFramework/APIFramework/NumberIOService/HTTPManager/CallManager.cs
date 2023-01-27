using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace APIFramework;

public class CallManager
{
    private readonly HttpClient _client;
    public HttpResponseMessage ResponseMessage { get; set; }
    public string ResponseContent { get; set; }
    public int ResponseStatusCode { get; private set; }
    public Dictionary<string, IEnumerable<string>> ResponseHeaders { get; private set; }

    public CallManager()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri(AppConfigReader.BaseUrl);
    }
    
    public async Task MakeRequestAsync(string input)
    {
        var request = new HttpRequestMessage();
        request.RequestUri = new Uri(input,UriKind.Relative);
        request.Method = HttpMethod.Get;
        request.Content.Headers.Add("Conent-Type", "application/json");


        ResponseMessage = await _client.SendAsync(request);

        ResponseContent = await ResponseMessage.Content.ReadAsStringAsync();
        ResponseStatusCode = (int)ResponseMessage.StatusCode;
        ResponseHeaders = new Dictionary<string, IEnumerable<string>>(ResponseMessage.Headers);
        foreach (var header in ResponseMessage.Content.Headers)
        {
            ResponseHeaders.Append(header);
        }
    }
}
