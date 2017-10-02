using System;
using System.Text;

public class Animal
{
    private string name;
    private int age;
    private Genders gender;

    public Animal(string name, int age, Genders gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public Genders Gender
    {
        get { return this.gender; }
        set { this.gender = value; }
    }


    public int Age
    {
        get { return this.age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Invalid input!");
            }
            this.age = value;
        }
    }



    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public virtual string ProduceSound()
    {
        return "";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.GetType().Name}");
        sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
        sb.Append(ProduceSound());

        return sb.ToString();
    }
}

