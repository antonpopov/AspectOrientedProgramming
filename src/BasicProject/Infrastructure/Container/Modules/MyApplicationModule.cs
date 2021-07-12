namespace AutofacConfiguration.Infrastructure.Container.Modules
{
    using Autofac;
    using AutofacConfiguration.Services;

    public class MyApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<ConsoleLoggerService>()
                .As<ILoggerService>();
        }
    }
}
