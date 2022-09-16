using BlogAPI.Models;

namespace BlogAPI.Data
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author> GetByIDAsync(int id);
        Task<Author> CreateAsync(Author model);
        Task UpdateAsync(int id, Author model);
        Task DeleteAsync(int id);
        Task<IEnumerable<Nomenclature>> GetNomenclatureAsync(int id);
    }
}
