using System;
using System.Collections.Generic;

namespace _07.BalancedParentheses
{
    public class Program
    {
        static void Main(string[] args)
        {
            var sequence = Console.ReadLine();
            var stack = new Stack<char>();
            bool isCorrect = true;

            foreach (var bracket in sequence)
            {
                if (bracket == '{' || bracket == '[' || bracket == '(')
                {
                    stack.Push(bracket);
                }
                else if (bracket == '}' || bracket == ']' || bracket == ')')
                {
                    if (stack.Count == 0)
                    {
                        Console.WriteLine("NO");
                        isCorrect = false;
                        break;
                    }
                    else if (bracket == '}' && stack.Peek() != '{')
                    {
                        Console.WriteLine("NO");
                        isCorrect = false;
                        break;
                    }
                    else if (bracket == ']' && stack.Peek() != '[')
                    {
                        Console.WriteLine("NO");
                        isCorrect = false;
                        break;
                    }
                    else if(bracket == ')' && stack.Peek() != '(')
                    {
                        Console.WriteLine("NO");
                        isCorrect = false;
                        break;
                    }
                    else
                    {
                        stack.Pop();
                    }
                    
                }
            }

            if (stack.Count == 0 && isCorrect)
            {
                Console.WriteLine("YES");
            }
           
        }
    }
}
