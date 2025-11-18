using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.DAL
{
    public class ProductDAL
    {
        private string connectionString = "Server=localhost;Database=InventoryDB;Trusted_Connection=True;";

        // 🔍 Get all products
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Products";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        ProductID = Convert.ToInt32(reader["ProductID"]),
                        ProductName = reader["ProductName"].ToString(),
                        Category = reader["Category"].ToString(),
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        Price = Convert.ToDecimal(reader["Price"]),
                        Supplier = reader["Supplier"].ToString(),
                        AddedDate = Convert.ToDateTime(reader["AddedDate"])
                    });
                }
            }

            return products;
        }

        // ➕ Insert a new product
        public bool InsertProduct(Product product)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Products 
                                 (ProductName, Category, Quantity, Price, Supplier, AddedDate) 
                                 VALUES 
                                 (@ProductName, @Category, @Quantity, @Price, @Supplier, @AddedDate)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Category", product.Category);
                cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Supplier", product.Supplier);
                cmd.Parameters.AddWithValue("@AddedDate", product.AddedDate);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
        public bool UpdateProduct(Product product)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Products SET 
                         ProductName = @ProductName,
                         Category = @Category,
                         Quantity = @Quantity,
                         Price = @Price,
                         Supplier = @Supplier,
                         AddedDate = @AddedDate
                         WHERE ProductID = @ProductID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Category", product.Category);
                cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Supplier", product.Supplier);
                cmd.Parameters.AddWithValue("@AddedDate", product.AddedDate);
                cmd.Parameters.AddWithValue("@ProductID", product.ProductID);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool DeleteProduct(int productId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Products WHERE ProductID = @ProductID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductID", productId);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

    }
}
