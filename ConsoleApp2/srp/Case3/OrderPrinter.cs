using System;

namespace ConsoleApp2.srp.Case3
{
    /// <summary>
    /// Отвечает за вывод информации о заказе.
    /// Реализует только логику отображения данных.
    /// </summary>
    class OrderPrinter
    {
        public void Print(Order order)
        {
            Console.WriteLine("Order #" + order.OrderId);

            foreach (var item in order.Items)
            {
                Console.WriteLine(" - " + item);
            }
        }
    }
}
