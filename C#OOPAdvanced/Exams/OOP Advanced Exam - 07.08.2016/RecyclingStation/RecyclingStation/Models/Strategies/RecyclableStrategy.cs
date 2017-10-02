namespace RecyclingStation.Models.Strategies
{
    using WasteDisposal.Interfaces;

    public class RecyclableStrategy
        : IGarbageDisposalStrategy
    {
        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            var energyBalance = ((garbage.Weight * garbage.VolumePerKg) / 2) * -1;
            var capitalBalance = 400 * garbage.Weight;

            return new ProcessingData(energyBalance, capitalBalance);
        }
    }
}
