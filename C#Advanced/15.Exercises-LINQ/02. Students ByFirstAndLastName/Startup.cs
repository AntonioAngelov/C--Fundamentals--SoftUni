namespace _02.Students_ByFirstAndLastName
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
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (currentStudent[0] != "END")
            {
                if (string.Compare(currentStudent[0], currentStudent[1]) < 0)
                {
                    students.Add(currentStudent.Take(2).ToArray());
                }

                currentStudent = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            foreach (var student in students)
            {
                Console.WriteLine(string.Join(" ", student));
            }

        }
    }
}
