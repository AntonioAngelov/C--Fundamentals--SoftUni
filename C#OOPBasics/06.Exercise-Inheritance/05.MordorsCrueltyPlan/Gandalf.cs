public class Gandalf
{
    private int happyness;

    public Gandalf()
    {
        this.happyness = 0;
    }

    public void Eat(string food)
    {
        this.happyness += HappynessFactory.GetHappyness(food);
    }

    private string Mood()
    {
        return MoodFactory.GetMood(this.happyness);
    }

    public override string ToString()
    {
        return $"{this.happyness}\n{this.Mood()}";
    }
}

