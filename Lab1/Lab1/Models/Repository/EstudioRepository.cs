using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Models.Entities; // Ajusta a tu namespace correspondiente
using Microsoft.EntityFrameworkCore;

namespace Models.Repositorydotnet.Models.Repository
{
    public class EstudioRepository : IEstudioRepository
    {
        private readonly PersonaDbContext _context; // Asume que Estudio está en el mismo DbContext

        public EstudioRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estudio>> GetAllEstudiosAsync()
        {
            return await _context.Estudios.ToListAsync();
        }

        public async Task<Estudio> GetEstudioByIdAsync(int idProf)
        {
            return await _context.Estudios.FirstOrDefaultAsync(e => e.IdProf == idProf);
        }

        public async Task AddEstudioAsync(Estudio estudio)
        {
            _context.Estudios.Add(estudio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEstudioAsync(Estudio estudio)
        {
            _context.Entry(estudio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEstudioAsync(int idProf)
        {
            var estudio = await _context.Estudios.FindAsync(idProf);
            if (estudio != null)
            {
                _context.Estudios.Remove(estudio);
                await _context.SaveChangesAsync();
            }
        }
    }
}
