namespace DecoratorPatternDemo.Services.SuperHeros.Decorators
{
    using DecoratorPatternDemo.Models;
    using System;
    using System.Collections.Generic;

    public class ExceptionHandlingDecorator : ISuperherosService
    {
        private readonly ISuperherosService superherosService;

        public ExceptionHandlingDecorator(ISuperherosService superherosService)
            => this.superherosService = superherosService;

        public Superhero Delete(int id)
        {
            Superhero result = null;
            try
            {
                result = this.superherosService.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}{Environment.NewLine}{ex.Message}{Environment.NewLine}");

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
                Console.WriteLine($"{ex.Message}{Environment.NewLine}{ex.Message}{Environment.NewLine}");

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
                Console.WriteLine($"{ex.Message}{Environment.NewLine}{ex.Message}{Environment.NewLine}");

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
                Console.WriteLine($"{ex.Message}{Environment.NewLine}{ex.Message}{Environment.NewLine}");

                throw;
            }

            return result;
        }
    }
}
