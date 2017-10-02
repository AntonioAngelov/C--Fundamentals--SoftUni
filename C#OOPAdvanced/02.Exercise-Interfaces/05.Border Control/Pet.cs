public class Pet : IBirthdate
{
    private string birthdate;
    private string name;

    public Pet(string name, string birthdate)
    {
        this.Birthdate = birthdate;
        this.Name = name;
    }
    
    public string Birthdate
    {
        get { return this.birthdate; }
        private set { this.birthdate = value; }
        
    }

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }
}


