using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testing.Models;

namespace Testing
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts(); // stubbed out method 
        public Product GetProduct(int id); // stubbed out method


        public void UpdateProduct(Product product); // stubbed out method


        public void InsertProduct(Product productToInsert);// stubbed out method
        public IEnumerable<Category> GetCategories();// stubbed out method
        public Product AssignCategory();// stubbed out method

        public void DeleteProduct(Product product); // stubbed out method

    }
}
