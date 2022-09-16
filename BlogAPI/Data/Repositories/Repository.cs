using Npgsql;

namespace BlogAPI.Data
{
    public class Repository
    {
        //Connection to PGSQL DB
        protected readonly NpgsqlConnection connection;

        //Table
        protected readonly string table;

        //Constructor with set up
        public Repository(IConfiguration configuration, string tableName)
        {
            table = tableName;
            string connectionString = configuration.GetConnectionString("default");
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }

        //Finalizer to close connection
        ~Repository()
        {
            if (connection != null)
                connection.Close();
        }
    }
}
