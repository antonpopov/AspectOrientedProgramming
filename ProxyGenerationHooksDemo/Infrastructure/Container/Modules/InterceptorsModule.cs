namespace ProxyGenerationDemo.Infrastructure.Container.Modules
{
    using System.Linq;

    using Autofac;
    using Castle.DynamicProxy;
    using ProxyGenerationDemo.Infrastructure.Container.Interceptors;

    public class InterceptorsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ExceptionHandlingInterceptor>();

            builder.RegisterType<LoggingInterceptor>();

            builder.RegisterType<TransactionInterceptor>();

            //builder
            //    .RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
            //    .Where(x
            //        => x.IsClass &&
            //           x.GetInterfaces()
            //                .Any(y => y == typeof(IInterceptor)))
            //    .AsSelf()
            //    .InstancePerLifetimeScope();
        }
    }
}
