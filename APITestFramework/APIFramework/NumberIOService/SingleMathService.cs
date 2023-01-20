using Newtonsoft.Json;

namespace APIFramework;

public class SingleMathService : Service
{

    #region Constructors
    public SingleMathService(CallManager callManager) : base() { }
    #endregion

    #region Methods
    public override async Task MakeRequestAsync(string number)
    {
        ResponseString = await CallManager.MakeRequestAsync($"{number}/math");

        Content = JsonConvert.DeserializeObject<Model>(ResponseString);
    }
    #endregion
}