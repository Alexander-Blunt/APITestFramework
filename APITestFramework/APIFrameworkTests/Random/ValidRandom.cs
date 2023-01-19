using APIFramework;

namespace APIFrameworkTests;

public class ValidRandom
{
    SingleRandomTriviaService _singleRandomTriviaService;
    [OneTimeSetUp]
    public async Task SetUp()
    {
        CallManager _callManager = new();
        _singleRandomTriviaService = new(_callManager);
        await _singleRandomTriviaService.MakeRequestAsync();
    }

    [Category("User Story #5")]
    [Test]
    public void GivenValidParameter_RandomRequest_ReturnsStatusCode200()
    {
        int statusCode = (int)_singleRandomTriviaService.CallManager.RestResponse.StatusCode;

        Assert.That(statusCode, Is.EqualTo(200));
    }

    [Category("User Story #5")]
    [Test]
    public void GivenValidMonthDay_RandomRequest_FoundIsTrue()
    {
        bool found = _singleRandomTriviaService.Content.Found;

        Assert.That(found, Is.True);
    }
}
