using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    static void Main(string[] args)
    {
        var peopleData = Console.ReadLine()
            .TrimEnd(';')
            .Split(';')
            .ToArray();

        var productsData = Console.ReadLine()
            .TrimEnd(';')
            .Split(';')
            .ToArray();

        Dictionary<string, Person> people = new Dictionary<string, Person>();
        Dictionary<string, Product> products = new Dictionary<string, Product>();

        foreach (var data in peopleData)
        {
            var splitted = data.Split('=').ToArray();

            try
            {
                people.Add(splitted[0], new Person(splitted[0], double.Parse(splitted[1])));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

        }

        foreach (var data in productsData)
        {
            var splitted = data.Split('=').ToArray();

            try
            {
                products.Add(splitted[0], new Product(splitted[0], double.Parse(splitted[1])));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        var input = Console.ReadLine();

        while (input != "END")
        {
            var command = input.Split(' ').ToArray();

            people[command[0]].AdProductToBag(products[command[1]]);

            input = Console.ReadLine();
        }

        foreach (var person in people.Values)
        {
            var toPrint = person.ToString();

            Console.WriteLine(toPrint);
        }

    }
}