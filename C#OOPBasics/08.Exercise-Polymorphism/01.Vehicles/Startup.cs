using System;
using System.Linq;

public class Startup
{
    static void Main(string[] args)
    {
        var carInfo = Console.ReadLine()
            .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        var truckInfo = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        var busInfo = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
        Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(carInfo[3]));
        Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

        var numberOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCommands; i++)
        {
            var command = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

            if (command[0] == "Refuel")
            {
                if (command[1] == "Car")
                {
                    car.Refuel(double.Parse(command[2]));
                }
                else if (command[1] == "Truck")
                {
                    truck.Refuel(double.Parse(command[2]));
                }
                else
                {
                    bus.Refuel(double.Parse(command[2]));
                }
            }
            else if (command[0] == "Drive")
            {
                if (command[1] == "Car")
                {
                    car.Drive(double.Parse(command[2]));
                }
                else if(command[1] == "Truck")
                {
                    truck.Drive(double.Parse(command[2]));
                }
                else
                {
                    bus.Drive(double.Parse(command[2]));
                }
            }
            else
            {
                bus.DriveEmpty(double.Parse(command[2]));
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);

    }
}

