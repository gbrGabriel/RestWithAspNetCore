using Microsoft.AspNetCore.Mvc;
using RestWithAspNetCore.Api.Interfaces;
using RestWithAspNetCore.Api.Model;

namespace RestWithAspNetCore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _personService.FindAll());
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await _personService.FindById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Person person)
        {
            if (person == null) return BadRequest("Invalid Model");

            return Ok(await _personService.Create(person));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Person person)
        {
            if (person == null) return BadRequest("Invalid Model");

            return Ok(await _personService.Update(person));
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _personService.Delete(id);

            return NoContent();
        }

    }
}
