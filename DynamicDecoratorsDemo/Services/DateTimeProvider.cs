using System;

namespace DynamicDecoratorsDemo.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetDateTimeNow()
            => DateTime.Now;
    }
}
