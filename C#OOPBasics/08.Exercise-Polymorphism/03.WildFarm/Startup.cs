using System;
using System.Linq;

public class Startup
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();

        while (input != "End")
        {
            var animalInfo = input
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var foodInfo = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Food food;
            if (foodInfo[0] == "Meat")
            {
                food = new Meat(int.Parse(foodInfo[1]));
            }
            else
            {
                food = new Vegetable(int.Parse(foodInfo[1]));
            }

            Animal animal;

            if (animalInfo[0] == "Mouse")
            {
                animal = new Mouse(animalInfo[1], animalInfo[0], double.Parse(animalInfo[2]), animalInfo[3]);
            }
            else if (animalInfo[0] == "Zebra")
            {
                animal = new Zebra(animalInfo[1], animalInfo[0], double.Parse(animalInfo[2]), animalInfo[3]);
            }
            else if (animalInfo[0] == "Cat")
            {
                animal = new Cat(animalInfo[1], animalInfo[0], double.Parse(animalInfo[2]), animalInfo[3], animalInfo[4]);
            }
            else
            {
                animal = new Tiger(animalInfo[1], animalInfo[0], double.Parse(animalInfo[2]), animalInfo[3]);
            }
               
            animal.MakeSound();
            animal.Eat(food);
            Console.WriteLine(animal);

            input = Console.ReadLine();
        }
    }
}

