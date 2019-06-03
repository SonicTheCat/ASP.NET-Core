using CHUSHKA.Models;
using System.Collections.Generic;

namespace CHUSHKA.Service.Contracts
{
    public interface IProductsService
    {
        void AddProduct(Product product);

        IEnumerable<Product> AllProducts();

        Product GetProductById(int id);

        void EditProduct(); 
    }
}