namespace CHUSHKA.Service.Contracts
{
    using CHUSHKA.Models;
    using System.Collections.Generic;

    public interface IOrdersService
    {
        void MakeOrder(Order order);

        IEnumerable<Order> AllOrders();

        Order GetOrderById(int id); 
    }
}