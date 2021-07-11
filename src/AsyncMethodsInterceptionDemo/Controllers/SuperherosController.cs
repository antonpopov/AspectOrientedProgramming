namespace AsyncMethodsInterceptionDemo.Controllers
{
    using AsyncMethodsInterceptionDemo.Models.Superheros;
    using AsyncMethodsInterceptionDemo.Services.Superheros;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class SuperherosController : ControllerBase
    {
        private readonly ISuperherosService superHerosService;

        public SuperherosController(ISuperherosService superHerosService)
            => this.superHerosService = superHerosService;

        [HttpGet]
        public async Task<ActionResult<Superhero>> GetAll()
        {
            var superHeros = await this.superHerosService.GetAllAsync();

            return this.Ok(superHeros);
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<ActionResult<Superhero>> Get(int id)
        {
            var superHero = await this.superHerosService.GetAsync(id);

            return this.Ok(superHero);
        }

        [HttpPut]
        public async Task<ActionResult<Superhero>> Update(Superhero superHero)
        {
            var updatedSuperHero = await this.superHerosService.UpdateAsync(superHero);
            if (updatedSuperHero == null)
            {
                return this.NotFound();
            }

            return this.Ok(updatedSuperHero);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var existingSuperhero = await this.superHerosService.DeleteAsync(id);

            if (existingSuperhero == null)
            {
                return this.NotFound();
            }

            return this.Ok();
        }
    }
}
