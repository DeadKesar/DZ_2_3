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

            public void SaveToDatabase()
            {
                Console.WriteLine("Order saved to database!");
            }

            public void PrintOrder()
            {
                Console.WriteLine("Order #" + OrderId);
                foreach (var item in Items)
                {
                    Console.WriteLine(" - " + item);
                }
            }

            public void SendOrderConfirmation()
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
                order.PrintOrder();
                order.SaveToDatabase();
                order.SendOrderConfirmation();
            }
        }
    }
}
