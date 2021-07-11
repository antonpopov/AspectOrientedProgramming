namespace AsyncMethodsInterceptionDemo.Infrastructure.Container.Interceptors
{
    using AsyncMethodsInterceptionDemo.Services;
    using AsyncMethodsInterceptionDemo.Services.Logging;
    using Castle.DynamicProxy;

    public class LoggingInterceptor : ProcessingAsyncInterceptor<string>
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

        protected override string StartingInvocation(IInvocation invocation)
        {
            string interceptedMethodName = invocation.Method.Name;

            this.loggerService
                    .Log($"Stepped in {interceptedMethodName} at {this.dateTimeProvider.GetDateTimeNow()}");

            return interceptedMethodName;
        }

        protected override void CompletedInvocation(IInvocation invocation, string state)
        {
            this.loggerService
                    .Log($"Stepped out of {state} at {this.dateTimeProvider.GetDateTimeNow()}");
        }
    }
}
