using LoggingExceptionHandlingTransactioningCccDemo.Models.Superheros;
using System.Collections.Generic;

namespace LoggingExceptionHandlingTransactioningCccDemo.Services.Superheros
{
    public interface ISuperherosService
    {
        Superhero Get(int id);

        IEnumerable<Superhero> GetAll();

        Superhero Update(Superhero updatedSuperhero);

        Superhero Delete(int id);
    }
}
