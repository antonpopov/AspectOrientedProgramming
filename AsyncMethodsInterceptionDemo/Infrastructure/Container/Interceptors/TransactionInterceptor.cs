namespace AsyncMethodsInterceptionDemo.Infrastructure.Container.Interceptors
{
    using System.Transactions;

    using Castle.DynamicProxy;

    public class TransactionInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            using (var scope = new TransactionScope())
            {
                invocation.Proceed();

                scope.Complete();
            }
        }
    }
}
