using APIFramework.NumberIOService.DataHandling;
using System.Net.Http.Headers;

namespace APIFramework;

public class NumbersService
{
    #region Parameters
    public CallManager CallManager { get; set; }
    public HttpResponseHeaders? Headers { get; set; }
    public DTO DTO { get; set; }
    public Model? Content { get; set; }
    public string? ContentString { get; set; }
    #endregion

    #region Constructors
    public NumbersService()
    {
        CallManager = new CallManager();
        DTO = new DTO();
    }
    #endregion

    #region Methods
    public async Task MakeRequestAsync(string endpoint)
    {
        await CallManager.MakeRequestAsync(endpoint);
        Headers = CallManager.Headers;
        DTO.DeserializeJson(CallManager.Content);
        Content = DTO.Content;
    }

    public int GetStatus()
    {
        return (int)CallManager.RestResponse.StatusCode;
    }
    #endregion
}
