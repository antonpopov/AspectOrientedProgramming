namespace AsyncMethodsInterceptionDemo.Infrastructure.Container.Interceptors
{
    using System;
    using System.Threading.Tasks;
    using System.Transactions;

    using Castle.DynamicProxy;

    public class TransactionInterceptor : AsyncInterceptorBase
    {
        protected override async Task InterceptAsync(
            IInvocation invocation,
            IInvocationProceedInfo proceedInfo,
            Func<IInvocation, IInvocationProceedInfo, Task> proceed)
        {
            using (var scope = new TransactionScope())
            {
                await proceed(invocation, proceedInfo)
                    .ConfigureAwait(false);

                scope.Complete();
            }
        }

        protected override async Task<TResult> InterceptAsync<TResult>(
            IInvocation invocation,
            IInvocationProceedInfo proceedInfo,
            Func<IInvocation, IInvocationProceedInfo, Task<TResult>> proceed)
        {
            using (var scope = new TransactionScope())
            {
                var result =
                    await proceed(invocation, proceedInfo)
                        .ConfigureAwait(false);

                scope.Complete();

                return result;
            }
        }
    }
}
