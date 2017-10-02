using System;
using System.Collections.Generic;

namespace _01.ReverseStrings
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();
            var stack = new Stack<char>(input);

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
