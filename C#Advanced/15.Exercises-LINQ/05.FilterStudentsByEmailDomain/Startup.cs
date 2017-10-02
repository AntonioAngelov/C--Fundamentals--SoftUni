namespace _05.FilterStudentsByEmailDomain
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
                if (currentStudent.EndsWith("@gmail.com"))
                {
                    students.Add(string.Join(" ", currentStudent
                        .Split(' ')
                        .Take(2)
                        .ToArray()));
                }

                currentStudent = Console.ReadLine();
            }

            Console.WriteLine(string.Join("\n", students));
        }
    }
}
