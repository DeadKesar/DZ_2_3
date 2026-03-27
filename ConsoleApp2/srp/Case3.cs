using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.srp
{
    class Case3
    {
        public class Order //этот класс будет отвечать только за хранение данных заказа, добавлен public для доступа 
        {
            public int OrderId ;
            public List<string> Items = new List<string>();

            public void AddItem(string item)
            {
                Items.Add(item);
            }
        }
        
        public class OrderRepository // этот класс отвечает только за хранение закозов в базе данных
        {
            public void Save(Order order) //сокращение имени функции для читаемости - отсутствие загромождённости. +добавление параметра
            {
                if (order == null)    //проверка на пустой заказ
                    throw new ArgumentNullException(nameof(order));    //nameof(order) - защита от переименования
                Console.WriteLine("Order saved to database!");
            }
        }

        public class OrderPrinter //этот класс отвечает только за вывод данных заказа
        {
            public void Print(Order order) //сокращение имени функции для читаемости - отсутствие загромождённости +добавление параметра
            {
                if (order == null)    //проверка на пустой заказ
                    throw new ArgumentNullException(nameof(order));
                Console.WriteLine("Order #" + order.OrderId); // order.OrderId - тк OrderId теперь в другом классе
                foreach (var item in order.Items)    //order.Items - Items теперь в другом классе
                {
                    Console.WriteLine(" - " + item);
                }
            }
        }

        public class EmailNotification    //этот класс отвечает за отправку email
        {
            public void Send(Order order)    //сокращение имени функции для читаемости - отсутствие загромождённости +добавление параметра
            {
                if (order == null)    //проверка на пустой заказ
                    throw new ArgumentNullException(nameof(order));
                Console.WriteLine("Order confirmation email sent!");
            }
        }


        public class App
        {
            static void Main()
            {
                Order order = new Order();
                order.OrderId = 1;     //добавляем id к заказу
                order.AddItem("Laptop");
                
                OrderPrinter printer = new OrderPrinter();    //создание объектов новых классов
                OrderRepository repository = new OrderRepository();
                EmailNotification emailService = new EmailNotification();
                
                printer.Print(order);    // использование самих функций
                repository.Save(order);
                emailService.Send(order);
            }
        }
    }
}
