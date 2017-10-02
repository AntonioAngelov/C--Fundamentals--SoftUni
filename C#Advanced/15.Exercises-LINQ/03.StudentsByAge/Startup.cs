namespace _03.StudentsByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            List<string> students = new List<string>();

            var currentStudent = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (currentStudent[0] != "END")
            {
                if (int.Parse(currentStudent[2]) >= 18 && int.Parse(currentStudent[2]) <= 24)
                {
                    students.Add(string.Join(" ", currentStudent));
                }

                currentStudent = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            Console.WriteLine(string.Join("\n", students));
            
        }
    }
}
