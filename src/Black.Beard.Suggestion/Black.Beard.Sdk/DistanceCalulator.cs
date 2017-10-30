using System;
using System.Runtime.CompilerServices;

namespace Bb.Sdk
{
    public static class DistanceCalulator
    {
        /// @brief The usual PI/180 constant
        const double DEG_TO_RAD = 0.017453292519943295769236907684886;
        /// @brief Earth's quatratic mean radius for WGS-84
        const double EARTH_RADIUS_IN_METERS = 6372797.560856;

        /** @brief Computes the arc, in radian, between two WGS-84 positions.
          *
          * The result is equal to <code>Distance(from,to)/EARTH_RADIUS_IN_METERS</code>
          *    <code>= 2*asin(sqrt(h(d/EARTH_RADIUS_IN_METERS )))</code>
          *
          * where:<ul>
          *    <li>d is the distance in meters between 'from' and 'to' positions.</li>
          *    <li>h is the haversine function: <code>h(x)=sin²(x/2)</code></li>
          * </ul>
          *
          * The haversine formula gives:
          *    <code>h(d/R) = h(from.lat-to.lat)+h(from.lon-to.lon)+cos(from.lat)*cos(to.lat)</code>
          *
          * @sa http://en.wikipedia.org/wiki/Law_of_haversines
          */
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static double ArcInRadians(double long1, double lat1, double long2, double lat2)
        {
            double latitudeArc = (lat1 - lat2) * DEG_TO_RAD;
            double longitudeArc = (long1 - long2) * DEG_TO_RAD;
            double latitudeH = Math.Sin(latitudeArc * 0.5);
            latitudeH *= latitudeH;
            double lontitudeH = Math.Sin(longitudeArc * 0.5);
            lontitudeH *= lontitudeH;
            double tmp = Math.Cos(lat1 * DEG_TO_RAD) * Math.Cos(lat2 * DEG_TO_RAD);
            return 2.0 * Math.Asin(Math.Sqrt(latitudeH + tmp * lontitudeH));
        }

        /** @brief Computes the distance, in meters, between two WGS-84 positions.
          *
          * The result is equal to <code>EARTH_RADIUS_IN_METERS*ArcInRadians(from,to)</code>
          *
          * @sa ArcInRadians
          */
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DistanceInMeters(double long1, double lat1, double long2, double lat2)
        {
            return EARTH_RADIUS_IN_METERS * ArcInRadians(long1, lat1, long2, lat2);
        }

        internal static void DistanceInMeters(double yLong, double xLat, object y, object x)
        {
            throw new NotImplementedException();
        }
    }
}
