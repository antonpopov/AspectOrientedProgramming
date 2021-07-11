namespace LoggingExceptionHandlingTransactioningCccDemo.Services
{
    using System;

    public interface IDateTimeProvider
    {
        DateTime GetDateTimeNow();
    }
}
