public class FireMonument : Monument
{
    private int fireAffinity;

    public FireMonument(string name, int fireAffinity) 
        : base(name)
    {
        this.FireAffinity = fireAffinity;
    }

    public int FireAffinity
    {
        get { return fireAffinity; }
        private set { fireAffinity = value; }
    }

    public override string ToString()
    {
        return $"Fire Monument: {this.Name}, Fire Affinity: {this.FireAffinity}";
    }
}

