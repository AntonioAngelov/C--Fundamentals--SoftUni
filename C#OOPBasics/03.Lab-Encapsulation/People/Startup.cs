using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        //Exercise 1 -> Sort Persons by Name and Age
        //SortPeopleByNameAndAge();
        //Exercise 2 -> Salary Increase
        //SalaryIncrease();
    }

    private static void SalaryIncrease()
    {
        var lines = int.Parse(Console.ReadLine());

        var persons = new List<Person>();

        for (int i = 0; i < lines; i++)
        {
            var cmdArgs = Console.ReadLine().Split();
            var person = new Person(cmdArgs[0], cmdArgs[1],
                int.Parse(cmdArgs[2]), 
                double.Parse(cmdArgs[3]));

            persons.Add(person);
        }

        var bonus = double.Parse(Console.ReadLine());

        persons.ForEach(p => Console.WriteLine(p.ToString()));
    }

    //private static void SortPeopleByNameAndAge()
    //{
    //    var lines = int.Parse(Console.ReadLine());

    //    var persons = new List<Person>();

    //    for (int i = 0; i < lines; i++)
    //    {
    //        var cmdArgs = Console.ReadLine().Split();

    //        var person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]));

    //        persons.Add(person);
    //    }

    //    persons.OrderBy(p => p.FirstName)
    //    .ThenBy(p => p.Age)
    //    .ToList()
    //    .ForEach(p => Console.WriteLine(p.ToString()));
    //}
}

