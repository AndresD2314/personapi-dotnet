using Lab1.Models.Entities;

namespace Models.Repositorydotnet.Models.Repository
{
    public interface IEstudioRepository
    {
        Task<Estudio> GetEstudioByIdAsync(int idProf);
        Task<IEnumerable<Estudio>> GetAllEstudiosAsync();
        Task AddEstudioAsync(Estudio estudio);
        Task UpdateEstudioAsync(Estudio estudio);
        Task DeleteEstudioAsync(int idProf);
    }
}