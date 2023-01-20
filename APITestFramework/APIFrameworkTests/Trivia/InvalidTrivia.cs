using APIFramework;

namespace APIFrameworkTests;

public class GivenInvalidTriviaRequest_SingleTriviaService
{
    TriviaService _service;
    [OneTimeSetUp]
    public async Task SetUp()
    {
        _service = new();
        await _service.MakeRequestAsync("garbage");
    }

    [Category("AC 1.3")]
    [Test]
    public void ReturnsStatusCode404()
    {
        int statusCode = (int)_service.CallManager.RestResponse.StatusCode;

        Assert.That(statusCode, Is.EqualTo(404));
    }
}