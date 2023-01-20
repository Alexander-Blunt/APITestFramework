﻿using APIFramework;


namespace APIFrameworkTests.Date;

public class InvalidDate
{
    DateService _service;
    [OneTimeSetUp]
    public async Task SetUp()
    {
        _service = new();
        await _service.MakeRequestAsync("garbage");
    }

    [Category("User Story #3")]
    public void GivenInvalidRequest_DateRequest_ReturnsCode404()
    {
        int statusCode = (int)_service.CallManager.RestResponse.StatusCode;

        Assert.That(statusCode, Is.EqualTo(404));
    }

}
