public class Threeuple<T, U, K>
{
    private T item1;
    private U item2;
    private K item3;

    public Threeuple(T item1, U item2, K item3)
    {
        this.Item1 = item1;
        this.Item2 = item2;
        this.Item3 = item3;
    }

    public T Item1
    {
        get { return this.item1; }
        private set { this.item1 = value; }
    }

    public U Item2
    {
        get { return this.item2; }
        private set { this.item2 = value; }
    }

    public K Item3
    {
        get { return this.item3; }
        private set { this.item3 = value; }
    }

    public override string ToString()
    {
        return $"{item1} -> {item2} -> {item3}";
    }
}
