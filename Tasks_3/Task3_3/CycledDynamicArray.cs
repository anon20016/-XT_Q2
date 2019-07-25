using System;
using System.Collections.Generic;
using System.Text;

namespace Task3_3
{
    public class CycledDynamicArray<T> : DynamicArray<T>, IEnumerable<T>, IEnumerator<T>, ICloneable where T : IComparable
    {
        private int index = -1;

        public CycledDynamicArray(IEnumerable<T> arr) : base(arr)
        {
        }       

        public new bool MoveNext()
        {
            index++;
            if (index == Length)
            {
                index = 0;
            }
            return true;
        }
    }
}
