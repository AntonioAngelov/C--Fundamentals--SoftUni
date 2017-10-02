namespace _01.Database.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class TestDatabase
    {
        [Test]
        public void InitializeDatabaseWithCorrectArray()
        {
            Database sud = new Database(new int[] {1, 2, 3});

            Assert.AreEqual(16, sud.Data.Length, "Data capacity is wrong!");
        }

        [Test]
        public void InitializeDatabaseWithWrongArray()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => new Database(new int[17]));

            Assert.That(ex.Message, Is.EqualTo("Array's capacity must be exactly 16!"));
        }

        [Test]
        public void AddingElementIntoNotFullDatabase()
        {
            //Arrange
            Database sud = new Database(new int[] {});
            int[] expected = new int[16];
            expected[0] = 98;

            //Act
            sud.Add(98);

            //Assert
            Assert.AreEqual(expected, sud.Fetch());
        }

        [Test]
        public void AddingElementIntoFullDatabase()
        {
            int[] data = new int[16];
            Database sud = new Database(data);

            var ex = Assert.Throws<InvalidOperationException>(() => sud.Add(1));

            Assert.That(ex.Message, Is.EqualTo("Array's capacity must be exactly 16!"));
        }

        [Test]
        public void RemovingElementFromNonEmptyDatabase()
        {
            //Arrange
            Database sud = new Database(new int[] { });
            sud.Add(1);
            var expected = new int[16];

            //Act
            sud.Remove();

            //Assert
            Assert.AreEqual(expected, sud.Fetch());
        }

        [Test]
        public void RemovingElementFromEmptyDatabase()
        {
            int[] data = new int[17];

            var ex = Assert.Throws<InvalidOperationException>(() => new Database(data));

            Assert.That(ex.Message, Is.EqualTo("Array's capacity must be exactly 16!"));
        }

        [Test]
        public void FetchMethodReturnsArrayOfInts()
        {
            Database sud = new Database(new int[16]);

            Assert.AreEqual(new int[16], sud.Fetch(), "Fetch doesnt return int[]!");
        }
    }
}
