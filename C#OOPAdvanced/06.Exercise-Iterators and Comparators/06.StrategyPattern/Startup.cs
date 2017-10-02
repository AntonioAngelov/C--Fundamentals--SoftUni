using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    static void Main(string[] args)
    {
        NameComparator nameComparator = new NameComparator();
        SortedSet<Person> peopleByName = new SortedSet<Person>(nameComparator);

        AgeComparator ageComparator = new AgeComparator();
        SortedSet<Person> peopleByAge = new SortedSet<Person>(ageComparator);

        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var person = Console.ReadLine()
                .Split(' ')
                .ToList();

            peopleByName.Add(new Person(person[0], int.Parse(person[1])));
            peopleByAge.Add(new Person(person[0], int.Parse(person[1])));
        }

        Console.WriteLine(string.Join(Environment.NewLine, peopleByName));
        Console.WriteLine(string.Join(Environment.NewLine, peopleByAge));
    }
}

