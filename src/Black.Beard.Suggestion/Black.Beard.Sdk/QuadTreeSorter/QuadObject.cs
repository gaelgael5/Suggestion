using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bb.Sdk.QuadTreeSorter
{

    /// <summary>
    /// As a bind for a point on the map with an item
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QuadObject<T> : IQuadObject
    {

        public QuadObject(T item, Rect rect)
        {
            this.Item = item;
            this.Bounds = rect;
        }

        public Rect Bounds { get; private set; }
        public T Item { get; private set; }

    }
}
