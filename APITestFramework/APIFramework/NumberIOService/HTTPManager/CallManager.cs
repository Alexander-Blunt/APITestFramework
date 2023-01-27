using RestSharp;

namespace APIFramework;

public class CallManager
{
    private readonly RestClient _client;
    public RestResponse RestResponse { get; set; }
    public string Content { get; internal set; }

    public CallManager()
    {
        _client = new RestClient(AppConfigReader.BaseUrl);
    }
    
    public async Task<string> MakeRequestAsync(string input)
    {
        //Building Request
        var request = new RestRequest(); //HTTP Request
        request.Method = Method.Get;
        request.AddHeader("Content-Type", "application/json");
        request.Timeout = -1; //Response will not timeout

        request.Resource = $"{input}";

        RestResponse = await _client.ExecuteAsync(request);

        return RestResponse.Content;

        //request.resource comes in as string
    }
}
