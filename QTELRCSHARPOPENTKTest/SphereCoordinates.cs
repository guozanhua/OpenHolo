using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This class calculates the coordinates of a sphere based on a given angle and radius
 */

namespace QTELR_Interface
{
    static class SphereCoordinates
    {
        private static double x_0, y_0, z_0, radius_0;

        public static void updateCoordinates(double angle1, double angle2, double angle3)
        {
            setCoordinates(radius_0 * Math.Cos(convertRadtoDeg(angle1)), 0, radius_0 * Math.Sin(convertRadtoDeg(angle1)));
        }

        public static void setCoordinates(double newX, double newY, double newZ)
        { 
            x_0 = newX;
            y_0 = newY;
            z_0 = newZ;
            //Console.WriteLine("Coordinates: <" + x_0 + ", " + y_0 + ", " + z_0 + "> ");
        }

        public static void setRadius(double radius)
        {
            radius_0 = radius;
            //Console.WriteLine("Radius: " + radius_0);
        }

        public static double getX()
        {
            return x_0;
        }

        public static double getY()
        {
            return y_0;
        }

        public static double getZ()
        {
            return z_0;
        }

        public static double getRadius()
        {
            return radius_0;
        }

        private static double convertRadtoDeg(double rad)
        {
            return rad*(180 / Math.PI);
        }
    }
}
