using System;
using System.Collections;
using System.Collections.Generic;
using Epam.Task4.DynamicArray;

namespace Epam.Task4.CycledDynamicArray
{
    public class CycledDynamicArray<T> : DynamicArray<T>, IEnumerable<T>, IEnumerable
    {
        public CycledDynamicArray()
        {
        }

        public CycledDynamicArray(int capacity) : base(capacity)
        {
        }

        public CycledDynamicArray(IEnumerable<T> collection) : base(collection)
        {
        }

        public new IEnumerator<T> GetEnumerator()
        {
            return new CycledDynamicArrayEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CycledDynamicArrayEnumerator(this);
        }

        private class CycledDynamicArrayEnumerator : IEnumerator<T>
        {
            private int currentIndex = -1;

            private CycledDynamicArray<T> collection;

            internal CycledDynamicArrayEnumerator(CycledDynamicArray<T> collection)
            {
                this.collection = collection;
            }

            public T Current
            {
                get
                {
                    return this.collection[this.currentIndex];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return this.Current;
                }
            }

            public bool MoveNext()
            {
                ++this.currentIndex;
                if (this.currentIndex >= this.collection.Length)
                {
                    this.currentIndex = 0;
                }

                return true;
            }

            public void Reset()
            {
                this.currentIndex = -1;
            }

            void IDisposable.Dispose()
            {
            }
        }
    }
}
