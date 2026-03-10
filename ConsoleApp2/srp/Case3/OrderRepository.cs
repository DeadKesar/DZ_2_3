using System;

namespace ConsoleApp2.srp.Case3
{
    /// <summary>
    /// Отвечает за сохранение заказов.
    /// </summary>
    class OrderRepository
    {
        public void Save(Order order)
        {
            Console.WriteLine($"Order #{order.OrderId} saved to database!");
        }
    }
}
