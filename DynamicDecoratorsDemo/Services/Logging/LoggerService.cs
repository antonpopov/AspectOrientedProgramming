using System;

namespace DynamicDecoratorsDemo.Services.Logging
{
    public class LoggerService : ILoggerService
    {
        public void Log(string message)
            => Console.WriteLine(message);
    }
}
