using APIFramework;

namespace APIFrameworkTests;
public class InvalidMath
{
    SingleMathService _Service;
    [OneTimeSetUp]
    public async Task SetUp()
    {
        CallManager _callManager = new();
        _Service = new(_callManager);
        await _Service.MakeRequestAsync("test");
    }

    [Category("User Story #4")]
    [Test] //AC 1.2
    public void GivenInvalidRequest_MathRequest_ReturnsCode404()
    {
        int statusCode = (int)_Service.CallManager.RestResponse.StatusCode;

        Assert.That(statusCode, Is.EqualTo(404));
    }
}
