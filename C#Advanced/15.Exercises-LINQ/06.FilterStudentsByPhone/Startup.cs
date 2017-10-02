namespace _06.FilterStudentsByPhone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            List<string> students = new List<string>();

            var currentStudent = Console.ReadLine();

            while (currentStudent != "END")
            {
                var splitted = currentStudent.Split(' ').ToArray();

                if (splitted[2].StartsWith("02") || splitted[2].StartsWith("+3592"))
                {
                    students.Add(string.Join(" ", splitted
                        .Take(2)
                        .ToArray()));
                }

                currentStudent = Console.ReadLine();
            }

            Console.WriteLine(string.Join("\n", students));
        }
    }
}
