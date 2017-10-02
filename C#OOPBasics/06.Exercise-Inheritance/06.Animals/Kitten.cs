using System;

public class Kitten : Animal
{
    public Kitten(string name, int age) 
        :base (name, age, Genders.Female)
    { }

    public override string ProduceSound()
    {
        return "Miau";
    }
}

