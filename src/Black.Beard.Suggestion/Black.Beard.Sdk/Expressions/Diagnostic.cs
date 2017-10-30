using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bb.Sdk.Expressions
{

    /// <summary>
    /// return diagnostic on rule
    /// </summary>
    public class Diagnostic
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Diagnostic"/> class.
        /// </summary>
        /// <param name="crc">The CRC.</param>
        internal Diagnostic(int crc)
        {
            this.Crc = crc;
            this._items = new List<long>();
        }

        /// <summary>
        /// Appends the specified elapsed ticks.
        /// </summary>
        /// <param name="elapsedTicks">The elapsed ticks.</param>
        internal void Append(long elapsedTicks)
        {
            this._items.Add(elapsedTicks);
            lock(_lock)
                sorted = false;
        }

        public int Crc { get; }

        /// <summary>
        /// Gets all elapsed ticks.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public IEnumerable<long> Items { get { return this._items; } }

        /// <summary>
        /// return Averages of all calls time
        /// </summary>
        /// <returns></returns>
        public double Avg()
        {
            return this._items.Average();
        }

        /// <summary>
        /// return percentile of all calls time
        /// </summary>
        /// <param name="p">percentile, value 0-100</param>
        /// <returns></returns>
        public double Percentile(double p)
        {
            if (!this.sorted)
                lock (_lock)
                    if (!this.sorted)
                    {
                        var a = this._items.OrderBy(c => c).ToList();
                        this._items.Clear();
                        this._items.AddRange(a);
                        sorted = true;
                    }

            return statistics.Percentile(this._items.ToArray(), p);

        }

        private readonly List<long> _items;
        private volatile object _lock = new object();
        private bool sorted;

        private static class statistics
        {

            /// <span class="code-SummaryComment"><summary></span>
            /// Calculate percentile of a sorted data set
            /// </summary>
            /// <param name="sortedData">array of double values</param>
            /// <param name="p">percentile, value 0-100</param>
            /// <returns></returns>
            internal static double Percentile(long[] sortedData, double p)
            {
                // algo derived from Aczel pg 15 bottom
                if (p >= 100.0d)
                    return sortedData[sortedData.Length - 1];

                double position = (double)(sortedData.Length + 1) * p / 100.0;
                double leftNumber = 0.0d, rightNumber = 0.0d;

                double n = p / 100.0d * (sortedData.Length - 1) + 1.0d;

                if (position >= 1)
                {
                    leftNumber = sortedData[(int)System.Math.Floor(n) - 1];
                    rightNumber = sortedData[(int)System.Math.Floor(n)];
                }
                else
                {
                    leftNumber = sortedData[0]; // first data
                    rightNumber = sortedData[1]; // first data
                }

                if (leftNumber == rightNumber)
                    return leftNumber;
                else
                {
                    double part = n - System.Math.Floor(n);
                    return leftNumber + part * (rightNumber - leftNumber);
                }
            }

        }

    }

}
