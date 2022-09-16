using BlogAPI.Models;
using Dapper;

namespace BlogAPI.Data
{
    public class NomenclatureRepository : Repository, INomeclatureRepository
    {
        public NomenclatureRepository(IConfiguration configuration) : base(configuration, "nomenclature") { }

        public async Task<Nomenclature> CreateAsync(Nomenclature model)
        {
            string query = $"INSERT INTO {table}(title, pages, authorid, typeid) VALUES (@Title, @Pages, @AuthorId, @TypeId) RETURNING *";
            object param = new
            {
                Title = model.Title,
                Pages = model.Pages,
                TypeId = model.TypeId,
                AuthorId = model.AuthorId
            };
            Nomenclature nomenclature = await connection.QueryFirstOrDefaultAsync<Nomenclature>(query, param);
            return nomenclature;
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

        public async Task<IEnumerable<Nomenclature>> GetAllAsync()
        {
            string query = $"SELECT * FROM {table}";
            var list = await connection.QueryAsync<Nomenclature>(query);
            return list;
        }

        public async Task<Nomenclature> GetByIDAsync(int id)
        {
            string query = $"SELECT * FROM {table} WHERE id = @Id";
            object param = new
            {
                Id = id
            };
            var nomenclature = await connection.QueryFirstOrDefaultAsync<Nomenclature>(query, param);
            return nomenclature;
        }

        public async Task UpdateAsync(int id, Nomenclature model)
        {
            string query = $"UPDATE {table} SET (title, pages, authorid, typeid) = (@Title, @Pages, @AuthorId, @TypeId) WHERE id = @Id";
            object param = new
            {
                Id = id,
                Title = model.Title,
                Pages = model.Pages,
                TypeId = model.TypeId,
                AuthorId = model.AuthorId
            };
            await connection.QueryAsync(query, param);
        }

        public async Task<Author> GetAuthorAsync(int nomenclatureId)
        {
            string query = $"SELECT * FROM authors WHERE id = (SELECT authorid FROM {table} WHERE id = @NomenclatureId)";
            object param = new
            {
                NomenclatureId = nomenclatureId
            };
            var author = await connection.QueryFirstOrDefaultAsync<Author>(query, param);
            return author;
        }
    }
}
