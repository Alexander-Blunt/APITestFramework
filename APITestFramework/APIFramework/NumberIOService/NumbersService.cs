using APIFramework.NumberIOService.DataHandling;
using System.Net.Http.Headers;

namespace APIFramework;

public class NumbersService
{
    #region Parameters
    public CallManager CallManager { get; set; }
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
        if (CallManager.ResponseHeaders["Content-Type"].Contains("aplication/json"))
        {
            Content = DTO.DeserializeJson(CallManager.ResponseContent);
        }
        else
        {
            Content = null;
        }
    }

    public int GetStatus()
    {
        return CallManager.ResponseStatusCode;
    }
    #endregion
}
