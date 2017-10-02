using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumElement
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var maxStack = new Stack<int>();
            var maxElement = int.MinValue;

            for (int i = 0; i < N; i++)
            {
                var query = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                switch (query[0])
                {
                    case 1:
                        if (maxElement < query[1])
                        {
                            maxElement = query[1];
                            maxStack.Push(query[1]);
                        }
                       
                        stack.Push(query[1]);
                        break;
                    case 2:
                        if (maxStack.Peek() == stack.Peek() && maxStack.Count != 0)
                        {
                            maxStack.Pop();
                            if (maxStack.Count > 0)
                            {
                                maxElement = maxStack.Peek();
                            }
                            else
                            {
                                maxElement = int.MinValue;
                            }
                        }

                        stack.Pop();
                        break;
                    case 3:
                        Console.WriteLine(maxElement);
                        break;

                }
            }
        }

        
    }
}
