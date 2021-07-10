namespace DecoratorPatternDemo.Services.SuperHeros
{
    using DecoratorPatternDemo.Models;
    using System.Collections.Generic;

    public interface ISuperherosService
    {
        Superhero Get(int id);

        IEnumerable<Superhero> GetAll();

        Superhero Update(Superhero updatedSuperhero);

        Superhero Delete(int id);
    }
}
