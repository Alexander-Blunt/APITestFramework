using APIFramework;
using System.Collections.Generic;

namespace APIFrameworkTests;

public class ValidDate
{
    NumbersService _service;
    List<NumbersService> _numberServices;
    [OneTimeSetUp]
    public async Task SetUp()
    {
        _service = new();
        _numberServices = new() { new NumbersService(), new NumbersService() };

        await _service.MakeRequestAsync("2/3");
        await _service.MakeRequestAsync("random");

        await _numberServices[0].MakeRequestAsync("2/3");
        await _numberServices[1].MakeRequestAsync("3/2");
    }

    [Category("AC 3.1")]
    [Test] //3.1.1
    public void GivenValidParameter_DateRequest_ReturnsStatusCode200()
    {
        int statusCode = _service.GetStatus();

        Assert.That(statusCode, Is.EqualTo(200));
    }

    [Category("AC 3.1")]
    [Test] //3.1.2
    public void GivenValidMonthDay_DateRequest_Found()
    {
        bool found = _service.Content.Found;

        Assert.That(found, Is.True);
    }

    [Category("AC 3.1")]
    [Test] //3.1.3
    public void GivenValidMonthDay_DateRequest_ReturnsTypeDate()
    {
        string requestType = _service.Content.Type;

        Assert.That(requestType, Is.EqualTo("date"));
    }

    [Category("AC 3.1")]
    [Test] //3.1.4
    public void GivenValidMonthDay_DateRequest_ReturnsBodyContainingMonthAndDay()
    {
        string requestBody0 = _numberServices[0].Content.Text;
        string requestBody1 = _numberServices[1].Content.Text;

        string expected0 = "February";
        string expected1 = "March";

        Assert.That(requestBody0, Does.Contain(expected0));
        Assert.That(requestBody1, Does.Contain(expected1));
    }

    [Category("AC 5.1")]
    [Test] //5.1.3.1
    public void RandomDateRequest_ReturnsStatusCode200()
    {
        int statusCode = _service.GetStatus();

        Assert.That(statusCode, Is.EqualTo(200));
    }

    [Category("AC 3.1")]
    [Test] //5.1.3.2
    public void RandomDateRequest_ReturnsFound()
    {
        bool found = _service.Content.Found;

        Assert.That(found, Is.True);
    }

    [Category("AC 5.1")]
    [Test] //5.1.3.3
    public void RandomDateRequest_ReturnsTypeDate()
    {
        string requestType = _service.Content.Type;

        Assert.That(requestType, Is.EqualTo("date"));
    }
}
