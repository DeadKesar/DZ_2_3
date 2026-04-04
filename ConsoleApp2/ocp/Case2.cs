using System;

namespace ConsoleApp2.ocp
{
    class Case2
    {
        public abstract class Figure
        {
            public abstract double GetArea();  // у фигуры обязана быть реализация рассчета площади, для этого нужен abstract
        }
        // очень удобно код подходящий под принцип ocp был расположен ниже, не мог не воспользоваться данным подарком судьбы :)
        class Circle : Figure
        {
            public double Radius { get; set; }
            public Circle(double radius)
            {
                Radius = radius;
            }
            public override double GetArea()
            {
                return Math.PI * Radius * Radius;
            }
        }
        class Rectangle : Figure
        {
            public double Width { get; set; }
            public double Height { get; set; }
            public Rectangle(double width, double height)
            {
                Width = width;
                Height = height;
            }
            public override double GetArea()
            {
                return Width * Height;
            }
        }
        class Application
        {
            static void Main()
            {
                Figure c = new Circle(5); // Переменная базового типа ссылается на объект потомка
                Figure r = new Rectangle(4, 6); // Переменная базового типа ссылается на объект потомка
                Console.WriteLine("Circle area: " + c.GetArea());
                Console.WriteLine("Rectangle area: " + r.GetArea());
            }
        }
    }
}
