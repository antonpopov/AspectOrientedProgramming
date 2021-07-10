namespace ProxyGenerationDemo.Infrastructure.Container.ProxyGeneration.Selectors
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Castle.DynamicProxy;
    using ProxyGenerationDemo.Infrastructure.Container.Interceptors;
    using ProxyGenerationDemo.Services.Superheros;

    public class SuperherosServiceInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            if (method.Name.Equals(nameof(ISuperherosService.GetAll)))
            {
                var result = interceptors
                    .Where(x => x.GetType() != typeof(ExceptionHandlingInterceptor))
                    .ToArray();

                return result;
            }

            return interceptors;
        }
    }
}
