using System;
using System.Collections.Generic;
using System.Text;

namespace Black.Beard.Suggestion.UnitTests.Models
{

    public class Index<T>
    {

        public Index(params T[] values)
        {
            this._buckets1 = new HashSet<T>(values);
            this._buckets2 = new bool[values.Length];

            int length = values.Length;
            for (int i = 0; i < length; i++)
            {
                int crc = (values[i].GetHashCode() & 0x7fffffff) % length;
                this._buckets2[crc] = true;
            }

        }

        public bool Contains(T value)
        {
            int crc = (value.GetHashCode() & 0x7fffffff) % this._buckets2.Length;

            if (!this._buckets2[crc])
                return false;

            return this._buckets1.Contains(value);

        }

        private HashSet<T> _buckets1;
        private bool[] _buckets2;

    }

}
