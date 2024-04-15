using Lab1.Models.Entities;

namespace Models.Repositorydotnet.Models.Repository
{
    public interface IPersonaRepository
{
    Task<Persona> GetPersonaByIdAsync(int cc);
    Task<IEnumerable<Persona>> GetAllPersonasAsync();
    Task AddPersonaAsync(Persona persona);
    Task UpdatePersonaAsync(Persona persona);
    Task DeletePersonaAsync(int cc);
}
}
