namespace _03.Iterator.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using System.Diagnostics;
    using System.IO;

    [TestFixture]
    public class PrintMethodTests
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
        public void PrintsorrectResult()
        {
            //Arrange
            StringWriter sud = new StringWriter();
            Console.SetOut(sud);

            //Act
            this.list.Print();

            //Assert
            Assert.AreEqual(this.data[0], sud.ToString().Trim(), "Print method doesn'tprint correct element!");
        }
    }
}
