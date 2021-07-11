namespace AsyncMethodsInterceptionDemo.Infrastructure.Container.Interceptors
{
    using AsyncMethodsInterceptionDemo.Services;
    using AsyncMethodsInterceptionDemo.Services.Logging;
    using Castle.DynamicProxy;

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
