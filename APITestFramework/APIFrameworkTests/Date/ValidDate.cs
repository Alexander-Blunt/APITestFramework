using APIFramework;
using APIFramework.NumberIOService;
using System.Collections.Generic;

namespace APIFrameworkTests;

public class ValidDate
{
    SingleDateService _singleDateService;
    SingleDateService _singleRandomDateService;
    List<SingleDateService> dateServices;
    [OneTimeSetUp]
    public async Task SetUp()
    {
        _singleDateService = new(new CallManager());
        _singleRandomDateService = new(new CallManager());

        dateServices = new() {
            new(new CallManager()),
            new(new CallManager())
        };

        await _singleDateService.MakeRequestAsync(2, 3);
        await _singleRandomDateService.MakeRandomRequestAsync();

        await dateServices[0].MakeRequestAsync(3,2);
        await dateServices[1].MakeRequestAsync(1,3);

    }

    [Category("AC 3.1")]
    [Test] //3.1.1
    public void GivenValidParameter_DateRequest_ReturnsStatusCode200()
    {
        int statusCode = (int)_singleDateService.CallManager.RestResponse.StatusCode;

        Assert.That(statusCode, Is.EqualTo(200));
    }

    [Category("AC 3.1")]
    [Test] //3.1.2
    public void GivenValidMonthDay_DateRequest_Found()
    {
        bool found = _singleDateService.Content.Found;

        Assert.That(found, Is.True);
    }

    [Category("AC 3.1")]
    [Test] //3.1.3
    public void GivenValidMonthDay_DateRequest_ReturnsTypeDate()
    {
        string requestType = _singleDateService.Content.Type;

        Assert.That(requestType, Is.EqualTo("date"));
    }

    [Category("AC 3.1")]
    [Test] //3.1.4
    public void GivenValidMonthDay_DateRequest_ReturnsBodyContainingMonthAndDay()
    {
        string requestBody0 = dateServices[0].Content.Text;
        string requestBody1 = dateServices[1].Content.Text;

        string expected0 = "February";
        string expected1 = "March";

        Assert.That(requestBody0, Does.Contain(expected0));
        Assert.That(requestBody1, Does.Contain(expected1));
    }

    [Category("AC 5.1")]
    [Test] //5.1.3.1
    public void RandomDateRequest_ReturnsStatusCode200()
    {
        int statusCode = (int)_singleRandomDateService.CallManager.RestResponse.StatusCode;

        Assert.That(statusCode, Is.EqualTo(200));
    }

    [Category("AC 3.1")]
    [Test] //5.1.3.2
    public void RandomDateRequest_ReturnsFound()
    {
        bool found = _singleRandomDateService.Content.Found;

        Assert.That(found, Is.True);
    }

    [Category("AC 5.1")]
    [Test] //5.1.3.3
    public void RandomDateRequest_ReturnsTypeDate()
    {
        string requestType = _singleRandomDateService.Content.Type;

        Assert.That(requestType, Is.EqualTo("date"));
    }
}
