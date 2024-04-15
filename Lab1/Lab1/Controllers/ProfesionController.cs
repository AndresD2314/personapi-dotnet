using Lab1.Models.Entities; // Ajusta a tu namespace correspondiente
using Microsoft.AspNetCore.Mvc;
using Models.Repositorydotnet.Models.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapidotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesionController : ControllerBase
    {
        private readonly IProfesionRepository _profesionRepository;

        public ProfesionController(IProfesionRepository profesionRepository)
        {
            _profesionRepository = profesionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profesion>>> GetProfesionesAsync()
        {
            var profesiones = await _profesionRepository.GetAllProfesionesAsync();
            return Ok(profesiones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Profesion>> GetProfesionById(int id)
        {
            var profesion = await _profesionRepository.GetProfesionByIdAsync(id);
            if (profesion == null)
            {
                return NotFound();
            }
            return profesion;
        }

        [HttpPost]
        public async Task<ActionResult<Profesion>> CreateProfesionAsync(Profesion profesion)
        {
            await _profesionRepository.AddProfesionAsync(profesion);
            return CreatedAtAction(nameof(GetProfesionById), new { id = profesion.Id }, profesion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfesion(int id, Profesion profesion)
        {
            if (id != profesion.Id)
            {
                return BadRequest();
            }

            await _profesionRepository.UpdateProfesionAsync(profesion);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesion(int id)
        {
            var profesionToDelete = await _profesionRepository.GetProfesionByIdAsync(id);
            if (profesionToDelete == null)
            {
                return NotFound();
            }

            await _profesionRepository.DeleteProfesionAsync(id);

            return NoContent();
        }
    }
}
