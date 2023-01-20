using Newtonsoft.Json;

namespace APIFramework;

public class DateService : Service
{
    public DateService() : base() { }

    public override async Task MakeRequestAsync(string number)
    {
        ResponseString = await CallManager.MakeRequestAsync($"{number}/date");

        Content = JsonConvert.DeserializeObject<Model>(ResponseString);
    }
}
