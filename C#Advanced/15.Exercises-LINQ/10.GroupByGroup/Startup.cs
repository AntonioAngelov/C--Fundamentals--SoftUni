namespace _10.GroupByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            var currentStudent = Console.ReadLine();

            while (currentStudent != "END")
            {
                var splitted = currentStudent.Split(' ').ToArray();
                var name = string.Join(" ", splitted.Take(2));
                var group = int.Parse(splitted.Last());
                
                Person currentPerson = new Person(name, group);
                people.Add(currentPerson);
               
                currentStudent = Console.ReadLine();
            }

            var grouped = people
                .GroupBy(p => p.Group)
                .ToDictionary(p => p.Key, p => string.Join(", ", p.Select(c => c.Name)));

            foreach (var group in grouped.Keys.OrderBy(g => g))
            {


                Console.WriteLine($"{group} - {grouped[group]}");
            }
        }
    }
}
