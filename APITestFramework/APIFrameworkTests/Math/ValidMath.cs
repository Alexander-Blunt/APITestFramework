using APIFramework;

namespace APIFrameworkTests;

public class ValidMath
{
    SingleNumberService _singleNumberService;
    [OneTimeSetUp]
    public async Task SetUp()
    {
        CallManager _callManager = new();
        _singleNumberService = new(_callManager);
        await _singleNumberService.MakeRequestAsync();
    }

    //given a valid parameter
    //when i make a date request
    //i get status 200
    [Test]
    public void GivenValidParameter_MathRequest_ReturnsStatusCode200()
    {
        int statusCode = _singleNumberService.CallManager.Response.Header.StatusCode;

        Assert.That(statusCode, Is.EqualTo(200));
    }

    //given a valid month and day
    //when i make a date request
    //then i get a date response
    [Test]
    public void GivenValidMonthDay_MathRequest_FoundIsTrue()
    {
        bool found = _singleNumberService.Content.Found;

        Assert.That(found, Is.True);
    }
}
