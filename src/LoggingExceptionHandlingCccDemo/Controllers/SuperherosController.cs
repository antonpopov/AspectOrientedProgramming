using LoggingExceptionHandlingCccDemo.Models.Superheros;
using LoggingExceptionHandlingCccDemo.Services.Superheros;
using Microsoft.AspNetCore.Mvc;

namespace LoggingExceptionHandlingCccDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperherosController : ControllerBase
    {
        private readonly ISuperherosService superHerosService;

        public SuperherosController(ISuperherosService superHerosService)
            => this.superHerosService = superHerosService;

        [HttpGet]
        public ActionResult<Superhero> GetAll()
        {
            var superHeros = this.superHerosService.GetAll();

            return this.Ok(superHeros);
        }

        [HttpGet]
        [Route("get-by-id")]
        public ActionResult<Superhero> Get(int id)
        {
            var superHero = this.superHerosService.Get(id);

            return this.Ok(superHero);
        }

        [HttpPut]
        public ActionResult<Superhero> Update(Superhero superHero)
        {
            var updatedSuperHero = this.superHerosService.Update(superHero);
            if (updatedSuperHero == null)
            {
                return this.NotFound();
            }

            return this.Ok(updatedSuperHero);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var existingSuperhero = this.superHerosService.Delete(id);

            if (existingSuperhero == null)
            {
                return this.NotFound();
            }

            return this.Ok();
        }
    }
}
