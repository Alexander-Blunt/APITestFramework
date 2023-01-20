using APIFramework;

namespace APIFrameworkTests;

public class ValidMath
{
    SingleMathService _Service;
    [OneTimeSetUp]
    public async Task SetUp()
    {
        CallManager _callManager = new();
        _Service = new(_callManager);
        await _Service.MakeRequestAsync("5");
    }

    [Category("User Story #4")]
    [Test] 
    public void GivenValidParameter_MathRequest_ReturnsStatusCode200()
    {
        int statusCode = (int)_Service.CallManager.RestResponse.StatusCode;

        Assert.That(statusCode, Is.EqualTo(200));
    }

    [Category("User Story #4")]
    [Test]
    public void GivenValidMonthDay_MathRequest_FoundIsTrue()
    {
        bool found = _Service.Content.Found;

        Assert.That(found, Is.True);
    }

    [Category("User Story #4")]
    [Test] 
    public void GivenValidNumber_MathRequest_ReturnsTypeMath()
    {
        string requestType = _Service.Content.Type;

        Assert.That(requestType, Is.EqualTo("math"));
    }
}
