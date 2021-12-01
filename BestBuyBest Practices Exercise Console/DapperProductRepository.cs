using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using Dapper;

namespace BestBuyBest_Practices_Exercise_Console
{
    public class DapperProductRepository :IProductRepository
    {
        private readonly IDbConnection _connection; // Field
        //Constructor
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products (Name , Price, CategoryID)" +
                "VALUES (@name, @price, @categoryID);",
                new { name = name, price = price, categoryID = categoryID });
        }

        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM product WHERE ProductID = @productID;",
                new { productID = productID });
            _connection.Execute("DELETE FROM sales WHERE productID = @productID;",
                new { productID = productID });
            _connection.Execute("DELETE FROM reviews WHERE ProductID =@productID;",
                new { productID = productID });
            Console.WriteLine($"Product #{productID} Deleted");
            Thread.Sleep(3000);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM product;");
        }

        public void UpdateProduct(int productID, string updatedName)
        {
            _connection.Execute("UPDATE products SET Name = @updatedName WHERE ProductID = @productID;",
                new { productID = productID, updatedName = updatedName });
            Console.WriteLine($"productID #{productID} Updated");
            Thread.Sleep(3000);

        }
    }
}
