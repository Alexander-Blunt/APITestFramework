using APIFramework;

namespace APIFrameworkTests;

public class ValidMath
{
    NumbersService _Service;
    [OneTimeSetUp]
    public async Task SetUp()
    {
        _Service = new();
        await _Service.MakeRequestAsync("5");
    }

    [Category("AC 4.1")]
    [Test] 
    public void GivenValidParameter_MathRequest_ReturnsStatusCode200()
    {
        int statusCode = _Service.GetStatus();

        Assert.That(statusCode, Is.EqualTo(200));
    }

    [Category("AC 4.1")]
    [Test]
    public void GivenValidMonthDay_MathRequest_FoundIsTrue()
    {
        bool found = _Service.Content.Found;

        Assert.That(found, Is.True);
    }

    [Category("AC 4.1")]
    [Test] 
    public void GivenValidNumber_MathRequest_ReturnsTypeMath()
    {
        string requestType = _Service.Content.Type;

        Assert.That(requestType, Is.EqualTo("math"));
    }
}
