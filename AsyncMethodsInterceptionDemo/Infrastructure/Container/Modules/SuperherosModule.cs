namespace AsyncMethodsInterceptionDemo.Infrastructure.Container.Modules
{
    using AsyncMethodsInterceptionDemo.Infrastructure.Container.Interceptors;
    using AsyncMethodsInterceptionDemo.Services.Superheros;
    using Autofac;
    using Autofac.AsyncExtras.DynamicProxy;
    using Castle.DynamicProxy;

    public class SuperHerosModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Registering Interceptors with Castle.Core.AsyncInterceptor in Autofac
            builder
                .Register(ctx =>
                {
                    var superherosService = new SuperherosService();

                    var proxyGenerator = new ProxyGenerator();

                    var transactionHandlingInterceptor =
                        ctx.Resolve<TransactionInterceptor>();

                    var transactionProxy = proxyGenerator
                        .CreateInterfaceProxyWithTargetInterface<ISuperherosService>(superherosService, transactionHandlingInterceptor);

                    var exceptionHandlingInterceptor =
                        ctx.Resolve<ExceptionHandlingInterceptor>();

                    var exceptionHandlingProxy = proxyGenerator
                        .CreateInterfaceProxyWithTargetInterface(transactionProxy, exceptionHandlingInterceptor);

                    var loggingInterceptor =
                        ctx.Resolve<LoggingInterceptor>();

                    var loggingProxy = proxyGenerator
                        .CreateInterfaceProxyWithTargetInterface(exceptionHandlingProxy, loggingInterceptor);

                    return loggingProxy;
                })
                .As<ISuperherosService>()
                .InstancePerLifetimeScope();


            // Registering interceptors using custom Autofac extension methods
            // NB! Latest version of Autofac has breaking changes and this approach needs adjsutments.
            //builder
            //    .RegisterType<SuperherosService>()
            //    .As<ISuperherosService>()
            //    .EnableAsyncInterfaceInterceptors()
            //    .InterceptedBy(typeof(LoggingInterceptor), typeof(ExceptionHandlingInterceptor), typeof(TransactionInterceptor))
            //    .InstancePerLifetimeScope();
        }
    }
}
