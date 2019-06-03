using System.Collections.Generic;
using System.Linq;
using CHUSHKA.Data;
using CHUSHKA.Models;
using CHUSHKA.Service.Contracts;

namespace CHUSHKA.Service
{
    public class ProductsService : IProductsService
    {
        private readonly ChushkaDbContext db;

        public ProductsService(ChushkaDbContext db)
        {
            this.db = db; 
        }

        public void AddProduct(Product product)
        {
            if (product == null)
            {
                return; 
            }

            this.db.Products.AddAsync(product).Wait();
            this.db.SaveChangesAsync().Wait(); 
        }

        public IEnumerable<Product> AllProducts()
        {
            return this.db.Products.ToList(); 
        }

        public void EditProduct()
        {
            this.db.SaveChangesAsync().Wait(); 
        }

        public Product GetProductById(int id)
        {
            return this.db.Products.FirstOrDefault(x => x.Id == id);
        }
    }
}