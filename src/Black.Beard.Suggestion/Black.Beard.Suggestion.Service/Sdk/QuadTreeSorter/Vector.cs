using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bb.Sdk.QuadTreeSorter
{

    /// <summary>Représente un déplacement dans l'espace 2D. </summary>
    [Serializable]
    public struct Vector
    {

        internal double _x;
        internal double _y;

        /// <summary> Obtient ou définit le composant <see cref="P:System.Windows.Vector.X" /> de ce vecteur. </summary>
        /// <returns>Composant <see cref="P:System.Windows.Vector.X" /> de ce vecteur. La valeur par défaut est 0.</returns>
        public double X
        {
            get { return this._x; }
            set { this._x = value; }
        }

        /// <summary> Obtient ou définit le composant <see cref="P:System.Windows.Vector.Y" /> de ce vecteur. </summary>
        /// <returns>Composant <see cref="P:System.Windows.Vector.Y" /> de ce vecteur. La valeur par défaut est 0.</returns>
        public double Y
        {
            get { return this._y; }
            set { this._y = value; }
        }

        /// <summary> Obtient la longueur de ce vecteur. </summary>
        /// <returns>Longueur de ce vecteur. </returns>
        public double Length { get { return Math.Sqrt(this._x * this._x + this._y * this._y); } }

        /// <summary> Initialise une nouvelle instance de la structure <see cref="T:System.Windows.Vector" />. </summary>
        /// <param name="x">Offset <see cref="P:System.Windows.Vector.X" /> du nouveau <see cref="T:System.Windows.Vector" />.</param>
        /// <param name="y">Offset <see cref="P:System.Windows.Vector.Y" /> du nouveau <see cref="T:System.Windows.Vector" />.</param>
        public Vector(double x, double y)
        {
            this._x = x;
            this._y = y;
        }

        /// <summary> Compare l'égalité de deux vecteurs.</summary>
        /// <returns>true si les composants <see cref="P:System.Windows.Vector.X" /> et <see cref="P:System.Windows.Vector.Y" /> de <paramref name="vector1" /> et <paramref name="vector2" /> sont égaux ; sinon, false.</returns>
        /// <param name="vector1">Premier vecteur à comparer.</param>
        /// <param name="vector2">Deuxième vecteur à comparer.</param>
        public static bool operator ==(Vector vector1, Vector vector2)
        {
            return vector1.X == vector2.X && vector1.Y == vector2.Y;
        }

        /// <summary>Compare l'inégalité de deux vecteurs.</summary>
        /// <returns>true si les composants <see cref="P:System.Windows.Vector.X" /> et <see cref="P:System.Windows.Vector.Y" /> de <paramref name="vector1" /> et <paramref name="vector2" /> sont différents ; sinon, false.</returns>
        /// <param name="vector1">Premier vecteur à comparer.</param>
        /// <param name="vector2">Deuxième vecteur à comparer.</param>
        public static bool operator !=(Vector vector1, Vector vector2)
        {
            return !(vector1 == vector2);
        }

        /// <summary> Compare l'égalité de deux vecteurs spécifiés.</summary>
        /// <returns>true si les composants <see cref="P:System.Windows.Vector.X" /> et <see cref="P:System.Windows.Vector.Y" /> de <paramref name="vector1" /> et <paramref name="vector2" /> sont égaux ; sinon, false.</returns>
        /// <param name="vector1">Premier vecteur à comparer.</param>
        /// <param name="vector2">Deuxième vecteur à comparer.</param>
        public static bool Equals(Vector vector1, Vector vector2)
        {
            return vector1.X.Equals(vector2.X) && vector1.Y.Equals(vector2.Y);
        }

        /// <summary>Détermine si le <see cref="T:System.Object" /> spécifié est une structure <see cref="T:System.Windows.Vector" /> et, si c'est le cas, s'il a les mêmes valeurs <see cref="P:System.Windows.Vector.X" /> et <see cref="P:System.Windows.Vector.Y" /> que ce vecteur.</summary>
        /// <returns>true si <paramref name="o" /> est un <see cref="T:System.Windows.Vector" /> et a les mêmes valeurs <see cref="P:System.Windows.Vector.X" /> et <see cref="P:System.Windows.Vector.Y" /> que ce vecteur ; sinon, false.</returns>
        /// <param name="o">Vecteur à comparer.</param>
        public override bool Equals(object o)
        {
            if (o == null || !(o is Vector))
                return false;
            Vector vector = (Vector)o;
            return Vector.Equals(this, vector);
        }

        /// <summary> Compare l'égalité de deux vecteurs.</summary>
        /// <returns>true si <paramref name="value" /> a les mêmes valeurs <see cref="P:System.Windows.Vector.X" /> et <see cref="P:System.Windows.Vector.Y" /> que ce vecteur ; sinon, false.</returns>
        /// <param name="value">Vecteur à comparer à ce vecteur.</param>
        public bool Equals(Vector value)
        {
            return Vector.Equals(this, value);
        }

        /// <summary> Retourne le code de hachage pour ce vecteur. </summary>
        /// <returns>Code de hachage pour cette instance.</returns>
        public override int GetHashCode()
        {
            return this.X.GetHashCode() ^ this.Y.GetHashCode();
        }

        /// <summary> Nie le vecteur spécifié. </summary>
        /// <returns>Vecteur avec des valeurs <see cref="P:System.Windows.Vector.X" /> et <see cref="P:System.Windows.Vector.Y" />, opposées aux valeurs <see cref="P:System.Windows.Vector.X" /> et <see cref="P:System.Windows.Vector.Y" /> de <paramref name="vector" />.</returns>
        /// <param name="vector">Vecteur à nier.</param>
        public static Vector operator -(Vector vector)
        {
            return new Vector(-vector._x, -vector._y);
        }

        /// <summary> Nie ce vecteur. Le vecteur conserve la même grandeur, mais avec une direction opposée. </summary>
        public void Negate()
        {
            this._x = -this._x;
            this._y = -this._y;
        }

        /// <summary>Ajoute deux vecteurs et retourne le résultat sous forme de vecteur. </summary>
        /// <returns>Somme de <paramref name="vector1" /> et <paramref name="vector2" />. </returns>
        /// <param name="vector1">Premier vecteur à ajouter.</param>
        /// <param name="vector2">Deuxième vecteur à ajouter.</param>
        public static Vector operator +(Vector vector1, Vector vector2)
        {
            return new Vector(vector1._x + vector2._x, vector1._y + vector2._y);
        }

        /// <summary> Ajoute deux vecteurs et retourne le résultat sous forme de structure <see cref="T:System.Windows.Vector" />. </summary>
        /// <returns>Somme de <paramref name="vector1" /> et <paramref name="vector2" />.</returns>
        /// <param name="vector1">Premier vecteur à ajouter.</param>
        /// <param name="vector2">Deuxième vecteur à ajouter.</param>
        public static Vector Add(Vector vector1, Vector vector2)
        {
            return new Vector(vector1._x + vector2._x, vector1._y + vector2._y);
        }

        /// <summary> Soustrait un vecteur spécifié d'un autre. </summary>
        /// <returns>Différence entre <paramref name="vector1" /> et <paramref name="vector2" />. </returns>
        /// <param name="vector1">Vecteur duquel <paramref name="vector2" /> est soustrait. </param>
        /// <param name="vector2">Vecteur à soustraire de <paramref name="vector1" />.</param>
        public static Vector operator -(Vector vector1, Vector vector2)
        {
            return new Vector(vector1._x - vector2._x, vector1._y - vector2._y);
        }

        /// <summary> Soustrait le vecteur spécifié d'un autre vecteur spécifié. </summary>
        /// <returns>Différence entre <paramref name="vector1" /> et <paramref name="vector2" />. </returns>
        /// <param name="vector1">Vecteur duquel <paramref name="vector2" /> est soustrait.</param>
        /// <param name="vector2">Vecteur à soustraire de <paramref name="vector1" />.</param>
        public static Vector Subtract(Vector vector1, Vector vector2)
        {
            return new Vector(vector1._x - vector2._x, vector1._y - vector2._y);
        }

        /// <summary> Convertit un point par le vecteur spécifié et retourne le point résultant. </summary>
        /// <returns>Résultat de la conversion de <paramref name="point" /> par <paramref name="vector" />.</returns>
        /// <param name="vector">Vecteur utilisé pour convertir <paramref name="point" />.</param>
        /// <param name="point">Point à convertir.</param>
        public static Point operator +(Vector vector, Point point)
        {
            return new Point(point._x + vector._x, point._y + vector._y);
        }

        /// <summary> Convertit le point spécifié par le vecteur spécifié et retourne le point résultant.</summary>
        /// <returns>Résultat de la conversion de <paramref name="point" /> par <paramref name="vector" />.</returns>
        /// <param name="vector">Valeur de conversion du point spécifié.</param>
        /// <param name="point">Point à convertir.</param>
        public static Point Add(Vector vector, Point point)
        {
            return new Point(point._x + vector._x, point._y + vector._y);
        }

        /// <summary>Multiplie le vecteur spécifié par la scalaire indiquée et retourne le vecteur résultant. </summary>
        /// <returns>Résultat de la multiplication de <paramref name="vector" /> par <paramref name="scalar" />.</returns>
        /// <param name="vector">Vecteur à multiplier.</param>
        /// <param name="scalar">Scalaire à multiplier.</param>
        public static Vector operator *(Vector vector, double scalar)
        {
            return new Vector(vector._x * scalar, vector._y * scalar);
        }

        /// <summary> Multiplie le vecteur spécifié par la scalaire indiquée et retourne le <see cref="T:System.Windows.Vector" /> résultant. </summary>
        /// <returns>Résultat de la multiplication de <paramref name="vector" /> par <paramref name="scalar" />.</returns>
        /// <param name="vector">Vecteur à multiplier.</param>
        /// <param name="scalar">Scalaire à multiplier.</param>
        public static Vector Multiply(Vector vector, double scalar)
        {
            return new Vector(vector._x * scalar, vector._y * scalar);
        }

        /// <summary> Multiplie la scalaire spécifiée par le vecteur indiqué et retourne le vecteur résultant. </summary>
        /// <returns>Résultat de la multiplication de <paramref name="scalar" /> par <paramref name="vector" />.</returns>
        /// <param name="scalar">Scalaire à multiplier.</param>
        /// <param name="vector">Vecteur à multiplier.</param>
        public static Vector operator *(double scalar, Vector vector)
        {
            return new Vector(vector._x * scalar, vector._y * scalar);
        }

        /// <summary> Multiplie la scalaire spécifiée par le vecteur indiqué et retourne le <see cref="T:System.Windows.Vector" /> résultant. </summary>
        /// <returns>Résultat de la multiplication de <paramref name="scalar" /> par <paramref name="vector" />.</returns>
        /// <param name="scalar">Scalaire à multiplier.</param>
        /// <param name="vector">Vecteur à multiplier.</param>
        public static Vector Multiply(double scalar, Vector vector)
        {
            return new Vector(vector._x * scalar, vector._y * scalar);
        }

        /// <summary> Divise le vecteur spécifié par la scalaire indiquée et retourne le vecteur résultant.</summary>
        /// <returns>Résultat de la division de <paramref name="vector" /> par <paramref name="scalar" />.</returns>
        /// <param name="vector">Vecteur à diviser.</param>
        /// <param name="scalar">Scalaire par laquelle <paramref name="vector" /> sera divisé.</param>
        public static Vector operator /(Vector vector, double scalar)
        {
            return vector * (1.0 / scalar);
        }

        /// <summary> Divise le vecteur spécifié par la scalaire indiquée et retourne le résultat sous forme de <see cref="T:System.Windows.Vector" />.</summary>
        /// <returns>Résultat de la division de <paramref name="vector" /> par <paramref name="scalar" />.</returns>
        /// <param name="vector">Structure vectorielle à diviser.</param>
        /// <param name="scalar">Valeur par laquelle <paramref name="vector" /> est divisé.</param>
        public static Vector Divide(Vector vector, double scalar)
        {
            return vector * (1.0 / scalar);
        }

        ///// <summary> Transforme l'espace de coordonnées du vecteur spécifié à l'aide du <see cref="T:System.Windows.Media.Matrix" /> spécifié. </summary>
        ///// <returns>Résultat de la transformation de <paramref name="vector" /> par <paramref name="matrix" />.</returns>
        ///// <param name="vector">Vecteur à transformer.</param>
        ///// <param name="matrix">Transformation à appliquer au <paramref name="vector" />.</param>
        //public static Vector operator *(Vector vector, Matrix matrix)
        //{
        //    return matrix.Transform(vector);
        //}

        /// <summary> Calcule le produit scalaire des deux structures vectorielles spécifiées et retourne le résultat sous forme de <see cref="T:System.Double" />.</summary>
        /// <returns>Retourne un <see cref="T:System.Double" /> qui contient le produit scalaire de <paramref name="vector1" /> et <paramref name="vector2" /> qui est calculé à l'aide de la formule suivante :vector1.X * vector2.X + vector1.Y * vector2.Y</returns>
        /// <param name="vector1">Premier vecteur à multiplier.</param>
        /// <param name="vector2">Deuxième vecteur à multiplier.</param>
        public static double operator *(Vector vector1, Vector vector2)
        {
            return vector1._x * vector2._x + vector1._y * vector2._y;
        }

        /// <summary> Calcule le produit scalaire des deux vecteurs spécifiés et retourne le résultat sous forme de <see cref="T:System.Double" />.</summary>
        /// <returns>
        ///   <see cref="T:System.Double" /> qui contient le produit scalaire de <paramref name="vector1" /> et de <paramref name="vector2" />, qui est calculé à l'aide de la formule suivante : ((vector1.X * vector2.X) + (vector1.Y * vector2.Y) </returns>
        /// <param name="vector1">Premier vecteur à multiplier.</param>
        /// <param name="vector2">Deuxième structure vectorielle à multiplier.</param>
        public static double Multiply(Vector vector1, Vector vector2)
        {
            return vector1._x * vector2._x + vector1._y * vector2._y;
        }

        /// <summary> Calcule le déterminant de deux vecteurs.</summary>
        /// <returns>Déterminant de <paramref name="vector1" /> et <paramref name="vector2" />.</returns>
        /// <param name="vector1">Premier vecteur à évaluer.</param>
        /// <param name="vector2">Deuxième vecteur à évaluer.</param>
        public static double Determinant(Vector vector1, Vector vector2)
        {
            return vector1._x * vector2._y - vector1._y * vector2._x;
        }

    }

}
