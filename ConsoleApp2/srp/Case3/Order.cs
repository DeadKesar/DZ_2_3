using System.Collections.Generic;

namespace ConsoleApp2.srp.Case3
{
    /// <summary>
    /// Класс заказа.
    /// Содержит идентификатор заказа и список товаров.
    /// </summary>
    class Order
    {
		// Поля заменены на свойства, чтобы обеспечить инкапсуляцию и контролируемый доступ к данным класса
        public int OrderId { get; set; }
        public List<string> Items { get; } = new List<string>();

        public void AddItem(string item)
        {
            Items.Add(item);
        }
    }
}