using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SimpleTextEditor
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            string text = "";
            var lastStrings = new Stack<string>();
            lastStrings.Push(text);

            for (int i = 0; i < n; i++)
            {
                var operation = Console.ReadLine().Split(' ').ToArray();
                switch (operation[0])
                {
                    case "1":
                        text += operation[1];
                        lastStrings.Push(text);
                        break;
                    case "2":
                       text = text.Substring(0, text.Length - int.Parse(operation[1]));
                        lastStrings.Push(text);
                        break;
                    case "3":
                        Console.WriteLine(text[int.Parse(operation[1]) - 1]);
                        break;
                    case "4":
                        lastStrings.Pop();
                        text = lastStrings.Peek();
                        break;
                        
                }
            }

        }
    }
}
