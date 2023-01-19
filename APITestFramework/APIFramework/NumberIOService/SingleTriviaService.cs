using Newtonsoft.Json;

namespace APIFramework;

public class SingleTriviaService : Service
{

    #region Constructors
    public SingleTriviaService(CallManager callManager) : base(callManager) { }
    #endregion

    #region Methods
    public override async Task MakeRandomRequestAsync()
    {
        ResponseString = await CallManager.MakeRequestAsync("random/trivia");

        Content = JsonConvert.DeserializeObject<Model>(ResponseString);
    }

    public override Task MakeRequestAsync(int number)
    {
        throw new NotImplementedException();
    }
    #endregion
}