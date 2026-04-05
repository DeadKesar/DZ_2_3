using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.ocp
{
    class Case2
    {
        // сделал общий класс для фигур(абстрактный), каждая сама считает площадь
        abstract class Figure
        {
            public abstract double GetArea();
        }

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

        // сейчас калькулятор не проверяет на иф/элс и работает через тип figure
        class AreaCalculator
        {
            public double Calculate(Figure figure)
            {
                return figure.GetArea();
            }
        }

        class Program
        {
            static void Main()
            {
                Circle c = new Circle(5);
                Rectangle r = new Rectangle(4, 6);

                AreaCalculator calculator = new AreaCalculator();

                Console.WriteLine("Circle area: " + calculator.Calculate(c));
                Console.WriteLine("Rectangle area: " + calculator.Calculate(r));
            }
        }
    }
}