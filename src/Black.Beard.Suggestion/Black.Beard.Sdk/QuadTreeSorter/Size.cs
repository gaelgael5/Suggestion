using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bb.Sdk.QuadTreeSorter
{

    /// <summary>Implémente une structure utilisée pour décrire le <see cref="T:System.Windows.Size" /> d'un objet. </summary>
    [Serializable]
    public struct Size
    {

        internal double _width;
        internal double _height;
        private static readonly Size s_empty = Size.CreateEmptySize();

        /// <summary>Obtient une valeur qui représente un <see cref="T:System.Windows.Size" /> vide statique. </summary>
        /// <returns>Une instance vide de <see cref="T:System.Windows.Size" />.</returns>
        public static Size Empty { get { return Size.s_empty; } }

        /// <summary>Obtient une valeur qui indique si cette instance de <see cref="T:System.Windows.Size" /> est <see cref="P:System.Windows.Size.Empty" />. </summary>
        /// <returns>true si cette instance de taille est <see cref="P:System.Windows.Size.Empty" /> ; sinon, false.</returns>
        public bool IsEmpty
        {
            get
            {
                return this._width < 0.0;
            }
        }

        /// <summary>Obtient ou définit la <see cref="P:System.Windows.Size.Width" /> de cette instance de <see cref="T:System.Windows.Size" />. </summary>
        /// <returns>
        ///   <see cref="P:System.Windows.Size.Width" /> de cette instance de <see cref="T:System.Windows.Size" />. La valeur par défaut est 0. La valeur ne peut pas être négative.</returns>
        public double Width
        {
            get { return this._width; }
            set
            {
                if (this.IsEmpty)
                    throw new InvalidOperationException("Size_CannotModifyEmptySize");
                if (value < 0.0)
                    throw new ArgumentException("Size_WidthCannotBeNegative");
                this._width = value;
            }
        }

        /// <summary>Obtient ou définit la <see cref="P:System.Windows.Size.Height" /> de cette instance de <see cref="T:System.Windows.Size" />. </summary>
        /// <returns>
        ///   <see cref="P:System.Windows.Size.Height" /> de cette instance de <see cref="T:System.Windows.Size" />. La valeur par défaut est 0. La valeur ne peut pas être négative.</returns>
        public double Height
        {
            get { return this._height; }
            set
            {
                if (this.IsEmpty)
                    throw new InvalidOperationException("Size_CannotModifyEmptySize");
                if (value < 0.0)
                    throw new ArgumentException("Size_HeightCannotBeNegative");
                this._height = value;
            }
        }

        /// <summary>Initialise une nouvelle instance de la structure <see cref="T:System.Windows.Size" /> et lui attribue une <paramref name="width" /> et une <paramref name="height" /> initiales.</summary>
        /// <param name="width">La largeur initiale de l'instance de <see cref="T:System.Windows.Size" />.</param>
        /// <param name="height">La hauteur initiale de l'instance de <see cref="T:System.Windows.Size" />.</param>
        public Size(double width, double height)
        {
            if (width < 0.0 || height < 0.0)
                throw new ArgumentException("Size_WidthAndHeightCannotBeNegative");
            this._width = width;
            this._height = height;
        }

        private static Size CreateEmptySize()
        {
            return new Size
            {
                _width = double.NegativeInfinity,
                _height = double.NegativeInfinity
            };
        }

    }

}
