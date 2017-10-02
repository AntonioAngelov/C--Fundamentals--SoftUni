using System;

public class Tomcat : Animal
{
    public Tomcat(string name, int age) 
        :base (name, age, Genders.Male)
    { }

    public override string ProduceSound()
    {
        return "Give me one million b***h";
    }
}

