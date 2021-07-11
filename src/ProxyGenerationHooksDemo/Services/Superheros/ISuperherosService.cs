namespace ProxyGenerationDemo.Services.Superheros
{
    using System.Collections.Generic;

    using ProxyGenerationDemo.Models.Superheros;

    public interface ISuperherosService
    {
        Superhero Get(int id);

        IEnumerable<Superhero> GetAll();

        Superhero Update(Superhero updatedSuperhero);

        Superhero Delete(int id);
    }
}
