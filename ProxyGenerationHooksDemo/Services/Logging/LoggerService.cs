using System;

namespace ProxyGenerationDemo.Services.Logging
{
    public class LoggerService : ILoggerService
    {
        public void Log(string message)
            => Console.WriteLine(message);
    }
}
