using APIFramework;

namespace APIFrameworkTests;

public class ValidDate
{
    SingleTriviaService _singleNumberService;
    [OneTimeSetUp]
    public async Task SetUp()
    {
        CallManager _callManager = new();
        _singleNumberService = new(_callManager);
        await _singleNumberService.MakeRandomRequestAsync();
    }

    [Category("User Story #3")]
    [Test]
    public void GivenValidParameter_DateRequest_ReturnsStatusCode200()
    {
        int statusCode = (int)_singleNumberService.CallManager.RestResponse.StatusCode;

        Assert.That(statusCode, Is.EqualTo(200));
    }

    [Category("User Story #3")]
    [Test]
    public void GivenValidMonthDay_DateRequest_FoundIsTrue()
    {
        bool found = _singleNumberService.Content.Found;

        Assert.That(found, Is.True);
    }

    [Category("User Story #3")]
    [Test]
    public void GivenValidMonthDay_DateRequest_ReturnsTypeDate()
    {
        string requestType = _singleNumberService.Content.Type;

        Assert.That(requestType, Is.EqualTo("date"));

    }

}
