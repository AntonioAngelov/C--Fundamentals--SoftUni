namespace RecyclingStation.Models.Strategies
{
    using WasteDisposal.Interfaces;

    public class StorableStrategy
        : IGarbageDisposalStrategy
    {
        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            var garbageVolume = garbage.Weight * garbage.VolumePerKg;

            var energyBalance = garbageVolume * 0.13;
            var capitalBalance = 0.65 * garbageVolume;

            return new ProcessingData(0 - energyBalance, 0 - capitalBalance);
        }
    }
}
