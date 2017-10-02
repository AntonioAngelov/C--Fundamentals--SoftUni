public class Citizen : IIdentifiable, IBirthdate, IBuyer
{
    private string name;
    private int age;
    private string id;
    private string birthdate;
    private int food;

    public Citizen(string name, int age, string id,string birthdate)
    {
        this.name = name;
        this.age = age;
        this.Id = id;
        this.Birthdate = birthdate;
        this.food = 0;
    }

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }

    public int Age
    {
        get { return this.age; }
        private set { this.age = value; }
    }

    public string Id
    {
        get { return this.id; }
        private set { this.id = value; }
    }

    public string Birthdate
    {
        get { return this.birthdate; }
        private set { this.birthdate = value; }
    }

    public void BuyFood()
    {
        this.food += 10;
    }

    public int Food
    {
        get { return this.food; }
    }
}

