using System;

public class Tiger : Feline
{
    public Tiger(string animalName, string animalType,
        double animalWeight, string livingRegion)
        : base(animalName, animalType, animalWeight, livingRegion)
    {}

    public override void Eat(Food food)
    {
        if (food is Meat)
        {
            base.Eat(food);
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name}s are not eating that type of food!");
        }
    }

    public override void MakeSound()
    {
        Console.WriteLine("ROAAR!!!");
    }
}

