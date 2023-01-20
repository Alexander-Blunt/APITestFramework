using APIFramework;

namespace APIFrameworkTests;

public class ValidRandomMath
{
    MathService _Service;
    [OneTimeSetUp]
    public async Task SetUp()
    {
        _Service = new();
        await _Service.MakeRequestAsync("random");
    }

    [Category("AC 5.4")]
    [Test]
    public void GivenValidParameter_RandomRequest_ReturnsStatusCode200()
    {
        int statusCode = (int)_Service.CallManager.RestResponse.StatusCode;

        Assert.That(statusCode, Is.EqualTo(200));
    }

    [Category("AC 5.4")]
    [Test]
    public void GivenNumber_RandomRequest_FoundIsTrue()
    {
        bool found = _Service.Content.Found;

        Assert.That(found, Is.True);
    }
}
