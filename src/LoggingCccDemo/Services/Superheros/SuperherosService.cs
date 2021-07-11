using LoggingCccDemo.Models.Superheros;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoggingCccDemo.Services.Superheros
{
    public class SuperherosService : ISuperherosService
    {
        private static readonly IList<Superhero> Superheros = new List<Superhero>
        {
            new Superhero
            {
                Id = IdProvider.GenerateId(),
                Name = "Batman",
                RealName = "Bruce Wayne",
                Universe = Universe.Dc
            },
            new Superhero
            {
                Id = IdProvider.GenerateId(),
                Name = "Wolverine",
                RealName = "Logan",
                Universe = Universe.Marvel
            }
        };

        public Superhero Get(int id)
        {
            // Logging
            Console.WriteLine($"Stepped in {nameof(this.Get)} at {DateTime.Now}");

            var superhero = Superheros
                .FirstOrDefault(x => x.Id == id);

            // Logging
            Console.WriteLine($"Stepped out of {nameof(this.Get)} at {DateTime.Now}");

            return superhero;


        }

        public IEnumerable<Superhero> GetAll()
        {
            // Logging
            Console.WriteLine($"Stepped in {nameof(this.GetAll)} at {DateTime.Now}");

            var superheros = Superheros
                .ToList();

            // Logging
            Console.WriteLine($"Stepped out of {nameof(this.GetAll)} at {DateTime.Now}");

            return superheros;
        }

        public Superhero Update(Superhero updatedSuperhero)
        {
            // Logging
            Console.WriteLine($"Stepped in {nameof(this.Update)} at {DateTime.Now}");

            var existingSuperhero = Superheros
                .SingleOrDefault(x => x.Id == updatedSuperhero.Id);

            Superheros.Remove(existingSuperhero);
            Superheros.Add(updatedSuperhero);

            // Logging
            Console.WriteLine($"Stepped out of {nameof(this.Update)} at {DateTime.Now}");

            return updatedSuperhero;
        }

        public Superhero Delete(int id)
        {
            // Logging
            Console.WriteLine($"Stepped in {nameof(this.Delete)} at {DateTime.Now}");

            var existingSuperhero = Superheros.SingleOrDefault(x => x.Id == id);

            // Logging
            Console.WriteLine($"Stepped out of {nameof(this.Delete)} at {DateTime.Now}");

            return existingSuperhero;
        }
    }
}
