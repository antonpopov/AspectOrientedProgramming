namespace DecoratorPatternDemo.Services
{
    using System;

    public interface IDateTimeProvider
    {
        DateTime GetDateTimeNow();
    }
}
