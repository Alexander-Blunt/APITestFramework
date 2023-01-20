using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework;

public class YearService : Service
{
    #region Constructors
    public YearService() : base() { }
    #endregion

    #region Methods

    public override async Task MakeRequestAsync(string number)
    {
        ResponseString = await CallManager.MakeRequestAsync($"{number}/year");

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
