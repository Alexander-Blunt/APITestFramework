using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.NumberIOService.DataHandling;

public class DTO
{
    public Model? Content { get; set; }

    public void DeserializeJson(string ResponseString)
    {
        try { Content = JsonConvert.DeserializeObject<Model>(ResponseString); }
        catch (JsonReaderException e) {  }
    }
}
