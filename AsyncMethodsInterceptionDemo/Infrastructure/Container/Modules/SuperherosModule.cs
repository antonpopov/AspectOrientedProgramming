namespace AsyncMethodsInterceptionDemo.Infrastructure.Container.Modules
{
    using AsyncMethodsInterceptionDemo.Infrastructure.Container.Interceptors;
    using AsyncMethodsInterceptionDemo.Services.Superheros;
    using Autofac;
    using Autofac.AsyncExtras.DynamicProxy;

    public class SuperHerosModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<SuperherosService>()
                .As<ISuperherosService>()
                .EnableAsyncInterfaceInterceptors()
                .InterceptedBy(typeof(LoggingInterceptor), typeof(ExceptionHandlingInterceptor), typeof(TransactionInterceptor))
                .InstancePerLifetimeScope();
        }
    }
}
