using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.ocp
{
    class Case2
    {
        abstract class Figure
        {
            public abstract double GetArea();
        }

        class Circle : Figure
        {
            public double Radius;

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
            public double Width;
            public double Height;

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

        class Program
        {
            static void Main()
            {
                Figure c = new Circle(5);
                Figure r = new Rectangle(4, 6);

                Console.WriteLine("Circle area: " + c.GetArea());
                Console.WriteLine("Rectangle area: " + r.GetArea());
            }
        }
    }
}
