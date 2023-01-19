using Newtonsoft.Json;

namespace APIFramework.NumberIOService;

public class SingleDateService : Service
{
    public SingleDateService(CallManager callManager) : base(callManager) { }
    public override async Task MakeRandomRequestAsync()
    {
        ResponseString = await CallManager.MakeRequestAsync("random/date");

        Content = JsonConvert.DeserializeObject<Model>(ResponseString);
    }

    public override async Task MakeRequestAsync(int number)
    {
        ResponseString = await CallManager.MakeRequestAsync($"{number.ToString()}/date");

        Content = JsonConvert.DeserializeObject<Model>(ResponseString);
    }
    
    public async Task MakeRequestAsync(int day, int month)
    {
        ResponseString = await CallManager.MakeRequestAsync($"{month.ToString()}/{day.ToString()}/date");
        
        Content = JsonConvert.DeserializeObject<Model>(ResponseString);
    }
}
