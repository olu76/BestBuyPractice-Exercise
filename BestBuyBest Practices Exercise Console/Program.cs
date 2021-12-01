using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace BestBuyBest_Practices_Exercise_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            //var TestRepo = new DapperDeparmentRepository(conn);

            //Console.WriteLine("Type a new Department name.");

            //var newDepartment = Console.ReadLine();

            //TestRepo.InsertDepartment(newDepartment);

            //var departments = TestRepo.GetAllDepartments();

            //foreach (var dept in departments)
            //{
            //    Console.WriteLine($"Dept Name: {dept.Name}");
            //    Console.WriteLine($"Dept ID: {dept.DepartmentID}");
            //}


            var product = new DapperProductRepository(conn);

            Console.WriteLine("What is the Name of your new product?");
            var prodName = Console.ReadLine();

            Console.WriteLine("What is the Price?");
            var prodPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("What is the Category ID?");
            var prodCat = int.Parse(Console.ReadLine());

            product.CreateProduct(prodName, prodPrice, prodCat);

            var prodList = product.GetAllProducts();

            foreach (var prod in prodList)
            {
                Console.WriteLine($"{prod.ProductID} - {prod.Name} - {prod.Price} - {prod.CategoryID}");
            }

            Console.WriteLine("What is the product ID that you want to update?");
            var prodID = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the new Product Name?");
            var newName = Console.ReadLine();

            product.UpdateProduct(prodID, newName);

            foreach (var prod in prodList)
            {
                Console.WriteLine($"{prod.ProductID} - {prod.Name} - {prod.Price} - {prod.CategoryID}");
            }

            Console.WriteLine("What is the Product ID that you want to delete?");
            prodID = int.Parse(Console.ReadLine());

            product.DeleteProduct(prodID);

            foreach (var prod in prodList)
            {
                Console.WriteLine($"{prod.ProductID} - {prod.Name} - {prod.Price} - {prod.CategoryID}");
            }



        }
    }
}
