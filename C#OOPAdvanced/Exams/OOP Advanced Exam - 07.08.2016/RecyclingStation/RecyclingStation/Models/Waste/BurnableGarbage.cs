namespace RecyclingStation.Models
{
    using Attributes;

    [Burnable]
    public class BurnableGarbage 
        : Garbage
    {
        public BurnableGarbage(string name, double weight, double volumePerKg) 
            : base(name, weight, volumePerKg)
        {
            
        }
    }
}
