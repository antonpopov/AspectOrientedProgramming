namespace ProxyGenerationDemo.Services
{
    using System;

    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetDateTimeNow()
            => DateTime.Now;
    }
}
