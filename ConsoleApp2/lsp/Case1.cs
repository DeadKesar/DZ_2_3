using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.lsp
{
    internal class Case1
    {
    /*
    1. электрокар больше не наследует метод refuel. для машин на бензине выделил отдельный интерфейс IRefuelable.
    2. из базового класса vehicle удалил свойства бензобака (FuelLevel, FuelCapacity), они были перенесены в класс BenzCar.
    3. класс vehicle и метод drive сделал абстрактными чтобы у каждого типа транспорта была своя логика.
    */
        private abstract class Vehicle
        {
            public string LicensePlate { get; set; }

            public virtual void StartEngine()
            {
                Console.WriteLine("Engine started for vehicle " + LicensePlate);
            }

            public virtual void StopEngine()
            {
                Console.WriteLine("Engine stopped for vehicle " + LicensePlate);
            }

            public abstract void Drive(double distance);
        }

        private interface IRefuelable
        {
            void Refuel(double amount);
            double GetFuelLevel();
        }

        private class BenzCar : Vehicle, IRefuelable
        {   
            public double FuelLevel { get; set; }
            public double FuelCapacity { get; set; }
            public void Refuel(double amount)
            {
                FuelLevel += amount;
                Console.WriteLine("Refueled " + amount + " liters for vehicle " + LicensePlate);
            }

            public virtual double GetFuelLevel()
            {
                return FuelLevel;
            }

            public override void Drive(double distance)
            {
                FuelLevel -= distance * 0.1;
                Console.WriteLine("Vehicle " + LicensePlate + " drove " + distance + " km");
            }
        }

        private class ElectricVehicle : Vehicle
        {
            public double BatteryLevel { get; set; }
            public double BatteryCapacity { get; set; }

            public override void StartEngine()
            {
                Console.WriteLine("Electric vehicle " + LicensePlate + " started silently");
            }
            public override void Drive(double distance)
            {
                BatteryLevel -= distance * 0.2;
                Console.WriteLine("Electric vehicle " + LicensePlate + " drove " + distance + " km");
            }

            public void Charge(double amount)
            {
                BatteryLevel += amount;
                Console.WriteLine("Charged " + amount + " kWh for electric vehicle " + LicensePlate);
            }

            public void GetBatteryInfo()
            {
                Console.WriteLine("Battery level: " + BatteryLevel + "/" + BatteryCapacity);
            }
        }
    }
}
