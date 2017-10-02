using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicStackOperations
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var N = input[0];
            var S = input[1];
            var X = input[2];

            var elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var stack = new Stack<int>();

            for (int i = 0; i < N; i++)
            {
                stack.Push(elements[i]);
            }

            while (S != 0 && stack.Count != 0)
            {
                stack.Pop();
                --S;
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (stack.Contains(X))
            {
                Console.WriteLine("true");
            }
            else
            {
                var min = int.MaxValue;

                while (stack.Count != 0)
                {
                    var current = stack.Pop();
                    if (current < min)
                    {
                        min = current;
                    }
                }

                Console.WriteLine(min);
            }

        }
    }
}
