namespace DecoratorPatternDemo.Infrastructure.Container.Modules
{
    using System;

    using Autofac;
    using DecoratorPatternDemo.Controllers;
    using DecoratorPatternDemo.Services.Superheros;
    using DecoratorPatternDemo.Services.Superheros.Decorators;

    public class SuperHerosModule : Module
    {
        private static Type ISuperHeroServiceType = typeof(ISuperherosService);

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<SuperherosService>()
                .As<ISuperherosService>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<TransactionDecorator>()
                .Keyed<ISuperherosService>(nameof(TransactionDecorator))
                .InstancePerLifetimeScope();

            builder
                .RegisterType<ExceptionHandlingDecorator>()
                .WithParameter(
                    (pi, ctx) => pi.ParameterType == ISuperHeroServiceType,
                    (pi, ctx) => ctx.ResolveKeyed<ISuperherosService>(nameof(TransactionDecorator)))
                .Keyed<ISuperherosService>(nameof(ExceptionHandlingDecorator))
                .InstancePerLifetimeScope();

            builder
                .RegisterType<LoggingDecorator>()
                .WithParameter(
                    (pi, ctx) => pi.ParameterType == ISuperHeroServiceType,
                    (pi, ctx) => ctx.ResolveKeyed<ISuperherosService>(nameof(ExceptionHandlingDecorator)))
                .Keyed<ISuperherosService>(nameof(LoggingDecorator))
                .InstancePerLifetimeScope();

            builder
                .RegisterType(typeof(SuperherosController))
                .WithParameter(
                    (pi, ctx) => pi.ParameterType == ISuperHeroServiceType,
                    (pi, ctx) => ctx.ResolveKeyed<ISuperherosService>(nameof(LoggingDecorator)))
                .InstancePerLifetimeScope();
        }
    }
}
