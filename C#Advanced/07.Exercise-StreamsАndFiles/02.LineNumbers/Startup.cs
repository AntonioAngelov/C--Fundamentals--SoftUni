using System;
using System.IO;

namespace _02.LineNumbers
{
    public class Startup
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../source.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../result.txt"))
                {
                    int counter = 0;
                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        writer.WriteLine($"{counter} {line}");

                        ++counter;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
