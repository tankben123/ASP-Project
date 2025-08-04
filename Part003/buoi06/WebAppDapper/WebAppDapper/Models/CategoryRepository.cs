using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace WebAppDapper.Models
{
    public class CategoryRepository: BaseRepository
    {
        public CategoryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                if (connection.State != ConnectionState.Open)
                {
                    throw new InvalidOperationException("Failed to open database connection.");
                }
                //returnawait connection.QueryAsync<Category>("select * from category");
                return await connection.QueryAsync<Category>("GetCategories", commandType: CommandType.StoredProcedure);
            }

        }

        public int Add(Category category)
        {
            string sql = "INSERT INTO Category (CategoryCode, CategoryName) VALUES (@CategoryCode, @CategoryName);";
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                if (connection.State != ConnectionState.Open)
                {
                    throw new InvalidOperationException("Failed to open database connection.");
                }
                //return connection.Execute(sql, new { CategoryCode = category.CategoryCode, CategoryName = category.CategoryName});
                return connection.Execute("AddCategory", new { CategoryCode = category.CategoryCode, CategoryName = category.CategoryName }, commandType: CommandType.StoredProcedure);
            }
        }


        public int Delete(short categoryId)
        {
            string sql = "DELETE FROM Category WHERE CategoryId = @CategoryId";
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                if (connection.State != ConnectionState.Open)
                {
                    throw new InvalidOperationException("Failed to open database connection.");
                }
                //return connection.Execute(sql, new { CategoryId = categoryId });
                return connection.Execute("DeleteCategory", new { id = categoryId }, commandType: CommandType.StoredProcedure);
            }
        }

        public Category? GetCategory(short id)
        {
            string sql = "SELECT * FROM Category WHERE CategoryId = @CategoryId";
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.OpenAsync();
                if (connection.State != ConnectionState.Open)
                {
                    throw new InvalidOperationException("Failed to open database connection.");
                }
                return  connection.QueryFirstOrDefault<Category>(sql, new { CategoryId = id });
            }
        }

        public int Edit(Category category)
        {
            string sql = "UPDATE Category SET CategoryCode = @CategoryCode, CategoryName = @CategoryName WHERE CategoryId = @CategoryId";
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                if (connection.State != ConnectionState.Open)
                {
                    throw new InvalidOperationException("Failed to open database connection.");
                }
                //return connection.Execute(sql, new { CategoryCode = category.CategoryCode, CategoryName = category.CategoryName, CategoryId = category.CategoryId });
                return connection.Execute("EditCategory", new { code = category.CategoryCode, name = category.CategoryName, id = category.CategoryId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
