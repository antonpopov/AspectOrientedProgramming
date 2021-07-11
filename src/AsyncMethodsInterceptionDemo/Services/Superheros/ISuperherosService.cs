namespace AsyncMethodsInterceptionDemo.Services.Superheros
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AsyncMethodsInterceptionDemo.Models.Superheros;

    public interface ISuperherosService
    {
        Superhero Get(int id);

        Task<IEnumerable<Superhero>> GetAllAsync();

        Task<Superhero> UpdateAsync(Superhero updatedSuperhero);

        Task<Superhero> DeleteAsync(int id);
    }
}
