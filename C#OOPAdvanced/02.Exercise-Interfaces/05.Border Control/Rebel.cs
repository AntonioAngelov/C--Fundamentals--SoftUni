public class Rebel : IBuyer
{
    private string name;
    private int age;
    private string group;
    private int food;

    public Rebel(string name, int age, string group)
    {
        this.Name = name;
        this.Age = age;
        this.Group = group;
        this.food = 0;
    }

    public string Group
    {
        get { return group; }
        set { group = value; }
    }


    public int Age
    {
        get { return age; }
        set { age = value; }
    }


    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public void BuyFood()
    {
        this.food += 5;
    }

    public int Food
    {
        get { return this.food; }
    }
}
