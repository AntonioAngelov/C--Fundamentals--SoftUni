using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Iterator.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CreateIteratorTests
    {
        [Test]
        public void CreateIteratorWithValidParamethers()
        {
            var data = new List<string>();

            ListIterator sud = new ListIterator(data);

            Assert.AreEqual(data, sud.Data.ToList(), "Iterator wasn't created!");
        }

        [Test]
        public void ThrowExceptionForCreatingIteratorWithNull()
        {
            Assert.Throws<ArgumentNullException>(() => new ListIterator(null));
        }

    }
}
