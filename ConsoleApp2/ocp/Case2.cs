using System;
using System.Collections.Generic;

namespace ConsoleApp2.ocp
{
    interface IShape
    {
        double GetArea();
    }

    class Circle : IShape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    class Rectangle : IShape
    {
        public double Width { get; }
        public double Height { get; }

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

    class AreaCalculator
    {
        public double Calculate(IShape shape)
        {
            return shape.GetArea();
        }

        public double CalculateTotal(IEnumerable<IShape> shapes)
        {
            double total = 0;

            foreach (var shape in shapes)
            {
                total += shape.GetArea();
            }

            return total;
        }
    }

    class Program
    {
        static void Main()
        {
            IShape c = new Circle(5);
            IShape r = new Rectangle(4, 6);

            AreaCalculator calculator = new AreaCalculator();

            Console.WriteLine("Circle area: " + calculator.Calculate(c));
            Console.WriteLine("Rectangle area: " + calculator.Calculate(r));

            var shapes = new List<IShape> { c, r };
            Console.WriteLine("Total area: " + calculator.CalculateTotal(shapes));
        }
    }
}
