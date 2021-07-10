using Castle.DynamicProxy;
using System.Transactions;

namespace ProxyGenerationDemo.Infrastructure.Container.Interceptors
{
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
