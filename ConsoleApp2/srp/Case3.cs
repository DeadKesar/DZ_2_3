using System;
using System.Collections.Generic;

namespace ConsoleApp2.srp
{
    class Case3
    {
        class Order
        {
            public int OrderId { get; set; }
            public List<string> Items { get; } = new List<string>();

            public void AddItem(string item)
            {
                Items.Add(item);
            }
        }

        class OrderPrinter
        {
            public void PrintOrder(Order order)
            {
                Console.WriteLine("Order #" + order.OrderId);
                foreach (var item in order.Items)
                {
                    Console.WriteLine(" - " + item);
                }
            }
        }

        class OrderRepository
        {
            public void SaveToDatabase(Order order)
            {
                Console.WriteLine("Order saved to database!");
            }
        }

        class OrderNotificationService
        {
            public void SendOrderConfirmation(Order order)
            {
                Console.WriteLine("Order confirmation email sent!");
            }
        }

        public class App
        {
            public void Execute()
            {
                Order order = new Order { OrderId = 1 };
                OrderPrinter printer = new OrderPrinter();
                OrderRepository repository = new OrderRepository();
                OrderNotificationService notificationService = new OrderNotificationService();

                order.AddItem("Laptop");
                printer.PrintOrder(order);
                repository.SaveToDatabase(order);
                notificationService.SendOrderConfirmation(order);
            }
        }
    }
}