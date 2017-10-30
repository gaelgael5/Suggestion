using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bb.Sdk.QuadTreeSorter
{

    /// <summary>Décrit la largeur, la hauteur et l'emplacement d'un rectangle. </summary>
    [Serializable]
    public struct Rect
    {
        internal double _x;
        internal double _y;
        internal double _width;
        internal double _height;
        private static readonly Rect s_empty = Rect.CreateEmptyRect();
        /// <summary>Obtient une valeur spéciale qui représente un rectangle sans position ou zone. </summary>
        /// <returns>Le rectangle vide qui a <see cref="P:System.Windows.Rect.X" /> et des valeurs de propriété <see cref="P:System.Windows.Rect.Y" /> de <see cref="F:System.Double.PositiveInfinity" />et a <see cref="P:System.Windows.Rect.Width" /> et des valeurs de propriété <see cref="P:System.Windows.Rect.Height" /> de <see cref="F:System.Double.NegativeInfinity" />.</returns>
        public static Rect Empty
        {
            get
            {
                return Rect.s_empty;
            }
        }
        /// <summary>Obtient une valeur qui indique si le rectangle est le rectangle <see cref="P:System.Windows.Rect.Empty" />.</summary>
        /// <returns>true si le rectangle est le rectangle<see cref="P:System.Windows.Rect.Empty" /> ; sinon, false.</returns>
        public bool IsEmpty
        {
            get
            {
                return this._width < 0.0;
            }
        }
        /// <summary>Obtient ou définit la position de l'angle supérieur gauche du rectangle.</summary>
        /// <returns>La position du coin supérieur gauche du rectangle. La valeur par défaut est (0, 0). </returns>
        public Point Location
        {
            get
            {
                return new Point(this._x, this._y);
            }
            set
            {
                if (this.IsEmpty)
                {
                    throw new InvalidOperationException("Rect_CannotModifyEmptyRect");
                }
                this._x = value._x;
                this._y = value._y;
            }
        }
        /// <summary>Obtient ou définit la largeur et la hauteur du rectangle. </summary>
        /// <returns>Une structure <see cref="T:System.Windows.Size" /> qui spécifie la hauteur et la largeur du rectangle.</returns>
        public Size Size
        {
            get
            {
                if (this.IsEmpty)
                {
                    return Size.Empty;
                }
                return new Size(this._width, this._height);
            }
            set
            {
                if (value.IsEmpty)
                {
                    this = Rect.s_empty;
                    return;
                }
                if (this.IsEmpty)
                {
                    throw new InvalidOperationException("Rect_CannotModifyEmptyRect");
                }
                this._width = value._width;
                this._height = value._height;
            }
        }
        /// <summary>Obtient ou définit la valeur d'axe x du côté gauche du rectangle. </summary>
        /// <returns>La  valeur d'axe x du côté gauche du rectangle.</returns>
        public double X
        {
            get
            {
                return this._x;
            }
            set
            {
                if (this.IsEmpty)
                {
                    throw new InvalidOperationException("Rect_CannotModifyEmptyRect");
                }
                this._x = value;
            }
        }
        /// <summary>Obtient ou définit la valeur d'axe y du côté supérieur du rectangle. </summary>
        /// <returns>La valeur d'axe y du côté supérieur du rectangle.</returns>
        public double Y
        {
            get
            {
                return this._y;
            }
            set
            {
                if (this.IsEmpty)
                {
                    throw new InvalidOperationException("Rect_CannotModifyEmptyRect");
                }
                this._y = value;
            }
        }
        /// <summary>Obtient ou définit la largeur du rectangle.  </summary>
        /// <returns>Un nombre positif qui représente la largeur du rectangle. La valeur par défaut est 0.</returns>
        public double Width
        {
            get
            {
                return this._width;
            }
            set
            {
                if (this.IsEmpty)
                {
                    throw new InvalidOperationException("Rect_CannotModifyEmptyRect");
                }
                if (value < 0.0)
                {
                    throw new ArgumentException("Size_WidthCannotBeNegative");
                }
                this._width = value;
            }
        }
        /// <summary>Obtient ou définit la hauteur du rectangle. </summary>
        /// <returns>Un nombre positif qui représente la hauteur du rectangle. La valeur par défaut est 0.</returns>
        public double Height
        {
            get
            {
                return this._height;
            }
            set
            {
                if (this.IsEmpty)
                {
                    throw new InvalidOperationException("Rect_CannotModifyEmptyRect");
                }
                if (value < 0.0)
                {
                    throw new ArgumentException("Size_HeightCannotBeNegative");
                }
                this._height = value;
            }
        }
        /// <summary>Obtient la valeur d'axe x du côté gauche du rectangle. </summary>
        /// <returns>La  valeur d'axe x du côté gauche du rectangle.</returns>
        public double Left
        {
            get
            {
                return this._x;
            }
        }
        /// <summary>Obtient la position de l'axe y du haut du rectangle. </summary>
        /// <returns>La  position de l'axe y du haut du rectangle.</returns>
        public double Top
        {
            get
            {
                return this._y;
            }
        }
        /// <summary>Obtient la valeur d'axe x du côté droit du rectangle.  </summary>
        /// <returns>La valeur d'axe x du côté droit du rectangle.</returns>
        public double Right
        {
            get
            {
                if (this.IsEmpty)
                {
                    return double.NegativeInfinity;
                }
                return this._x + this._width;
            }
        }
        /// <summary>Obtient la valeur d'axe y du bas du rectangle. </summary>
        /// <returns>La valeur d'axe y du bas du rectangle. Si le rectangle est vide, la valeur est <see cref="F:System.Double.NegativeInfinity" />.</returns>
        public double Bottom
        {
            get
            {
                if (this.IsEmpty)
                {
                    return double.NegativeInfinity;
                }
                return this._y + this._height;
            }
        }
        /// <summary>Obtient la position du coin supérieur gauche du rectangle. </summary>
        /// <returns>La position du coin supérieur gauche du rectangle.</returns>
        public Point TopLeft
        {
            get
            {
                return new Point(this.Left, this.Top);
            }
        }
        /// <summary>Obtient la position du coin supérieur droit du rectangle. </summary>
        /// <returns>La position du coin supérieur droit du rectangle.</returns>
        public Point TopRight
        {
            get
            {
                return new Point(this.Right, this.Top);
            }
        }
        /// <summary>Obtient la position du coin inférieur gauche du rectangle </summary>
        /// <returns>La position du coin inférieur gauche du rectangle.</returns>
        public Point BottomLeft
        {
            get
            {
                return new Point(this.Left, this.Bottom);
            }
        }
        /// <summary>Obtient la position du coin inférieur droit du rectangle </summary>
        /// <returns>La position du coin inférieur droit du rectangle.</returns>
        public Point BottomRight
        {
            get
            {
                return new Point(this.Right, this.Bottom);
            }
        }
        /// <summary>Compare l'égalité exacte de deux rectangles.</summary>
        /// <returns>true si les rectangles ont les mêmes <see cref="P:System.Windows.Rect.Location" /> et valeurs <see cref="P:System.Windows.Rect.Size" />; sinon, false.</returns>
        /// <param name="rect1">Premier rectangle à comparer.</param>
        /// <param name="rect2">Deuxième rectangle à comparer.</param>
        public static bool operator ==(Rect rect1, Rect rect2)
        {
            return rect1.X == rect2.X && rect1.Y == rect2.Y && rect1.Width == rect2.Width && rect1.Height == rect2.Height;
        }
        /// <summary>Compare si deux rectangles sont inégaux.  </summary>
        /// <returns>true si les rectangles n'ont pas les mêmes valeurs  <see cref="P:System.Windows.Rect.Location" /> et <see cref="P:System.Windows.Rect.Size" />; sinon, false.</returns>
        /// <param name="rect1">Premier rectangle à comparer.</param>
        /// <param name="rect2">Deuxième rectangle à comparer.</param>
        public static bool operator !=(Rect rect1, Rect rect2)
        {
            return !(rect1 == rect2);
        }
        /// <summary>Indique si les rectangles spécifiés sont égaux. </summary>
        /// <returns>true si les rectangles ont les mêmes <see cref="P:System.Windows.Rect.Location" /> et valeurs <see cref="P:System.Windows.Rect.Size" />; sinon, false.</returns>
        /// <param name="rect1">Premier rectangle à comparer.</param>
        /// <param name="rect2">Deuxième rectangle à comparer.</param>
        public static bool Equals(Rect rect1, Rect rect2)
        {
            if (rect1.IsEmpty)
            {
                return rect2.IsEmpty;
            }
            return rect1.X.Equals(rect2.X) && rect1.Y.Equals(rect2.Y) && rect1.Width.Equals(rect2.Width) && rect1.Height.Equals(rect2.Height);
        }
        /// <summary>Détermine si l'objet spécifié est égal au rectangle actuel.</summary>
        /// <returns>true si <paramref name="o" /> est un <see cref="T:System.Windows.Rect" /> et qu'il possède les mêmes propriétés <see cref="P:System.Windows.Rect.Location" /> et <see cref="P:System.Windows.Rect.Size" /> que le rectangle actuel ; sinon, false.</returns>
        /// <param name="o">Objet à comparer avec le rectangle actuel.</param>
        public override bool Equals(object o)
        {
            if (o == null || !(o is Rect))
            {
                return false;
            }
            Rect rect = (Rect)o;
            return Rect.Equals(this, rect);
        }
        /// <summary>Indique si le rectangle spécifié est égal au rectangle actuel. </summary>
        /// <returns>true si le rectangle spécifié a les mêmes valeurs <see cref="P:System.Windows.Rect.Location" /> et <see cref="P:System.Windows.Rect.Size" /> que le rectangle actuel ; sinon, false.</returns>
        /// <param name="value">Le rectangle à comparer avec le rectangle actuel.</param>
        public bool Equals(Rect value)
        {
            return Rect.Equals(this, value);
        }
        /// <summary>Crée un code de hachage pour le rectangle. </summary>
        /// <returns>Code de hachage pour la structure <see cref="T:System.Windows.Rect" /> en cours.</returns>
        public override int GetHashCode()
        {
            if (this.IsEmpty)
            {
                return 0;
            }
            return this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Width.GetHashCode() ^ this.Height.GetHashCode();
        }

        /// <summary>Initialise une nouvelle instance de la structure <see cref="T:System.Windows.Rect" /> qui a l'emplacement de coin supérieur gauche, et la largeur et la hauteur spécifiés. </summary>
        /// <param name="location">Un point qui spécifie l'emplacement du coin supérieur gauche du rectangle.</param>
        /// <param name="size">Une structure <see cref="T:System.Windows.Size" /> qui spécifie la hauteur et la largeur du rectangle.</param>
        public Rect(Point location, Size size)
        {
            if (size.IsEmpty)
            {
                this = Rect.s_empty;
                return;
            }
            this._x = location._x;
            this._y = location._y;
            this._width = size._width;
            this._height = size._height;
        }
        /// <summary>Initialise une nouvelle instance de la structure <see cref="T:System.Windows.Rect" /> qui a les coordonnées x et y, et la largeur et la hauteur spécifiées. </summary>
        /// <param name="x">La coordonnée x du coin supérieur gauche du rectangle.</param>
        /// <param name="y">La coordonnée y du coin supérieur gauche du rectangle.</param>
        /// <param name="width">Largeur du rectangle.</param>
        /// <param name="height">Hauteur du rectangle.</param>
        public Rect(double x, double y, double width, double height)
        {
            if (width < 0.0 || height < 0.0)
            {
                throw new ArgumentException("Size_WidthAndHeightCannotBeNegative");
            }
            this._x = x;
            this._y = y;
            this._width = width;
            this._height = height;
        }
        /// <summary>Initialise une nouvelle instance de la structure <see cref="T:System.Windows.Rect" /> qui est exactement assez  grande pour contenir les deux points spécifiés. </summary>
        /// <param name="point1">Le premier point que doit contenir le nouveau rectangle.</param>
        /// <param name="point2">Le deuxième point que doit contenir le nouveau rectangle.</param>
        public Rect(Point point1, Point point2)
        {
            this._x = Math.Min(point1._x, point2._x);
            this._y = Math.Min(point1._y, point2._y);
            this._width = Math.Max(Math.Max(point1._x, point2._x) - this._x, 0.0);
            this._height = Math.Max(Math.Max(point1._y, point2._y) - this._y, 0.0);
        }


        /// <summary>Initialise une nouvelle instance de la structure <see cref="T:System.Windows.Rect" /> qui fait la taille spécifiée et est localisée à (0,0).  </summary>
        /// <param name="size">Une structure <see cref="T:System.Windows.Size" /> qui spécifie la hauteur et la largeur du rectangle.</param>
        public Rect(Size size)
        {
            if (size.IsEmpty)
            {
                this = Rect.s_empty;
                return;
            }
            this._x = (this._y = 0.0);
            this._width = size.Width;
            this._height = size.Height;
        }
        /// <summary>Indique si le rectangle contient le point spécifié.</summary>
        /// <returns>true si le rectangle contient le point spécifié ; sinon, false.</returns>
        /// <param name="point">Point à vérifier.</param>
        public bool Contains(Point point)
        {
            return this.Contains(point._x, point._y);
        }

        /// <summary>Indique si le rectangle contient les coordonnées x et y spécifiées. </summary>
        /// <returns>true si (<paramref name="x" />, <paramref name="y" />) est contenu par le rectangle ; sinon, false.</returns>
        /// <param name="x">Coordonnée x du point à vérifier.</param>
        /// <param name="y">Coordonnée y du point à vérifier.</param>
        public bool Contains(double x, double y)
        {
            return !this.IsEmpty && this.ContainsInternal(x, y);
        }

        /// <summary>Indique si le rectangle contient le rectangle spécifié. </summary>
        /// <returns>true si <paramref name="rect" /> est entièrement contenu par le rectangle ; sinon, false.</returns>
        /// <param name="rect">Le rectangle à vérifier.</param>
        public bool Contains(Rect rect)
        {
            return !this.IsEmpty && !rect.IsEmpty && (this._x <= rect._x && this._y <= rect._y && this._x + this._width >= rect._x + rect._width) && this._y + this._height >= rect._y + rect._height;
        }

        /// <summary>Indique si le rectangle spécifié se croise avec le rectangle actuel. </summary>
        /// <returns>true si le rectangle spécifié se croise avec le rectangle actuel ; sinon, false.</returns>
        /// <param name="rect">Le rectangle à vérifier.</param>
        public bool IntersectsWith(Rect rect)
        {
            return !this.IsEmpty && !rect.IsEmpty && (rect.Left <= this.Right && rect.Right >= this.Left && rect.Top <= this.Bottom) && rect.Bottom >= this.Top;
        }

        /// <summary>Trouve l'intersection du rectangle actuel et du rectangle spécifié, et stocke le résultat comme le rectangle actuel. </summary>
        /// <param name="rect">Le rectangle devant trouver l'intersection avec le rectangle actuel.</param>
        public void Intersect(Rect rect)
        {
            if (!this.IntersectsWith(rect))
            {
                this = Rect.Empty;
                return;
            }
            double num = Math.Max(this.Left, rect.Left);
            double num2 = Math.Max(this.Top, rect.Top);
            this._width = Math.Max(Math.Min(this.Right, rect.Right) - num, 0.0);
            this._height = Math.Max(Math.Min(this.Bottom, rect.Bottom) - num2, 0.0);
            this._x = num;
            this._y = num2;
        }

        /// <summary>Renvoie l'intersection des rectangles spécifiés. </summary>
        /// <returns>L'intersection des deux rectangles, ou <see cref="P:System.Windows.Rect.Empty" /> si aucune intersection n'existe.</returns>
        /// <param name="rect1">Premier rectangle à comparer.</param>
        /// <param name="rect2">Deuxième rectangle à comparer.</param>
        public static Rect Intersect(Rect rect1, Rect rect2)
        {
            rect1.Intersect(rect2);
            return rect1;
        }

        /// <summary>Multiplie la taille du rectangle actuel par les valeurs x et y spécifiées.</summary>
        /// <param name="scaleX">Le facteur d'échelle sur l'axe x.</param>
        /// <param name="scaleY">Le facteur d'échelle sur l'axe y.</param>
        public void Scale(double scaleX, double scaleY)
        {
            if (this.IsEmpty)
            {
                return;
            }
            this._x *= scaleX;
            this._y *= scaleY;
            this._width *= scaleX;
            this._height *= scaleY;
            if (scaleX < 0.0)
            {
                this._x += this._width;
                this._width *= -1.0;
            }
            if (scaleY < 0.0)
            {
                this._y += this._height;
                this._height *= -1.0;
            }
        }
        private bool ContainsInternal(double x, double y)
        {
            return x >= this._x && x - this._width <= this._x && y >= this._y && y - this._height <= this._y;
        }
        private static Rect CreateEmptyRect()
        {
            return new Rect
            {
                _x = double.PositiveInfinity,
                _y = double.PositiveInfinity,
                _width = double.NegativeInfinity,
                _height = double.NegativeInfinity
            };
        }
    }


}
