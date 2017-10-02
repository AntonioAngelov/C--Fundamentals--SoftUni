namespace RecyclingStation.WasteDisposal
{
    using System;
    using System.Collections.Generic;
    using Attributes;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class StrategyHolder : IStrategyHolder
    {
        private readonly IDictionary<Type, IGarbageDisposalStrategy> strategies;

        public StrategyHolder()
        {
            this.strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
        }

        public IReadOnlyDictionary<Type,IGarbageDisposalStrategy> GetDisposalStrategies => 
            (IReadOnlyDictionary<Type, IGarbageDisposalStrategy>)this.strategies;

        public bool AddStrategy(Type disposableAttribute, IGarbageDisposalStrategy strategy)
        {
            if (!disposableAttribute.IsSubclassOf(typeof(DisposableAttribute)) || disposableAttribute.IsAbstract)
            {
                throw new ArgumentException("The passed in type is not a subclass of Disposable Attribute!");
            }

            if (!this.strategies.ContainsKey(disposableAttribute))
            {
                this.strategies.Add(disposableAttribute, strategy);
                return true;
            }

            return false;
        }

        public bool RemoveStrategy(Type disposableAttribute)
        {
            if (!disposableAttribute.IsSubclassOf(typeof(DisposableAttribute)) || disposableAttribute.IsAbstract)
            {
                throw new ArgumentException("The passed in type is not a subclass of Disposable Attribute!");
            }

            if (this.strategies.ContainsKey(disposableAttribute))
            {
                this.strategies.Remove(disposableAttribute);
                return true;
            }

            return false;
        }
    }
}
