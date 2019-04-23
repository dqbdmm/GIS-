using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Compress
{
    class Lambert
    {
        public static PointF blToXY(PointF point)
        {
            double L = point.X;
            double B = point.Y;
            L = toRadian(L);
            B = toRadian(B);

            double B0 = toRadian(0);
            double L0 = toRadian(105);
            double B1 = toRadian(20);
            double B2 = toRadian(40);
            double a = 6378245, b = 6356863.019;
            double e = Math.Sqrt(1 - (b / a) * (b / a));

            double mB1 = Math.Cos(B1) / Math.Sqrt(1 - e * e * Math.Sin(B1) * Math.Sin(B1));
            double mB2 = Math.Cos(B2) / Math.Sqrt(1 - e * e * Math.Sin(B2) * Math.Sin(B2));

            double t = getT(B, e);
            double tB0 = getT(B0, e);
            double tB1 = getT(B1, e);
            double tB2 = getT(B2, e);

            double n = Math.Log(mB1 / mB2) / Math.Log(tB1 / tB2);

            double F = mB1 / (n * Math.Pow(tB1, n));

            double r = getR(a, F, t, n);
            double r0 = getR(a, F, tB0, n);

            double theta = n * (L - L0);

            double X, Y;
            X = r0 - r * Math.Cos(theta);
            Y = r * Math.Sin(theta);

            return new PointF(Convert.ToSingle(Y), Convert.ToSingle(X));

        }
        static double getT(double B, double e)
        {
            return Math.Tan(Math.PI / 4 - B / 2) / Math.Pow((1 - e * Math.Sin(B)) / (1 + e * Math.Sin(B)), e / 2);
        }
        static double getR(double a, double F, double t, double n)
        {
            return a * F * Math.Pow(t, n);
        }

        static double toRadian(double degree)
        {
            return degree / 180 * Math.PI;
        }
    }
}
