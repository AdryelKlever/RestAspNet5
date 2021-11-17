using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestAspNet5.Models;
using RestAspNet5.Services;

namespace RestAspNet5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonService _personSerive;

        public PersonController(ILogger<PersonController> logger, IPersonService personService) 
        {
            _logger = logger;
            _personSerive = personService;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            return Ok(_personSerive.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personSerive.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonModel person) 
        {
            if (person == null) return BadRequest();
            return Ok(_personSerive.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] PersonModel person)
        {
            if (person == null) return BadRequest();
            return Ok(_personSerive.Update(person));
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            _personSerive.Delete(id);
            return NoContent();
        }

    }
}
