namespace AutofacConfiguration.Controllers
{
    using AutofacConfiguration.Services;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILoggerService loggerService;

        public TestController(ILoggerService loggerService)
            => this.loggerService = loggerService;

        [HttpGet]
        public ActionResult Test()
        {
            this.loggerService.Log("Some random message.");

            return this.Ok();
        }
    }
}
