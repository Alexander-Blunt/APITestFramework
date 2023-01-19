﻿using APIFramework;

namespace APIFrameworkTests;

public class ValidMath
{
    SingleTriviaService _singleNumberService;
    [OneTimeSetUp]
    public async Task SetUp()
    {
        CallManager _callManager = new();
        _singleNumberService = new(_callManager);
        await _singleNumberService.MakeRandomRequestAsync();
    }

    [Category("User Story #4")]
    [Test]
    public void GivenValidParameter_MathRequest_ReturnsStatusCode200()
    {
        int statusCode = (int)_singleNumberService.CallManager.RestResponse.StatusCode;

        Assert.That(statusCode, Is.EqualTo(200));
    }

    [Category("User Story #4")]
    [Test]
    public void GivenValidMonthDay_MathRequest_FoundIsTrue()
    {
        bool found = _singleNumberService.Content.Found;

        Assert.That(found, Is.True);
    }
}
