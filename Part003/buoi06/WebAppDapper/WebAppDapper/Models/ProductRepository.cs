using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace WebAppDapper.Models
{
    public class ProductRepository : BaseRepository
    {
        public ProductRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public IEnumerable<Product> GetProducts()
        {
            string sql = "select Product.*, CategoryName from Product left join Category on Product.categoryid = Category.categoryid";
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                if (connection.State != ConnectionState.Open)
                {
                    throw new InvalidOperationException("Failed to open database connection.");
                }
                //return connection.Query<Product>("GetProducts", commandType: CommandType.StoredProcedure);
                return connection.Query<Product>("GetProducts", commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Product> SearchProducts(string searchTerm)
        {
            string sql = "select Product.*, CategoryName from Product left join Category on Product.categoryid = Category.categoryid where ProductName like @SearchTerm or ProductCode like @SearchTerm";
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                if (connection.State != ConnectionState.Open)
                {
                    throw new InvalidOperationException("Failed to open database connection.");
                }
                return connection.Query<Product>(sql, new { SearchTerm = "%" + searchTerm + "%" });
            }
        }
    }
}
