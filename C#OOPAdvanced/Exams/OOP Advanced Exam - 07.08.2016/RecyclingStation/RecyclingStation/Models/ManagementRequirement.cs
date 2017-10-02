namespace RecyclingStation.Models
{
    using System;
    using System.Linq;
    using Interfaces;
    using WasteDisposal.Attributes;
    using WasteDisposal.Interfaces;

    public class ManagementRequirement
        : IManagementRequirement
    {
        private Type bannedWasteType;
        private double minCapital;
        private double minEnergy;

        public ManagementRequirement(Type bannedWasteType, double minCapital, double minEnergy)
        {
            this.BannedWasteType = bannedWasteType;
            this.MinCapital = minCapital;
            this.MinEnergy = minEnergy;
        }

        public Type BannedWasteType
        {
            get { return this.bannedWasteType; }
            private set
            {
                if (!typeof(IWaste).IsAssignableFrom(value) ||
                    value.IsAbstract ||
                    !value.GetCustomAttributes(false).Any(a => a.GetType().IsSubclassOf(typeof(DisposableAttribute))))
                {
                    throw new ArgumentException("The passed in waste eather does not inherit IWaste, or does not contain correct attribute!");
                }

                this.bannedWasteType = value;
            }
        }

        public double MinCapital
        {
            get { return this.minCapital; }
            private set { this.minCapital = value; }
        }

        public double MinEnergy
        {
            get { return this.minEnergy; }
            set { this.minEnergy = value; }
        }

        public bool CheckWasteForProcessing(double currentEnergy, double currentCapital, IWaste garbage)
        {
            if (currentCapital < this.minCapital || currentEnergy < this.minEnergy)
            {
                if (garbage.GetType() == BannedWasteType)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
