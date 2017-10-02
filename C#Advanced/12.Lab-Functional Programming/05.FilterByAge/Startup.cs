namespace _05.FilterByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Dictionary<string, int> people = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var currentPerson = Console.ReadLine()
                    .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                people.Add(currentPerson[0], int.Parse(currentPerson[1]));
            }

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();


            if (condition == "younger")
            {
                PrintPeople(people.Where(p => p.Value < age).ToList(), format);
            }
            else
            {
                PrintPeople(people.Where(p => p.Value >= age).ToList(), format);
            }




        }

        private static void PrintPeople(List<KeyValuePair<string, int>> people, string format)
        {
            switch (format)
            {
                case "name":
                    people.ForEach(p => Console.WriteLine(p.Key));
                    break;
                case "age":
                    people.ForEach(p => Console.WriteLine(p.Value));
                    break;
                case "name age":
                     people.ForEach(p => Console.WriteLine($"{p.Key} - {p.Value}"));
                    break;
            }
        }
    }
}
