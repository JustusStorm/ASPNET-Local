using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Testing.Models;

namespace Testing
{
    public class ProductRepository : IProductRepository
    {
        // properties 
        private readonly IDbConnection _conn;



        // Constructors
        public ProductRepository (IDbConnection conn)
        {
            _conn = conn;
        }

        public Product AssignCategory()
        {
            var categoryList = GetCategories();
            var product = new Product();
            product.Categories = categoryList;

            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM products;");
        }

        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM categories");
        }

        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM products WHERE productid = @id",
                new { id = id });
        }

        public void InsertProduct(Product productToInsert)
        {
            _conn.Execute("INSERT INTO products (Name, Price, CategoryID, StockLevel) VALUES (@name, @price, @categoryID, @stockLevel);",
                new { name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.CategoryID, stockLevel = productToInsert.StockLevel});
        }

        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE products SET Name = @name , Price = @price WHERE ProductID = @id;",
                new { name = product.Name, price = product.Price, id = product.ProductID });
        }

        public void DeleteProduct(Product product)
        {
            _conn.Execute("DELETE FROM reviews WHERE ProductID = @id;",
                new { id = product.ProductID });
            _conn.Execute("DELETE FROM sales WHERE ProductID = @id;",
                new { id = product.ProductID });
            _conn.Execute("DELETE FROM products WHERE ProductID = @id;",
                new { id = product.ProductID });
        }
    }
}
