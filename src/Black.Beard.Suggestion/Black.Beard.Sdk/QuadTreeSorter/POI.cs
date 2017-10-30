using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bb.Sdk.QuadTreeSorter
{
    /// <summary>
    /// As a point on the Map
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class POI<T> : QuadObject<T> 
    {

        public POI(T item, double x, double y, double diameter)
            : base(item, new Rect(x, y, diameter, diameter))
        {

        }

    }
}
