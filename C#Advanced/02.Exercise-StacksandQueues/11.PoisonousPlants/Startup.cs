﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PoisonousPlants
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var plants = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[] days = new int[n];
            Stack<int> proximityStack = new Stack<int>();
            proximityStack.Push(0);

            for (int i = 1; i < plants.Length; i++)
            {
                int maxDays = 0;
                while (proximityStack.Count > 0 && plants[proximityStack.Peek()] >= plants[i])
                {
                    maxDays = Math.Max(maxDays, days[proximityStack.Pop()]);
                }

                if (proximityStack.Count > 0)
                {
                    days[i] = maxDays + 1;
                }
                proximityStack.Push(i);
            }
            Console.WriteLine(days.Max());
        }
    }
}
