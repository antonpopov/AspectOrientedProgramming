﻿namespace FunctionalRequirementsDemo.Services.Superheros
{
    using System.Collections.Generic;

    using FunctionalRequirementsDemo.Models;

    public interface ISuperherosService
    {
        Superhero Get(int id);

        IEnumerable<Superhero> GetAll();

        Superhero Update(Superhero updatedSuperhero);

        Superhero Delete(int id);
    }
}
