namespace DecoratorPatternDemo.Services.SuperHeros.Decorators
{
    using DecoratorPatternDemo.Models;
    using System;
    using System.Collections.Generic;

    public class LoggingDecorator : ISuperherosService
    {
        private readonly ISuperherosService superherosService;

        public LoggingDecorator(ISuperherosService superherosService)
            => this.superherosService = superherosService;

        public Superhero Get(int id)
        {
            Console.WriteLine($"Stepped in {nameof(this.Get)} at {DateTime.Now}");

            var result = this.superherosService.Get(id);

            Console.WriteLine($"Stepped out of {nameof(this.Get)} at {DateTime.Now}");

            return result;
        }

        public IEnumerable<Superhero> GetAll()
        {
            Console.WriteLine($"Stepped in {nameof(this.GetAll)} at {DateTime.Now}");

            var result = this.superherosService.GetAll();

            Console.WriteLine($"Stepped out of {nameof(this.GetAll)} at {DateTime.Now}");

            return result;
        }

        public Superhero Update(Superhero updatedSuperhero)
        {
            Console.WriteLine($"Stepped in {nameof(this.Update)} at {DateTime.Now}");

            var result = this.superherosService.Update(updatedSuperhero);

            Console.WriteLine($"Stepped out of {nameof(this.Update)} at {DateTime.Now}");

            return result;
        }

        public Superhero Delete(int id)
        {
            Console.WriteLine($"Stepped in {nameof(this.Delete)} at {DateTime.Now}");

            var result = this.superherosService.Delete(id);

            Console.WriteLine($"Stepped out of {nameof(this.Delete)} at {DateTime.Now}");

            return result;
        }
    }
}
