namespace _07.ExcellentStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            List<string> excellentStudents = new List<string>();

            var currentStudent = Console.ReadLine();

            while (currentStudent != "END")
            {
                var splitted = currentStudent.Split(' ').ToArray();
                var names = splitted.Take(2);
                var grades = splitted.Skip(2);

                if (grades.Contains("6"))
                {
                    excellentStudents.Add(string.Join(" ", names));
                }

                currentStudent = Console.ReadLine();
            }

            Console.WriteLine(string.Join("\n", excellentStudents));
        }
    }
}
