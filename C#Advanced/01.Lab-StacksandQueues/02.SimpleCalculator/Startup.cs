using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SimpleCalculator
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Reverse().ToArray();
            var stack = new Stack<string>(input);

            while (stack.Count > 1)
            {
                int first = int.Parse(stack.Pop());
                String operation = stack.Pop();
                int second = int.Parse(stack.Pop());

                switch (operation)
                {
                    case "+":
                        stack.Push((first + second).ToString());
                        break;
                    case "-":
                        stack.Push((first - second).ToString());
                        break;
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
