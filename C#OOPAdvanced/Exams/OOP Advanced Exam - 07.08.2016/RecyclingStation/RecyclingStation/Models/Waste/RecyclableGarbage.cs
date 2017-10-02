namespace RecyclingStation.Models
{
    using Attributes;

    [Recyclable]
    public class RecyclableGarbage 
        : Garbage
    {
        public RecyclableGarbage(string name, double weight, double volumePerKg) 
            : base(name, weight, volumePerKg)
        {}
    }
}
