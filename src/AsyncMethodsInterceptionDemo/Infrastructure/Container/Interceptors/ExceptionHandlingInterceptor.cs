namespace AsyncMethodsInterceptionDemo.Infrastructure.Container.Interceptors
{
    using System;
    using System.Threading.Tasks;
    using AsyncMethodsInterceptionDemo.Services.Logging;
    using Castle.DynamicProxy;

    public class ExceptionHandlingInterceptor : AsyncInterceptorBase
    {
        private readonly ILoggerService loggerService;

        public ExceptionHandlingInterceptor(ILoggerService loggerService)
            => this.loggerService = loggerService;

        protected override async Task InterceptAsync(
            IInvocation invocation,
            IInvocationProceedInfo proceedInfo,
            Func<IInvocation, IInvocationProceedInfo, Task> proceed)
        {
            try
            {
                // Cannot simply return the the task, as any exceptions would not be caught below.
                await proceed(invocation, proceedInfo)
                        .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.loggerService
                        .Log($"{ex.Message}{Environment.NewLine}{ex.Message}{Environment.NewLine}");

                throw;
            }
        }

        protected override async Task<TResult> InterceptAsync<TResult>(
            IInvocation invocation,
            IInvocationProceedInfo proceedInfo,
            Func<IInvocation, IInvocationProceedInfo, Task<TResult>> proceed)
        {
            try
            {
                // Cannot simply return the the task, as any exceptions would not be caught below.
                return await proceed(invocation, proceedInfo)
                        .ConfigureAwait(false);
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
