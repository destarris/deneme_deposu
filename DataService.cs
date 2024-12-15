using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace deneme
{
    
    public class DataService
    {
        private readonly string _connectionString;

        public DataService(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Örnek: Tüm ürünleri listeleyen bir metot
        public async Task<List<string>> GetProductsAsync()
        {
            var products = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("SELECT ProductName FROM Products", connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            products.Add(reader.GetString(0)); // İlk sütun: ProductName
                        }
                    }
                }
            }

            return products;
        }
    }

}
