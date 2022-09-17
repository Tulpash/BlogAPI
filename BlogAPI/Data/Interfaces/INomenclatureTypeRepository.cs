using BlogAPI.Models;

namespace BlogAPI.Data
{
    public interface INomenclatureTypeRepository
    {
        Task<IEnumerable<NomenclatureType>> GetAllAsync();
        Task<NomenclatureType> GetByIDAsync(int id);
        Task<NomenclatureType> CreateAsync(NomenclatureType model);
        Task UpdateAsync(int id, NomenclatureType model);
        Task DeleteAsync(int id);
    }
}
