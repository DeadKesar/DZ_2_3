using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.srp
{
    class Case3
    {
        class Order
        {
            public int orderId { get; set;  }
            public List<string> items { get; } = new List<string>();

            public Order(string item)
            {
                items.Add(item);
            } 

        }
        public class SendOrderService
        {
            public void SendOrder()
            {
                Console.WriteLine("Order confirmation email sent!");
            }
        }

        public class PrinterOrderService
        {
            public void PrintOrder(List<string> items, int orderId)
            {
                Console.WriteLine("Order #" + orderId);
                foreach (var item in items)
                {
                    Console.WriteLine(" - " + item);
                }
            }
        }

        public class SaveToDatabaseService
        {
            public void SaveToDatabase()
            {
                Console.WriteLine("Order saved to Database!");
            }
        }



        public class App
        {
            static void Main()
            {
                Order order = new Order("Laptop");


                PrinterOrderService printer = new PrinterOrderService(); 
                SaveToDatabaseService saver = new SaveToDatabaseService();
                SendOrderService sender = new SendOrderService(); 

                printer.PrintOrder(order.items, order.orderId);
                saver.SaveToDatabase();
                sender.SendOrder(); 
            }
        }
    }
}
