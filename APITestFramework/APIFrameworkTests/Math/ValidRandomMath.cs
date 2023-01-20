using APIFramework;

namespace APIFrameworkTests;

public class ValidRandomMath
{
    SingleMathService _Service;
    [OneTimeSetUp]
    public async Task SetUp()
    {
        CallManager _callManager = new();
        _Service = new(_callManager);
        await _Service.MakeRequestAsync("random");
    }

    [Category("User Story #4")]
    [Test]
    public void GivenValidParameter_RandomRequest_ReturnsStatusCode200()
    {
        int statusCode = (int)_Service.CallManager.RestResponse.StatusCode;

        Assert.That(statusCode, Is.EqualTo(200));
    }

    [Category("User Story #4")]
    [Test]
    public void GivenNumber_RandomRequest_FoundIsTrue()
    {
        bool found = _Service.Content.Found;

        Assert.That(found, Is.True);
    }
}
