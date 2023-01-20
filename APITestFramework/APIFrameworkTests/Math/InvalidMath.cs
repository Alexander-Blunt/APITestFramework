using APIFramework;

namespace APIFrameworkTests;

public class InvalidMath
{
    MathService _Service;
    [OneTimeSetUp]
    public async Task SetUp()
    {
        _Service = new();
        await _Service.MakeRequestAsync("test");
    }

    [Category("AC 4.2")]
    [Test]
    public void GivenInvalidRequest_MathRequest_ReturnsCode404()
    {
        int statusCode = _Service.GetStatus();

        Assert.That(statusCode, Is.EqualTo(404));
    }
}
