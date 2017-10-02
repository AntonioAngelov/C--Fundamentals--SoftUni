using System;public class Person 
{
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get; set; }

    public int Age { get; set; }

    public override bool Equals(object obj)
    {
        var other = obj as Person;

        if (other == null)
        {
            return false;
        }

        if (this.Name == other.Name && this.Age == other.Age)
        {
            return true;
        }

        return false;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;

            hash += hash * 23 + this.Name.GetHashCode();
            hash += hash * 23 + this.Age.GetHashCode();
            return hash;
        }
    }

    
}

