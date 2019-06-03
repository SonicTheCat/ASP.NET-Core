using Microsoft.AspNetCore.Authorization;
using CHUSHKA.WEB.Common;
using Microsoft.AspNetCore.Mvc;
using CHUSHKA.WEB.ViewModels;
using CHUSHKA.Models;
using CHUSHKA.Data;
using CHUSHKA.Service.Contracts;

namespace CHUSHKA.WEB.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService; 
        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService; 
        }

        [Authorize(Roles = GlobalConstants.AdministratorRole)]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRole)]
        public IActionResult Create(ProductViewModel viewModel)
        {
            var product = new Product
            {
                Name = viewModel.Name,
                Price = viewModel.Price,
                Description = viewModel.Description,
                Type = viewModel.Type
            };

            this.productsService.AddProduct(product);

            return Redirect(GlobalConstants.HomeIndexUrl);
        }
        
        public IActionResult Edit(int id)
        {
            var product = this.productsService.GetProductById(id);
            if (product == null)
            {
                return NotFound(); 
            }

            var productViewModel = new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Type = product.Type
            };

            return this.View(productViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel viewModel)
        {
            var product = this.productsService.GetProductById(viewModel.Id);

            if (product == null)
            {
                return NotFound();
            }

            product.Name = viewModel.Name;
            product.Price = viewModel.Price;
            product.Description = viewModel.Description;
            product.Type = viewModel.Type; 

            this.productsService.EditProduct();

            return Redirect(GlobalConstants.HomeIndexUrl);
        }

        public IActionResult Details(int id)
        {
            var product = this.productsService.GetProductById(id);

            if (product == null)
            {
                return this.NotFound(); 
            }

            var productViewModel = new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Type = product.Type
            };

            return this.View(productViewModel); 
        }
    }
}