using Lab1.Models.Entities; // Ajusta a tu namespace correspondiente
using Microsoft.AspNetCore.Mvc;
using Models.Repositorydotnet.Models.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personapidotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefonoController : ControllerBase
    {
        private readonly ITelefonoRepository _telefonoRepository;

        public TelefonoController(ITelefonoRepository telefonoRepository)
        {
            _telefonoRepository = telefonoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Telefono>>> GetTelefonosAsync()
        {
            var telefonos = await _telefonoRepository.GetAllTelefonosAsync();
            return Ok(telefonos);
        }

        [HttpGet("{duenio}")]
        public async Task<ActionResult<Telefono>> GetTelefonoByDuenio(int duenio)
        {
            var telefono = await _telefonoRepository.GetTelefonoByIdAsync(duenio);
            if (telefono == null)
            {
                return NotFound();
            }
            return telefono;
        }

        [HttpPost]
        public async Task<ActionResult<Telefono>> CreateTelefonoAsync(Telefono telefono)
        {
            await _telefonoRepository.AddTelefonoAsync(telefono);
            // Asignando la acción a GetTelefonoByDuenio para generar la URL de ubicación
            return CreatedAtAction(nameof(GetTelefonoByDuenio), new { duenio = telefono.Duenio }, telefono);
        }

        [HttpPut("{duenio}")]
        public async Task<IActionResult> UpdateTelefono(int duenio, Telefono telefono)
        {
            if (duenio != telefono.Duenio)
            {
                return BadRequest();
            }

            await _telefonoRepository.UpdateTelefonoAsync(telefono);

            return NoContent();
        }

        [HttpDelete("{duenio}")]
        public async Task<IActionResult> DeleteTelefono(int duenio)
        {
            var telefonoToDelete = await _telefonoRepository.GetTelefonoByIdAsync(duenio);
            if (telefonoToDelete == null)
            {
                return NotFound();
            }

            await _telefonoRepository.DeleteTelefonoAsync(duenio);

            return NoContent();
        }
    }
}
