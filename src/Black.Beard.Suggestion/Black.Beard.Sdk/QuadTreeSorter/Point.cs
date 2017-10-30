using Bb.Suggestion.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bb.Sdk.QuadTreeSorter
{
  

    /// <summary>Représente une paire de coordonnées X/Y dans un espace à deux dimensions.  </summary>
    [Serializable]
    public struct Point : IPoint
    {
        internal double _x;
        internal double _y;

        /// <summary>Obtient ou définit la coordonnée <see cref="P:System.Windows.Point.X" />-de cette structure <see cref="T:System.Windows.Point" />. </summary>
        /// <returns>Coordonnée <see cref="P:System.Windows.Point.X" />-de cette structure <see cref="T:System.Windows.Point" />.  La valeur par défaut est 0.</returns>
        public double X
        {
            get { return this._x; }
            set { this._x = value; }
        }
        /// <summary>Obtient ou définit la coordonnée <see cref="P:System.Windows.Point.Y" /> de ce <see cref="T:System.Windows.Point" />. </summary>
        /// <returns>Coordonnée <see cref="P:System.Windows.Point.Y" />-de cette structure <see cref="T:System.Windows.Point" />.  La valeur par défaut est 0.</returns>
        public double Y
        {
            get { return this._y; }
            set { this._y = value; }
        }

        /// <summary>Compare l'égalité de deux structures <see cref="T:System.Windows.Point" />.  Remarque : les coordonnées de points sont décrites à l'aide de valeurs <see cref="T:System.Double" />. Comme les valeurs <see cref="T:System.Double" /> peuvent perdre en précision lorsqu'elles sont exploitées, il est possible qu'une comparaison entre deux valeurs <see cref="T:System.Double" /> logiquement égales échoue. </summary>
        /// <returns>true si <paramref name="point1" /> et <paramref name="point2" /> contiennent les mêmes valeurs respectives <see cref="P:System.Windows.Point.X" /> et <see cref="P:System.Windows.Point.Y" /> ; sinon, false.</returns>
        /// <param name="point1">Premier point à comparer.</param>
        /// <param name="point2">Deuxième point à comparer.</param>
        public static bool Equals(Point point1, Point point2)
        {
            return point1.X.Equals(point2.X) && point1.Y.Equals(point2.Y);
        }

        /// <summary>Détermine si l'<see cref="T:System.Object" /> spécifié est un <see cref="T:System.Windows.Point" /> et s'il contient les mêmes coordonnées que ce <see cref="T:System.Windows.Point" />. Remarque : les coordonnées <see cref="T:System.Windows.Point" /> sont décrites à l'aide de valeurs <see cref="T:System.Double" />. Comme les valeurs <see cref="T:System.Double" /> peuvent perdre en précision lorsqu'elles sont exploitées, il est possible qu'une comparaison entre deux valeurs Doubles logiquement égales échoue. </summary>
        /// <returns>true si <paramref name="o" /> est un <see cref="T:System.Windows.Point" /> et qu'il reprend les mêmes valeurs <see cref="P:System.Windows.Point.X" /> et <see cref="P:System.Windows.Point.Y" /> que <see cref="T:System.Windows.Point" /> ; sinon, false.</returns>
        /// <param name="o">
        ///   <see cref="T:System.Object" /> à comparer.</param>
        public override bool Equals(object o)
        {
            if (o == null || !(o is Point))
            {
                return false;
            }
            Point point = (Point)o;
            return Point.Equals(this, point);
        }

        /// <summary>Compare l'égalité de deux structures <see cref="T:System.Windows.Point" />.  Remarque : <see cref="T:System.Windows.Point" /> les coordonnées sont exprimées à l'aide de valeurs Double. Comme les valeurs <see cref="T:System.Double" /> peuvent perdre en précision lorsqu'elles sont exploitées, il est possible qu'une comparaison entre deux valeurs Doubles logiquement égales échoue. </summary>
        /// <returns>true si les deux structures <see cref="T:System.Windows.Point" /> contiennent les mêmes valeurs de <see cref="P:System.Windows.Point.X" /> et <see cref="P:System.Windows.Point.Y" /> ; sinon, false.</returns>
        /// <param name="value">Point à comparer à cette instance.</param>
        public bool Equals(Point value)
        {
            return Point.Equals(this, value);
        }

        /// <summary>Retourne le code de hachage pour ce <see cref="T:System.Windows.Point" />.</summary>
        /// <returns>Code de hachage pour cette structure <see cref="T:System.Windows.Point" />.</returns>
        public override int GetHashCode()
        {
            return this.X.GetHashCode() ^ this.Y.GetHashCode();
        }

        /// <summary>Crée une structure <see cref="T:System.Windows.Point" /> qui contient les coordonnées spécifiées. </summary>
        /// <param name="x">Coordonnée x de la nouvelle structure <see cref="T:System.Windows.Point" />. </param>
        /// <param name="y">Coordonnée y de la nouvelle structure <see cref="T:System.Windows.Point" />. </param>
        public Point(double x, double y)
        {
            this._x = x;
            this._y = y;
        }

    }

}
