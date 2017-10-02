using System;

public class Cat : Animal
{
    public Cat(string name, int age, Genders gender) 
        :base (name, age, gender)
    { }

    public override string ProduceSound()
    {
        return "MiauMiau";
    }
}
