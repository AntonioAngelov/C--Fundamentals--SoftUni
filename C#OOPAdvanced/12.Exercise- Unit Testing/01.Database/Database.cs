using System;

namespace _01.Database
{
    public class Database
    {
        private int[] data;
        private int currentIndex = 0;

        public Database(int[] data)
        {
            this.Data = data;
            this.currentIndex += data.Length;
        }

        public int[] Data
        {
            get { return this.data; }
            private set
            {
                if (value.Length > 16)
                {
                    throw new  InvalidOperationException("Array's capacity must be exactly 16!");
                }

                this.data = new int[16];
                for (int i = 0; i < value.Length; i++)
                {
                    this.data[i] = value[i];
                }
            }
        }

        public void Add(int value)
        {
            if (this.currentIndex == 16)
            {
                throw new InvalidOperationException("Array's capacity must be exactly 16!");
            }

            this.data[this.currentIndex] = value;
            this.currentIndex++;
        }

        public void Remove()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("Cannot remove element from empty database!");
            }

            this.data[this.currentIndex - 1] = 0;
            this.currentIndex--;
        }

        public int[] Fetch()
        {
            return this.Data;
        }
    }
}
