using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_3
{
    public class DynamicArray<T> : IEnumerable<T>, IEnumerator<T>, ICloneable where T : IComparable
    {
        private T[] arr;
        private int capacity;
        private int index = -1;

        public T Current
        {   
            get
            {
                return this.Array[this.index];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return this.Array[this.index];
            }
        }
                
        public DynamicArray(int n = 8)
        {
            Array = new T[n];
            Capacity = n;
            Length = n;
        }

        public DynamicArray(IEnumerable<T> array, int cnt = 0)
        {
            if (cnt == 0)
            {
                cnt = array.Count();
            }

            Array = new T[cnt];
            Capacity = cnt;
            Length = cnt;

            for (int i = 0; i < cnt; i++)
            {
                Array[i] = array.ElementAt(i);
            }
        }

        public T[] Array { get; set; }

        public int Capacity
        {
            get => capacity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (value < Length)
                {
                    Length = value;
                }
                capacity = value;
            }
        }

        public int Length { get; private set; }

        public T this[int index]
        {
            get => index >= 0 ? Array[index] : this.Array[Length + index];
            set
            {
                if (index < Length)
                {
                    if (index >= 0)
                    {
                        Array[index] = value;
                    }
                    else
                    {
                        Array[Length + index] = value;
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public void Add(T x)
        {
            Expansion();
            Array[Length++] = x;
        }

        public void Expansion()
        {
            if (Capacity == Length)
            {
                Capacity *= 2;
                T[] temp = new T[Capacity];
                Array.CopyTo(temp, 0);
                Array = temp;
            }
        }

        public void AddRange(IEnumerable<T> arr)
        {
            for (; Capacity - Length < arr.Count(); Capacity *= 2) ;            

            T[] temp = new T[Capacity];

            T[] temp = new T[Capacity];
            Array.CopyTo(temp, 0);
            Array = temp;
            foreach (var item in arr)
            {
                this.Add(item);
            }
        }

        public bool Remove(T x)
        {
            for (int i = 0; i < Length; i++)
            {
                if (x.CompareTo(Array[i]) == 0)
                {
                    ShiftLeft(i);
                    return true;
                }
            }
            return false;
        }

        private bool ShiftLeft(int i)
        {
            for (int j = i; j < Length - 1; j++)
            {
                Array[j] = Array[j + 1];
            }
            i--;
            Length--;
            return true;
        }
        private bool ShiftRight(int i)
        {
            for (int j = Length; j > i; j--)
            {
                Array[j] = Array[j - 1];
            }
            i--;
            Length--;
            return true;
        }

        public bool Insert(T value, int index)
        {
            if (Length < index)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                Expansion();
                ShiftRight(index);
                Array[index] = value;
                Length++;

                return true;
            }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            this.index++;
            if (this.index == this.Length)
            {
                this.Reset();
                return false;
            }

            return true;
        }

        public void Reset()
        {
            index = -1;
        }

        public T[] ToArray()
        {
            return Array;
        }

        public object Clone()
        {
            return new DynamicArray<T>(this.Array, this.Capacity);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)Array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)Array).GetEnumerator();
        }
    }
}
