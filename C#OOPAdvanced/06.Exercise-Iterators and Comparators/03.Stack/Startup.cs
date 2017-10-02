using System;
using System.Linq;

public class Startup
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine();

        Stack<int> stack = new Stack<int>();

        while (input != "END")
        {
            if (input == "Pop")
            {
                try
                {
                    stack.Pop();
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                var elements = input
                    .Split(new string[] {",", " "}, StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1)
                    .Select(int.Parse)
                    .ToList();

                foreach (var e in elements)
                {
                    stack.Push(e);
                }
            }

            input = Console.ReadLine();
        }

        for (int i = 0; i < 2; i++)
        {
            foreach (var el in stack)
            {
                Console.WriteLine(el);
            }
        }

    }
}

