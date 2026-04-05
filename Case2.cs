using System;

namespace ConsoleApp2.ocp
{
    class Case2
    {
        // Абстракция для всех фигур, AreaCalculator закрыт для модификации, PUBLIC для использования вне case2, если надо
        public interface IShape
        {
            double GetArea();
        }

        public class Circle : IShape
        {
            public double Radius { get; }//clean code

            public Circle(double radius)
            {
                Radius = radius;
            }

            public double GetArea()
            {
                return Math.PI * Radius * Radius;
            }
        }

        public class Rectangle : IShape
        {
            public double Width { get; }//clean code
            public double Height { get; }//clean code

            public Rectangle(double width, double height)
            {
                Width = width;
                Height = height;
            }

            public double GetArea()
            {
                return Width * Height;
            }
        }

        public class AreaCalculator
        {
            // Теперь метод принимает абстракцию IShape
            public double Calculate(IShape shape)
            {
                return shape.GetArea();//Нет if-ов OCP принцип
            }
        }

        class Program
        {
            static void Main()
            {
                var circle = new Circle(5);
                var rectangle = new Rectangle(4, 6);

                var calculator = new AreaCalculator();

                Console.WriteLine("Circle area: " + calculator.Calculate(circle));
                Console.WriteLine("Rectangle area: " + calculator.Calculate(rectangle));
            }
        }
    }
}