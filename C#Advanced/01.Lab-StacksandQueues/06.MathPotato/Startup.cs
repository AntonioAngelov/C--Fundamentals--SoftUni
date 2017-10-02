using System;
using System.Collections.Generic;

namespace _06.MathPotato
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var children = Console.ReadLine().Split(' ');
            var num = int.Parse(Console.ReadLine());
            var queue = new Queue<string>(children);

            int cycle = 1;
            while (queue.Count != 1)
            {
                for (int i = 1; i < num; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                if (IsPrime(cycle))
                {
                    Console.WriteLine($"Prime {queue.Peek()}");
                }
                else
                {
                    Console.WriteLine($"Removed {queue.Dequeue()}");
                }
                cycle++;
            }

            Console.WriteLine("Last is " + queue.Dequeue());

        }

        public static bool IsPrime(int num)
        {
            if (num == 1) return false;

            for (int i = 2; i < num; i++)
            {
                if (num % i == 0) return false;
            }

            return true;
        }
    }
}
