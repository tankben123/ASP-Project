using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Data;

namespace WebApp.Models
{
    public class EmployeeRepository
    {
        string connectionString;

        public EmployeeRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("BookStore") ?? throw new InvalidOperationException("Connection string 'BookStore' not found.");
        }
        public IEnumerable<Employee> GetEmployees()
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                //connection.Open();
                return connection.Query<Employee>("SELECT * FROM Employee");
            }
        }

        public int Add(Employee obj)
        {
            string sql = "if exists(select * from Employee where EmployeeId = @EmployeeId OR Email = @Email)\r\n\tINSERT INTO Employee(EmployeeId, FirstName, LastName, Gender, Email, Phone) VALUES \r\n\t\t\t\t\t\t(@EmployeeId, @FirstName, @LastName, @Gender, @Email, @Phone)";

            obj.EmployeeId = GetEmployees().Max(e => e.EmployeeId) + 1;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Execute(sql, new
                {
                    EmployeeId = obj.EmployeeId,
                    FirstName = obj.FirstName,
                    LastName = obj.LastName,
                    Gender = obj.Gender,
                    Email = obj.Email,
                    Phone = obj.Phone
                });
            }
        }

        public int AddWithProcedure(Employee obj)
        {
            obj.EmployeeId = GetEmployees().Max(e => e.EmployeeId) + 1;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Execute("AddEmployee", param: new
                {
                    EmployeeId = obj.EmployeeId,
                    FirstName = obj.FirstName,
                    LastName = obj.LastName,
                    Gender = obj.Gender,
                    Email = obj.Email,
                    Phone = obj.Phone
                }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
