using System;

namespace Bb.Sdk.QuadTreeSorter
{

    /// <summary>
    /// As an abstract of QuadObject
    /// </summary>
    public interface IQuadObject
    {
        Rect Bounds { get; }

        //event EventHandler BoundsChanged;
    }

}