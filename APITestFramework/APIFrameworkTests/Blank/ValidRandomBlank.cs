using APIFramework;

namespace APIFrameworkTests;

public class GivenValidRandomTriviaRequest_SingleBlankService
{
    BlankService _service;
    [OneTimeSetUp]
    public async Task SetUp()
    {
        _service = new();
        await _service.MakeRequestAsync("random");
    }

    [Category("AC 5.1")]
    [Test]
    public void ReturnsStatusCode200()
    {
        int statusCode = (int)_service.CallManager.RestResponse.StatusCode;

        Assert.That(statusCode, Is.EqualTo(200));
    }

    [Category("AC 5.1")]
    [Test]
    public void ReturnsFoundTrue()
    {
        bool found = _service.Content.Found;

        Assert.That(found, Is.True);
    }

    [Category("AC 5.1")]
    [Test]
    public void ReturnsTypeTrivia()
    {
        string requestType = _service.Content.Type;

        Assert.That(requestType, Is.EqualTo("trivia"));
    }

    [Category("AC 5.1")]
    [Test]
    public void ReturnsYear0()
    {
        Assert.That(_service.Content.Year, Is.EqualTo(0));
    }

    [Category("AC 5.1")]
    [Test]
    public void ReturnsText()
    {
        Assert.That(_service.Content.Text, Is.Not.Null);
    }
}
