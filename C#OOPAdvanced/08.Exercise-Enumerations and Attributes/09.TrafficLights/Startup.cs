using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main(string[] args)
    {
        var lights = Console.ReadLine()
            .Split(' ')
            .ToList();

        var n = int.Parse(Console.ReadLine());

        List<TrafficLight> trafficLights = new List<TrafficLight>();

        lights.ForEach(tl => trafficLights.Add(new TrafficLight(tl)));

        for (int i = 0; i < n; i++)
        {
            foreach (var tl in trafficLights)
            {
                tl.ChangeSignal();
            }

            Console.WriteLine(string.Join(" ", trafficLights));
        }
    }
}

