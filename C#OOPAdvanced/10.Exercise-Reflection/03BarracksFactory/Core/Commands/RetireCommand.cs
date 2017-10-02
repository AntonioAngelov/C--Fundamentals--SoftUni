namespace _03BarracksFactory.Core.Commands
{
    using System.Collections.Generic;
    using System.Reflection;
    using Attributes;
    using Contracts;

    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];

            SortedDictionary<string, int> unitsAmount = this.GetUnits();
            bool containsUnit = unitsAmount.ContainsKey(unitType);

            if (containsUnit)
            {
                this.repository.RemoveUnit(unitType);

                return $"{unitType} retired!";
            }

            return "No such units in repository.";
        }

        private SortedDictionary<string, int> GetUnits()
        {
            FieldInfo unitsContainerInfo = this.repository.GetType()
                .GetField("amountOfUnits", BindingFlags.NonPublic | BindingFlags.Instance);

            var unitsAmount = (SortedDictionary<string, int>) unitsContainerInfo.GetValue(this.repository);

            return unitsAmount;
        }
    }
}
