using BlogAPI.Models;
using Dapper;

namespace BlogAPI.Data
{
    public class AuthorRepository : Repository, IAuthorRepository
    {
        public AuthorRepository(IConfiguration configuration) : base(configuration, "authors") { }

        public async Task<Author> CreateAsync(Author model)
        {
            string query = $"INSERT INTO {table}(firstname, lastname, age) VALUES (@First, @Last, @Age) RETURNING *";
            object param = new
            {
                First = model.FirstName,
                Last = model.LastName,
                Age = model.Age
            };
            Author author = await connection.QueryFirstOrDefaultAsync<Author>(query, param);
            return author;
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

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            string query = $"SELECT * FROM {table}";
            var list = await connection.QueryAsync<Author>(query);
            return list;
        }

        public async Task<Author> GetByIDAsync(int id)
        {
            string query = $"SELECT * FROM {table} WHERE id = @Id";
            object param = new
            {
                Id = id
            };
            Author author = await connection.QueryFirstOrDefaultAsync<Author>(query, param);
            return author;
        }

        public async Task UpdateAsync(int id, Author model)
        {
            string query = $"UPDATE {table} SET (firstname, lastname, age) = (@First, @Last, @Age) WHERE id = @Id";
            object param = new
            {
                Id = id,
                First = model.FirstName,
                Last = model.LastName,
                Age = model.Age
            };
            await connection.QueryAsync(query, param);
        }

        public async Task<IEnumerable<Nomenclature>> GetNomenclatureAsync(int authorId)
        {
            string query = "SELECT * FROM nomenclature WHERE authorid = @AuthorId";
            object param = new 
            {
                AuthorId = authorId
            };
            var list = await connection.QueryAsync<Nomenclature>(query, param);
            return list;
        }
    }
}
