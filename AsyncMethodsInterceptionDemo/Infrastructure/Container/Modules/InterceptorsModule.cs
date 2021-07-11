namespace AsyncMethodsInterceptionDemo.Infrastructure.Container.Modules
{
    using System.Linq;

    using AsyncMethodsInterceptionDemo.Infrastructure.Container.Interceptors;
    using Autofac;
    using Castle.DynamicProxy;

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
            //                .Any(y => y == typeof(IAsyncInterceptor)))
            //    .AsSelf()
            //    .InstancePerLifetimeScope();
        }
    }
}
