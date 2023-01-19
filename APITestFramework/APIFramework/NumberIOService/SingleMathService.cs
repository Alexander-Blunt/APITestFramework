using Newtonsoft.Json;

namespace APIFramework;

public class SingleMathService : Service
{

    #region Constructors
    public SingleMathService(CallManager callManager) : base(callManager) { }
    #endregion

    #region Methods
    public override async Task MakeRandomRequestAsync()
    {
        ResponseString = await CallManager.MakeRequestAsync("random/math");

        Content = JsonConvert.DeserializeObject<Model>(ResponseString);
    }

    public override async Task MakeRequestAsync(int number)
    {
        ResponseString = await CallManager.MakeRequestAsync($"{number}/math");

        Content = JsonConvert.DeserializeObject<Model>(ResponseString);
    }
    #endregion
}