using DynamicDecoratorsDemo.Models.Superheros;
using System.Collections.Generic;
using System.Linq;

namespace DynamicDecoratorsDemo.Services.Superheros
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
            => Superheros
                    .FirstOrDefault(x => x.Id == id);

        public IEnumerable<Superhero> GetAll()
            => Superheros
                    .ToList();

        public Superhero Update(Superhero updatedSuperhero)
        {
            var existingSuperhero = Superheros
               .SingleOrDefault(x => x.Id == updatedSuperhero.Id);

            Superheros
                .Remove(existingSuperhero);

            Superheros
                .Add(updatedSuperhero);

            return updatedSuperhero;
        }

        public Superhero Delete(int id)
            => Superheros
                    .SingleOrDefault(x => x.Id == id);
    }
}
