using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        Dictionary<string, Car> cars = new Dictionary<string, Car>();

        for (int i = 0; i < n; i++)
        {
            var currentCar = Console.ReadLine()
                .Split(' ')
                .ToArray();

            var model = currentCar[0];
            var fuelAmount = double.Parse(currentCar[1]);
            var fuelConsumption = double.Parse(currentCar[2]);

            cars.Add(model, new Car(model, fuelAmount, fuelConsumption));
        }

        var input = Console.ReadLine();

        while (input != "End")
        {
            var command = input.Split(' ').ToArray();

            cars[command[1]].Drive(double.Parse(command[2]));

            input = Console.ReadLine();
        }

        foreach (var car in cars.Values)
        {
            Console.WriteLine(car.ToString());
        }
    }
}

