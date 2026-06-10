using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.srp
{
    class Case3
    {
        class Order
        {
            public int OrderId;
            public List<string> Items = new List<string>();

            public void AddItem(string item)
            {
                Items.Add(item);
            }
        }

        class OrderRepository
        {
            public void SaveToDatabase(Order order)
            {
                Console.WriteLine("Order saved to database!");
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

        class OrderConfirmationSender
        {
            public void SendOrderConfirmation(Order order)
            {
                Console.WriteLine("Order confirmation email sent!");
            }
        }

        public class App
        {
            static void Main()
            {
                Order order = new Order();
                order.AddItem("Laptop");

                OrderPrinter printer = new OrderPrinter();
                printer.PrintOrder(order);

                OrderRepository repository = new OrderRepository();
                repository.SaveToDatabase(order);

                OrderConfirmationSender sender = new OrderConfirmationSender();
                sender.SendOrderConfirmation(order);
            }
        }
    }
}
