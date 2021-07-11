namespace DynamicDecoratorsDemo.Services.Logging
{
    using System;

    public class LoggerService : ILoggerService
    {
        public void Log(string message)
            => Console.WriteLine(message);
    }
}
