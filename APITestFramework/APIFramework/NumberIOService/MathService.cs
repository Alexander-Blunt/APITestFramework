using Newtonsoft.Json;

namespace APIFramework;

public class MathService : Service
{

    #region Constructors
    public MathService() : base() { }
    #endregion

    #region Methods
    public override async Task MakeRequestAsync(string number)
    {
        ResponseString = await CallManager.MakeRequestAsync($"{number}/math");

        Content = JsonConvert.DeserializeObject<Model>(ResponseString);
    }
    #endregion
}