using APIFramework;

namespace APIFrameworkTests.Date;

[Ignore("Methods not Implemented")]
public class InvalidDate
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
    public void GivenInvalidRequest_DateRequest_ReturnsCode404()
    {
        int statusCode = (int)_singleNumberService.CallManager.RestResponse.StatusCode;

        Assert.That(statusCode, Is.EqualTo(404));
    }

}
