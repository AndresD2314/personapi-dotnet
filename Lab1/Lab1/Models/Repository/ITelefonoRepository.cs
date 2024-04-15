using Lab1.Models.Entities;

namespace Models.Repositorydotnet.Models.Repository
{
    public interface ITelefonoRepository
    {
        Task<Telefono> GetTelefonoByIdAsync(int id);
        Task<IEnumerable<Telefono>> GetAllTelefonosAsync();
        Task AddTelefonoAsync(Telefono telefono);
        Task UpdateTelefonoAsync(Telefono telefono);
        Task DeleteTelefonoAsync(int id);
    }
}
