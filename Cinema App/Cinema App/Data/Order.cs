using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema_App
{
    class Order
    {
        public short OrderId { get; }
        public List<BasketItem> Items { get; }
        public DateTime OrderDate { get; }
        public Guid UserId { get; }

        public Order(List<BasketItem> items, Controller controller = null)
        {
            Items = items;
            OrderId = GenerateOrderID();
            OrderDate = DateTime.Now;
            UserId = controller.CurrentUser.GUID;

            while (controller.DataStore.GetOrderByID(OrderId) != null)
                OrderId = GenerateOrderID();
        }

        [JsonConstructor]
        public Order(List<BasketItem> items, short orderId, DateTime orderDate, Guid userId)
        {
            Items = items;
            OrderId = orderId;
            OrderDate = orderDate;
            UserId = userId;
        }

        short GenerateOrderID()
        {
            Random rnd = new Random();
            return (short)rnd.Next(0, short.MaxValue);
        }

    }
}
