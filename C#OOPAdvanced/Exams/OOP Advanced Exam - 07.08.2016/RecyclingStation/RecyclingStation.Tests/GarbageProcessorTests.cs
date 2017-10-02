namespace RecyclingStation.Tests
{
    using System;
    using Attributes;
    using MockedObjects;
    using Models;
    using Models.Strategies;
    using Models.Waste;
    using NUnit.Framework;
    using WasteDisposal;
    using WasteDisposal.Interfaces;

    [TestFixture]
    public class GarbageProcessorTests
    {
        private IStrategyHolder strategyHolder;
        private IGarbageProcessor garbageProcessor;

        [SetUp]
        public void Initialize()
        {
            this.strategyHolder = new StrategyHolder();
            this.strategyHolder.AddStrategy(typeof(BurnableAttribute), new BurnableStrategy());
            this.strategyHolder.AddStrategy(typeof(RecyclableAttribute), new RecyclableStrategy());

            this.garbageProcessor = new GarbageProcessor(this.strategyHolder);
        }

        [Test]
        public void StrategyHolder_WithNewInstance_ShouldReturnTheGivenStrategyHolder()
        {
            Assert.AreEqual(this.strategyHolder, this.garbageProcessor.StrategyHolder);
        }

        [Test]
        public void
            ProcessWaste_WithStrategyHolderThatDoesNotContainNeededStrategyStrategies_ShouldThrowArgumentException()
        {
            var ex =
                Assert.Throws<ArgumentException>(
                    () => this.garbageProcessor.ProcessWaste(new StorableGarbage("a", 1, 1)));

            Assert.AreEqual("The passed in garbage does not implement a supported Disposable Strategy Attribute.", ex.Message);
        }

        [Test]
        public void ProcessWaste_WithWasteThatDoesNotHaveAttributes_ShouldThrowArgumentException()
        {
            var ex =
                Assert.Throws<ArgumentException>(
                    () => this.garbageProcessor.ProcessWaste(new MockedWasteWithoutAtributes()));

            Assert.AreEqual("The passed in garbage does not implement a supported Disposable Strategy Attribute.", ex.Message);
        }

        [Test]
        public void ProcessWaste_WithValidWasteAndContainedStrategy_ShouldReturnCorrectProcessingData()
        {
            var sut = this.garbageProcessor.ProcessWaste(new BurnableGarbage("a", 1, 1));
            var expected = new ProcessingData(0.8, 0);

            Assert.AreEqual(expected.EnergyBalance, sut.EnergyBalance);
            Assert.AreEqual(expected.CapitalBalance, sut.CapitalBalance);
        }
    }
}
