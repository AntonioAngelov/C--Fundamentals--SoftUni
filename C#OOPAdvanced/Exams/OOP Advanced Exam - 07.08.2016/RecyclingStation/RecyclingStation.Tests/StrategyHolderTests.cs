namespace RecyclingStation.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Attributes;
    using Models.Strategies;
    using Moq;
    using NUnit.Framework;
    using WasteDisposal;
    using WasteDisposal.Interfaces;

    [TestFixture]
    public class StrategyHolderTests
    {
        private IStrategyHolder strategyHolder;
        private Dictionary<Type, IGarbageDisposalStrategy> data;

        private Mock<IGarbageDisposalStrategy> mockedStrategy;

        [SetUp]
        public void Initialize()
        {
            this.strategyHolder = new StrategyHolder();

            this.mockedStrategy = new Mock<IGarbageDisposalStrategy>();
            this.data= new Dictionary<Type, IGarbageDisposalStrategy>();
        }

        [Test]
        public void GetDisposalStrategies_WithNewInstance_ShoulderReturnEmptyDictionary()
        {
            var strategies = this.strategyHolder.GetDisposalStrategies;

            Assert.AreEqual(0, strategies.Count, "Operation returned incorrect result!");
        }

        [Test]
        public void GetDisposalStrategies_ShouldReturnAReadonlyDictionary()
        {
            var strategies = this.strategyHolder.GetDisposalStrategies;

            Assert.IsInstanceOf(typeof(IReadOnlyDictionary<Type, IGarbageDisposalStrategy>), strategies);
        }

        [Test]
        public void AddStrategy_WithAtributeThatDoesNotInheritDisposableAttribute_ShouldThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => this.strategyHolder.AddStrategy(typeof(string), new BurnableStrategy()));

            Assert.AreEqual("The passed in type is not a subclass of Disposable Attribute!", ex.Message);
        }

        [Test]
        public void AddStrategy_WithAttributeThatIsNotContained_ShouldReturnTrue()
        {
            var sut = this.strategyHolder.AddStrategy(typeof(BurnableAttribute), new BurnableStrategy());

            Assert.IsTrue(sut);
        }

        [Test]
        public void AddStrategy_WithAttributeThatIsNotContained_ShouldAddNewStrategyToTheStrategies()
        {
            this.strategyHolder.AddStrategy(typeof(BurnableAttribute), new BurnableStrategy());
            var strategies = this.strategyHolder.GetDisposalStrategies;

            Assert.IsTrue(strategies.Keys.Any(s => s == typeof(BurnableAttribute)));
        }

        [Test]
        public void AddStrategy_WithAttributeThatIsContained_ShouldReturnFalse()
        {
            this.strategyHolder.AddStrategy(typeof(BurnableAttribute), new BurnableStrategy());
            var sut = this.strategyHolder.AddStrategy(typeof(BurnableAttribute), new BurnableStrategy());

            Assert.IsFalse(sut);
        }

        [Test]
        public void AddStrategy_WithAttributeThatIsContained_ShouldNotAddNewStrategyToTheStrategies()
        {
            this.strategyHolder.AddStrategy(typeof(BurnableAttribute), new BurnableStrategy());
            var strategies = this.strategyHolder.GetDisposalStrategies;

            Assert.AreEqual(1, strategies.Count);
        }

        [Test]
        public void RemoveStrategy_WithAtributeThatDoesNotInheritDisposableAttribute_ShouldThrowArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => this.strategyHolder.RemoveStrategy(typeof(string)));

            Assert.AreEqual("The passed in type is not a subclass of Disposable Attribute!", ex.Message);
        }

        [Test]
        public void RemoveStrategy_WithAttributTypeThatIsNotContained_ShouldRetunrFalse()
        {
            var sut = this.strategyHolder.RemoveStrategy(typeof(BurnableAttribute));

            Assert.IsFalse(sut);
        }

        [Test]
        public void RemoveStrategy_WithAttributTypeThatISContained_ShouldRetunrTrue()
        {
            this.strategyHolder.AddStrategy(typeof(BurnableAttribute), new BurnableStrategy());
            var sut = this.strategyHolder.RemoveStrategy(typeof(BurnableAttribute));

            Assert.IsTrue(sut);
        }

        [Test]
        public void RemoveStrategy_WithAttributTypeThatISContained_ShouldRemoveTheStrategy()
        {
            this.strategyHolder.AddStrategy(typeof(BurnableAttribute), new BurnableStrategy());
            this.strategyHolder.RemoveStrategy(typeof(BurnableAttribute));
            var sut = this.strategyHolder.GetDisposalStrategies;

            Assert.AreEqual(0, sut.Count);
        }

    }
}
