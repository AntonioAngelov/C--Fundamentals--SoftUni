using System;
using System.Collections.Generic;

namespace _03.Iterator.Tests
{
    using System.Reflection;
    using NUnit.Framework;

    [TestFixture]
    public class MoveMethodTests
    {
        private ListIterator list;
        private List<string> data;

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
        public void MovingInternalIndexWhenThereNextIndex()
        {
            //Arrange
            Type listType = typeof(ListIterator);
            FieldInfo internalIndexInfo = listType.GetField("currentIndex", BindingFlags.NonPublic | BindingFlags.Instance);
            

            //Act
            var sud = this.list.Move();
            int value = (int)internalIndexInfo.GetValue(this.list);

            //Assert
            Assert.AreEqual(1, value, "Move method doesn't move the internal index!");
            Assert.IsTrue(sud);
        }

        [Test]
        public void ReturnsFalseIfThereIsNoNextIndex()
        {
            //Arrange
            this.list.Move();
            this.list.Move();

            //Act
            var sud = this.list.Move();

            //Assert
            Assert.IsFalse(sud);
        }
    }
}
