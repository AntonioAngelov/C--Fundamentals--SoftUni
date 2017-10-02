using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    static void Main(string[] args)
    {
        var animal = Console.ReadLine();
        List<Animal> animals = new List<Animal>();

        while (animal != "Beast!")
        {
            try
            {
                var animalInfo = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

                var name = animalInfo[0];
                var age = int.Parse(animalInfo[1]);

                Genders gender;
                Enum.TryParse(animalInfo[2], out gender);

                switch (animal)
                {
                    case "Cat":
                        animals.Add(new Cat(name, age, gender));
                        break;

                    case "Tomcat":
                        animals.Add(new Tomcat(name, age));
                        break;

                    case "Kitten":
                        animals.Add(new Kitten(name, age));
                        break;

                    case "Frog":
                        animals.Add(new Frog(name, age, gender));
                        break;

                    case "Dog":
                        animals.Add(new Dog(name, age, gender));
                        break;
                    default:
                        throw new ArgumentException("Invalid input!");
                        break;
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            animal = Console.ReadLine();
        }

        foreach (var a in animals)
        {
            Console.WriteLine(a);
        }

    }
}

