namespace RecyclingStation.Models.Waste
{
    using Attributes;

    [Storable]
    public class StorableGarbage 
        : Garbage
    {
        public StorableGarbage(string name, double weight, double volumePerKg) 
            : base(name, weight, volumePerKg)
        {
        }
    }
}
