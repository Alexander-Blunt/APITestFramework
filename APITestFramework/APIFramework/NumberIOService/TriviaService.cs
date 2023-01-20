using Newtonsoft.Json;

namespace APIFramework;

public class TriviaService : Service
{
    #region Constructors
    public TriviaService() : base() { }
    #endregion

    #region Methods

    public override async Task MakeRequestAsync(string number)
    {
        ResponseString = await CallManager.MakeRequestAsync($"{number}/trivia");

        Content = JsonConvert.DeserializeObject<Model>(ResponseString);
    }
    #endregion
}