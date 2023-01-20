using Newtonsoft.Json;

namespace APIFramework;

public class BlankService : Service
{
    #region Constructors
    public BlankService() : base() { }
    #endregion

    #region Methods
    public override async Task MakeRequestAsync(string resource)
    {
        ResponseString = await CallManager.MakeRequestAsync(resource);

        try
        {
            Content = JsonConvert.DeserializeObject<Model>(ResponseString);
        }
        catch (JsonReaderException e)
        {
        }
    }
    #endregion
}
