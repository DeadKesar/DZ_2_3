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
            public int OrderId { get; set; };
            public List<string> Items {get; set;} = new List<string>();

            public void AddItem(string item)
            {
                Items.Add(item);
            }
        }
        class OrderRepostory
        {
            public void SaveToDatabase(Order order)
            {
                Console.WriteLine("Order saved to database!");
            }
        }

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

        class OrderNotificationServise
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
                printer.Print(order);
                
                OrderRepository repository =  new OrderRepository();
                repo.Save(order);

                OrderNotificationService notifier = new OrderNotificationService();
                notifier.SendConfirmation(order);
            }
        }
}

