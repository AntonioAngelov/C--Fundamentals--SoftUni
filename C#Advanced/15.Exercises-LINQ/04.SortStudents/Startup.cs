namespace _04.SortStudents
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
                students.Add(currentStudent);

                currentStudent = Console.ReadLine();
            }

            Console.WriteLine(string.Join("\n", students
                .OrderBy(s => s.Split(' ').ToArray()[1])
                .ThenByDescending(s => s.Split(' ').ToArray()[0])));
        }
    }
}
