using APIFramework;

namespace APIFrameworkTests;

public class GivenInvalidRequest_SingleNumbersService
{
    NumbersService _service;
    [OneTimeSetUp]
    public async Task SetUp()
    {
        _service = new();
        await _service.MakeRequestAsync("garbage");
    }

    [Category("AC 1.3")]
    [Test]
    public void ReturnsStatusCode404()
    {
        int statusCode = _service.GetStatus();

        Assert.That(statusCode, Is.EqualTo(404));
    }
}