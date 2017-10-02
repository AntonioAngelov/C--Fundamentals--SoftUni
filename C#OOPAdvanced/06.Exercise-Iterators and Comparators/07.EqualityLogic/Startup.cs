using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        SortedSet<Person> peopleSortedSet = new SortedSet<Person>(new PersonComparator());
        HashSet<Person> peopleSet = new HashSet<Person>();

        for (int i = 0; i < n; i++)
        {
            var person = Console.ReadLine()
                .Split(' ')
                .ToList();

            peopleSet.Add(new Person(person[0], int.Parse(person[1])));
            peopleSortedSet.Add(new Person(person[0], int.Parse(person[1])));

        }

        Console.WriteLine(peopleSet.Count);
        Console.WriteLine(peopleSet.Count);
    }
}
