using Lab1.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Models.Repositorydotnet.Models.Repository;

namespace personapidotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonaController(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonasAsync()
        {
            var personas = await _personaRepository.GetAllPersonasAsync();
            return Ok(personas);
        }

        [HttpGet("{cc}")]
        public async Task<ActionResult<Persona>> GetPersonaByCc(int cc)
        {
            var persona = await _personaRepository.GetPersonaByIdAsync(cc);
            if (persona == null)
            {
                return NotFound();
            }
            return persona;
        }

        [HttpPost]
        public async Task<ActionResult<Persona>> CreatePersonaAsync(Persona persona)
        {
            await _personaRepository.AddPersonaAsync(persona);
            // Asume que la propiedad que identifica a la persona es 'cc'
            return CreatedAtAction(nameof(GetPersonaByCc), new { cc = persona.Cc }, persona);
        }

        [HttpPut("{cc}")]
        public async Task<IActionResult> UpdatePersona(int cc, Persona persona)
        {
            if (cc != persona.Cc)
            {
                return BadRequest();
            }

            await _personaRepository.UpdatePersonaAsync(persona);

            return NoContent();
        }

        [HttpDelete("{cc}")]
        public async Task<IActionResult> DeletePersona(int cc)
        {
            var personaToDelete = await _personaRepository.GetPersonaByIdAsync(cc);
            if (personaToDelete == null)
            {
                return NotFound();
            }

            await _personaRepository.DeletePersonaAsync(cc);

            return NoContent();
        }
    }
}