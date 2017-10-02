using System;
using System.Collections.Generic;

namespace _01.ReverseNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var stack = new Stack<string>(input);

            while (stack.Count != 0)
            {
                Console.Write(stack.Pop());
                if(stack.Count!=0) Console.Write(" ");
            }

            Console.WriteLine();
        }
    }
}
