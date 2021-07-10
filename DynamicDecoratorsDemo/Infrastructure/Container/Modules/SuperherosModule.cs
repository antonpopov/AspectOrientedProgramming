namespace DynamicDecoratorsDemo.Infrastructure.Container.Modules
{
    using Autofac;
    using Autofac.Extras.DynamicProxy;
    using DynamicDecoratorsDemo.Infrastructure.Container.Interceptors;
    using DynamicDecoratorsDemo.Services.Superheros;

    public class SuperHerosModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<SuperherosService>()
                .As<ISuperherosService>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(LoggingInterceptor), typeof(ExceptionHandlingInterceptor), typeof(TransactionInterceptor))
                .InstancePerLifetimeScope();
        }
    }
}
