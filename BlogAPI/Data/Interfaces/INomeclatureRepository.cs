using BlogAPI.Models;

namespace BlogAPI.Data
{
    public interface INomeclatureRepository
    {
        Task<IEnumerable<Nomenclature>> GetAllAsync();
        Task<Nomenclature> GetByIDAsync(int id);
        Task<Nomenclature> CreateAsync(Nomenclature model);
        Task UpdateAsync(int id, Nomenclature model);
        Task DeleteAsync(int id);
        Task<Author> GetAuthorAsync(int id);
    }
}
