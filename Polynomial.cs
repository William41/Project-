using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algebra_And_Calculus
{
    class Polynomial
    {
        int degree;
        int count;
        double[] polynomial;
        public Polynomial(int count)
        {
            this.count = count;
            polynomial = new double[count];
        }
        public int Degree
        {
            get { return this.degree; }
            set
            {
                this.degree = value;
            }
        }
        public int Count
        {
            get { return this.count; }
            set
            {
                this.count = value;
            }
        }
        void rev()
        {
            Array.Reverse(polynomial);
        }
        public double this[int coeff]
        {
            get { return polynomial[coeff]; }
            set { polynomial[coeff] = value; }
        }
        public int getCount(Polynomial p)
        {
            int c = 0;
            for (int i = 0; i < p.Count; i++)
            {
                c++;
            }
            return c;
        }
        public int getDegree(Polynomial p)
        {
            int c;
            c = p.Count - 1;
            return c;
        }
        Polynomial duplicate()
        {
            Polynomial p = new Polynomial(count);
            for (int i = 0; i < count; i++)
                p[i] = polynomial[i];
            return p;
        }
        public static Polynomial Parse(string ip)
        {
            MATHEMATICS math = new MATHEMATICS(12);
            string[] co = ip.Split(',');
            Polynomial res = new Polynomial(co.Length);
            for (int i = 0; i < co.Length; i++)
            {
                res[i] = math.EvaluateReal(co[i]);
            }
            return res;
        }
        public static Polynomial zeroPoly(int c)
        {
            Polynomial zer = new Polynomial(c);
            for (int i = 0; i < c; i++)
                zer[i] = 0.0;
            return zer;
        }
        public static Polynomial UnityPoly(int c)
        {
            Polynomial zer = new Polynomial(c);
            for (int i = 0; i < c; i++)
                zer[i] = 1.0;
            return zer;
        }
        public static string Format(Polynomial p)
        {
            StringBuilder sb1 = new StringBuilder();
            if (MATHEMATICS.isFrac == true & MATHEMATICS.precision <= 6)
            {
                for (int i = 0; i < p.Count; i++)
                {
                    sb1.Append("+");
                    sb1.Append("(" + p.decToFrac(Math.Round(p[i], MATHEMATICS.precision)) + ")");
                    sb1.Append(",");
                }
            }
            else if (MATHEMATICS.isFrac == false || MATHEMATICS.precision > 6)
            {
                for (int i = 0; i < p.Count; i++)
                {
                    sb1.Append(p.Assign(p[i]));
                    sb1.Append(Math.Round(p[i], MATHEMATICS.precision));
                    sb1.Append(",");
                }
            }
            string u = sb1.ToString();
            u= "P(" + u.Substring(0, u.Length - 1) + ")";
            return u;
        }
        string Assign(double x)
        {
            if (x < 0)
                return string.Empty;
            else
                return "+";
        }
        string decToFrac(double d)
        {
            string str = d.ToString();
            if (str.Contains('.'))
            {
                String[] parts = str.Split('.');
                long whole = long.Parse(parts[0]);
                long numerator = long.Parse(parts[1]);
                long denominator = (long)Math.Pow(10, parts[1].Length);
                long divisor = GCD(numerator, denominator);
                long num = numerator / divisor;
                long den = denominator / divisor;
                long g = den * whole + num;
                String fraction = g + "/" + den;
                return fraction;
            }
            return d.ToString();
        }
        static long GCD(long a, long b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sb1 = new StringBuilder();
            string u = null, d;
            if (MATHEMATICS.isFrac == true & MATHEMATICS.precision <= 6)
            {
                for (int i = 0; i < polynomial.Length; i++)
                {
                    sb1.Append("+");
                    sb1.Append("(" + decToFrac(Math.Round(polynomial[i], MATHEMATICS.precision)) + ")");
                    sb1.Append(",");
                }
                u = sb1.ToString();
                MATHEMATICS.m_Primatives["polyAns"] = "P(" + u.Substring(0, u.Length - 1) + ")";
                //return "P(" + u.Substring(0, u.Length - 1) + ")";
            }
            else if (MATHEMATICS.isFrac == false || MATHEMATICS.precision > 6)
            {
                for (int i = 0; i < polynomial.Length; i++)
                {
                    sb1.Append(Assign(polynomial[i]));
                    sb1.Append(Math.Round(polynomial[i], MATHEMATICS.precision));
                    sb1.Append(",");
                }
                u = sb1.ToString();
                MATHEMATICS.m_Primatives["polyAns"] = "P(" + u.Substring(0, u.Length - 1) + ")";
               // return "P(" + u.Substring(0, u.Length - 1) + ")";
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (MATHEMATICS.isFrac == true & MATHEMATICS.precision <= 6)
            {
                for (int i = 0; i < polynomial.Length; i++)
                {
                    sb.Append(Assign(polynomial[i]));
                    sb.Append("(" + decToFrac(Math.Round(polynomial[i], MATHEMATICS.precision)) + ")");
                    if (i != 0)
                    {
                        sb.Append("x^");
                        sb.Append(i);
                    }
                }
                d = sb.ToString();
                return d;
            }
            else if (MATHEMATICS.isFrac == false || MATHEMATICS.precision > 6)
            {
                for (int i = 0; i < polynomial.Length; i++)
                {
                    sb.Append(Assign(polynomial[i]));
                    sb.Append(Math.Round(polynomial[i], MATHEMATICS.precision));
                    if (i != 0)
                    {
                        sb.Append("x^");
                        sb.Append(i);
                    }
                }
                return sb.ToString();
            }
            return "P(" + u.Substring(0, u.Length - 1) + ")"; 
        }
        //operator overloading
        static Polynomial add(Polynomial a, Polynomial b)
        {
            Polynomial c = new Polynomial(Math.Max(a.Count, b.Count));
            int m = a.Count;
            int n = b.Count;
            int i = 0;
            for (i = 0; i < m; i++)
                c[i] = a[i];
            for (i = 0; i < n; i++)
                c[i] += b[i];
            return c;
        }
        static Polynomial subtract(Polynomial a, Polynomial b)
        {
            Polynomial c = new Polynomial(Math.Max(a.Count, b.Count));
            int m = a.Count;
            int n = b.Count;
            int i = 0;
            for (i = 0; i < m; i++)
                c[i] = a[i];
            for (i = 0; i < n; i++)
                c[i] -= b[i];
            return c;
        }
        public static Polynomial power(Polynomial a, int pow)
        {
            if (pow == 0)
                return UnityPoly(a.count);
            if (pow == 1)
                return a.duplicate();
            Polynomial o = UnityPoly(1);
            int i = 1;
            while (i <= pow)
            {
                o = o * a;
                i++;
            }
            return o;
        }
        static Polynomial multiply(Polynomial a, Polynomial b)
        {
            Polynomial c = new Polynomial(a.Count + b.Count - 1);
            int m = a.Count;
            int n = b.Count;
            int i = 0, j = 0;
            for (i = 0; i < (m + n - 1); i++)
                c[i] = 0;
            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    c[i + j] = c[i + j] + (a[i] * b[j]);
                }
            }
            return c;
        }
        static Polynomial multiply2(double a, Polynomial b)
        {
            Polynomial c = new Polynomial(b.Count);
            int n = b.Count;
            int i = 0, j = 0;
            for (i = 0; i < (n); i++)
                c[i] = 0;
            for (j = 0; j < n; j++)
            {
                c[j] = a * b[j];
            }
            return c;
        }
        static Polynomial subtract2(Polynomial a)
        {
            Polynomial c = new Polynomial(a.Count);
            int m = a.Count;
            int i = 0;
            for (i = 0; i < m; i++)
                c[i] = -a[i];
            return c;
        }
        static Polynomial divide(Polynomial a, Polynomial b)
        {
            if (b == zeroPoly(b.Count))
                throw new Exception("Error");
            Polynomial q;
            int m = a.Count - 1;
            int n = b.Count - 1;
            a.rev();
            b.rev();
            double bm = b[0];
            q = new Polynomial(m - n + 1);
            b[1] = -b[1];
            q[0] = a[0] / bm;
            for (int i = 1; i <= m - n; i++)
            {
                q[i] = q[i - 1] * b[1] + a[i];
            }
            //   System.Windows.Forms.MessageBox.Show(q[m - n - 1].ToString());
            //for (int i =1; i <= m - n; i++)
            //{     
            //    for (int j = 1; j <= i; j++)
            //    {
            //        System.Windows.Forms.MessageBox.Show(q[m - n - i+j].ToString());
            //        s +=((q[m - n - i + j]) * (b[n - j] / bm));
            //    }
            //    q[m - n - i] = (a[m - i] / bm)+ s;
            //    System.Windows.Forms.MessageBox.Show(s.ToString());
            //    System.Windows.Forms.MessageBox.Show((a[m - i] / bm).ToString());
            //}

            //System.Windows.Forms.MessageBox.Show(q[0].ToString() + "\n" + q[1].ToString() + "\n" + q[2].ToString());
            q.rev();
            return q;
        }
        static Polynomial divide2(Polynomial a, double b)
        {
            Polynomial p = new Polynomial(a.Count);
            int m = a.Count;
            for (int i = 0; i < m; i++)
            {
                p[i] = a[i] / b;
            }
            return p;
        }
        public static Polynomial operator +(Polynomial a, Polynomial b)
        {
            return add(a, b);
        }
        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            return subtract(a, b);
        }
        public static Polynomial operator -(Polynomial a)
        {
            return subtract2(a);
        }
        public static Polynomial operator *(Polynomial a, Polynomial b)
        {
            return multiply(a, b);
        }
        public static Polynomial operator *(double a, Polynomial b)
        {
            return multiply2(a, b);
        }
        public static Polynomial operator ^(Polynomial a, int pow)
        {
            return power(a, pow);
        }
        public static Polynomial operator /(Polynomial a, Polynomial b)
        {
            return divide(a, b);
        }
        public static Polynomial operator /(double a, Polynomial b)
        {
            return zeroPoly(b.Count);
        }
        public static Polynomial operator /(Polynomial a, double b)
        {
            return divide2(a, b);
        }
    }
}
