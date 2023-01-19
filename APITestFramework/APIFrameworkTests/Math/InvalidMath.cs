using APIFramework;

namespace APIFrameworkTests;
[Ignore("Not fixed yet")]
public class InvalidMath
{
    SingleMathService _singleNumberService;
    [OneTimeSetUp]
    public async Task SetUp()
    {
        CallManager _callManager = new();
        _singleNumberService = new(_callManager);
        //await _singleNumberService.MakeRequestAsync();
    }

    [Category("User Story #4")]
    [Test] //AC 1.2
    public void GivenInvalidRequest_MathRequest_ReturnsCode404()
    {
        int statusCode = (int)_singleNumberService.CallManager.RestResponse.StatusCode;

        Assert.That(statusCode, Is.EqualTo(404));
    }
}
