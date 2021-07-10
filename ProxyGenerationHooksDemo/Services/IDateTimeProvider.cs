using System;

namespace ProxyGenerationDemo.Services
{
    public interface IDateTimeProvider
    {
        DateTime GetDateTimeNow();
    }
}
