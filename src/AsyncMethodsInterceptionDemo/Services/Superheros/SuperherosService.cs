namespace AsyncMethodsInterceptionDemo.Services.Superheros
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AsyncMethodsInterceptionDemo.Models.Superheros;

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

        public async Task<Superhero> GetAsync(int id)
            => await Task
                .FromResult(
                    Superheros
                        .FirstOrDefault(x => x.Id == id));

        public async Task<IEnumerable<Superhero>> GetAllAsync()
            => await Task
                .FromResult(Superheros.ToList());

        public async Task<Superhero> UpdateAsync(Superhero updatedSuperhero)
        {
            var existingSuperhero = Superheros
               .SingleOrDefault(x => x.Id == updatedSuperhero.Id);

            Superheros
                .Remove(existingSuperhero);

            Superheros
                .Add(updatedSuperhero);

            return await Task.FromResult(updatedSuperhero);
        }

        public async Task<Superhero> DeleteAsync(int id)
            => await Task
                .FromResult(
                    Superheros
                        .SingleOrDefault(x => x.Id == id));
    }
}
