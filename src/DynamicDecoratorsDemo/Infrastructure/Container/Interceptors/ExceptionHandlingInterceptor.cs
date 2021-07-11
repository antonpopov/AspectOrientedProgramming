namespace DynamicDecoratorsDemo.Infrastructure.Container.Interceptors
{
    using Castle.DynamicProxy;
    using DynamicDecoratorsDemo.Services.Logging;
    using System;

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
