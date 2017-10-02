using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            var carInfo = Console.ReadLine()
                .Split(' ')
                .ToArray();

            var model = carInfo[0];
            var engineSpeed = int.Parse(carInfo[1]);
            var enginePower = int.Parse(carInfo[2]);
            var cargoWeight = int.Parse(carInfo[3]);
            var cargoType = carInfo[4];

            var tire1Pressure = double.Parse(carInfo[5]);
            var tire1Age = int.Parse(carInfo[6]);

            var tire2Pressure = double.Parse(carInfo[7]);
            var tire2Age = int.Parse(carInfo[8]);

            var tire3Pressure = double.Parse(carInfo[9]);
            var tire3Age = int.Parse(carInfo[10]);

            var tire4Pressure = double.Parse(carInfo[11]);
            var tire4Age = int.Parse(carInfo[12]);

            var currentCar = new Car(model, new Engine(engineSpeed, enginePower),
                new Cargo(cargoWeight, cargoType),  new Tire(tire1Age, tire1Pressure), 
                new Tire(tire2Age, tire2Pressure), new Tire(tire3Age, tire3Pressure),  new Tire(tire4Age, tire4Pressure));

            cars.Add(currentCar);
        }

        var command = Console.ReadLine();

        if (command == "fragile")
        {
            foreach (var car in cars.Where(c => c.Cargo.Type == "fragile" && (c.Tire1.Pressure < 1 || c.Tire2.Pressure < 1 || c.Tire3.Pressure < 1 || c.Tire4.Pressure < 1)))
            {
                Console.WriteLine(car.Model);
            }
        }
        else
        {
            foreach (var car in cars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250))
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}

