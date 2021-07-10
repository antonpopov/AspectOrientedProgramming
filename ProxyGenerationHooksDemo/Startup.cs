using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProxyGenerationDemo.Services;
using ProxyGenerationDemo.Services.Logging;
using System.Reflection;

namespace ProxyGenerationDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public ILifetimeScope AutofacContainer { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddControllersAsServices();

            services
                .AddSwaggerGen(c
                    => c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProxyGenerationHooksDemo", Version = "v1" }));

            services
                .AddScoped<ILoggerService, LoggerService>()
                .AddScoped<IDateTimeProvider, DateTimeProvider>();
        }

        public void ConfigureContainer(ContainerBuilder builder)
            => builder
                .RegisterAssemblyModules(Assembly.GetExecutingAssembly());

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.AutofacContainer =
                app.ApplicationServices.GetAutofacRoot();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProxyGenerationHooksDemo v1"));
            }

            app
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints
                    => endpoints
                        .MapControllers());
        }
    }
}