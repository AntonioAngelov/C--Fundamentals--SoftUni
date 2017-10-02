public class Ferrari : ICar
{
    private string driver;

    public Ferrari(string driver)
    {
        this.Driver = driver;
    }

    public string Driver
    {
        get { return this.driver; }
        private set { this.driver = value; }
    }

    public string Model
    {
        get { return "488-Spider"; }
    }

    public string Brakes()
    {
        return "Brakes!";
    }

    public string Gas()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.Brakes()}/{this.Gas()}/{this.Driver}";
    }
}
