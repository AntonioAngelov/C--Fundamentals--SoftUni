using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _15.MelrahShake
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            
            var pattern = Console.ReadLine();

            var firstIndex = text.IndexOf(pattern);
            var lastIndex = text.LastIndexOf(pattern);

            while (firstIndex > -1 
                && lastIndex > -1 
                && pattern.Length != 0 
                && firstIndex != lastIndex
                && firstIndex + pattern.Length <= lastIndex )
            {
                Console.WriteLine("Shaked it.");
                text = text.Remove(firstIndex, pattern.Length);
                text = text.Remove(lastIndex - pattern.Length, pattern.Length);

                pattern = pattern.Remove(pattern.Length / 2, 1);

                firstIndex = text.IndexOf(pattern);
                lastIndex = text.LastIndexOf(pattern);
            }

            Console.WriteLine("No shake.");
            Console.WriteLine(text);
           
        }
    }
}
