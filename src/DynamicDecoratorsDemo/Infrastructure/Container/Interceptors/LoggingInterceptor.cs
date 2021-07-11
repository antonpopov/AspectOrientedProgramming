namespace DynamicDecoratorsDemo.Infrastructure.Container.Interceptors
{
    using System;

    using Castle.DynamicProxy;
    using DynamicDecoratorsDemo.Services;
    using DynamicDecoratorsDemo.Services.Logging;

    public class LoggingInterceptor : IInterceptor
    {
        private readonly ILoggerService loggerService;
        private readonly IDateTimeProvider dateTimeProvider;

        public LoggingInterceptor(
            ILoggerService loggerService,
            IDateTimeProvider dateTimeProvider)
        {
            this.loggerService = loggerService;
            this.dateTimeProvider = dateTimeProvider;
        }

        public void Intercept(IInvocation invocation)
        {
            string interceptedMethodName = invocation.Method.Name;

            this.loggerService
                    .Log($"Stepped in {interceptedMethodName} at {this.dateTimeProvider.GetDateTimeNow()}");

            invocation.Proceed();

            this.loggerService
                    .Log($"Stepped out of {interceptedMethodName} at {this.dateTimeProvider.GetDateTimeNow()}");
        }
    }
}
