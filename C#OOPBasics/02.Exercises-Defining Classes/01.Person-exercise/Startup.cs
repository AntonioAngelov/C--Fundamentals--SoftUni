using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        //problem 3 Oldest Family Member
        //Problem3();

        //problem 4 Oinion Poll
        Problem4();
    }

    private static void Problem4()
    {
        int n = int.Parse(Console.ReadLine());
        List<Person> people = new List<Person>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .ToArray();

            Person currentPerson = new Person(input[0], int.Parse(input[1]));
            people.Add(currentPerson);
        }

        people
            .Where(p => p.age  > 30)
            .OrderBy(p => p.name)
            .ToList()
            .ForEach(p => Console.WriteLine($"{p.name} - {p.age}"));
    }

    private static void Problem3()
    {
        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
        }

        int n = int.Parse(Console.ReadLine());
        var family = new Family();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .ToArray();

            Person currentMember = new Person(input[0], int.Parse(input[1]));
            family.AddMember(currentMember);
        }

        Console.WriteLine(family.GetOldestMember().ToString());
    }
}
