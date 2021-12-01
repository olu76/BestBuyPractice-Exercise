using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyBest_Practices_Exercise_Console
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();

        public void CreateProduct(string name, double price, int categoryID);

        public void UpdateProduct(int productID, string updateName);

        public void DeleteProduct(int productID);
    }
}
