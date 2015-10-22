using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynom
{
    public class Polynom
    {
        double[] Coefficients;

        public int Length
        {
            get
            {
                return Coefficients.Length;
            }
        }

        public Polynom(double[] coef)
        {
            Coefficients = coef;
        }

        public Polynom(double coef, int count)
        {
            Coefficients = new double[count];
            for (int i = 0; i < count; i++)
                Coefficients[i] = coef;
        }

        public Polynom(int count) : this(0, count) { }

        public override string ToString()
        {
            string result = String.Empty;
            string buf = String.Empty;
            for (int i = 0; i < Coefficients.Length; i++)
            {

                if (Coefficients[i] != 0)
                {
                    buf = (i == 0) ? String.Empty : " + ";
                    result += $"{buf}{Coefficients[i]} * x^{i}";
                }
            }
            return result;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj.ToString() == ToString();
        }

        public double this[int index]
        {
            get
            {
                if (index >= 0 && index < Coefficients.Length)
                return Coefficients[index];
                throw new IndexOutOfRangeException();
            }
        }

        public static Polynom operator*(Polynom poly, double coef)
        {
            double[] res = new double[poly.Length];

            for (int i = 0; i < res.Length; i++)
            {
                res[i] = poly[i] * coef;
            }

            return new Polynom(res);
        }

        public static Polynom operator *(double coef, Polynom poly)
        {
            return poly * coef;
        }

        public static Polynom operator+(Polynom poly1, Polynom poly2)
        {
            int length = (int)Math.Max(poly1.Length, poly2.Length);

            double[] res = new double[length];

            for (int i = 0; i < length; i++)
            { 
                res[i] = poly1.GetCoef(i) + poly2.GetCoef(i);
            }

            return new Polynom(res);
        }

        public static Polynom operator-(Polynom poly1, Polynom poly2)
        {
            return poly1 + poly2 * (-1);
        }

        public static Polynom operator*(Polynom poly1, Polynom poly2)
        {
            Polynom result = new Polynom(poly1.Length + poly2.Length);
            for (int i = 0; i < poly2.Length; i++)
            {
                double[] buf = new double[poly1.Length + i];
                for (int j = 0; j < poly1.Length; j++)
                {
                    buf[j + i] = poly1[j] * poly2[i];
                }
                result += new Polynom(buf);
            }

            return result;
        }

        private double GetCoef(int index)
        {
            double param;

            try { param = Coefficients[index]; }
            catch { param = 0; }

            return param;
        }

    }
}
