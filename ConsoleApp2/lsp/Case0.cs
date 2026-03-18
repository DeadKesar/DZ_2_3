using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.lsp
{
    internal class Case0
    {
        public abstract class Shape
        {

            public abstract double CalculateArea();

            public abstract void Draw();

        }

        public class Circle : Shape
        {
            public int Radius { get; set; }

            public Circle(int radius)
            {
                Radius = radius;
            }

            public override double CalculateArea()
            {
                return Math.PI * Radius * Radius;
            }

            public override void Draw()
            {
                Console.WriteLine($"Drawing circle with radius {Radius}.");
            }
        }

    }
}
