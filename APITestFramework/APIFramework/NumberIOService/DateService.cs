using Newtonsoft.Json;

namespace APIFramework;

public class DateService : Service
{
    public DateService() : base() { }

    public override async Task MakeRequestAsync(string number)
    {
        ResponseString = await CallManager.MakeRequestAsync($"{number}/date");
		try
		{
            Content = JsonConvert.DeserializeObject<Model>(ResponseString);
        }
        catch (JsonReaderException e)
		{
		}
    }
}
