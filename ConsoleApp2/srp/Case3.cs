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

    class Case3Fixed
    {
        //в Order теперь только метод AddItem
        public class Order
        {
            public int OrderId;
            public List<string> Items = new List<string>();

            public void AddItem(string item)
            {
                Items.Add(item);
            }
        }

        //класс для сохранения в базу данных
        public class OrderSave
        {
            public void SaveToDatabase(Order order)
            {
                Console.WriteLine("Order saved to database!");
            }
        }

        //класс для печати заказа
        public class OrderPrinter
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

        //класс для отправки подтверждения
        public class OrderConfirmationService
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

                var printer = new OrderPrinter();
                var repo = new OrderSave();
                var confirmation = new OrderConfirmationService();  

                printer.PrintOrder(order);
                repo.SaveToDatabase(order);
                confirmation.SendOrderConfirmation(order);
            }
        }
    }
}
