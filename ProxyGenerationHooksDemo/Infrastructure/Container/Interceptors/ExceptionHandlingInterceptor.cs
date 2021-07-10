namespace ProxyGenerationDemo.Infrastructure.Container.Interceptors
{
    using System;

    using Castle.DynamicProxy;
    using ProxyGenerationDemo.Services.Logging;

    public class ExceptionHandlingInterceptor : IInterceptor
    {
        private readonly ILoggerService loggerService;

        public ExceptionHandlingInterceptor(ILoggerService loggerService)
            => this.loggerService = loggerService;

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                this.loggerService
                        .Log($"{ex.Message}{Environment.NewLine}{ex.Message}{Environment.NewLine}");

                throw;
            }
        }
    }
}
