using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.srp
{
        //уюрали class Case3 тк лишняя обертка, оборачивать классы внутрь другого пустого класса не надо
        public class Order
        {   
            public int OrderId{ get; set;} //Clean code(используем автоматические свойства set get, чтбы чтобы компилятор сам создал закрытую перменную для хранения данных
            public List<string> Items{get; set;} = new List<string>();

            public void AddItem(string item)
            {
                Items.Add(item);
            }
            //создали класс,который отвечает только за сохранение в базу!!!
            public class OrderRepository
            {
            public void SaveToDatabase(Order order)
            {
                Console.WriteLine("Order saved to database!");
                }
            }
            //создали класс который отвечает только за печать, вывод на экран
            public class OrderPrinter{
                public void PrintOrder(Order order)
            {
                //clean code(знак $ позволяет нам вставоять переменные прямо в строку
                Console.WriteLine($"Order #{order.OrderId}");
                foreach (var item in order.Items)
                {
                    Console.WriteLine($" -  {item}");
                    }
                }
            }
        //класс отвечает только за отправку писем
            public class OrderNotifier{
            public void SendOrderConfirmation(Order order)
            {
                Console.WriteLine("Order confirmation email sent!");
            }
        }
        

        public class App
        {
            static void Main()
            {
                Order order = new Order{OrderId=1};
                order.AddItem("Laptop");
                //вызываем нужные классы ,чтобы передать им наш заказ
                OrderPrinter printer=new OrderPrinter();
                printer.PrintOrder(order);
                OrderRepository repository=new OrderRepository();
                repository.SaveToDatabase(order);
                OrderNotifier notifier=new OrderNotifier();
                notifier.SendOrderConfirmation(order);
            }
        }
    }
}

