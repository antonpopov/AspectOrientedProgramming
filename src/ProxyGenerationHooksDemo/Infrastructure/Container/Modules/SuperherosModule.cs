namespace ProxyGenerationDemo.Infrastructure.Container.Modules
{
    using Autofac;
    using Autofac.Extras.DynamicProxy;
    using ProxyGenerationDemo.Infrastructure.Container.Interceptors;
    using ProxyGenerationDemo.Infrastructure.Container.ProxyGeneration.Options;
    using ProxyGenerationDemo.Services.Superheros;

    public class SuperHerosModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<SuperherosService>()
                .As<ISuperherosService>()
                .EnableInterfaceInterceptors(new SuperherosServiceProxyGenerationOptions())
                .InterceptedBy(typeof(LoggingInterceptor), typeof(ExceptionHandlingInterceptor), typeof(TransactionInterceptor))
                .InstancePerLifetimeScope();
        }
    }
}
