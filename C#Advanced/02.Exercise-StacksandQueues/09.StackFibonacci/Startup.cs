using System;
using System.Collections.Generic;

namespace _09.StackFibonacci
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<long>();
            stack.Push(1);
            stack.Push(0);
            while (n > 0)
            {
                var prev = stack.Pop();
                var nextEl = prev + stack.Peek();
                stack.Push(prev);
                stack.Push(nextEl);
                --n;
            }

            Console.WriteLine(stack.Pop());

        }
    }
}
