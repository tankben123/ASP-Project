using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConsole
{
    internal class BookRepository
    {
        static string connectionString = "Server=172.168.5.160,8888;Database=Store;User Id=fa11;Password=Toan@2023";
        public int Add(DataTable table)
        {
            using (SqlBulkCopy copy = new SqlBulkCopy(connectionString)) 
            {
                try
                {
                    copy.DestinationTableName = "Book";
                    copy.WriteToServer(table);
                    return 0;
                }
                catch (Exception ex) { 
                    System.Console.WriteLine(ex.Message);
                    return -1;
                }
                
            }   
                
        }
    }
}
