using System;

namespace ConsoleApp2.lsp
{
    internal class Case0
    {
        public abstract class Shape
        {
            public abstract int CalculateArea();
            public abstract void Draw();
        }

        public class Rectangle : Shape
        {
            protected int Width { get; set; }
            protected int Height { get; set; }

            public void SetWidth(int width)
            {
                Width = width;
                Console.WriteLine($"Width set to {width}.");
            }

            public void SetHeight(int height)
            {
                Height = height;
                Console.WriteLine($"Height set to {height}.");
            }

            public override int CalculateArea()
            {
                return Width * Height;
            }

            public override void Draw()
            {
                Console.WriteLine("Drawing rectangle.");
            }
        }

        public class Circle : Shape
        {
            public int Radius { get; set; }

            public Circle(int radius)
            {
                Radius = radius;
            }

            public void SetRadius(int radius)
            {
                Radius = radius;
                Console.WriteLine($"Circle radius set to {radius}.");
            }

            public override int CalculateArea()
            {
                return (int)(Math.PI * Radius * Radius);
            }

            public override void Draw()
            {
                Console.WriteLine("Drawing circle.");
            }
        }
    }
}
