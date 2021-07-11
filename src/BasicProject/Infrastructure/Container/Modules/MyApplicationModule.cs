namespace BasicProject.Infrastructure.Container.Modules
{
    using Autofac;
    using BasicProject.Services;

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
