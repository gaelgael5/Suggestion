using Bb.Sdk.QuadTreeSorter;
using Bb.Suggestion.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Sdk
{

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SearchPoi<T>
    {
       
        private QuadTree<QuadObject<T>> _quadTreelist;
        private List<T> _list;
        private double _left = double.MaxValue;
        private double _right = double.MinValue;
        private double _top = double.MaxValue;
        private double _bottom = double.MinValue;
        private Func<T, IPoint> _getPoint;
        private double _diameter;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="getPoint"></param>
        public SearchPoi(double diameter, Func<T, IPoint> getPoint)
        {           
            this._list = new List<T>();
            this._getPoint = getPoint;
            this._diameter = diameter;
        }

        /// <summary>
        /// Add az new point on the map
        /// </summary>
        /// <param name="item"></param>
        public virtual void Add(T item)
        {

            _list.Add(item);

            var p = this._getPoint(item);

            // recupère les tailles pour dimensionner l'area de trie.
            _left = Math.Min(p.X, _left);
            _right = Math.Max(p.X, _right);

            _top = Math.Min(p.Y, _top);
            _bottom = Math.Max(p.Y, _bottom);

        }

        /// <summary>
        /// Build the map
        /// </summary>
        public void Build()
        {

            double l;
            double v;
            
       
     
            v = _bottom != _top ? _bottom - _top : 1;
            l = _right != _left ? _right - _left : 1;


            if (double.IsInfinity(v))
                v = 0;

            if (double.IsInfinity(l))
                l = 0;

            // taille de la surface
            Size size = new Size(l, v);

            _quadTreelist = new QuadTree<QuadObject<T>>(size, 15);

            foreach (var item in _list)
            {
                var o = this._getPoint(item);
                //var o = item.Address.GeocodingResult;
                var poi = new POI<T>(item, o.X, o.Y, _diameter);
                _quadTreelist.Insert(poi);
            }

        }

        /// <summary>
        /// Find pudo list
        /// </summary>
        /// <param name="longitude">The longitude.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="maxdistance">The maxdistance.</param>
        /// <returns></returns>
        public IEnumerable<ResultSearchPoi<T>> Items(double longitude, double latitude, double maxdistance)
        {

            var rayon_de_la_terre = 6371;       // en km
            var distance = maxdistance / 1000;  // en km

            var ceta = (180 * distance) / (3.14159265359 * rayon_de_la_terre);

            var point = new Rect(longitude, latitude, 1, 1);
            foreach (var item in _quadTreelist.Query(point))
            {
                var o = _getPoint(item.Item);
                var o1 = (int)EarthDistanceCalc(o.X, o.Y, longitude, latitude);
                if (o1 <= maxdistance)
                    yield return new ResultSearchPoi<T>(o1, item.Item, longitude, latitude);
            }
        }

        /// <summary>
        /// Calcul de la distance entre deux points sur la terre
        /// </summary>
        /// <param name="Lat1">point1 - latitude</param>
        /// <param name="Long1">point 1 - longitude</param>
        /// <param name="Lat2">point 2 _ latitude</param>
        /// <param name="Long2">point 2 - longitude</param>
        /// <returns>distance en mètres</returns>
        public static double EarthDistanceCalc(double Long1, double Lat1, double Long2, double Lat2)
        {
            /*
            The Haversine formula according to Dr. Math.
            http://mathforum.org/library/drmath/view/51879.html

            dlon = lon2 - lon1
            dlat = lat2 - lat1
            a = (sin(dlat/2))^2 + cos(lat1) * cos(lat2) * (sin(dlon/2))^2
            c = 2 * atan2(sqrt(a), sqrt(1-a))
            d = R * c

            Where
            * dlon is the change in longitude
            * dlat is the change in latitude
            * c is the great circle distance in Radians.
            * R is the radius of a spherical Earth.
            * The locations of the two points in
            spherical coordinates (longitude and
            latitude) are lon1,lat1 and lon2, lat2.
            */
            double dDistance = Double.MinValue;
            double dLat1InRad = Lat1 * (Math.PI / 180.0);
            double dLong1InRad = Long1 * (Math.PI / 180.0);
            double dLat2InRad = Lat2 * (Math.PI / 180.0);
            double dLong2InRad = Long2 * (Math.PI / 180.0);

            double dLongitude = dLong2InRad - dLong1InRad;
            double dLatitude = dLat2InRad - dLat1InRad;

            // Intermediate result a.
            double a = Math.Pow(Math.Sin(dLatitude / 2.0), 2.0) +
            Math.Cos(dLat1InRad) * Math.Cos(dLat2InRad) *
            Math.Pow(Math.Sin(dLongitude / 2.0), 2.0);

            // Intermediate result c (great circle distance in Radians).
            double c = 2.0 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1.0 - a));

            // Distance.
            // const Double kEarthRadiusMiles = 3956.0;
            const Double kEarthRadiusKms = 6376.5;
            dDistance = kEarthRadiusKms * c;

            // resultat en mètres
            return dDistance * 1000;
        }
        
    }

    /// <summary>
    /// is a distance of a point
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [System.Diagnostics.DebuggerDisplay("{Distance} -> {Item.ToString()}")]
    public struct ResultSearchPoi<T>
    {

        T _item;
        double _distance;
        Point _point;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <param name="item">The item.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="latitude">The latitude.</param>
        internal ResultSearchPoi(double distance, T item, double longitude, double latitude)
        {
            _distance = distance;
            _item = item;

            _point = new Point(longitude, latitude);

        }

        /// <summary>
        /// instance of <see cref="T"/>
        /// </summary>
        public T Item { get { return _item; } }

        /// <summary>
        /// distance of the original position
        /// </summary>
        public double Distance { get { return _distance; } }

        /// <summary>
        /// is null
        /// </summary>
        public bool IsNull { get { return _item == null; } }

        /// <summary>
        /// compared point
        /// </summary>
        public Point Point { get { return _point; } }

    }


}
