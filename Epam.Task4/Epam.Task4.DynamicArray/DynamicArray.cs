using System;
using System.Collections;
using System.Collections.Generic;

namespace Epam.Task4.DynamicArray
{
    public class DynamicArray<T> : IEnumerable, IEnumerable<T>, ICloneable
    {
        private T[] array;
        private int length;
        private int capacity;

        public DynamicArray()
        {
            this.array = new T[8];
            this.length = 0;
            this.capacity = this.array.Length;
        }

        public DynamicArray(int capacity)
        {
            this.array = new T[capacity];
            this.length = 0;
            this.capacity = this.array.Length;
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            if (collection is ICollection tempColl)
            {
                this.array = new T[tempColl.Count];
                this.length = 0;
                this.capacity = tempColl.Count;
            }

            if (collection is DynamicArray<T> tempDA)
            {
                this.array = new T[tempDA.Length];
                this.length = 0;
                this.capacity = tempDA.Length;
            }

            foreach (T item in collection)
            {
                this.Add(item);
            }
        }

        public int Length { get => this.length; }

        public int Capacity
        {
            get => this.capacity;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity must be greater than or equal to zero.", nameof(value));
                }

                if (value > this.capacity)
                {
                    this.ArrayExpansion(value);
                }
                else
                {
                    this.ArrayReduction(value);
                }
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= 0)
                {
                    if (index >= this.Length)
                    {
                        throw new ArgumentOutOfRangeException("Index is out of range", nameof(index));
                    }

                    return this.array[index];
                }
                else
                {
                    if (this.Length + index < 0)
                    {
                        throw new ArgumentOutOfRangeException("Index is out of range", nameof(index));
                    }

                    return this.array[this.Length + index];
                }
            }

            set
            {
                if (index >= 0)
                {
                    if (index >= this.Length)
                    {
                        throw new ArgumentOutOfRangeException("Index is out of range", nameof(index));
                    }

                    this.array[index] = value;
                }
                else
                {
                    if (this.Length + index < 0)
                    {
                        throw new ArgumentOutOfRangeException("Index is out of range", nameof(index));
                    }

                    this.array[this.Length + index] = value;
                }
            }
        }

        public void Add(T item)
        {
            if (this.length == this.capacity)
            {
                this.ArrayExpansion(this.Length * 2);
            }

            this.array[this.Length] = item;
            this.length++;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            int length;
            if (collection is ICollection tempColl)
            {
                if ((tempColl.Count + this.length) > this.capacity)
                {
                    length = tempColl.Count + this.length;
                    this.ArrayExpansion(length);
                }
            }

            if (collection is DynamicArray<T> tempDA)
            {
                if ((tempDA.Length + this.length) > this.capacity)
                {
                    length = tempDA.Length + this.length;
                    this.ArrayExpansion(length);
                }
            }

            foreach (T item in collection)
            {
                this.Add(item);
            }
        }

        public bool Insert(int index, T item)
        {
            try
            {
                T test = this[index];
            }
            catch (Exception)
            {
                return false;
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }

            T[] temp;

            if (this.length == this.capacity)
            {
                temp = new T[this.capacity * 2];
            }
            else
            {
                temp = new T[this.capacity];
            }

            index = index >= 0
                ? index
                : this.length + index;

            for (int i = 0, j = 0; i < this.length; i++, j++)
            {
                if (i == index)
                {
                    temp[j] = item;
                    j++;
                }

                temp[j] = this.array[i];
            }

            this.array = temp;
            this.length++;
            this.capacity = temp.Length;
            return true;
        }

        public bool Remove(T item)
        {
            for (int index = 0; index < this.Length; index++)
            {
                if (this.array[index].Equals(item))
                {
                    T[] temp = new T[this.capacity];

                    for (int i = 0, j = 0; i < this.Length; i++)
                    {
                        if (i == index)
                        {
                            continue;
                        }

                        temp[j] = this.array[i];
                        j++;
                    }

                    this.array = temp;
                    this.length--;
                    return true;
                }
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            T test = this[index];
            T[] temp = new T[this.capacity];

            index = index >= 0
                ? index
                : this.length + index;

            for (int i = 0, j = 0; i < this.Length; i++)
            {
                if (i == index)
                {
                    continue;
                }

                temp[j] = this.array[i];
                j++;
            }

            this.array = temp;
            this.length--;
        }

        public object Clone()
        {
            return new DynamicArray<T>
            {
                array = this.array,
                length = this.length,
                capacity = this.capacity,
            };
        }

        public T[] ToArray()
        {
            T[] temp = new T[this.length];
            Array.Copy(this.array, temp, this.length);
            return temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DynamicArrayEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new DynamicArrayEnumerator(this);
        }

        private void ArrayExpansion(int length)
        {
            T[] temp = new T[length];

            for (int i = 0; i < this.Length; i++)
            {
                temp[i] = this.array[i];
            }

            this.array = temp;
            this.capacity = this.array.Length;
        }

        private void ArrayReduction(int length)
        {
            T[] temp = new T[length];

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = this.array[i];
            }

            this.array = temp;
            this.length = this.array.Length;
            this.capacity = this.array.Length;
        }

        private class DynamicArrayEnumerator : IEnumerator<T>
        {
            private int currentIndex = -1;

            private DynamicArray<T> collection;

            internal DynamicArrayEnumerator(DynamicArray<T> collection)
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
                return ++this.currentIndex < this.collection.Length;
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
