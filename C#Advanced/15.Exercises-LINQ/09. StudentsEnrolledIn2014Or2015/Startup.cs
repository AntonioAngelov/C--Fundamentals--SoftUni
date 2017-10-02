namespace _09.StudentsEnrolledIn2014Or2015
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            List<string> grades = new List<string>();

            var currentStudent = Console.ReadLine();

            while (currentStudent != "END")
            {
                var splitted = currentStudent.Split(' ').ToArray();
                var facNum = splitted[0];
                var currentStudGrades = splitted.Skip(1);

                if (facNum.EndsWith("14") || facNum.EndsWith("15"))
                {
                    grades.Add(string.Join(" ", currentStudGrades));
                }

                currentStudent = Console.ReadLine();
            }

            Console.WriteLine(string.Join("\n", grades));
        }
    }
}
