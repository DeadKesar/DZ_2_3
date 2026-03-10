namespace ConsoleApp2.srp.Case3
{
    /// <summary>
    /// Класс запуска сценария работы приложения.
    /// Координирует создание заказа и вызов сервисов, отвечающих за вывод, сохранение и отправку подтверждения.
    /// </summary>
    public class App
    {
        public static void Run()  // static void Main() заменен на public static void Run(), т.к. точка входа проекта – в Program.cs
        {
            // Создание заказа
            Order order = new Order { OrderId = 1 };
            order.AddItem("Laptop");

            // Создание сервисов, каждый из которых отвечает за отдельную задачу
            OrderPrinter printer = new OrderPrinter();
            OrderRepository repository = new OrderRepository();
            OrderConfirmationService confirmationService = new OrderConfirmationService();

            // Вывод заказа в консоль, сохранение заказа, отправка подтверждения
            printer.Print(order);
            repository.Save(order);
            confirmationService.Send(order);
        }
    }
}