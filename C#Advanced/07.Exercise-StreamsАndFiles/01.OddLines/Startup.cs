using System;
using System.IO;

namespace _01.OddLines
{
    public class Startup
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../somefile.txt"))
            {
                int counter = 0;

                var line = reader.ReadLine();

                while (line != null)
                {

                    if (counter % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    ++counter;
                    line = reader.ReadLine();
                }
            }


        }
    }
}
