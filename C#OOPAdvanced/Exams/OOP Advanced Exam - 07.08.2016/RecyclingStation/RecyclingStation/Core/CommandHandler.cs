using System;
using System.Linq;

namespace RecyclingStation.Core
{
    using System.Reflection;
    using Interfaces;
    using Models;
    using WasteDisposal;
    using WasteDisposal.Attributes;
    using WasteDisposal.Interfaces;

    class CommandHandler
        : ICommandHandler
    {
        public CommandHandler(IGarbageProcessor garbageProcessor, IBalanceManager balanceManager)
        {
            this.GarbageProcessor = garbageProcessor;
            this.BalanceManager = balanceManager;
            this.InitializeStrategies();
        }

        public CommandHandler()
            : this(new GarbageProcessor(), new BalanceManager())
        {
        }

        public IGarbageProcessor GarbageProcessor { get; }

        public IBalanceManager BalanceManager { get; }

        public string ProcessGarbage(string[] parameters)
        {
            IWaste garbage = InstantiateWaste(parameters);

            if (this.BalanceManager.CheckWasteForProcessing(garbage))
            {
                IProcessingData processingData = this.GarbageProcessor.ProcessWaste(garbage);
                this.BalanceManager.ApplyProcessedResult(processingData);

                return $"{garbage.Weight:f2} kg of {garbage.Name} successfully processed!";
            }
            else
            {
                return "Processing Denied!";
            }
        }

        public string Status()
        {
            return $"Energy: {this.BalanceManager.EnergyBalance:f2} Capital: {this.BalanceManager.CapitalBalance:f2}";
        }

        public void InitializeStrategies()
        {
            var assemblyTypes = Assembly.GetExecutingAssembly().DefinedTypes.ToArray();

            var attributes = assemblyTypes.Where(x => typeof(DisposableAttribute).IsAssignableFrom(x) &&
            x != typeof(DisposableAttribute) &&
            !x.IsInterface);

            var strategies = assemblyTypes.Where(s => typeof(IGarbageDisposalStrategy).IsAssignableFrom(s) &&
                                                      s != typeof(IGarbageDisposalStrategy) &&
                                                      !s.IsInterface &&
                                                      !s.IsAbstract);

            foreach (var attribute in attributes)
            {
                string strategyName = attribute.Name.Replace("Attribute", "Strategy");
                var strategy = strategies.FirstOrDefault(s => s.Name == strategyName);

                if (strategy != null)
                {
                    var strategyInstance = (IGarbageDisposalStrategy)Activator.CreateInstance(strategy);

                    this.GarbageProcessor.StrategyHolder.AddStrategy(attribute, strategyInstance);
                }
            }

        }

        public IWaste InstantiateWaste(string[] parameters)
        {
            var type = parameters[3];
            var typeName = type + "Garbage";
            var garbageType = Assembly.GetExecutingAssembly().DefinedTypes.FirstOrDefault(t => t.Name == typeName);

            if (garbageType == null)
            {
                throw new ArgumentException("Unsuported garbage type was passed!");
            }

            ConstructorInfo garbageConstructor = garbageType.GetConstructors()[0];
            ParameterInfo[] constructorParams = garbageConstructor.GetParameters();

            object[] convertedParameters = new object[constructorParams.Length];

            for (int i = 0; i < convertedParameters.Length; i++)
            {
                Type paramType = constructorParams[i].ParameterType;

                if (typeof(IConvertible).IsAssignableFrom(paramType))
                {
                    convertedParameters[i] = Convert.ChangeType(parameters[i], paramType);
                }
            }

            IWaste waste = (IWaste) Activator.CreateInstance(garbageType, convertedParameters);

            return waste;
        }

        public string ChangeManagementRequirement(string[] parameters)
        {
            IManagementRequirement requirement = this.InstantiateNewManagementRequiremenet(parameters);
            this.BalanceManager.ManagemenentRequirement = requirement;
            return "Management requirement changed!";
        }

        private IManagementRequirement InstantiateNewManagementRequiremenet(string[] parameters)
        {
            var type = parameters[2];
            var garbageTypeName = type + "Garbage";
            Type garbageType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == garbageTypeName);
            var minEnergy = double.Parse(parameters[0]);
            var minCapital = double.Parse(parameters[1]);

            var requirement = new ManagementRequirement(garbageType, minCapital, minEnergy);

            return requirement;
        }
    }
}
