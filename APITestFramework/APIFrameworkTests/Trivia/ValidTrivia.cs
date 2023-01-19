using APIFramework;

namespace APIFrameworkTests;

public class Tests
{
    SingleTriviaService _service;
    [OneTimeSetUp]
    public async Task SetUp()
    {
        CallManager _callManager = new();
        _service = new(_callManager);
        await _service.MakeRandomRequestAsync();
    }

    [Category("User Story #1")]
    [Test]
    public void GivenValidParameter_DateRequest_ReturnsStatusCode200()
    {
        int statusCode = (int)_service.CallManager.RestResponse.StatusCode;

        Assert.That(statusCode, Is.EqualTo(200));
    }

    [Category("User Story #1")]
    [Test]
    public void GivenValidMonthDay_DateRequest_FoundIsTrue()
    {
        bool found = _service.Content.Found;

        Assert.That(found, Is.True);
    }

    [Category("User Story #1")]
    [Test]
    public void GivenValidMonthDay_DateRequest_ReturnsTypeDate()
    {
        string requestType = _service.Content.Type;

        Assert.That(requestType, Is.EqualTo("trivia"));

    }
}