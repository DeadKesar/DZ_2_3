using System;

namespace ConsoleApp2.ocp
{
    class Case2
    {
        interface IShape
        {
            double GetArea();
        }

        class Circle : IShape
        {
            public double Radius;
            public Circle(double radius) => Radius = radius;

            public double GetArea() => Math.PI * Radius * Radius;
        }

        class Rectangle : IShape
        {
            public double Width, Height;
            public Rectangle(double width, double height)
            {
                Width = width;
                Height = height;
            }

            public double GetArea() => Width * Height;
        }

        class Triangle : IShape
        {
            public double Base, Height;
            public Triangle(double b, double h) { Base = b; Height = h; }

            public double GetArea() => 0.5 * Base * Height;
        }

        class AreaCalculator
        {
            public double Calculate(IShape shape)
            {
                return shape.GetArea();
            }
        }

        class Program
        {
            static void Main()
            {
                AreaCalculator calculator = new AreaCalculator();

                Console.WriteLine("Circle area:  "    + calculator.Calculate(new Circle(5)));
                Console.WriteLine("Rectangle area: " + calculator.Calculate(new Rectangle(4, 6)));
                Console.WriteLine("Triangle area: "  + calculator.Calculate(new Triangle(3, 8)));
            }
        }
    }
}
