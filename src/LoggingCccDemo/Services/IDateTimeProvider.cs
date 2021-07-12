namespace LoggingCccDemo.Services
{
    using System;

    public interface IDateTimeProvider
    {
        DateTime GetDateTimeNow();
    }
}