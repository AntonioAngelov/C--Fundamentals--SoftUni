namespace _01.StudentsByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            List<string[]> students = new List<string[]>();

            var currentStudent = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (currentStudent[0] != "END")
            {
                if (currentStudent[2] == "2")
                {
                    students.Add(currentStudent.Take(2).ToArray());
                }

                currentStudent = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            students = students.OrderBy(s => s[0]).ToList();

            foreach (var student in students)
            {
                Console.WriteLine(string.Join(" ", student));
            }
            
        }
    }
}
