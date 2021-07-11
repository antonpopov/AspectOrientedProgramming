namespace ProxyGenerationDemo.Infrastructure.Container.ProxyGeneration.Hooks
{
    using System;
    using System.Reflection;

    using Castle.DynamicProxy;
    using ProxyGenerationDemo.Services.Superheros;

    public class SkipGetAllProxyGenerationHook : IProxyGenerationHook
    {
        public void MethodsInspected()
        {
        }

        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        {
        }

        public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
            => methodInfo.Name
                .Equals(nameof(ISuperherosService.GetAll)) ? false : true;
    }
}
