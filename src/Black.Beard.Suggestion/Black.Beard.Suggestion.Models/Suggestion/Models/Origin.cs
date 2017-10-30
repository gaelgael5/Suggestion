using System;
using Bb.Suggestion.Service;

namespace Bb.Suggestion.Models
{
    public class Origin : IPoint
    {
        public Origin()
        {

        }

        public double X { get; set; }

        public double Y { get; set; }

        public Address Address { get; set; }

        internal void Initialize()
        {
            throw new NotImplementedException();
        }
    }

}