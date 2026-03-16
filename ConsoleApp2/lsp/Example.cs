using System;

namespace ConsoleApp2.lsp
{
    internal class ExampleFixed
    {
        // базовая утка
        private class Utka
        {
            public virtual void Kryakat()
            {
                Console.WriteLine("Я крякаю");
            }
        }

        private class FlyingDuck : Utka
        {
            public virtual void Letat()
            {
                Console.WriteLine("Я летаю");
            }
        }


        private class NyryayuschayaUtka : FlyingDuck
        {
            public override void Kryakat()
            {
                Console.WriteLine("КРЯЯЯЯЯ!!!!");
            }

            public override void Letat()
            {
                Console.WriteLine("Как-то летаю, всё ок");
            }

            public void Nyrnut()
            {
                Console.WriteLine("Ныряю под воду");
            }
        }

       
        private class KiborgUtka : Utka
        {
            public override void Kryakat()
            {
                Console.WriteLine("BEEP");
            }

            public void DoLaser()
            {
                Console.WriteLine("Вы умерли...");
            }
        }
    }
}