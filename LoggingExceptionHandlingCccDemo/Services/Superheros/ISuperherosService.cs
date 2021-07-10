using LoggingExceptionHandlingCccDemo.Models.Superheros;
using System.Collections.Generic;

namespace LoggingExceptionHandlingCccDemo.Services.Superheros
{
    public interface ISuperherosService
    {
        Superhero Get(int id);

        IEnumerable<Superhero> GetAll();

        Superhero Update(Superhero updatedSuperhero);

        Superhero Delete(int id);
    }
}
