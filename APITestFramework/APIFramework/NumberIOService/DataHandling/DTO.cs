using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.NumberIOService.DataHandling;

public class DTO
{
    public Model DeserializeJson(string ResponseString)
    {
        return JsonConvert.DeserializeObject<Model>(ResponseString);
    }
}