using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _01.Listy_Iterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private const int currentInternalIndexInitialValue = 0;
        private readonly List<T> collection;
        private int currentInternalIndex;

        public ListyIterator()
        {
            this.collection = new List<T>();
            this.currentInternalIndex = currentInternalIndexInitialValue;
        }

        public ListyIterator(IEnumerable<T> collectionData)
        {
            this.collection = new List<T>(collectionData);
        }

        public bool Move()
        {
            if (currentInternalIndex < this.collection.Count - 1)
            {
                this.currentInternalIndex++;
            }
            else
            {
                return false;
            }

            return true;
        }

        public bool HasNext() => this.currentInternalIndex < this.collection.Count - 1;

        public T Print()
        {
            if (this.collection.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }

            return this.collection[this.currentInternalIndex];
        }

        private class ListyIteratorEnumerator : IEnumerator<T>
        {
            private readonly List<T> data;
            private int currentIndex;

            public ListyIteratorEnumerator(List<T> data)
            {
                this.Reset();

                this.data = data;
            }

            public T Current => this.data[this.currentIndex];

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }

            public bool MoveNext() => ++this.currentIndex < this.data.Count;

            public void Reset() => currentIndex = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < collection.Count; i++)
            {
                yield return this.collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
