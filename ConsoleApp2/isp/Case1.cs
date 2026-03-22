using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.isp
{
    internal class Case1
    {
        public interface IPrinter { 
            void Print(string document);
        }
        public interface IScanner {
            void Scan(string document);
        }

        public interface IFax {
            void Fax(string document);
        }

        public interface ICopy {
            void Copy(string document);
        }
        public class BasicPrinter : IPrinter
        {
            public string Model { get; set; }

            public BasicPrinter(string model)
            {
                Model = model;
            }

            public void Print(string document)
            {
                Console.WriteLine("BasicPrinter printing: " + document);
            }

            public void Maintenance()
            {
                Console.WriteLine("Performing maintenance on BasicPrinter " + Model);
            }
        }

        public class AllInOnePrinter : IPrinter, IScanner, IFax, ICopy
        {
            public string Model { get; set; }

            public AllInOnePrinter(string model)
            {
                Model = model;
            }

            public void Print(string document)
            {
                Console.WriteLine("AllInOnePrinter printing: " + document);
            }

            public void Scan(string document)
            {
                Console.WriteLine("AllInOnePrinter scanning: " + document);
            }

            public void Fax(string document)
            {
                Console.WriteLine("AllInOnePrinter faxing: " + document);
            }

            public void Copy(string document)
            {
                Console.WriteLine("AllInOnePrinter copying: " + document);
            }

            public void Calibrate()
            {
                Console.WriteLine("Calibrating printer " + Model); 
            }
        }

    }
}
