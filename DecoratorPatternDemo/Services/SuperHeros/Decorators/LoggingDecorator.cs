namespace DecoratorPatternDemo.Services.Superheros.Decorators
{
    using DecoratorPatternDemo.Models.Superheros;
    using DecoratorPatternDemo.Services.Logging;
    using System;
    using System.Collections.Generic;

    public class LoggingDecorator : ISuperherosService
    {
        private readonly ISuperherosService superherosService;
        private readonly ILoggerService loggerService;
        private readonly IDateTimeProvider dateTimeProvider;

        public LoggingDecorator(
            ISuperherosService superherosService,
            ILoggerService loggerService,
            IDateTimeProvider dateTimeProvider)
        {
            this.superherosService = superherosService;
            this.loggerService = loggerService;
            this.dateTimeProvider = dateTimeProvider;
        }

        public Superhero Get(int id)
        {
            this.loggerService
                    .Log($"Stepped in {nameof(this.Get)} at {this.dateTimeProvider.GetDateTimeNow()}");

            var result = this.superherosService.Get(id);

            this.loggerService
                    .Log($"Stepped out of {nameof(this.Get)} at {this.dateTimeProvider.GetDateTimeNow()}");

            return result;
        }

        public IEnumerable<Superhero> GetAll()
        {
            this.loggerService
                    .Log($"Stepped in {nameof(this.GetAll)} at {this.dateTimeProvider.GetDateTimeNow()}");

            var result = this.superherosService.GetAll();

            this.loggerService
                    .Log($"Stepped out of {nameof(this.GetAll)} at {this.dateTimeProvider.GetDateTimeNow()}");

            return result;
        }

        public Superhero Update(Superhero updatedSuperhero)
        {
            this.loggerService
                    .Log($"Stepped in {nameof(this.Update)} at {this.dateTimeProvider.GetDateTimeNow()}");

            var result = this.superherosService.Update(updatedSuperhero);

            this.loggerService
                    .Log($"Stepped out of {nameof(this.Update)} at {this.dateTimeProvider.GetDateTimeNow()}");

            return result;
        }

        public Superhero Delete(int id)
        {
            this.loggerService
                    .Log($"Stepped in {nameof(this.Delete)} at {this.dateTimeProvider.GetDateTimeNow()}");

            var result = this.superherosService.Delete(id);

            this.loggerService
                    .Log($"Stepped out of {nameof(this.Delete)} at {this.dateTimeProvider.GetDateTimeNow()}");

            return result;
        }
    }
}
