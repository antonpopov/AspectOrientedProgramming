namespace LoggingExceptionHandlingTransactioningCccDemo.Services.Logging
{
    using System;

    public class ConsoleLoggerService : ILoggerService
    {
        public void Log(string message)
            => Console.WriteLine(message);
    }
}
