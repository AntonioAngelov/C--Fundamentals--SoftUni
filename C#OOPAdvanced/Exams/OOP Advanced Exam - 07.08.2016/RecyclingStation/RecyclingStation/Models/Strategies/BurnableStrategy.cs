namespace RecyclingStation.Models.Strategies
{
    using WasteDisposal.Interfaces;

    public class BurnableStrategy
        : IGarbageDisposalStrategy
    {
        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            var energyBalance = (garbage.Weight * garbage.VolumePerKg) * 0.8;

            return new ProcessingData(energyBalance, 0);
        }
    }
}
