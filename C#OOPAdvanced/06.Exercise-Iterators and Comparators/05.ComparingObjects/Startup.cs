using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main(string[] args)
    {
        List<Person> people = new List<Person>();

        var input = Console.ReadLine();

        while (input != "END")
        {
            var splitted = input
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            people.Add(new Person(splitted[0], int.Parse(splitted[1]), splitted[2]));

            input = Console.ReadLine();
        }

        var n = int.Parse(Console.ReadLine()) - 1;
        Person person = people[n];

        var eaqualPeaople = people.Where(p => p.CompareTo(person) == 0);

        if (eaqualPeaople.Count() == 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{eaqualPeaople.Count()} {people.Count - eaqualPeaople.Count()} {people.Count}");
        }


    }
}

