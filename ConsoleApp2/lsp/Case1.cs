using System;

namespace ConsoleApp2.lsp
{
    internal class Case1
    {
        private abstract class Vehicle
        {
            public string LicensePlate { get; set; }

            public abstract void StartEngine();
            public abstract void StopEngine();
            public abstract void Drive(double distance);
        }

        private class ElectricVehicle : Vehicle
        {
            public double BatteryLevel { get; set; }
            public double BatteryCapacity { get; set; }

            public override void StartEngine()
            {
                Console.WriteLine("Electric vehicle " + LicensePlate + " started silently");
            }

            public override void StopEngine()
            {
                Console.WriteLine($"Electric vehicle {LicensePlate} stopped");
            }

            public override void Drive(double distance)
            {
                BatteryLevel -= distance * 0.2;
                Console.WriteLine("Electric vehicle " + LicensePlate + " drove " + distance + " km");
            }
        }
    }
}