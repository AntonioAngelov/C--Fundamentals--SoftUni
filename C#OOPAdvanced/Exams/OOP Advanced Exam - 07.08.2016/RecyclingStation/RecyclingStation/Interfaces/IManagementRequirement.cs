namespace RecyclingStation.Interfaces
{
    using System;
    using WasteDisposal.Interfaces;

    public interface IManagementRequirement
    {
        Type BannedWasteType { get; }

        double MinCapital { get;  }

        double MinEnergy { get; }

        bool CheckWasteForProcessing(double currentEnergy, double currentCapital, IWaste garbage);

    }
}
