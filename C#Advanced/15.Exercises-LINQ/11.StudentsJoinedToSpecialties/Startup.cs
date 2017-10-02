namespace _11.StudentsJoinedToSpecialties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            List<StudentSpecialty> specialities = new List<StudentSpecialty>();

            var input = Console.ReadLine();

            while (input != "Students:")
            {
                var splitted = input.Split(' ').ToArray();
                var specialityName = string.Join(" ", splitted.Take(2));
                var facultyNum = splitted.Last();

                specialities.Add(new StudentSpecialty(specialityName, facultyNum));
                
                input = Console.ReadLine();
            }

            List<Student> students = new List<Student>();

            input = Console.ReadLine();

            while (input != "END")
            {
                var splitted = input.Split(' ').ToArray();
                var facultyNum = splitted[0];
                var studentName = string.Join(" ", splitted.Skip(1));

                students.Add(new Student(studentName, facultyNum));

                input = Console.ReadLine();
            }

            students = students.OrderBy(s => s.Name).ToList();

            foreach (var student in students)
            {
                foreach (var speciality in specialities.Where(s => s.FacultyNumbr == student.FacultyNumber))
                {
                    Console.WriteLine($"{student.Name} {student.FacultyNumber} {speciality.SpecialityName}");
                }  
            }


        }
    }
}
