namespace CHUSHKA.WEB.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using CHUSHKA.WEB.Models;
    using System.Collections.Generic;
    using CHUSHKA.WEB.ViewModels;
    using CHUSHKA.Models;
    using CHUSHKA.Service.Contracts;
    using System.Linq;

    public class HomeController : Controller
    {
        private IProductsService productService;

        public HomeController(IProductsService productsService)
        {
            this.productService = productsService;
        }

        public IActionResult Index()
        {
            var products = this.productService
                .AllProducts()
                .Select(x => new ProductViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    Type = x.Type
                })
                .ToList();

            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}