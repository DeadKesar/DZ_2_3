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


    // новый класс по образу старого case3. Нарушение SRP было в классе Order, который отвечал и за создание заказов (добавление обьекта в список), и за уведомление, и за вывод их в консоль. Надо разделить функционал. Были созданы классы informative, OrderPrinter
    class Case3better 
    {
        // изменённый класс Order без лишнего. Отвечает только за добавление обьекта в cписок и данные самого обьекта.
        public class Order
        {
            public int OrderId;
            public List<string> Items = new List<string>();

            public void AddItem(string item)
            {
                Items.Add(item);
            }
        }

        // класс Informative, содержащий методы по выводу соответвующего сообщения. Принимает обьек класса Order в качестве параметра
        public class Informative
        {
            public void SaveToDatabase(Order order) { Console.WriteLine("Order saved to database!"); }

            public void SendOrderConfirmation(Order order) { Console.WriteLine("Order confirmation email sent!"); }

            }

        // класс OrderPrinter, выводящий заказы в консоль. Принимает обьек класса Order в качестве параметра
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

        public class App
        {
            // для каждого отдельного класса теперь создаются обьекты работы с ними, будь то сам обьект - заказ, вывод на экран, или уведомление. SRP соблюден.
            static void Main()
            {
                Order order = new Order();
                order.OrderId = 612;
                order.AddItem("Laptop");

                OrderPrinter printer = new OrderPrinter();
                printer.PrintOrder(order);

                Informative info = new Informative();
                info.SaveToDatabase(order);
                info.SendOrderConfirmation(order);
            }
        }
    }
}
