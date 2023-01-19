using Newtonsoft.Json;

namespace APIFramework;

public class SingleRandomTriviaService
{
    #region Parameters
    public CallManager CallManager { get; set; }
    public Model? ResponseContent { get; private set; }
    public string? ResponseString { get; private set; }
    #endregion

    #region Constructors
    public SingleRandomTriviaService(CallManager callManager)
    {
        CallManager = callManager;
    }
    #endregion

    #region Methods
    public async Task MakeRequestAsync()
    {
        ResponseString = await CallManager.MakeRequestAsync("random/trivia");

        ResponseContent = JsonConvert.DeserializeObject<Model>(ResponseString);
    }
    #endregion
}