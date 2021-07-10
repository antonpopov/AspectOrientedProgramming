namespace DecoratorPatternDemo.Services.Superheros.Decorators
{
    using DecoratorPatternDemo.Models.Superheros;
    using DecoratorPatternDemo.Services.Logging;
    using System;
    using System.Collections.Generic;

    public class ExceptionHandlingDecorator : ISuperherosService
    {
        private readonly ISuperherosService superherosService;
        private readonly ILoggerService loggerService;

        public ExceptionHandlingDecorator(ISuperherosService superherosService, ILoggerService loggerService)
        {
            this.superherosService = superherosService;
            this.loggerService = loggerService;
        }

        public Superhero Delete(int id)
        {
            Superhero result = null;
            try
            {
                result = this.superherosService.Delete(id);
            }
            catch (Exception ex)
            {
                this.loggerService
                        .Log($"{ex.Message}{Environment.NewLine}{ex.Message}{Environment.NewLine}");

                throw;
            }

            return result;
        }

        public Superhero Get(int id)
        {
            Superhero result = null;

            try
            {
                result = this.superherosService.Get(id);
            }
            catch (Exception ex)
            {
                this.loggerService
                        .Log($"{ex.Message}{Environment.NewLine}{ex.Message}{Environment.NewLine}");

                throw;
            }

            return result;
        }

        public IEnumerable<Superhero> GetAll()
        {
            IEnumerable<Superhero> result = null;

            try
            {
                result = this.superherosService.GetAll();
            }
            catch (Exception ex)
            {
                this.loggerService
                        .Log($"{ex.Message}{Environment.NewLine}{ex.Message}{Environment.NewLine}");

                throw;
            }

            return result;
        }

        public Superhero Update(Superhero updatedSuperhero)
        {
            Superhero result = null;

            try
            {
                result = this.superherosService.Update(updatedSuperhero);
            }
            catch (Exception ex)
            {
                this.loggerService
                        .Log($"{ex.Message}{Environment.NewLine}{ex.Message}{Environment.NewLine}");

                throw;
            }

            return result;
        }
    }
}
