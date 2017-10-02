using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Iterator
{
    public class ListIterator
    {
        private List<string> data;
        private int currentIndex;

        public ListIterator(List<string> newData)
        {
            this.Data = newData;
            this.currentIndex = 0;
        }

        public IReadOnlyCollection<string> Data
        {
            get { return this.data.AsReadOnly(); }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                this.data = value.ToList();
            }
        }

        public bool Move()
        {
            if (this.HasNext())
            {
                ++this.currentIndex;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (this.currentIndex + 1 < this.data.Count)
            {
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (this.data.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.data[this.currentIndex]);
        }
    }
}
