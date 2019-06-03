namespace CHUSHKA.WEB.Controllers
{
    using CHUSHKA.Models;
    using CHUSHKA.Service.Contracts;
    using CHUSHKA.WEB.Common;
    using CHUSHKA.WEB.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;
    using System.Security.Claims;

    [Authorize]
    public class OrdersController : Controller
    {
        //private readonly IProductsService productsService;
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        public IActionResult Make(int id)
        {
            //var product = this.productsService.GetProductById(productId);
            //if (product == null)
            //{
            //    return this.NotFound(); 
            //}

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var order = new Order()
            {
                ProductId = id,
                ClientId = userId,
                OrderedOn = DateTime.UtcNow
            };

            this.ordersService.MakeOrder(order);

            return this.Redirect(GlobalConstants.HomeIndexUrl); 
        }

        [Authorize(Roles = GlobalConstants.AdministratorRole)]
        public IActionResult All()
        {
            var orders = this.ordersService.AllOrders()
                .Select(x => new OrderViewModel()
                {
                   Id = x.Id,
                   Client = x.Client, 
                   Product = x.Product, 
                   OrderedOn = x.OrderedOn
                })
                .ToList(); 

            return this.View(orders); 
        }
    }
}