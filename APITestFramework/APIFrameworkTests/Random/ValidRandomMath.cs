using APIFramework;

namespace APIFrameworkTests;

public class ValidRandomMath
{
    SingleMathService _singleRandomMathService;
    [OneTimeSetUp]
    public async Task SetUp()
    {
        CallManager _callManager = new();
        _singleRandomMathService = new(_callManager);
        await _singleRandomMathService.MakeRandomRequestAsync();
    }

    [Category("User Story #4")]
    [Test]
    public void GivenValidParameter_RandomRequest_ReturnsStatusCode200()
    {
        int statusCode = (int)_singleRandomMathService.CallManager.RestResponse.StatusCode;

        Assert.That(statusCode, Is.EqualTo(200));
    }

    [Category("User Story #4")]
    [Test]
    public void GivenNumber_RandomRequest_FoundIsTrue()
    {
        bool found = _singleRandomMathService.Content.Found;

        Assert.That(found, Is.True);
    }
}
