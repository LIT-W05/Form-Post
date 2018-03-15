using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication9.Models
{
    public class NorthwindManager
    {
        private string _connectionString;

        public NorthwindManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Product> GetProducts(int minStock, int maxStock)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Products WHERE UnitsInStock BETWEEN @min AND @max";
            cmd.Parameters.AddWithValue("@min", minStock);
            cmd.Parameters.AddWithValue("@max", maxStock);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                products.Add(new Product
                {
                    Id = (int)reader["ProductId"],
                    Name = (string)reader["ProductName"],
                    QuantityInStock = (short)reader["UnitsInStock"],
                    QuantityPerUnit = (string)reader["QuantityPerUnit"],
                    UnitPrice = (decimal)reader["UnitPrice"]
                });
            }

            connection.Close();
            connection.Dispose();
            return products;
        }
    }
}