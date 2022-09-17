using BlogAPI.Models;
using Dapper;

namespace BlogAPI.Data
{
    public class NomenclatureTypeRepository : Repository, INomenclatureTypeRepository
    {
        public NomenclatureTypeRepository(IConfiguration configuretion) : base(configuretion, "nomenclaturetypes") { }

        public async Task<NomenclatureType> CreateAsync(NomenclatureType model)
        {
            string query = $"INSERT INTO {table}(title) VALUES(@Title) RETURNING *";
            object param = new 
            {
                Title = model.Title
            };
            var type = await connection.QueryFirstOrDefaultAsync<NomenclatureType>(query, param);
            return type;
        }

        public async Task DeleteAsync(int id)
        {
            string query = $"DELETE FROM {table} WHERE id = @Id";
            object param = new 
            {
                Id = id
            };
            await connection.QueryAsync(query, param);
        }

        public async Task<IEnumerable<NomenclatureType>> GetAllAsync()
        {
            string query = $"SELECT * FROM {table}";
            var list = await connection.QueryAsync<NomenclatureType>(query); 
            return list;
        }

        public async Task<NomenclatureType> GetByIDAsync(int id)
        {
            string query = $"SELECT * FROM {table} WHERE id = @Id";
            object param = new 
            {
                Id = id
            };
            var type = await connection.QueryFirstOrDefaultAsync<NomenclatureType>(query, param);
            return type;
        }

        public async Task UpdateAsync(int id, NomenclatureType model)
        {
            string query = $"UPDATE {table} SET title = @Title WHERE id = @Id";
            object param = new
            {
                Id = id,
                Title = model.Title
            };
            await connection.QueryAsync(query, param);
        }
    }
}
