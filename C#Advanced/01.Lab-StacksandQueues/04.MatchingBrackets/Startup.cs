using System;
using System.Collections.Generic;

namespace _04.MatchingBrackets
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var expression = Console.ReadLine();
            var stack = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    stack.Push(i);
                }
                else if(expression[i] == ')')
                {
                    int startIndex = stack.Pop();
                    string content = expression.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(content);
                }
            }
        }
    }
}
