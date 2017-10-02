using System;public class Box<T> 
    where T : IComparable<T>
{
    public Box(T value)
    {
        this.Value = value;
    }

    public T Value { get; private set; }

    public override string ToString()
    {
        return $"{typeof(T)}: {this.Value}";
    }
}
