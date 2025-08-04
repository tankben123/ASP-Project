using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace WebAppDapper.Models
{
    public class ProductRepository:BaseRepository
    {
        public ProductRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public IEnumerable<Product> GetProducts()
        {
            string sql = "SELECT product.* FROM Product";
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                if (connection.State != ConnectionState.Open)
                {
                    throw new InvalidOperationException("Failed to open database connection.");
                }
                //return connection.Query<Product>("GetProducts", commandType: CommandType.StoredProcedure);
                return connection.Query<Product>("SELECT * FROM Product", commandType: CommandType.Text);
            }
        }
    }
}
