namespace _08.WeakStudents
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

                if (grades.Where(g => g == "2" || g == "3").Count() >= 2)
                {
                    excellentStudents.Add(string.Join(" ", names));
                }

                currentStudent = Console.ReadLine();
            }

            Console.WriteLine(string.Join("\n", excellentStudents));
        }
    }
}
