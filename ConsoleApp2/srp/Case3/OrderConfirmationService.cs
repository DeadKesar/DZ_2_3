using System;

namespace ConsoleApp2.srp.Case3
{
    /// <summary>
    /// Сервис отправки подтверждения заказа.
    /// Отвечает только за уведомление пользователя.
    /// </summary>
    class OrderConfirmationService
    {
        public void Send(Order order)
        {
            Console.WriteLine($"Order confirmation for order #{order.OrderId} sent!");
        }
    }
}