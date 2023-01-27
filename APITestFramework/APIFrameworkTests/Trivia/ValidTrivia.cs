using APIFramework;

namespace APIFrameworkTests;

public class GivenValidTriviaRequest_SingleNumbersService
{
    NumbersService _service;
    [OneTimeSetUp]
    public async Task SetUp()
    {
        _service = new();
        await _service.MakeRequestAsync("12");
    }

    [Category("AC 1.2")]
    [Test]
    public void ReturnsStatusCode200()
    {
        int statusCode = _service.GetStatus();

        Assert.That(statusCode, Is.EqualTo(200));
    }

    [Category("AC 1.2")]
    [Test]
    public void ReturnsFoundTrue()
    {
        bool found = _service.Content.Found;

        Assert.That(found, Is.True);
    }

    [Category("AC 1.2")]
    [Test]
    public void ReturnsTypeTrivia()
    {
        string requestType = _service.Content.Type;

        Assert.That(requestType, Is.EqualTo("trivia"));
    }

    [Category("AC 1.2")]
    [Test]
    public void ReturnsCorrectNumber()
    {
        Assert.That(_service.Content.Number, Is.EqualTo(12));
    }

    [Category("AC 1.2")]
    [Test]
    public void ReturnsYear0()
    {
        Assert.That(_service.Content.Year, Is.EqualTo(0));
    }

    [Category("AC 1.2")]
    [Test]
    public void ReturnsText()
    {
        Assert.That(_service.Content.Text, Is.Not.Null);
    }
}