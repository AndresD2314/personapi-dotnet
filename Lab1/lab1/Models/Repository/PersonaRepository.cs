namespace Models.Repositorydotnet.Models.Repository
{
using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Models.Entities;
using Microsoft.EntityFrameworkCore;
    using personapidotnet.Controllers;

    public class PersonaRepository : IPersonaRepository
{
    private readonly PersonaDbContext _context;

    public PersonaRepository(PersonaDbContext context)
    {
        _context = context;
    }


        public async Task<IEnumerable<Persona>> GetAllPersonasAsync()
        {
            return await _context.Personas
                                 .Include(p => p.Estudios)
                                 .Include(p => p.Telefonos)
                                 .ToListAsync();
        }


        public async Task<Persona> GetPersonaByIdAsync(int Cc)
    {
            return await _context.Personas
                              .Include(p => p.Estudios)
                              .Include(p => p.Telefonos)
                              .FirstOrDefaultAsync(p => p.Cc == Cc);
        }

    public async Task AddPersonaAsync(Persona persona)
    {
        _context.Personas.Add(persona);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePersonaAsync(Persona persona)
    {
        _context.Entry(persona).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeletePersonaAsync(int id)
    {
        var persona = await _context.Personas.FindAsync(id);
        if (persona != null)
        {
            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
        }
    }
}
}
