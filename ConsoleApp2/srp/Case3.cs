using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.srp
{
    class Case3
    {
        public class Order // вместо добавления функций в один класс создаём для каждой специфической функции отдельный класс и можем добавлять в эти классы похожие функции
        {
            public int OrderId { get; set; }
            public List<string> Items { get; set; }
            
            public Order()
            {
                Items = new List<string>();
            }
            
            public void AddItem(string item)
            {
                Items.Add(item);
            }
        }
        public class OrderDatabaseService // класс для работы с базами данных
        {
            public void SaveToDatabase(Order order)
            {
                Console.WriteLine("Order saved to database!");
            }
        }
        public class OrderPrintService // класс для заполнения данных о заказе
        {
            public void PrintOrder(Order order)
            {
                Console.WriteLine("Order #" + OrderId);
                foreach (var item in Items)
                {
                    Console.WriteLine(" - " + item);
                }
            }
        }
        public class OrderNotificationService // класс для работы с уведомлениями
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
                OrderPrintService printer = new OrderPrintService();
                printer.PrintOrder(order);
                OrderDatabaseService db = new OrderDatabaseService();
                db.Save(order);
                OrderNotificationService notifier = new OrderNotificationService();
                notifier.SendOrderConfirmation(order);
            }
        }
    }
}
