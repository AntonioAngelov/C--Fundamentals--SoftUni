using System.Collections.Generic;

namespace _03.Iterator.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class HasNextMethodTests
    {
        private List<string> data;
        private ListIterator list;

        [SetUp]
        public void MoveInit()
        {
            this.data = new List<string>()
            {
                "az", "ti", "toi"
            };

            this.list = new ListIterator(this.data);
        }

        [Test]
        public void ReturnsTrueIfThereIsNextIndex()
        {
            //Act
            bool sud = this.list.HasNext();

            //Assert
            Assert.IsTrue(sud);
        }

        [Test]
        public void ReturnsFalseIfThereIsNoNextIndex()
        {
            //Arrange
            this.list.Move();
            this.list.Move();

            //Act
            bool sud = this.list.HasNext();

            //Assert
            Assert.IsFalse(sud);
        }
    }
}
