using APIFramework;

namespace APIFrameworkTests;

public class ValidRandom
{
    SingleNumberService _singleNumberService;
    [OneTimeSetUp]
    public async Task SetUp()
    {
        CallManager _callManager = new();
        _singleNumberService = new(_callManager);
        await _singleNumberService.MakeRequestAsync();
    }

    [Category("User Story #5")]
    [Test]
    public void GivenValidParameter_RandomRequest_ReturnsStatusCode200()
    {
        int statusCode = _singleNumberService.CallManager.Response.Header.StatusCode;

        Assert.That(statusCode, Is.EqualTo(200));
    }

    [Category("User Story #5")]
    [Test]
    public void GivenValidMonthDay_RandomRequest_FoundIsTrue()
    {
        bool found = _singleNumberService.Content.Found;

        Assert.That(found, Is.True);
    }
}
