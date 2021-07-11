namespace ProxyGenerationDemo.Infrastructure.Container.ProxyGeneration.Options
{
    using Castle.DynamicProxy;
    using ProxyGenerationDemo.Infrastructure.Container.ProxyGeneration.Hooks;
    using ProxyGenerationDemo.Infrastructure.Container.ProxyGeneration.Selectors;

    public class SuperherosServiceProxyGenerationOptions : ProxyGenerationOptions
    {
        public SuperherosServiceProxyGenerationOptions()
            : base(new SkipGetAllProxyGenerationHook())
        {
            //this.Selector = new SuperherosServiceInterceptorSelector();
        }
    }
}
