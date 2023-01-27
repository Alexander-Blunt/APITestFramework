using APIFramework;
using APIFramework.NumberIOService.DataHandling;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;

namespace APIFrameworkTests;

public class DTOTests
{
    DTO _sut;
    string validJson;
    string invalidJson;
    [OneTimeSetUp]
    public void SetUp()
    {
        validJson = "{\r\n    " +
            "\"text\": \"25 is the percentage of all scald burns to children from hot tap water.\",\r\n    " +
            "\"number\": 25,\r\n    " +
            "\"found\": true,\r\n    " +
            "\"type\": \"trivia\"\r\n}";
        invalidJson = "invalid json";
    }

    [Category("DTO")]
    [Test]
    public void GivenValidJson_Deserialize_CreatesAContentObject()
    {
        _sut = new DTO();

        _sut.DeserializeJson(validJson);

        Assert.That(_sut.Content.Text, Is.EqualTo("25 is the percentage of all scald burns to children from hot tap water."));
        Assert.That(_sut.Content.Number, Is.EqualTo(25));
        Assert.That(_sut.Content.Found, Is.True);
        Assert.That(_sut.Content.Type, Is.EqualTo("trivia"));
    }

    [Category("DTO")]
    [Test]
    public void GivenInvalidJson_Deserialize_ThrowsError()
    {
        _sut = new DTO();

        Assert.That(() => _sut.DeserializeJson(invalidJson), Throws.TypeOf<JsonReaderException>());
    }
}
