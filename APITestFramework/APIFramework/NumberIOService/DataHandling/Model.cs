
using Newtonsoft.Json;

public class Model
{
    [JsonProperty("text")]
    public string Text { get; set; }
    [JsonProperty("year")]
    public int Year { get; set; }
    [JsonProperty("number")]
    public int Number { get; set; }
    [JsonProperty("found")]
    public bool Found { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
}
