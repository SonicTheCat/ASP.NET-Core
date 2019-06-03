namespace CHUSHKA.Service
{
    using CHUSHKA.Data;
    using CHUSHKA.Models;
    using CHUSHKA.Service.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public class OrdersService : IOrdersService
    {
        private readonly ChushkaDbContext db;

        public OrdersService(ChushkaDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Order> AllOrders()
        {
            return this.db.Orders
                .Include(x => x.Client)
                .Include(x => x.Product)
                .ToList();
        }

        public Order GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public void MakeOrder(Order order)
        {
            if (order == null)
            {
                return; 
            }

            this.db.Orders.AddAsync(order).Wait();
            this.db.SaveChanges(); 
        }
    }
}