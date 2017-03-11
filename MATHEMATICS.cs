using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
namespace Algebra_And_Calculus
{
    public enum Mode { DEG, RAD, GRAD }
    class MATHEMATICS
    {
        public Mode mode;
        public static int precision, ch = 0;
        public int rounding_number = precision;
        public static double factor, invfactor;
        static string dms = null,gtitle="";
        static double m1 = 0, m2 = 0;
        public static int X = 0, Y = 0;
        public static int is3d = 0;
        public static bool isFrac = false;
        public static bool isPol = false, isCart = false;
        static char c;
        static bool xasy;
        Graph gra = new Graph();
        public static BindingList<string> solutions = new BindingList<string>();
        public static Hashtable m_Primatives = new Hashtable();
        public static Hashtable func_table = new Hashtable();
        public static Hashtable conics = new Hashtable();
        public static Hashtable func_List = new Hashtable();
        public static Bitmap plot= new Bitmap(478, 456);
        public static string title;
        public static int var_count;    //for defining user defined functions
        public static DataSet ds = new DataSet();
        public static double[] DataX, DataY, freq;
        public static string[] key;
        public static List<PointF> points;
        public static List<PointF> pointsP;
        static List<double> xval, yval, t1;
        double[] lroots = { -0.0243502926634244, 0.0243502926634244, -0.0729931217877990, 0.0729931217877990, -0.1214628192961206, 0.1214628192961206, -0.1696444204239928, 0.1696444204239928, -0.2174236437400071, 0.2174236437400071, -0.2646871622087674, 0.2646871622087674, -0.3113228719902110, 0.3113228719902110, -0.3572201583376681, 0.3572201583376681, -0.4022701579639916, 0.4022701579639916, -0.4463660172534641, 0.4463660172534641, -0.4894031457070530, 0.4894031457070530, -0.5312794640198946, 0.5312794640198946, -0.5718956462026340, 0.5718956462026340, -0.6111553551723933, 0.6111553551723933, -0.6489654712546573, 0.6489654712546573, -0.6852363130542333, 0.6852363130542333, -0.7198818501716109, 0.7198818501716109, -0.7528199072605319, 0.7528199072605319, -0.7839723589433414, 0.7839723589433414, -0.8132653151227975, 0.8132653151227975, -0.8406292962525803, 0.8406292962525803, -0.8659993981540928, 0.8659993981540928, -0.8893154459951141, 0.8893154459951141, -0.9105221370785028, 0.9105221370785028, -0.9295691721319396, 0.9295691721319396, -0.9464113748584028, 0.9464113748584028, -0.9610087996520538, 0.9610087996520538, -0.9733268277899110, 0.9733268277899110, -0.9833362538846260, 0.9833362538846260, -0.9910133714767443, 0.9910133714767443, -0.9963401167719553, 0.9963401167719553, -0.9993050417357722, 0.9993050417357722 };
        double[] weights = { 0.0486909570091397, 0.0486909570091397, 0.0485754674415034, 0.0485754674415034, 0.0483447622348030, 0.0483447622348030, 0.0479993885964583, 0.0479993885964583, 0.0475401657148303, 0.0475401657148303, 0.0469681828162100, 0.0469681828162100, 0.0462847965813144, 0.0462847965813144, 0.0454916279274181, 0.0454916279274181, 0.0445905581637566, 0.0445905581637566, 0.0435837245293235, 0.0435837245293235, 0.0424735151236536, 0.0424735151236536, 0.0412625632426235, 0.0412625632426235, 0.0399537411327203, 0.0399537411327203, 0.0385501531786156, 0.0385501531786156, 0.0370551285402400, 0.0370551285402400, 0.0354722132568824, 0.0354722132568824, 0.0338051618371416, 0.0338051618371416, 0.0320579283548516, 0.0320579283548516, 0.0302346570724025, 0.0302346570724025, 0.0283396726142595, 0.0283396726142595, 0.0263774697150547, 0.0263774697150547, 0.0243527025687109, 0.0243527025687109, 0.0222701738083833, 0.0222701738083833, 0.0201348231535302, 0.0201348231535302, 0.0179517157756973, 0.0179517157756973, 0.0157260304760247, 0.0157260304760247, 0.0134630478967186, 0.0134630478967186, 0.0111681394601311, 0.0111681394601311, 0.0088467598263639, 0.0088467598263639, 0.0065044579689784, 0.0065044579689784, 0.0041470332605625, 0.0041470332605625, 0.0017832807216964, 0.0017832807216964 };
        public struct Complex
        {
            public double real;
            public double imag;
            public Complex(double a, double b)
            {
                real = a;
                imag = b;
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
            string assign(double x)
            {
                if (x < 0)
                    return "";
                else if (x > 0)
                    return "+";
                else
                    return "";
            }
            public static Complex operator +(Complex a, Complex b)
            {
                Complex x;
                x.real = a.real + b.real;
                x.imag = a.imag + b.imag;
                return x;
            }
            public static Complex operator +(Complex a, double b)
            {
                Complex x;
                x.real = a.real + b;
                x.imag = a.imag;
                return x;
            }
            public static Complex operator +(double b, Complex a)
            {
                Complex x;
                x.real = a.real + b;
                x.imag = a.imag;
                return x;
            }
            public static Complex operator +(Complex a)
            {
                return a;
            }
            public static Complex operator -(Complex a, Complex b)
            {
                Complex x;
                x.real = a.real - b.real;
                x.imag = a.imag - b.imag;
                return x;
            }
            public static Complex operator -(Complex a, double b)
            {
                Complex x;
                x.real = a.real - b;
                x.imag = a.imag;
                return x;
            }
            public static Complex operator -(double b, Complex a)
            {
                Complex x;
                x.real = b - a.real;
                x.imag = -a.imag;
                return x;
            }
            public static Complex operator -(Complex a)
            {
                a.real = -a.real;
                a.imag = -a.imag;
                return a;
            }
            public static Complex operator *(Complex a, Complex b)
            {
                Complex v;
                double x1 = a.real;
                double x2 = b.real;
                double y1 = a.imag;
                double y2 = b.imag;
                v.real = x1 * x2 - y1 * y2;
                v.imag = x1 * y2 + y1 * x2;
                return v;
            }
            public static Complex operator *(double a, Complex b)
            {
                Complex v;
                double x2 = b.real;
                double y2 = b.imag;
                v.real = a * x2;
                v.imag = a * y2;
                return v;
            }
            public static Complex operator /(Complex a, Complex b)
            {
                Complex v;
                double x1 = a.real;
                double x2 = b.real;
                double y1 = a.imag;
                double y2 = b.imag;
                double z = x2 * x2 + y2 * y2;
                v.real = (x1 * x2 + y1 * y2) / z;
                v.imag = (y1 * x2 - x1 * y2) / z;
                return v;
            }
            public static Complex operator /(double x, Complex c)
            {
                double a = c.real;
                double b = c.imag;
                double z = a * a + b * b;
                Complex p;
                p.real = (x * a) / z;
                p.imag = -(x * b) / z;
                return p;
            }
            public static Complex operator /(Complex c, double x)
            {
                double a = c.real;
                double b = c.imag;
                Complex d;
                d.real = a / x;
                d.imag = b / x;
                return d;
            }
            public static bool operator ==(Complex a, Complex b)
            {
                if (a.real == b.real && a.imag == b.imag)
                    return true;
                else
                    return false;
            }
            public static bool operator <(Complex a, Complex b)
            {
                if (a.real < b.real && a.imag < b.imag)
                    return true;
                else
                    return false;
            }
            public static bool operator <(Complex a, double b)
            {
                if (a.real < b && a.imag < b)
                    return true;
                else
                    return false;
            }
            public static bool operator >(Complex a, Complex b)
            {
                if (a.real > b.real && a.imag > b.imag)
                    return true;
                else
                    return false;
            }
            public static bool operator >(Complex a, double b)
            {
                if (a.real > b && a.imag > b)
                    return true;
                else
                    return false;
            }
            public static bool operator !=(Complex a, Complex b)
            {
                if (a.real != b.real && a.imag != b.imag)
                    return true;
                else
                    return false;
            }
            public override bool Equals(Object obj)
            {
                return ((obj is Complex) && (this == (Complex)obj));
            }
            public override int GetHashCode()
            {
                return (real.GetHashCode() ^ imag.GetHashCode());
            }
            public static Complex zero()
            {
                Complex z;
                z.real = 0.0;
                z.imag = 0.0;
                return z;
            }
            public override string ToString()
            {
                string str = "";
                if (isCart == true)
                {
                    if (isFrac == true & precision <= 6)
                    {
                        if (Math.Round(real, precision) == 0.0)
                            str = "(" + decToFrac(Math.Round(imag, precision)) + ")i";
                        else if (Math.Round(imag, precision) == 0.0)
                            str = decToFrac(Math.Round(real, precision));
                        else
                            str = decToFrac(Math.Round(real, precision)) + " + (" + decToFrac(Math.Round(imag, precision)) + ")i";
                    }
                    else if (MATHEMATICS.isFrac == false || MATHEMATICS.precision > 6)
                    {
                        if (Math.Round(real, precision) == 0.0)
                            str = (Math.Round(imag, precision)) + "i";
                        else if (Math.Round(imag, precision) == 0.0)
                            str = (Math.Round(real, precision)).ToString();
                        else
                            str = (Math.Round(real, precision)) + assign(imag) + (Math.Round(imag, precision)) + "i";
                    }
                    m_Primatives["Ans"] = str;
                }
                else if (isPol == true)
                {
                    double z = Math.Round(Math.Sqrt(real * real + imag * imag), precision);
                    double t = Math.Round(Math.Atan2(imag, real) * invfactor, precision);
                    if (isFrac == true & precision <= 6)
                        str = decToFrac(z) + "∠" + decToFrac(t);
                    else if (MATHEMATICS.isFrac == false || MATHEMATICS.precision > 6)
                        str = z + "∠" + t;
                }
                return str;
            }
        }
        public struct Vector
        {
            public double x, y, z;
            string assign(double x)
            {
                if (x < 0)
                    return "";
                else
                    return "+";
            }  //ROUTINE TO ASSIGN A SIGN IN THE STRING...
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
            public static Vector operator +(Vector a, Vector b)
            {
                Vector c;
                c.x = a.x + b.x;
                c.y = a.y + b.y;
                c.z = a.z + b.z;
                return c;
            }
            public static Vector operator -(Vector a, Vector b)
            {
                Vector c;
                c.x = a.x - b.x;
                c.y = a.y - b.y;
                c.z = a.z - b.z;
                return c;
            }
            public static Vector operator -(Vector a)
            {
                Vector c;
                c.x = -a.x;
                c.y = -a.y;
                c.z = -a.z;
                return c;
            }
            public static Vector operator *(double b, Vector a)
            {
                Vector c;
                c.x = a.x * b;
                c.y = a.y * b;
                c.z = a.z * b;
                return c;
            }
            public static Vector operator /(Vector a, double b)
            {
                Vector v;
                v.x = a.x / b;
                v.y = a.y / b;
                v.z = a.z / b;
                return v;
            }
            public override string ToString()
            {
                string str = "";
                if (isFrac == true & precision <= 6)
                {
                    if (y == 0 && z == 0)
                        str = decToFrac(Math.Round(x, precision)).ToString();
                    else
                        str = "v(" + decToFrac(Math.Round(x, precision)) + "," + decToFrac(Math.Round(y, precision)) + "," + decToFrac(Math.Round(z, precision)) + ")";
                }
                else if (MATHEMATICS.isFrac == false || MATHEMATICS.precision > 6)
                {
                    if (y == 0 && z == 0)
                        str = Math.Round(x, precision).ToString();
                    else
                        str = "v(" + Math.Round(x, precision) + "," + assign(y) + Math.Round(y, precision) + "," + assign(z) + Math.Round(z, precision) + ")";
                }
                m_Primatives["Ans"] = str;
                return str;
            }
            public Vector Unit()
            {
                Vector v;
                v.x = v.y = v.z = 1.0;
                return v;
            }
        }
        public MATHEMATICS(int n)
        {
            this.rounding_number = n;
            this.mode = Mode.DEG;
        }
        public MATHEMATICS(Mode m)
        {
            this.mode = m;
        }
        public Mode Mode
        {
            get { return this.mode; }
            set
            {
                this.mode = value;
                switch (value)
                {
                    case Mode.RAD:
                        factor = 1.0;
                        invfactor = 1.0;
                        break;
                    case Mode.DEG:
                        factor = 2.0 * Math.Round(Math.PI, rounding_number) / 360.0;
                        invfactor = 57.295779513082323;
                        break;
                    case Mode.GRAD:
                        factor = 2.0 * Math.Round(Math.PI, rounding_number) / 400.0;
                        invfactor = (1.1111111111111112 * 57.295779513082323);
                        break;
                }
            }
        }
        private enum Precedence
        {
            None = 12,
            Log=11,
            Angle = 10,
            Factorial = 9,
            Unary = 8,
            Power = 7,
            Times = 6,
            Div = 5,
            Percent=4,
            IntDiv = 3,
            Modulus = 2,
            Plus = 1,
            equals=0
        }
        public double EvaluateReal(string expression)
        {
            string expr = null;
            bool is_unary = false;
            bool next_unary = false;
            int parens = 0;
            int expr_len = 0;
            string ch = null;
            string lexpr = null;
            string rexpr = null;
            int best_pos = 0;
            Precedence best_prec = default(Precedence);
            expr = expression.Replace(" ", "");
            expr_len = (expr).Length;
            if (expr_len == 0)
                return 0;
            is_unary = true;
            best_prec = Precedence.None;
            for (int pos = 0; pos <= expr_len - 1; pos++)
            {
                ch = expr.Substring(pos, 1);
                next_unary = false;
                if (ch == " ")
                {
                }
                else if (ch == "(")
                {
                    parens += 1;
                    next_unary = true;
                }
                else if (ch == ")")
                {
                    parens -= 1;
                    next_unary = false;
                    if (parens < 0)
                    {
                        throw new FormatException("Too many close parentheses in '" + expression + "'");
                    }
                }
                else if (parens == 0)
                {
                    if (ch=="="|ch=="%"|ch=="L"|ch == "R" | ch == "^" | ch == "P" | ch == "C" | ch == "E" | ch == "*" | ch == "×" | ch == "∙" | ch == "/" | ch == "%" | ch == "+" | ch == "-")
                    {
                        next_unary = true;
                        switch (ch)
                        {
                            case "=":
                                if (best_prec >= Precedence.equals)
                                {
                                    best_prec = Precedence.equals;
                                    best_pos = pos;
                                }
                                break;
                            case "L":
                                if (best_prec >= Precedence.Log)
                                {
                                    best_prec = Precedence.Log;
                                    best_pos = pos;
                                }
                                break;
                            case "P":
                            case "C":
                                if (best_prec >= Precedence.Factorial)
                                {
                                    best_prec = Precedence.Factorial;
                                    best_pos = pos;
                                }
                                break;
                            case "E":
                            case "^":
                            case "R":
                                if (best_prec >= Precedence.Power)
                                {
                                    best_prec = Precedence.Power;
                                    best_pos = pos;
                                }
                                break;
                            case "*":
                            case "×":
                            case "∙":
                            case "/":
                            case "%":
                                if (best_prec >= Precedence.Times)
                                {
                                    best_prec = Precedence.Times;
                                    best_pos = pos;
                                }
                                break;
                            case "+":
                            case "-":
                                if ((!is_unary) & best_prec >= Precedence.Plus)
                                {
                                    best_prec = Precedence.Plus;
                                    best_pos = pos;
                                }
                                break;
                        }
                    }
                }
                is_unary = next_unary;
            }
            if (parens != 0)
            {
                throw new FormatException("Missing close parenthesis in '" + expression + "'");
            }
            if (best_prec < Precedence.None)
            {
                lexpr = expr.Substring(0, best_pos);
                rexpr = expr.Substring(best_pos + 1);
                switch (expr.Substring(best_pos, 1))
                {
                    case ",":
                        m1 = EvaluateReal(lexpr);
                        m2 = EvaluateReal(rexpr);
                        return 0;
                    case "L":
                        return this.log(lexpr, rexpr);
                    case "P":
                        return this.Perm(EvaluateReal(lexpr), EvaluateReal(rexpr));
                    case "C":
                        return this.Comb(EvaluateReal(lexpr), EvaluateReal(rexpr));
                    case "^":
                        return Math.Pow(this.EvaluateReal(lexpr), this.EvaluateReal(rexpr));
                    case "R":
                        return this.root(this.EvaluateReal(rexpr), this.EvaluateReal(lexpr));
                    case "E":
                        return EvaluateReal(lexpr) * Math.Pow(10, EvaluateReal(rexpr));
                    case "*":
                    case "×":
                    case "∙":
                        return EvaluateReal(lexpr) * EvaluateReal(rexpr);
                    case "%":
                        {
                            double d=EvaluateReal(rexpr);
                            if (d == 0)
                                return EvaluateReal(lexpr) * 0.01 * 1;
                            else
                                return EvaluateReal(lexpr) * 0.01 * d;
                        }
                    case "/":
                        return EvaluateReal(lexpr) / EvaluateReal(rexpr);
                    case "+":
                        return EvaluateReal(lexpr) + EvaluateReal(rexpr);
                    case "-":
                        return EvaluateReal(lexpr) - EvaluateReal(rexpr);
                    case "=":
                        try
                        {
                            EvaluateReal(lexpr);
                            return 0;
                        }
                        catch
                        {
                            double ad=EvaluateReal(rexpr);
                            m_Primatives[lexpr] = ad;
                            return ad;
                        }
                }
            }
            if (expr.EndsWith("!"))
                return la_gamma(EvaluateReal(expr.Substring(0, expr_len - 1)) + 1);
            if (expr.EndsWith("²"))
                return Math.Pow(EvaluateReal(expr.Substring(0, expr_len - 1)), 2);
            if (expr.StartsWith("∛"))
                return this.cubeRoot(EvaluateReal(expr.Substring(1)));
            if (expr.EndsWith("³"))
                return Math.Pow(EvaluateReal(expr.Substring(0, expr_len - 1)), 3);
            if (expr.EndsWith("⁻¹"))
                return Math.Pow(EvaluateReal(expr.Substring(0, expr_len - 2)), -1);
            if (expr.EndsWith("ᵈ"))
            {
                if (this.Mode == Mode.DEG)
                    return EvaluateReal(expr.Substring(0, expr_len - 1));
                if (this.Mode == Mode.RAD)
                    return EvaluateReal(expr.Substring(0, expr_len - 1)) * 0.0174532925199433;
                if (this.Mode == Mode.GRAD)
                    return EvaluateReal(expr.Substring(0, expr_len - 1)) * 1.111111111111111;
            }
            if (expr.EndsWith("ʳ"))
            {
                if (this.Mode == Mode.DEG)
                    return EvaluateReal(expr.Substring(0, expr_len - 1)) * 57.29577951308233;
                if (this.Mode == Mode.RAD)
                    return EvaluateReal(expr.Substring(0, expr_len - 1));
                if (this.Mode == Mode.GRAD)
                    return EvaluateReal(expr.Substring(0, expr_len - 1)) * 63.66197723675814;
            }
            if (expr.EndsWith("ᵍ"))
            {
                if (this.Mode == Mode.DEG)
                    return EvaluateReal(expr.Substring(0, expr_len - 1)) * 0.9;
                if (this.Mode == Mode.RAD)
                    return EvaluateReal(expr.Substring(0, expr_len - 1)) * 0.015707963267949;
                if (this.Mode == Mode.GRAD)
                    return EvaluateReal(expr.Substring(0, expr_len - 1));
            }
            if (expr.StartsWith("√"))
                return Math.Sqrt(EvaluateReal(expr.Substring(1)));
            if (expr.EndsWith("T"))
                return EvaluateReal(expr.Substring(0, expr_len - 1)) * Math.Pow(10, 12);
            if (expr.EndsWith("G"))
                return EvaluateReal(expr.Substring(0, expr_len - 1)) * Math.Pow(10, 9);
            if (expr.EndsWith("M"))
                return EvaluateReal(expr.Substring(0, expr_len - 1)) * Math.Pow(10, 6);
            if (expr.EndsWith("k"))
                return EvaluateReal(expr.Substring(0, expr_len - 1)) * Math.Pow(10, 3);
            if (expr.EndsWith("m"))
                return EvaluateReal(expr.Substring(0, expr_len - 1)) * Math.Pow(10, -3);
            if (expr.EndsWith("μ"))
                return EvaluateReal(expr.Substring(0, expr_len - 1)) * Math.Pow(10, -6);
            if (expr.EndsWith("n"))
                return EvaluateReal(expr.Substring(0, expr_len - 1)) * Math.Pow(10, -9);
            if (expr.EndsWith("p"))
                return EvaluateReal(expr.Substring(0, expr_len - 1)) * Math.Pow(10, -12);
            if (expr.EndsWith("f"))
                return EvaluateReal(expr.Substring(0, expr_len - 1)) * Math.Pow(10, -15);
            if (expr.StartsWith("(") & expr.EndsWith(")"))
                return EvaluateReal(expr.Substring(1, expr_len - 2));
            if (expr.StartsWith("-"))
                return -EvaluateReal(expr.Substring(1));
            if (expr.StartsWith("+"))
                return EvaluateReal(expr.Substring(1));
            string[] sexp = new string[101];
            int[] data = new int[100];
            int n1;
            string fx;
            double a, b, h;
            if (expr_len > 3 & expr.EndsWith(")"))
            {
                int paren_pos = expr.IndexOf("(");
                if (paren_pos > 0)
                {
                    lexpr = expr.Substring(0, paren_pos);
                    rexpr = expr.Substring(paren_pos + 1, expr_len - paren_pos - 2);
                    switch (lexpr)
                    {
                        case "sin":
                            return Math.Round((Math.Sin(EvaluateReal(rexpr) * factor)), 12);
                        case "cos":
                            return Math.Round((Math.Cos(EvaluateReal(rexpr) * factor)), 12);
                        case "tan":
                        case "Tan":
                            return Math.Tan(EvaluateReal(rexpr) * factor);
                        case "sinh":
                            return Math.Round(Math.Sinh(EvaluateReal(rexpr)), 12);
                        case "cosh":
                            return Math.Round(Math.Cosh(EvaluateReal(rexpr)), 12);
                        case "tanh":
                        case "Tanh":
                            return Math.Round(Math.Tanh(EvaluateReal(rexpr)), 12);
                        case "cosec":
                            return 1 / (Math.Sin(EvaluateReal(rexpr) * factor));
                        case "sec":
                            return 1 / Math.Cos(EvaluateReal(rexpr) * factor);
                        case "cot":
                            return 1 / Math.Tan(EvaluateReal(rexpr) * factor);
                        case "cosech":
                            return 1 / Math.Round(Math.Sinh(EvaluateReal(rexpr)), 12);
                        case "sech":
                            return 1 / Math.Round(Math.Cosh(EvaluateReal(rexpr)), 12);
                        case "coth":
                            return 1 / Math.Round(Math.Tanh(EvaluateReal(rexpr)), 12);
                        case "fact":
                            return this.la_gamma(EvaluateReal(rexpr) + 1);
                        case "ceil":
                            return Math.Ceiling(EvaluateReal(rexpr));
                        case "floor":
                            return Math.Floor(EvaluateReal(rexpr));
                        case "sign":
                            return Math.Sign(EvaluateReal(rexpr));
                        case "mod":
                            return Math.Abs(EvaluateReal(rexpr));
                        case "inv":
                            return Math.Pow(EvaluateReal(rexpr), -1);
                        case "asin":
                            return Math.Round(Math.Asin(EvaluateReal(rexpr)) * invfactor, rounding_number);
                        case "acos":
                            return Math.Round(Math.Acos(EvaluateReal(rexpr)) * invfactor, rounding_number);
                        case "atan":
                            return Math.Round(Math.Atan(EvaluateReal(rexpr)) * invfactor, rounding_number);
                        case "acosec":
                            return Math.Round(Math.Asin(1 / EvaluateReal(rexpr)) * invfactor, rounding_number);
                        case "asec":
                            return Math.Round(Math.Acos(1 / EvaluateReal(rexpr)) * invfactor, rounding_number);
                        case "acot":
                            return Math.Round(Math.Atan(1 / EvaluateReal(rexpr)) * invfactor, rounding_number);
                        case "asinh":
                            return this.sinhIn(EvaluateReal(rexpr));
                        case "acosh":
                            return this.coshIn(EvaluateReal(rexpr));
                        case "atanh":
                            return this.tanhIn(EvaluateReal(rexpr));
                        case "acosech":
                            return this.sinhIn(1 / EvaluateReal(rexpr));
                        case "asech":
                            return this.coshIn(1 / EvaluateReal(rexpr));
                        case "acoth":
                            return this.tanhIn(1 / EvaluateReal(rexpr));
                        case "powe":
                            return Math.Exp(EvaluateReal(rexpr));
                        case "dec":
                            return this.Dec(EvaluateReal(rexpr));
                        case "int":
                            return this.Int(EvaluateReal(rexpr));
                        case "ln":
                            double lo = EvaluateReal(rexpr);
                            if (lo <= 0)
                                return double.NegativeInfinity;
                            return Math.Log(lo);
                        case "dms":
                            double p = Convert.ToDouble(EvaluateReal(rexpr));
                            double de = Int(p);
                            double mi = (p - de) * 60;
                            double min = Int(mi);
                            double sec = (mi - Int(mi)) * 60;
                            double op = de + min / 100.0 + sec / 10000;
                            dms = de + "°" + min + "'" + sec + "\"";
                            solutions.Add(dms);
                            return op;
                        case "deg":
                            double deg = 0, minu = 0, seco = 0;
                            string[] sep = new string[3] { "°", @"'", "\"" };
                            if (rexpr.Contains("°") || rexpr.Contains("'") || rexpr.Contains("\""))
                            {
                                sexp = rexpr.Split(sep, StringSplitOptions.None);
                                if (rexpr.Contains("°"))
                                    deg = EvaluateReal(sexp[0]);
                                if (rexpr.Contains("'"))
                                    minu = EvaluateReal(sexp[0]);
                                if (rexpr.Contains("\""))
                                    seco = EvaluateReal(sexp[0]);
                                if (rexpr.Contains("°") && rexpr.Contains("'"))
                                {
                                    deg = EvaluateReal(sexp[0]);
                                    minu = EvaluateReal(sexp[1]);
                                }
                                if (rexpr.Contains("°") && rexpr.Contains("\""))
                                {
                                    deg = EvaluateReal(sexp[0]);
                                    seco = EvaluateReal(sexp[1]);
                                }
                                if (rexpr.Contains("'") && rexpr.Contains("\""))
                                {
                                    min = EvaluateReal(sexp[0]);
                                    seco = EvaluateReal(sexp[1]);
                                }
                                if (rexpr.Contains("°") && rexpr.Contains("'") && rexpr.Contains("\""))
                                {
                                    deg = EvaluateReal(sexp[0]);
                                    minu = EvaluateReal(sexp[1]);
                                    minu = EvaluateReal(sexp[2]);
                                }
                                double r = deg + ((minu + (seco / 60.0)) / 60.0);
                                return r;
                            }
                            else
                            {
                                double t1 = EvaluateReal(rexpr);
                                int de1 = (int)t1; //extract the degrees
                                double m = (Dec(t1) * 100.0) / 60.0; //extract the minutes
                                double s = (Dec(m) * 100.0) / 3600.0;
                                return de1 + m + s;
                            }
                        case "log":
                            try
                            {
                                string st2; string st1;
                                int pos = rexpr.LastIndexOf(',');
                                st1 = rexpr.Substring(0, pos);
                                st2 = rexpr.Substring(pos + 1);
                                return log(st1, st2);
                            }
                            catch (ArgumentOutOfRangeException ao)
                            {
                                string st2 = rexpr;
                                return log("10", st2);
                            }
                            catch
                            {
                                try
                                {

                                    string st2; string st1;
                                    int pos = rexpr.IndexOf(',');
                                    st1 = rexpr.Substring(0, pos);
                                    st2 = rexpr.Substring(pos + 1);
                                    return log(st1, st2);
                                }
                                catch
                                {
                                    string st2; string st1;
                                    int pos = GetNthIndex(rexpr, ',', 2);
                                    st1 = rexpr.Substring(0, pos);
                                    st2 = rexpr.Substring(pos + 1);
                                    return log(st1, st2);
                                }
                            }
                        case "perc":
                            int pos2 = rexpr.LastIndexOf(',');
                            string st12;
                            try
                            {
                                st12 = rexpr.Substring(0, pos2);
                            }
                            catch
                            {
                                throw new Exception("Syntax Error");
                            }
                            string st22 = rexpr.Substring(pos2 + 1);
                            return perc(st12, st22);
                        case "pol":
                            sexp = rexpr.Split(Convert.ToChar(","));
                            a = EvaluateReal(sexp[0]);
                            b = EvaluateReal(sexp[1]);
                            return polar(a, b);
                        case "rec":
                            sexp = rexpr.Split(Convert.ToChar(","));
                            a = EvaluateReal(sexp[0]);
                            b = EvaluateReal(sexp[1]);
                            return rect(a, b);
                        case "rnd":
                            double opt = EvaluateReal(rexpr);
                            Random rnd = new Random();
                            return rnd.NextDouble();
                        case "ran":
                            int opt2 = (int)EvaluateReal(rexpr);
                            Random rnd1 = new Random();
                            return rnd1.Next(opt2);
                        case "gcd":
                            sexp = rexpr.Split(Convert.ToChar(","));
                            n1 = sexp.Length;
                            for (int i = 0; i < n1; i++)
                                data[i] = Convert.ToInt32(EvaluateReal(sexp[i]));
                            return hcf(data, n1);
                        case "lcm":
                            sexp = rexpr.Split(Convert.ToChar(","));
                            n1 = sexp.Length;
                            for (int i = 0; i < n1; i++)
                                data[i] = Convert.ToInt32(EvaluateReal(sexp[i]));
                            return lcma(data, n1);
                        case "fu":
                            int pos1 = rexpr.LastIndexOf(Convert.ToChar(";"));
                            string a1 = (rexpr.Substring(0, pos1)).ToString();
                            double b2 = EvaluateReal(rexpr.Substring(pos1 + 1));
                            return FEval(a1, "x", b2);
                        case "∫":
                            sexp = rexpr.Split(Convert.ToChar(";"));
                            return integrate(sexp);
                        case "∑":
                            sexp = rexpr.Split(Convert.ToChar(";"));
                            fx = (sexp[0]).ToString();
                            a = EvaluateReal(sexp[1]);
                            b = EvaluateReal(sexp[2]);
                            h = EvaluateReal(sexp[3]);
                            return sum(fx, a, b, h);
                        case "rectify":
                            sexp = rexpr.Split(Convert.ToChar(";"));
                            fx = (sexp[0]).ToString();
                            a = EvaluateReal(sexp[1]);
                            b = EvaluateReal(sexp[2]);
                            return rectify(fx, a, b);
                        case "∏":
                            sexp = rexpr.Split(Convert.ToChar(";"));
                            fx = (sexp[0]).ToString();
                            a = EvaluateReal(sexp[1]);
                            b = EvaluateReal(sexp[2]);
                            h = EvaluateReal(sexp[3]);
                            return product(fx, a, b, h);
                        case @"d\dx":
                            sexp = rexpr.Split(Convert.ToChar(";"));
                            fx = (sexp[0]).ToString();
                            a = EvaluateReal(sexp[1]);
                            return Convert.ToDouble(diffrentiate(fx, "x", a));
                        case "lim":
                            sexp = rexpr.Split(Convert.ToChar(";"));
                            fx = (sexp[0]).ToString();
                            a = EvaluateReal(sexp[1]);
                            return limitEval(fx, a);
                        case "cont":
                            sexp = rexpr.Split(Convert.ToChar(";"));
                            string fxc = sexp[0];
                            double fxc1 = EvaluateReal(sexp[1]);
                            return checkContinuity(fxc, fxc1);
                        case "equ":
                            sexp = rexpr.Split(Convert.ToChar(";"));
                            return equ(sexp);
                        case "ftable":
                            sexp = rexpr.Split(Convert.ToChar(";"));
                            fx = (sexp[0]).ToString();
                            a = EvaluateReal(sexp[1]);
                            b = EvaluateReal(sexp[2]);
                            h = EvaluateReal(sexp[3]);
                            return ftable(fx, a, b, h);
                        case "conv":
                            sexp = rexpr.Split(Convert.ToChar(","));
                            int n3 = (int)EvaluateReal(sexp[0]);
                            int b3 = (int)EvaluateReal(sexp[1]);
                            b = EvaluateReal(sexp[2]);
                            return b * this.conversion(n3, b3);
                        case "pD":
                            sexp = rexpr.Split(Convert.ToChar(";"));
                            fx = (sexp[0]).ToString();
                            char a2 = Convert.ToChar(sexp[1]);
                            b = EvaluateReal(sexp[2]);
                            double c5 = EvaluateReal(sexp[3]);
                            double c6 = EvaluateReal(sexp[4]);
                            return this.partial_derivative(fx, a2, b, c5, c6);
                        case "constAdd":
                            sexp = rexpr.Split(';');
                            m_Primatives[sexp[0]] = EvaluateReal(sexp[1]);
                            return 0;
                        case "mean":
                            return mean(rexpr);
                        case "median":
                            return median(rexpr);
                        case "mode":
                            return modeS(rexpr);
                        case "sum":
                            return sum(rexpr);
                        case "sd":
                            return SD(rexpr);
                        case "sdp":
                            return SDP(rexpr);
                        case "range":
                            return range(rexpr);
                        case "cov":
                            return cov(rexpr);
                        case "corr":
                            return corr(rexpr);
                        case "chart":
                            chart(rexpr);
                            return 0;
                        case "qd":
                            if (rexpr == "X")
                                return Quartile(DataX);
                            else if (rexpr == "Y")
                                return Quartile(DataY);
                            else
                                return 0;
                        case "cfit":
                            Regression(int.Parse(rexpr));
                            return 0;
                        case "min":
                            return minD(rexpr);
                        case "max":
                            return maxD(rexpr);
                        case "Bin":
                            BinDist(rexpr);
                            return 0;
                        case "pois":
                            PoisDist(rexpr);
                            return 0;
                        case "Norm":
                            NormDist(rexpr);
                            return 0;
                        case "Z":
                            return SNV(EvaluateReal(rexpr));
                        case "pr":
                            double x = EvaluateReal(rexpr);
                            return Phi(x);
                        case "Q":
                            return Math.Abs(Phi(EvaluateReal(rexpr)) - 0.5);
                        case "r":
                            return 1 - Phi(EvaluateReal(rexpr));
                        case "S":
                            sexp = rexpr.Split(',');
                            return Phi(EvaluateReal(sexp[1])) - Phi(EvaluateReal(sexp[0]));
                        case "area":
                            return area(rexpr);
                        case "peri":
                            return perimeter(rexpr);
                        case "vol":
                            return volume(rexpr);
                        case "dist":
                            return dist(rexpr);
                        case "tri":
                            return SolveTri(rexpr);
                        case "midpoint":
                            return secF(1, rexpr);
                        case "secf":
                            return secF(2, rexpr);
                        case "centroid":
                            return secF(3, rexpr);
                        case "solveTri":
                            return SolveTri2(rexpr);
                        case "circle":
                            circle(rexpr);
                            return 0;
                        case "print":
                            return EvaluateReal(rexpr);
                        case "parabola":
                            parabola(rexpr);
                            return 0;
                        case "ellipse":
                            ellipse(rexpr);
                            return 0;
                        case "hyperbola":
                            hyperbola(rexpr);
                            return 0;
                        case "disp":
                            display(rexpr);
                            return 0;
                        case "key":
                            try
                            {
                                string[] temp;
                                temp = rexpr.Split(',');
                                n1 = temp.Length;
                                key = new string[n1];
                                for (int i = 0; i < n1; i++)
                                    key[i] = (temp[i]).ToString();
                            }
                            catch
                            {
                                throw new ArgumentException("Error resolving arguments");
                            }
                            return 0;
                        case "fplot":
                            graph(rexpr);
                            return 0;
                        default:
                            {
                                if (func_List.Contains(lexpr))
                                {
                                    string temp=(string)func_List[lexpr];
                                    double value = FEval(temp, "x", EvaluateReal(rexpr));
                                    return value;
                                }
                                return 0;
                            }
                    }
                }
            }
           
            if (expr_len > 1 & expr.EndsWith("}"))
            {
                int paren_pos = expr.IndexOf("{");
                if (paren_pos > 0)
                {
                    lexpr = expr.Substring(0, paren_pos);
                    rexpr = expr.Substring(paren_pos + 1, expr_len - paren_pos - 2);
                    switch (lexpr)
                    {
                        case "f":
                            try
                            {
                                sexp = rexpr.Split(',');
                                n1 = sexp.Length;
                                freq = new double[n1];
                                for (int i = 0; i < n1; i++)
                                    freq[i] = EvaluateReal(sexp[i]);
                            }
                            catch
                            {
                                throw new ArgumentException("Error resolving arguments");
                            }
                            return 0;
                        case "X":
                            try
                            {
                                sexp = rexpr.Split(',');
                                n1 = sexp.Length;
                                DataX = new double[n1];
                                for (int i = 0; i < n1; i++)
                                    DataX[i] = EvaluateReal(sexp[i]);
                                m_Primatives["nX"] = n1;
                            }
                            catch
                            {
                                throw new ArgumentException("Error resolving arguments");
                            }
                            return 0;
                        case "Y":
                            try
                            {
                                sexp = rexpr.Split(',');
                                n1 = sexp.Length;
                                DataY = new double[n1];
                                for (int i = 0; i < n1; i++)
                                    DataY[i] = EvaluateReal(sexp[i]);
                                m_Primatives["nY"] = n1;
                            }
                            catch
                            {
                                throw new ArgumentException("Error resolving arguments");
                            }
                            return 0;
                    }
                }
            }
            if (m_Primatives.Contains(expr))
            {
                try
                {
                    double value = double.Parse(m_Primatives[expr].ToString());
                    return value;
                }
                catch (Exception)
                {
                    throw new FormatException("Primative '" + expr + "' has value '" + m_Primatives[expr].ToString() + "' which is not a Double.");
                }
            }
            try
            {
                double value = double.Parse(expr);
                return value;
            }
            catch (Exception)
            {
                throw new FormatException("Error evaluating '" + expression + "' as a constant.");
            }
        }
        public int GetNthIndex(string s, char t, int n)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == t)
                {
                    count++;
                    if (count == n)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        public string decToFrac(double d)
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
        public static long GCD(long a, long b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
        private double perc(string st12, string st22)
        {
            double a = EvaluateReal(st12);
            double b = EvaluateReal(st22);
            return (a / b) * 100;
        }
        private void hyperbola(string rexpr)
        {
            Conics con = new Conics();
            string[] temp = rexpr.Split(';');
            double a = EvaluateReal(temp[0]);
            double b = EvaluateReal(temp[1]);
            conics.Clear();
            if (a > b)
            {
                double e = Math.Sqrt(1 + ((b * b) / (a * a)));
                conics["Equation"] = "x²/" + a * a + "- y²/" + b * b + "=1";
                conics["Centre"] = "( 0, 0 )";
                conics["Vertices"] = "( " + a + " , 0 ) , ( " + -a + " , 0 )";
                conics["Foci"] = "( " + a * e + " , 0 ) , ( " + -a * e + " , 0 )";
                conics["Length of transverse Axis"] = 2 * a;
                conics["Length of Conjugate Axis"] = 2 * b;
                conics["Equation of Transverse Axis"] = "y = 0";
                conics["Equation of Conjugate Axis"] = " x = 0";
                conics["Equation of Directrices"] = " x =" + a / e + " , " + "x = " + -a / e;
                conics["Eccentricity"] = e;
                conics["Length of Latus Rectum"] = 2 * b * b / a;
                con.Text = "Hyperbola";
                //gtitle = "x²/" + a * a + "- y²/" + b * b + "=1";
                graph("2;" + a + "*sec(t);" + b + "*Tan(t)");
                con.Show();
            }
            if (b > a)
            {
                double e = Math.Sqrt(1 + ((a * a) / (b * b)));
                conics["Equation"] = "y²/" + a * a + "-x²/" + b * b + "=1";
                conics["Centre"] = "( 0, 0 )";
                conics["Vertices"] = "( 0 ," + b + " ) , ( 0 ," + -b + " )";
                conics["Foci"] = "( 0 ," + b * e + " ) , ( 0 ," + -b * e + " )";
                conics["Length of Transverse Axis"] = 2 * b;
                conics["Length of Conjugate Axis"] = 2 * a;
                conics["Equation of Transverse Axis"] = "x = 0";
                conics["Equation of Conjugate Axis"] = " y = 0";
                conics["Equation of Directrices"] = " y =" + b / e + " , " + "y = " + -b / e;
                conics["Eccentricity"] = e;
                conics["Length of Latus Rectum"] = 2 * a * a / b;
                con.Text = "Hyperbola";
              //  gtitle = "y²/" + a * a + "-x²/" + b * b + "=1";
                graph("2;" + b + "*Tan(t);" + a + "*sec(t)");
                con.Show();
            }
        }
        private void ellipse(string rexpr)
        {
            Conics con = new Conics();
            string[] temp = rexpr.Split(';');
            double a = EvaluateReal(temp[0]);
            conics.Clear();
            double b = EvaluateReal(temp[1]);
            if (a > b)
            {
                double e = Math.Sqrt(1 - ((b * b) / (a * a)));
                conics["Equation"] = "x²/" + a * a + "+y²/" + b * b + "=1";
                conics["Centre"] = "( 0, 0 )";
                conics["Vertices"] = "( " + a + " , 0 ) , ( " + -a + " , 0 )";
                conics["Foci"] = "( " + a * e + " , 0 ) , ( " + -a * e + " , 0 )";
                conics["Length of Major Axis"] = 2 * a;
                conics["Length of Minor Axis"] = 2 * b;
                conics["Equation of Major Axis"] = "y = 0";
                conics["Equation of Minor Axis"] = " x = 0";
                conics["Equation of Directrices"] = " x =" + a / e + " , " + "x = " + -a / e;
                conics["Eccentricity"] = e;
                conics["Length of Latus Rectum"] = 2 * b * b / a;
                conics["Focal Distance of P(x,y)"] = a + "±" + e + "x";
                con.Text = "Ellipse";
               // gtitle = "x²/" + a * a + "+y²/" + b * b + "=1";
                graph("2;" + a + "*cos(t);" + b + "*sin(t)");
                con.Show();
            }
            if (b > a)
            {
                double e = Math.Sqrt(1 - ((a * a) / (b * b)));
                conics["Equation"] = "x²/" + a * a + "+y²/" + b * b + "=1";
                conics["Centre"] = "( 0, 0 )";
                conics["Vertices"] = "( 0 ," + b + " ) , ( 0 ," + -b + " )";
                conics["Foci"] = "( 0 ," + b * e + " ) , ( 0 ," + -b * e + " )";
                conics["Length of Major Axis"] = 2 * b;
                conics["Length of Minor Axis"] = 2 * a;
                conics["Equation of Major Axis"] = "x = 0";
                conics["Equation of Minor Axis"] = " y = 0";
                conics["Equation of Directrices"] = " y =" + b / e + " , " + "y = " + -b / e;
                conics["Eccentricity"] = e;
                conics["Length of Latus Rectum"] = 2 * a * a / b;
                conics["Focal Distance of P(x,y)"] = b + "±" + e + "y";
                //gtitle = "x²/" + a * a + "+y²/" + b * b + "=1";
                graph("2;" + a + "*sin(t);" + b + "*cos(t)");
                con.Show();
            }
        }
        private void parabola(string rexpr)
        {
            Conics con = new Conics();
            string[] temp = rexpr.Split(';');
            int ch = int.Parse(temp[0]);
            conics.Clear();
            if (ch == 0)
            {
                double a = EvaluateReal(temp[1]);
                conics["Vertex"] = "( 0, 0 )";
                conics["Equation"] = "y²=" + 4*a + "x";
                conics["Focus"] = "( " + a + " , 0 )";
                conics["Directrix"] = " x =" + -a;
                conics["Axis"] = " y = 0 ";
                conics["Length of Latus Rectum"] = 4 * a;
                conics["Focal Distance of P(x,y)"] = a + "+ x";
                graph("2;" + a + "*t*t;" + "2*" + a + "*t");
               // gtitle = "y²=" + 4 * a + "x";
                con.Show();
            }
            if (ch == 1)
            {
                double a = EvaluateReal(temp[1]);
                conics["Vertex"] = "( 0, 0 )";
                conics["Focus"] = "( " + -a + " , 0 )";
                conics["Equation"] = "y²=-" + 4*a + "x";
                conics["Directrix"] = " x =" + a;
                conics["Axis"] = " y = 0 ";
                conics["Length of Latus Rectum"] = 4 * a;
                conics["Focal Distance of P(x,y)"] = a + "- x";
                graph("2;" + -a + "*t*t;" + "2*" + a + "*t");
                //gtitle = "y²=-" + 4 * a + "x";
                con.Show();
            }
            if (ch == 2)
            {
                double a = EvaluateReal(temp[1]);
                conics["Vertex"] = "( 0, 0 )";
                conics["Focus"] = "( 0 ," + a + " )";
                conics["Equation"] = "x²=" + 4*a + "y";
                conics["Directrix"] = " y =" + -a;
                conics["Axis"] = " x = 0 ";
                conics["Length of Latus Rectum"] = 4 * a;
                conics["Focal Distance of P(x,y)"] = a + " + y";
                //gtitle = "x²=" + 4 * a + "y";
                graph("2;" + "2*" + a + "*t;" + a + "*t*t;");
                con.Show();
            }
            if (ch == 3)
            {
                double a = EvaluateReal(temp[1]);
                conics["Vertex"] = "( 0, 0 )";
                conics["Focus"] = "( 0 ," + -a + " )";
                conics["Equation"] = "x²=-" + 4*a + "y";
                conics["Directrix"] = " y =" + a;
                conics["Axis"] = " x = 0 ";
                conics["Length of Latus Rectum"] = 4 * a;
                conics["Focal Distance of P(x,y)"] = a + " - y";
                //gtitle = "x²=-" + 4 * a + "y";
                graph("2;" + "2*" + a + "*t;" + -a + "*t*t;");
                con.Show();
            }
        }
        private void circle(string rexpr)
        {
            Conics con = new Conics();
            string[] temp = rexpr.Split(';');
            int ch = int.Parse(temp[0]);
            conics.Clear();
            if (ch == 0)
            {
                double r = EvaluateReal(temp[1]);
                title = "Standard Circle";
                conics["Equation"] = "x²+y²=" + r * r;
                conics["Centre"] = "( 0 , 0 )";
                con.Text = title;
                graph("2;" + r + "*cos(t);" + r + "*sin(t)");
                gtitle = "x²+y²=" + r * r;
                con.Show();
            }
            if (ch == 1)
            {
                double g = -EvaluateReal(temp[1]);
                double f = -EvaluateReal(temp[2]);
                double r = g * g + f * f - 1;
                title = "General Circle";
                double d = Math.Sqrt(r);
                conics["Equation"] = "(x " + assign(g) + g + ")²+(y " + assign(f) + f + ")²=" + r;
                conics["Centre"] = "( " + -g + " , " + -f + " )";
                conics["Radius"] = d;
                con.Text = title;
                gtitle = "(x " + assign(g) + g + ")²+(y " + assign(f) + f + ")²=" + r;
                graph("2;" + -g + "+" + d + "*cos(t);" + -f + "+" + d + "*sin(t)");
                con.Show();
            }
        }
        private double secF(int p, string rexpr)
        {
            string[] temp = rexpr.Split(',');
            if (p == 1)
            {
                double x1 = EvaluateReal(temp[0]);
                double x2 = EvaluateReal(temp[2]);
                double y1 = EvaluateReal(temp[1]);
                double y2 = EvaluateReal(temp[3]);
                double x = (x1 + x2) / 2.0;
                double y = (y1 + y2) / 2.0;
                solutions.Add(x.ToString());
                solutions.Add(y.ToString());
                return 0;
            }
            if (p == 2)
            {
                int ch = int.Parse(temp[0]);
                if (ch == 1)
                {
                    double x1 = EvaluateReal(temp[1]);
                    double x2 = EvaluateReal(temp[3]);
                    double y1 = EvaluateReal(temp[2]);
                    double y2 = EvaluateReal(temp[4]);
                    double m = EvaluateReal(temp[5]);
                    double n = EvaluateReal(temp[6]);
                    double x = (m * x2 + n * x1) / (m + n);
                    double y = (m * y2 + n * y1) / (m + n);
                    solutions.Add(x.ToString());
                    solutions.Add(y.ToString());
                    return 0;
                }
                if (ch == 2)
                {
                    double x1 = EvaluateReal(temp[1]);
                    double x2 = EvaluateReal(temp[3]);
                    double y1 = EvaluateReal(temp[2]);
                    double y2 = EvaluateReal(temp[4]);
                    double m = EvaluateReal(temp[5]);
                    double n = EvaluateReal(temp[6]);
                    double x = (m * x2 - n * x1) / (m - n);
                    double y = (m * y2 - n * y1) / (m - n);
                    solutions.Add(x.ToString());
                    solutions.Add(y.ToString());
                    return 0;
                }
                throw new Exception("Syntax Error");
            }
            if (p == 3)
            {
                double x1 = EvaluateReal(temp[0]);
                double x2 = EvaluateReal(temp[2]);
                double x3 = EvaluateReal(temp[4]);
                double y1 = EvaluateReal(temp[1]);
                double y2 = EvaluateReal(temp[3]);
                double y3 = EvaluateReal(temp[5]);
                double x = (x1 + x2 + x3) / 3.0;
                double y = (y1 + y2 + y3) / 3.0;
                solutions.Add(x.ToString());
                solutions.Add(y.ToString());
                return 0;
            }
            else
                throw new Exception("Syntax Error");
        }
        private double SolveTri(string rexpr)
        {
            string[] temp = rexpr.Split(',');
            if (temp[0] == "x")//A unknown
            {
                double B = EvaluateReal(temp[1]);
                double C = EvaluateReal(temp[2]);
                double a = EvaluateReal(temp[3]);
                double b = EvaluateReal(temp[4]);
                double c = EvaluateReal(temp[5]);
                double s = b * b + c * c - a * a;
                double d = 2 * b * c;
                double A = Math.Acos(s / d) * invfactor;
                return A;
            }
            if (temp[1] == "x")//B unknown
            {
                double A = EvaluateReal(temp[0]);
                double C = EvaluateReal(temp[2]);
                double a = EvaluateReal(temp[3]);
                double b = EvaluateReal(temp[4]);
                double c = EvaluateReal(temp[5]);
                double s = a * a + c * c - b * b;
                double d = 2 * a * c;
                double B = Math.Acos(s / d) * invfactor;
                return B;
            }
            if (temp[2] == "x")//C unknown
            {
                double A = EvaluateReal(temp[0]);
                double B = EvaluateReal(temp[1]);
                double a = EvaluateReal(temp[3]);
                double b = EvaluateReal(temp[4]);
                double c = EvaluateReal(temp[5]);
                double s = b * b + a * a - c * c;
                double d = 2 * a * b;
                double C = Math.Acos(s / d) * invfactor;
                return C;
            }
            if (temp[3] == "x")//a unknown
            {
                double A = EvaluateReal(temp[0]);
                double B = EvaluateReal(temp[1]);
                double C = EvaluateReal(temp[2]);
                double b = EvaluateReal(temp[4]);
                double c = EvaluateReal(temp[5]);
                double s = b * b + c * c - 2 * b * c * Math.Cos(A * factor);
                double a = Math.Sqrt(s);
                return a;
            }
            if (temp[4] == "x")//b unknown
            {
                double A = EvaluateReal(temp[0]);
                double B = EvaluateReal(temp[1]);
                double C = EvaluateReal(temp[2]);
                double a = EvaluateReal(temp[3]);
                double c = EvaluateReal(temp[5]);
                double s = a * a + c * c - 2 * a * c * Math.Cos(B * factor);
                double b = Math.Sqrt(s);
                return b;
            }
            if (temp[5] == "x")//c unknown
            {
                double A = EvaluateReal(temp[0]);
                double B = EvaluateReal(temp[1]);
                double C = EvaluateReal(temp[2]);
                double a = EvaluateReal(temp[3]);
                double b = EvaluateReal(temp[4]);
                double s = b * b + a * a - 2 * a * b * Math.Cos(C * factor);
                double c = Math.Sqrt(s);
                return c;
            }
            else
                throw new Exception("Syntax Error");
        }
        private double SolveTri2(string rexpr)
        {
            string[] temp = rexpr.Split(',');
            int ch = int.Parse(temp[0]);
            if (ch == 0) //two sides one angle
            {
                double s1 = EvaluateReal(temp[1]);
                double s2 = EvaluateReal(temp[2]);
                double t = EvaluateReal(temp[3]);
                double d = s1 * s1 + s2 * s2 - 2 * s1 * s2 * Math.Cos(t * factor);
                return Math.Sqrt(d);
            }
            if (ch == 1) //three sides one angle
            {
                try
                {
                    double a = EvaluateReal(temp[1]);
                    double b = EvaluateReal(temp[2]);
                    double c = EvaluateReal(temp[3]);
                    if (temp[4] == "A")
                    {
                        double s = b * b + c * c - a * a;
                        double d = 2 * b * c;
                        double A = Math.Acos(s / d) * invfactor;
                        return A;
                    }
                    if (temp[4] == "B")
                    {
                        double s = a * a + c * c - b * b;
                        double d = 2 * a * c;
                        double B = Math.Acos(s / d) * invfactor;
                        return B;
                    }
                    if (temp[4] == "C")
                    {
                        double s = b * b + a * a - c * c;
                        double d = 2 * a * b;
                        double C = Math.Acos(s / d) * invfactor;
                        return C;
                    }
                }
                catch
                {
                    throw new Exception("Syntax Error");
                }
            }
            throw new Exception("Syntax Error");
        }
        private double dist(string rexpr)
        {
            string[] temp = rexpr.Split(',');
            int ch = int.Parse(temp[0]);
            if (ch == 1)
            {
                double x1 = EvaluateReal(temp[1]);
                double x2 = EvaluateReal(temp[3]);
                double y1 = EvaluateReal(temp[2]);
                double y2 = EvaluateReal(temp[4]);
                double x = (x2 - x1) * (x2 - x1);
                double y = (y2 - y1) * (y2 - y1);
                return Math.Sqrt(x + y);
            }
            if (ch == 2)
            {
                double a = EvaluateReal(temp[1]);
                double b = EvaluateReal(temp[2]);
                double c = EvaluateReal(temp[3]);
                double x = EvaluateReal(temp[4]);
                double y = EvaluateReal(temp[5]);
                double d = a * x + b * y + c;
                double s = Math.Sqrt(a * a + b * b);
                return Math.Abs(d / s);
            }
            if (ch == 3)
            {
                double a = EvaluateReal(temp[1]);
                double b = EvaluateReal(temp[2]);
                double c1 = EvaluateReal(temp[3]);
                double c2 = EvaluateReal(temp[4]);
                double d = c2 - c1;
                double s = Math.Sqrt(a * a + b * b);
                return Math.Abs(d / s);
            }
            else
                throw new Exception("Syntax Error");
        }
        private void display(string rexpr)
        {
            if (DataX == null & DataY == null)
                throw new Exception("Data sets are empty");
            else
            {
                string x="",y="";
                if (rexpr == "X")
                {
                    for (int i = 0; i < DataX.Length; i++)
                        solutions.Add(DataX[i].ToString());
                }
                if (rexpr == "Y")
                {
                    for (int i = 0; i < DataY.Length; i++)
                        solutions.Add(DataY[i].ToString());
                }
                if (rexpr == "freq")
                {
                    for (int i = 0; i < freq.Length; i++)
                        solutions.Add(freq[i].ToString());
                }
                if (rexpr == "X,Y" && DataX != null && DataY != null)
                {
                    x += string.Format(string.Join(",", DataX));
                    y += string.Format(string.Join(",", DataY));
                    solutions.Add(x);
                    solutions.Add(y);
                }
            }
        }
        private double volume(string rexpr)
        {
            string[] temp = rexpr.Split(',');
            int ch = int.Parse(temp[0]);
            if (ch == 0)
            {
                return EvaluateReal(temp[1]) * EvaluateReal(temp[1]) * EvaluateReal(temp[1]);//cube
            }
            if (ch == 1)
            {
                return (EvaluateReal(temp[1]) * EvaluateReal(temp[2]) * EvaluateReal(temp[3]));//rect
            }
            if (ch == 2)//cylinder
            {
                return Math.PI * EvaluateReal(temp[1]) * EvaluateReal(temp[1]) * EvaluateReal(temp[2]);
            }
            if (ch == 3)//cone
            {
                return 0.33333333333333333333333333 * Math.PI * EvaluateReal(temp[1]) * EvaluateReal(temp[1]) * EvaluateReal(temp[2]);
            }
            if (ch == 4)//sphere
            {
                return 1.3333333333333333333333333333333 * Math.PI * Math.Pow(EvaluateReal(temp[1]), 3);
            }
            if (ch == 5)//hemisphere
            {
                return 0.66666666666666666666666666666667 * Math.PI * Math.Pow(EvaluateReal(temp[1]), 3);
            }
            else
                throw new Exception("Syntax Error");
        }
        private double perimeter(string rexpr)
        {
            string[] temp = rexpr.Split(',');
            int ch = int.Parse(temp[0]);
            if (ch == 0)
            {
                return 4 * EvaluateReal(temp[1]);//square
            }
            if (ch == 1)
            {
                return 2 * (EvaluateReal(temp[1]) + EvaluateReal(temp[2]));//rect
            }
            if (ch == 2)
            {
                return EvaluateReal(temp[1]) + EvaluateReal(temp[2]) + EvaluateReal(temp[3]);
            }
            if (ch == 3)
            {
                return 2 * Math.PI * EvaluateReal(temp[1]);
            }
            else
                throw new Exception("Syntax Error");
        }
        private double area(string rexpr)
        {
            string[] temp = rexpr.Split(',');
            int ch = int.Parse(temp[0]);
            if (ch == 0)
            {
                return EvaluateReal(temp[1]) * EvaluateReal(temp[1]);//square
            }
            if (ch == 1)
            {
                return (EvaluateReal(temp[1]) * EvaluateReal(temp[2]));//rect
            }
            if (ch == 2)
            {
                return EvaluateReal(temp[1]) * EvaluateReal(temp[2]) * 0.5;
            }
            if (ch == 3)
            {
                double s = EvaluateReal(temp[1]) + EvaluateReal(temp[2]) + EvaluateReal(temp[3]);
                s *= 0.5;
                return Math.Sqrt(s * (s - EvaluateReal(temp[1])) * (s - EvaluateReal(temp[2])) * (s - EvaluateReal(temp[3])));
            }
            if (ch == 4)
            {
                return EvaluateReal(temp[1]) * EvaluateReal(temp[2]);
            }
            if (ch == 5)
            {
                return EvaluateReal(temp[1]) * EvaluateReal(temp[2]) * 0.5;
            }
            if (ch == 6)
            {
                return EvaluateReal(temp[1]) + EvaluateReal(temp[2]) * EvaluateReal(temp[2]) * 0.5;
            }
            if (ch == 7)
            {
                return EvaluateReal(temp[1]) * EvaluateReal(temp[1]) * Math.PI;
            }
            else
                throw new Exception("Syntax Error");
        }
        private double SNV(double x)
        {
            double z = 0, m = 0, sd = 0, s = 0;
            if (DataX == null && DataY == null && freq == null)
                throw new Exception("Data sets cannot be empty");
            if (DataX != null && DataY == null)
            {
                for (int i = 0; i < DataX.Length; i++)
                    s += DataX[i] * freq[i];
                m = s / DataX.Length;
                sd = StandardDev(DataX);
            }
            if (DataY != null && DataX == null)
            {
                for (int i = 0; i < DataY.Length; i++)
                    s += DataY[i] * freq[i];
                m = s / DataY.Length;
                sd = StandardDev(DataY);
            }
            z = (x - m) / sd;
            if (x < 0)
                z = (x + m) / sd;
            return z;
        }
        static double Phi(double x)
        {
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;
            int sign = 1;
            if (x < 0)
                sign = -1;
            x = Math.Abs(x) / Math.Sqrt(2.0);
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);
            return Math.Abs(0.5 * (1.0 + sign * y));
        }
        private Tuple<double, double> SimulEq2(double a1, double a2, double b1, double b2, double c1, double c2)
        {
            double d, dx, dy, x, y;
            d = a1 * b2 - b1 * a2;
            dx = c1 * b2 - b1 * c2;
            dy = a1 * c2 - c1 * a2;
            x = dx / d;
            y = dy / d;
            return Tuple.Create(x, y);
        }
        private Tuple<double, double, double> SimulEq3(double a1, double a2, double a3, double b1, double b2, double b3, double c1, double c2, double c3, double d1, double d2, double d3)
        {
            double d = a1 * (b2 * c3 - c2 * b3) - b1 * (a2 * c3 - a3 * c2) + c1 * (a2 * b3 - b2 * a3);
            double dx = d1 * (b2 * c3 - c2 * b3) - b1 * (d2 * c3 - d3 * c2) + c1 * (d2 * b3 - b2 * d3);
            double dy = a1 * (d2 * c3 - c2 * d3) - d1 * (a2 * c3 - a3 * c2) + c1 * (a2 * d3 - d2 * a3);
            double dz = a1 * (b2 * d3 - d2 * b3) - b1 * (a2 * d3 - a3 * d2) + d1 * (a2 * b3 - b2 * a3);
            double x = 0, y = 0, z = 0;
            x = dx / d;
            y = dy / d;
            z = dz / d;
            return Tuple.Create(x, y, z);
        }
        private void FitLine1(double[] x, double[] y)
        {
            double sxy = 0, sx = 0, sx2 = 0, sy = 0;
            int n = x.Length;
            if (freq == null)
            {
                for (int i = 0; i < n; i++)
                    sx += x[i];
                for (int i = 0; i < n; i++)
                    sy += y[i];
                for (int i = 0; i < n; i++)
                    sxy += (x[i] * y[i]);
                for (int i = 0; i < n; i++)
                    sx2 += (x[i] * x[i]);
            }
            else
            {
                for (int i = 0; i < n; i++)
                    sx += x[i] * freq[i];
                for (int i = 0; i < n; i++)
                    sy += y[i] * freq[i];
                for (int i = 0; i < n; i++)
                    sxy += (x[i] * y[i] * freq[i]);
                for (int i = 0; i < n; i++)
                    sx2 += (x[i] * x[i] * freq[i]);
            }
            m_Primatives["a"] = SimulEq2(n, sx, sx, sx2, sy, sxy).Item1;
            m_Primatives["b"] = SimulEq2(n, sx, sx, sx2, sy, sxy).Item2;
            m_Primatives["bY"] = sxy / sx2;
        }
        private void FitLine2(double[] x, double[] y)
        {
            double sxy = 0, sx = 0, sy2 = 0, sy = 0;
            int n = x.Length;
            if (freq == null)
            {
                for (int i = 0; i < n; i++)
                    sx += x[i];
                for (int i = 0; i < n; i++)
                    sy += y[i];
                for (int i = 0; i < n; i++)
                    sxy += (x[i] * y[i]);
                for (int i = 0; i < n; i++)
                    sy2 += (y[i] * y[i]);
            }
            else
            {
                for (int i = 0; i < n; i++)
                    sx += x[i] * freq[i];
                for (int i = 0; i < n; i++)
                    sy += y[i] * freq[i];
                for (int i = 0; i < n; i++)
                    sxy += (x[i] * y[i]) * freq[i];
                for (int i = 0; i < n; i++)
                    sy2 += (y[i] * y[i]) * freq[i];
            }
            m_Primatives["a"] = SimulEq2(n, sy, sy, sy2, sx, sxy).Item1;
            m_Primatives["b"] = SimulEq2(n, sy, sy, sy2, sx, sxy).Item2;
            m_Primatives["bX"] = sxy / sy2;
        }
        private void FitPara(double[] x, double[] y)
        {
            double sx = 0, sx2 = 0, sx3 = 0, sx4 = 0, sy = 0, sxy = 0, sx2y = 0;
            int n = x.Length;
            if (freq == null)
            {
                for (int i = 0; i < n; i++)
                    sx += x[i];
                for (int i = 0; i < n; i++)
                    sy += y[i];
                for (int i = 0; i < n; i++)
                    sx2 += x[i] * x[i];
                for (int i = 0; i < n; i++)
                    sx3 += x[i] * x[i] * x[i];
                for (int i = 0; i < n; i++)
                    sx4 += x[i] * x[i] * x[i] * x[i];
                for (int i = 0; i < n; i++)
                    sxy += (x[i] * y[i]);
                for (int i = 0; i < n; i++)
                    sx2y += (x[i] * x[i] * y[i]);
            }
            else
            {
                for (int i = 0; i < n; i++)
                    sx += x[i] * freq[i];
                for (int i = 0; i < n; i++)
                    sy += y[i] * freq[i];
                for (int i = 0; i < n; i++)
                    sx2 += x[i] * x[i] * freq[i];
                for (int i = 0; i < n; i++)
                    sx3 += x[i] * x[i] * x[i] * freq[i];
                for (int i = 0; i < n; i++)
                    sx4 += x[i] * x[i] * x[i] * x[i] * freq[i];
                for (int i = 0; i < n; i++)
                    sxy += (x[i] * y[i]) * freq[i];
                for (int i = 0; i < n; i++)
                    sx2y += (x[i] * x[i] * y[i]) * freq[i];
            }
            m_Primatives["a"] = SimulEq3(n, sx, sx2, sx, sx2, sx3, sx2, sx3, sx4, sy, sxy, sx2y).Item1;
            m_Primatives["b"] = SimulEq3(n, sx, sx2, sx, sx2, sx3, sx2, sx3, sx4, sy, sxy, sx2y).Item2;
            m_Primatives["c"] = SimulEq3(n, sx, sx2, sx, sx2, sx3, sx2, sx3, sx4, sy, sxy, sx2y).Item3;
        }
        double calculateGM(double[] data)
        {
            int n = data.Length;
            double r = 1.0 / n;
            double p = 1;
            if (freq == null)
            {
                for (int i = 0; i < n; i++)
                    p *= data[i];
            }
            else
            {
                if (n != freq.Length)
                    throw new Exception("Data size and frequency size should match");
                for (int i = 0; i < n; i++)
                    p *= Math.Pow(data[i], freq[i]);
            }
            return Math.Pow(p, r);
        }
        double calculateHM(double[] data)
        {
            int n = data.Length;
            double r = 1.0 / n;
            double s = 0, hm = 0;
            if (freq == null)
            {
                for (int i = 0; i < n; i++)
                    s += (1 / data[i]);
                hm = Math.Pow(r * s, -1);
            }
            else
            {
                if (n != freq.Length)
                    throw new Exception("Data size and frequency size should match");
                for (int i = 0; i < n; i++)
                    s += (freq[i] / data[i]);
                hm = Math.Pow(r * s, -1);
            }
            return hm;
        }
        private void FitExp1(double[] x, double[] y)
        {
            double sy = 0, sx = 0, sxy = 0, sx2 = 0;
            int n = x.Length;
            for (int i = 0; i < n; i++)
                sx += Math.Log10(x[i]);
            for (int i = 0; i < n; i++)
                sy += Math.Log10(y[i]);
            for (int i = 0; i < n; i++)
                sxy += Math.Log10(x[i]) * Math.Log10(y[i]);
            for (int i = 0; i < n; i++)
                sx2 += Math.Log10(x[i]) * Math.Log10(x[i]);
            double b = SimulEq2(n, sx, sx, sx2, sy, sxy).Item2;
            double a = Math.Pow(10, SimulEq2(n, sx, sx, sx2, sy, sxy).Item1);
            m_Primatives["a"] = a;
            m_Primatives["b"] = b;
        }
        private void FitExp2(double[] x, double[] y)
        {
            double sy = 0, sx = 0, sxy = 0, sx2 = 0;
            int n = x.Length;
            for (int i = 0; i < n; i++)
                sx += (x[i]);
            for (int i = 0; i < n; i++)
                sy += Math.Log10(y[i]);
            for (int i = 0; i < n; i++)
                sxy += x[i] * Math.Log10(y[i]);
            for (int i = 0; i < n; i++)
                sx2 += (x[i]) * (x[i]);
            double b = (SimulEq2(n, sx, sx, sx2, sy, sxy).Item2) / (Math.Log10(Math.E));
            double a = Math.Pow(10, SimulEq2(n, sx, sx, sx2, sy, sxy).Item1);
            m_Primatives["a"] = a;
            m_Primatives["b"] = b;
        }
        private void FitExp3(double[] x, double[] y)
        {
            double sy = 0, sx = 0, sxy = 0, sx2 = 0;
            int n = x.Length;
            for (int i = 0; i < n; i++)
                sx += Math.Log10(x[i]);
            for (int i = 0; i < n; i++)
                sy += Math.Log10(y[i]);
            for (int i = 0; i < n; i++)
                sxy += Math.Log10(x[i]) * Math.Log10(y[i]);
            for (int i = 0; i < n; i++)
                sx2 += Math.Log10(x[i]) * Math.Log10(x[i]);
            double A = (SimulEq2(n, sx, sx, sx2, sy, sxy).Item1);
            double B = SimulEq2(n, sx, sx, sx2, sy, sxy).Item2;
            m_Primatives["a"] = -1 / B;
            m_Primatives["b"] = Math.Pow(10, (-A / B));
        }
        private double SDP(string rexpr)
        {
            string[] temp = rexpr.Split(',');
            if (DataX == null & DataY == null)
                throw new Exception("Data sets cannot be empty");
            if (temp[0] == "X" & DataY == null)
                return StandardDevPop(DataX);
            if (temp[0] == "Y" && DataX == null)
                return StandardDevPop(DataY);
            else
            {
                m_Primatives["spX"] = StandardDevPop(DataX);
                m_Primatives["spY"] = StandardDevPop(DataY);
                return 0;
            }
        }
        private double SD(string rexpr)
        {
            string[] temp = rexpr.Split(',');
            if (DataX == null & DataY == null)
                throw new Exception("Data sets cannot be empty");
            if (temp[0] == "X" & DataY == null)
                return StandardDev(DataX);
            if (temp[0] == "Y" & DataX == null)
                return StandardDev(DataY);
            else
            {
                m_Primatives["sX"] = StandardDev(DataX);
                m_Primatives["sY"] = StandardDev(DataY);
                return 0;
            }
        }
        private double StatMedian(double[] data)
        {
            if (freq != null)
            {
                Array.Sort(data, freq);
                if (data.Length != freq.Length)
                    throw new Exception("Data sizes should match");
                double[] cf = new double[data.Length];
                cf[0] = freq[0];
                for (int i = 1; i < freq.Length; i++)
                    cf[i] = cf[i - 1] + freq[i];
                double s = 0;
                for (int i = 0; i < freq.Length; i++)
                    s += freq[i];
                if (s % 2 != 0)
                {
                    double x = 0;
                    int y = 0;
                    for (int i = 0; i < cf.Length; i++)
                    {
                        if ((s / 2.0) <= cf[i])
                        {
                            x = cf[i];
                            y = i;
                            break;
                        }
                    }
                    return data[y];
                }
                if (s % 2 == 0)
                {
                    double maxfreq1 = s / 2.0;
                    double maxfreq2 = maxfreq1 + 1;
                    double x1 = 0, x2 = 0;
                    int y1 = 0, y2 = 0;
                    for (int i = 0; i < cf.Length; i++)
                    {
                        if ((s / 2.0) <= cf[i])
                        {
                            x1 = cf[i];
                            y1 = i;
                            break;
                        }
                    }
                    for (int i = 0; i < cf.Length; i++)
                    {
                        if (maxfreq2 <= cf[i])
                        {
                            x2 = cf[i];
                            y2 = i;
                            break;
                        }
                    }
                    double a = data[y1];
                    double b = data[y2];
                    return (a + b) / 2.0;
                }
            }
            if (freq == null)
            {
                Array.Sort(data);
                double med = 0;
                int n = data.Length;
                if (n % 2 == 0)
                {
                    double x = data[n / 2 - 1];
                    double y = data[n / 2];
                    med = (x + y) / 2.0;
                    return med;
                }
                if (n % 2 != 0)
                {
                    med = data[(n - 1) / 2];
                    return med;
                }
            }
            throw new Exception("Syntax Error");
        }
        private void Regression(int ch)
        {
            if (DataX == null & DataY == null)
                throw new Exception("Data sets cannot be empty");
            if (ch == 0)
                FitLine1(DataX, DataY);
            if (ch == 1)
                FitLine2(DataX, DataY);
            if (ch == 2)
                FitPara(DataX, DataY);
            if (ch == 3)
                FitExp1(DataX, DataY);
            if (ch == 4)
                FitExp2(DataX, DataY);
            if (ch == 5)
                FitExp3(DataX, DataY);
        }
        private double range(string rexpr)
        {
            string[] temp = rexpr.Split(',');
            if (DataX == null & DataY == null)
                throw new Exception("Data sets cannot be empty");
            if (temp[0] == "X")
                return max(DataX) - min(DataX);
            if (temp[0] == "Y")
                return max(DataY) - min(DataY);
            if (temp[0] == "X" & temp[1] == "Y")
            {
                m_Primatives["rX"] = max(DataX) - min(DataX);
                m_Primatives["rY"] = max(DataY) - min(DataY);
                return 0;
            }
            return 0;
        }
        private double corr(string rexpr)
        {
            string[] temp = rexpr.Split(',');
            if (temp[0] != "X" & temp[1] != "Y")
                throw new Exception("Argument Error");
            if (DataX == null & DataY == null)
                throw new Exception("Data sets cannot be empty");
            if (DataY.Length != DataX.Length)
                throw new Exception("Size of data sets dont match");
            return (covariance(DataX, DataY)) / (StandardDev(DataX) * StandardDev(DataY));
        }
        double min(double[] data)
        {
            double min = data[0];
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] < min)
                    min = data[i];
            }
            return min;
        }
        double max(double[] data)
        {
            double max = data[0];
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] > max)
                    max = data[i];
            }
            return max;
        }
        double max(List<double> data)
        {
            double max = data[0];
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] > max)
                    max = data[i];
            }
            return max;
        }
        double covariance(double[] DataX, double[] DataY)
        {
            double cov = 0, s = 0, s1 = 0, mx, my;
            if (DataX.Length != DataY.Length)
                throw new Exception("Dimension Error");
            if (freq == null)
            {
                for (int i = 0; i < DataX.Length; i++)
                    s += DataX[i];
                for (int i = 0; i < DataY.Length; i++)
                    s1 += DataY[i];
            }
            else
            {
                for (int i = 0; i < DataX.Length; i++)
                    s += DataX[i] * freq[i];
                for (int i = 0; i < DataY.Length; i++)
                    s1 += DataY[i] * freq[i];
            }
            mx = s / DataX.Length;
            my = s / DataY.Length;
            for (int i = 0; i < DataX.Length; i++)
            {
                cov += (DataX[i] - mx) * (DataY[i] - my);
            }
            return cov / (DataX.Length - 1);
        }
        double StandardDev(double[] data)
        {
            double sd = 0, s = 0;
            int n = data.Length;
            for (int i = 0; i < n; i++)
                s += data[i];
            double m = s / n;
            if (freq != null)
            {
                for (int i = 0; i < n; i++)
                {
                    sd += (freq[i] * (data[i] - m) * (data[i] - m));
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    sd += (data[i] - m) * (data[i] - m);
                }
            }
            return Math.Sqrt(sd / (n));
        }
        double StandardDevPop(double[] data)
        {

            double sd = 0, s = 0;
            int n = data.Length;
            for (int i = 0; i < n; i++)
                s += data[i];
            double m = s / n;
            if (freq != null)
            {
                for (int i = 0; i < n; i++)
                {
                    sd += (freq[i] * (data[i] - m) * (data[i] - m));
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    sd += (data[i] - m) * (data[i] - m);
                }
            }
            return Math.Sqrt(sd / (n - 1));
        }
        private double cov(string rexpr)
        {
            string[] temp = rexpr.Split(',');
            if (temp[0] != "X" & temp[1] != "Y")
                throw new Exception("Argument Error");
            if (DataX == null & DataY == null)
                throw new Exception("Data sets cannot be empty");
            if (DataY.Length != DataX.Length)
                throw new Exception("Size of data sets dont match");
            return covariance(DataX, DataY);
        }
        private void chart(string rexpr)
        {
            ChartStats cst = new ChartStats();
            string[] temp = rexpr.Split(',');
            Series series = cst.chart1.Series.Add("key");
            int ch = int.Parse(temp[0]);
            if (temp[2] == "X")
            {
                for (int i = 0; i < key.Length; i++)
                {
                    series.Points.AddXY(key[i], DataX[i]);
                }
            }
            if (temp[2] == "Y")
            {
                for (int i = 0; i < key.Length; i++)
                {
                    series.Points.AddXY(key[i], DataY[i]);
                }
            }
            if (DataX == null & DataY == null)
                throw new Exception("Data sets cannot be empty");
            if (is3d == 1)
                cst.chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            else
                cst.chart1.ChartAreas[0].Area3DStyle.Enable3D = false;
            if (ch == 0)
                cst.chart1.Series[0].ChartType = SeriesChartType.Area;
            if (ch == 1)
                cst.chart1.Series[0].ChartType = SeriesChartType.Bar;
            if (ch == 2)
                cst.chart1.Series[0].ChartType = SeriesChartType.BoxPlot;
            if (ch == 3)
                cst.chart1.Series[0].ChartType = SeriesChartType.Bubble;
            if (ch == 4)
                cst.chart1.Series[0].ChartType = SeriesChartType.Candlestick;
            if (ch == 5)
                cst.chart1.Series[0].ChartType = SeriesChartType.Column;
            if (ch == 6)
                cst.chart1.Series[0].ChartType = SeriesChartType.Doughnut;
            if (ch == 7)
                cst.chart1.Series[0].ChartType = SeriesChartType.ErrorBar;
            if (ch == 8)
                cst.chart1.Series[0].ChartType = SeriesChartType.FastLine;
            if (ch == 9)
                cst.chart1.Series[0].ChartType = SeriesChartType.FastPoint;
            if (ch == 10)
                cst.chart1.Series[0].ChartType = SeriesChartType.Funnel;
            if (ch == 11)
                cst.chart1.Series[0].ChartType = SeriesChartType.Kagi;
            if (ch == 12)
                cst.chart1.Series[0].ChartType = SeriesChartType.Line;
            if (ch == 13)
                cst.chart1.Series[0].ChartType = SeriesChartType.Pie;
            if (ch == 14)
                cst.chart1.Series[0].ChartType = SeriesChartType.Point;
            if (ch == 15)
                cst.chart1.Series[0].ChartType = SeriesChartType.PointAndFigure;
            if (ch == 16)
                cst.chart1.Series[0].ChartType = SeriesChartType.Polar;
            if (ch == 17)
                cst.chart1.Series[0].ChartType = SeriesChartType.Pyramid;
            if (ch == 18)
                cst.chart1.Series[0].ChartType = SeriesChartType.Radar;
            if (ch == 19)
                cst.chart1.Series[0].ChartType = SeriesChartType.Range;
            if (ch == 20)
                cst.chart1.Series[0].ChartType = SeriesChartType.RangeBar;
            if (ch == 21)
                cst.chart1.Series[0].ChartType = SeriesChartType.RangeColumn;
            if (ch == 22)
                cst.chart1.Series[0].ChartType = SeriesChartType.Renko;
            if (ch == 23)
                cst.chart1.Series[0].ChartType = SeriesChartType.Spline;
            if (ch == 24)
                cst.chart1.Series[0].ChartType = SeriesChartType.SplineArea;
            if (ch == 25)
                cst.chart1.Series[0].ChartType = SeriesChartType.SplineRange;
            if (ch == 26)
                cst.chart1.Series[0].ChartType = SeriesChartType.StackedArea;
            if (ch == 27)
                cst.chart1.Series[0].ChartType = SeriesChartType.StackedArea100;
            if (ch == 28)
                cst.chart1.Series[0].ChartType = SeriesChartType.StackedBar;
            if (ch == 29)
                cst.chart1.Series[0].ChartType = SeriesChartType.StackedBar100;
            if (ch == 30)
                cst.chart1.Series[0].ChartType = SeriesChartType.StackedColumn;
            if (ch == 31)
                cst.chart1.Series[0].ChartType = SeriesChartType.StackedColumn100;
            if (ch == 32)
                cst.chart1.Series[0].ChartType = SeriesChartType.StepLine;
            if (ch == 33)
                cst.chart1.Series[0].ChartType = SeriesChartType.Stock;
            if (ch == 34)
                cst.chart1.Series[0].ChartType = SeriesChartType.ThreeLineBreak;
            cst.Show();
        }
        private double minD(string rexpr)
        {
            double min1 = 0;
            double min2 = 0;
            string[] temp = rexpr.Split(',');
            if (temp[0] == "X")
            {
                min1 = DataX[0];
                for (int i = 0; i < DataX.Length; i++)
                {
                    if (DataX[i] < min1)
                        min1 = DataX[i];
                }
                return min1;
            }
            else if (temp[0] == "Y")
            {
                min1 = DataY[0];
                for (int i = 0; i < DataY.Length; i++)
                {
                    if (DataY[i] < min1)
                        min1 = DataY[i];
                }
                return min1;
            }
            else if (temp[0] == "X" && temp[1] == "Y")
            {
                double min = 0;
                min1 = DataX[0];
                min2 = DataY[0];
                for (int i = 0; i < DataY.Length; i++)
                {
                    if (DataY[i] < min2)
                        min2 = DataY[i];
                    if (DataX[i] < min1)
                        min1 = DataX[i];
                    if (min1 < min2)
                        min = min1;
                    else if (min2 < min1)
                        min = min2;
                }
                return min;
            }
            return min1;
        }
        private double maxD(string rexpr)
        {
            double max1 = 0;
            double max2 = 0;
            string[] temp = rexpr.Split('.');
            if (temp[0] == "X")
            {
                max1 = DataX[0];
                for (int i = 0; i < DataX.Length; i++)
                {
                    if (DataX[i] > max1)
                        max1 = DataX[i];
                }
                return max1;
            }
            else if (temp[0] == "Y")
            {
                max1 = DataY[0];
                for (int i = 0; i < DataY.Length; i++)
                {
                    if (DataY[i] > max1)
                        max1 = DataY[i];
                }
                return max1;
            }
            else if (temp[0] == "X" && temp[1] == "Y")
            {
                double max = 0;
                max1 = DataX[0];
                max2 = DataY[0];
                for (int i = 0; i < DataY.Length; i++)
                {
                    if (DataY[i] > max2)
                        max2 = DataY[i];
                    if (DataX[i] > max1)
                        max1 = DataX[i];
                    if (max1 > max2)
                        max = max1;
                    else if (max2 > max1)
                        max = max2;
                }
                return max; ;
            }
            return max1;
        }
        double Quartile(double[] data)
        {
            if (data == null)
                throw new Exception("Data set cannot be empty");
            double q1, q2, q3;
            Array.Sort(data);
            int n = data.Length;
            double x = Dec((n + 1) / 4.0);
            double y = Dec(0.75 * (n + 1));
            double v = 0.75 * (n + 1);
            q1 = data[(n - 3) / 4] + x * (data[n / 4] - data[(n - 3) / 4]);
            q3 = data[(int)v - 1] + y * (data[(int)v] - data[(int)v - 1]);
            q2 = (q3 - q1) / 2;
            return q2;
        }
        double StatMode(double[] data)
        {
            if (freq != null)
            {
                if (data.Length != freq.Length)
                    throw new Exception("Data sizes should be same");
                else
                {
                    int c = 0;
                    double m = max(freq);
                    c = Array.IndexOf(freq, m);
                    return data[c];
                }
            }
            if (freq == null)
            {
                List<double> x = new List<double>();
                List<double> f = new List<double>();
                try
                {
                    var groups = from d in data
                                 group d by d into g
                                 select new { Note = g.Key, Count = g.Count() };
                    foreach (var g in groups)
                    {
                        x.Add(g.Note);
                        f.Add(g.Count);
                    }
                }
                catch
                {
                    throw new Exception("Error computing mode");
                }
                int c = 0;
                double m = max(f);
                c = f.IndexOf(m);
                return data[c];
            }
            throw new Exception("Syntax Error");
        }
        private double modeS(string rexpr)
        {
            if (rexpr == "X" && DataY == null)
                return StatMode(DataX);
            if (rexpr == "Y" && DataX == null)
                return StatMode(DataY);
            else
                throw new Exception("Syntax Error");
        }
        private void graph(string rexpr)
        {
            string[] temp = rexpr.Split(';');
            ch = int.Parse(temp[0]);
            
            if (ch == 0)
            {
                c = Convert.ToChar(temp[2]);
                if (c == 'x')
                {
                    xasy = false;
                   gtitle  = "y=" + temp[1];
                }
                else if (c == 'y')
                {
                    xasy = true;
                    gtitle = "x=" + temp[1].Replace("x", "y");
                }
                graphCart(temp[1]);
            }
            if (ch == 1)
            {
                gtitle = "f(t)=" + temp[1];
                graphPol(temp[1]);
               // gra.Show();
            }
            if (ch == 2)
            {
                gtitle = "x=" + temp[1] + ",y=" + temp[2];
                graphPara(temp[1], temp[2]);
            }
            if (ch == 3)
            {
                gtitle = "Custom plot";
                graphPoint(DataX, DataY);
            }
        }
        public void graphPoint(double[] x, double[] y)
        {
            Graph gra = new Graph();
            using (Graphics g = Graphics.FromImage(plot))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                RectangleF rect = new RectangleF((float)-10, (float)10, (float)(10 + 10), (float)(-10 - 10));
                PointF[] pts = 
                {
                    new PointF(0, 0),
                    new PointF(gra.picGraph.ClientSize.Width,0),
                    new PointF(0, gra.picGraph.ClientSize.Height)
                };
                g.Transform = new System.Drawing.Drawing2D.Matrix(rect, pts);
                using (System.Drawing.Pen graph_pen1 = new System.Drawing.Pen(System.Drawing.Color.Black, 0f))
                {
                    g.DrawLine(graph_pen1, 0, (int)-10, 0, (int)10);
                    g.DrawLine(graph_pen1, (int)(-10), 0, (int)(10), 0);
                }
                Pen pen1 = new Pen(Color.Green, 0);
                points = new List<PointF>();
                int n = DataX.Length;
                for (int i = 0; i < n; i++)
                {
                    points.Add(new PointF((float)DataX[i], (float)DataY[i]));
                }
                if (points.Count > 1)
                    g.DrawLines(pen1, points.ToArray());
            }
            gra.picGraph.Image = plot;
            gra.Text = gtitle;
            plot = new Bitmap(478, 456);
            gra.Show();
        }
        public void graphPara(string xt,string yt)
        {
            Graph gra = new Graph();
            using (Graphics g = Graphics.FromImage(plot))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                RectangleF rect = new RectangleF((float)-X, (float)Y, (float)(X + Y), (float)(-X - Y));
                PointF[] pts = 
                {
                    new PointF(0, 0),
                    new PointF(gra.picGraph.ClientSize.Width,0),
                    new PointF(0, gra.picGraph.ClientSize.Height)
                };
                g.Transform = new System.Drawing.Drawing2D.Matrix(rect, pts);
                using (System.Drawing.Pen graph_pen1 = new System.Drawing.Pen(System.Drawing.Color.Black, 0f))
                {
                    g.DrawLine(graph_pen1, 0, (int)-X, 0, (int)Y);
                    g.DrawLine(graph_pen1, (int)(-X), 0, (int)(Y), 0);
                }
                Pen p = new Pen(Color.Green, 0);
                xval = new List<double>();
                yval = new List<double>();
                t1 = new List<double>();
                points = new List<PointF>();
                for (double i = -X; i <= X; i += 0.025)
                {
                    t1.Add(i);
                }
                int t = t1.Count;
                for (int i = 0; i < t; i++)
                {
                    string z1 = xt.Replace("t", t1[i].ToString());
                    string z2 = yt.Replace("t", t1[i].ToString());
                    xval.Add(EvaluateReal(z1));
                    yval.Add(EvaluateReal(z2));
                }
                int n = yval.Count;
                for (int i = 0; i < n; i++)
                {
                    bool valid_point = false;
                    try
                    {
                        if (points.Count == 0) valid_point = true;
                        else
                        {
                            double dy = yval[i] - points[points.Count - 1].Y;
                            double dx = xval[i] - points[points.Count - 1].X;
                            if (Math.Abs(dy / 0.1) < 1000 && Math.Abs(dx / 0.1) < 1000)
                                valid_point = true;
                        }
                        if (valid_point)
                            points.Add(new PointF((float)xval[i], (float)yval[i]));
                    }
                    catch
                    {
                    }
                    if (!valid_point)
                    {
                        if (points.Count > 1) g.DrawLines(p, points.ToArray());
                        points.Clear();
                    }
                }
                if (points.Count > 1)
                    g.DrawLines(p, points.ToArray());
            }
            gra.picGraph.Image = plot;
            gra.Text = gtitle;
            plot = new Bitmap(478, 456);
            gra.Show();
        }
        public void graphPol(string ft)
        {
            Graph gra = new Graph();
            using (Graphics g = Graphics.FromImage(plot))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                RectangleF rect = new RectangleF((float)-X, (float)Y, (float)(X + Y), (float)(-X - Y));
                PointF[] pts = 
                {
                    new PointF(0, 0),
                    new PointF(gra.picGraph.ClientSize.Width,0),
                    new PointF(0, gra.picGraph.ClientSize.Height)
                };
                g.Transform = new System.Drawing.Drawing2D.Matrix(rect, pts);
                using (System.Drawing.Pen graph_pen1 = new System.Drawing.Pen(System.Drawing.Color.Black, 0f))
                {
                    g.DrawLine(graph_pen1, 0, (int)-X, 0, (int)Y);
                    g.DrawLine(graph_pen1, (int)(-X), 0, (int)(Y), 0);
                }
                Pen p = new Pen(Color.Green, 0);
                double t = -2 * Math.PI;
                string d;
                const double dt = Math.PI / 100.0;
                const double two_pi = Math.PI;
                pointsP = new List<PointF>();
                while (t <= 2 * two_pi)
                {
                    d = ft.Replace("t", t.ToString());
                    double r = this.EvaluateReal(d);
                    float x = (float)(r * Math.Cos(t));
                    float y = (float)(r * Math.Sin(t));
                    pointsP.Add(new PointF(x, y));
                    t += dt;
                }
                g.DrawLines(p, pointsP.ToArray());
            }
            gra.picGraph.Image = plot;
            gra.Text = gtitle;
            plot = new Bitmap(478, 456);
            gra.Show();
        }
        public void graphCart(string fx)
        {
            Graph gra = new Graph();
            using (Graphics g = Graphics.FromImage(plot))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                RectangleF rect = new RectangleF((float)-X, (float)Y, (float)(X + Y), (float)(-X - Y));
                PointF[] pts = 
                {
                    new PointF(0, 0),
                    new PointF(gra.picGraph.ClientSize.Width,0),
                    new PointF(0, gra.picGraph.ClientSize.Height)
                };
                g.Transform = new System.Drawing.Drawing2D.Matrix(rect, pts);
                using (System.Drawing.Pen graph_pen1 = new System.Drawing.Pen(System.Drawing.Color.Black, 0f))
                {
                    g.DrawLine(graph_pen1, 0, (int)-X, 0, (int)Y);
                    g.DrawLine(graph_pen1, (int)(-X), 0, (int)(Y), 0);
                }
                Pen p = new Pen(Color.Red, 0);
                points = new List<PointF>();
                xval = new List<double>();
                yval = new List<double>();
                if (xasy)
                    for (double i = -X; i <= X; i += 0.025)
                        yval.Add(i);
                else
                    for (double i = -X; i <= X; i += 0.025)
                        xval.Add(i);
                int t = xval.Count;
                int t1 = yval.Count;
                if (xasy)
                {
                    for (int i = 0; i < t1; i++)
                    {
                        string z = fx.Replace("x", yval[i].ToString());
                        xval.Add(EvaluateReal(z));
                    }
                }
                else
                {
                    for (int i = 0; i < t; i++)
                    {
                        string z = fx.Replace("x", xval[i].ToString());
                        yval.Add(EvaluateReal(z));
                    }
                }
                int n = yval.Count;
                for (int i = 0; i < n; i++)
                {
                    bool valid_point = false;
                    try
                    {
                        if (points.Count == 0) valid_point = true;
                        else
                        {
                            double dy = yval[i] - points[points.Count - 1].Y;
                            if (Math.Abs(dy / 0.1) < 1000) valid_point = true;
                        }
                        if (valid_point)
                            points.Add(new PointF((float)xval[i], (float)yval[i]));
                        if (xasy)
                            points.Add(new PointF((float)xval[i], (float)yval[i]));
                    }
                    catch
                    {
                    }
                    if (!valid_point)
                    {
                        if (points.Count > 1)
                            g.DrawLines(p, points.ToArray());
                        points.Clear();
                    }
                }
                if (points.Count > 1)
                    g.DrawLines(p, points.ToArray());
            }
            gra.picGraph.Image = plot;
            gra.Text = gtitle;
            plot = new Bitmap(478, 456);
            gra.Show();
        }
        private double median(string rexpr)
        {
            if (rexpr == "X")
                return StatMedian(DataX);
            if (rexpr == "Y")
                return StatMedian(DataY);
            throw new Exception("Syntax Error");
        }
        private double mean(string rexpr)
        {
            string[] temp = rexpr.Split(',');
            int ch = int.Parse(temp[0]);
            double meanx, meany;
            int n = 0, n1 = 0;
            if (ch == 0) //only x
            {
                if (DataX == null & DataY == null)
                    throw new Exception("Data sets cannot be empty");
                double s = 0, s1 = 0;
                if (DataX != null)
                {
                    n = DataX.Length;
                    m_Primatives["gX"] = calculateGM(DataX);
                    m_Primatives["hX"] = calculateHM(DataX);
                }
                if (DataY != null)
                {
                    n1 = DataY.Length;
                    m_Primatives["gY"] = calculateGM(DataY);
                    m_Primatives["hY"] = calculateHM(DataY);
                }
                for (int i = 0; i < n; i++)
                {
                    s += DataX[i];
                }
                for (int i = 0; i < n1; i++)
                {
                    s1 += DataY[i];
                }
                meanx = s / n;
                meany = s1 / n;
                m_Primatives["mX"] = meanx;
                m_Primatives["mY"] = meany;
                return 0;
            }
            if (ch == 1) //x and freq
            {
                if (DataX == null & DataY == null)
                    throw new Exception("Data sets cannot be empty");
                if (freq == null)
                    throw new Exception("Error in resolving frequency");
                if (DataX != null)
                    n = DataX.Length;
                if (DataY != null)
                    n1 = DataY.Length;
                int nf = freq.Length;
                if (n != nf)
                    throw new Exception("Data and frequency size should match");
                if (n1 != nf)
                    throw new Exception("Data and frequency size should match");
                double s = 0, s1 = 0;
                for (int i = 0; i < n; i++)
                {
                    s += DataX[i] * freq[i];
                }
                for (int i = 0; i < n1; i++)
                {
                    s1 += DataY[i] * freq[i];
                }
                m_Primatives["mX"] = s / n;
                m_Primatives["mY"] = s1 / n1;
                return 0;
            }
            else
                return 0;
        }
        private double sum(string rexpr)
        {
            string[] temp = rexpr.Split(';');
            double sum = 0;
            if (DataX == null && DataY == null)
                throw new Exception("Data sets cannot be empty");
            int ch = int.Parse(temp[0]);
            if (ch == 1)
            {
                if (temp[1] == "X" && DataX!= null)
                {
                    for (int i = 0; i < DataX.Length; i++)
                        sum += DataX[i];
                    return sum;
                }
            }
            if (ch == 2)
            {
                if (temp[1] == "X" && DataX != null)
                {
                    for (int i = 0; i < DataX.Length; i++)
                        sum += DataX[i] * DataX[i];
                    return sum;
                }
            }
            if (ch == 3)
            {
                if (temp[1] == "X" && DataX != null)
                {
                    for (int i = 0; i < DataX.Length; i++)
                        sum += DataX[i] * DataX[i] * DataX[i];
                    return sum;
                }
            }
            if (ch == 4)
            {
                if (temp[1] == "X" && temp[2] == "Y" && DataX != null && DataY != null)
                {
                    for (int i = 0; i < DataX.Length; i++)
                        sum += DataX[i] * DataY[i];
                    return sum;
                }
            }
            if (ch == 5)
            {
                if (temp[1] == "X" && temp[2] == "Y" && DataX != null && DataY != null)
                {
                    for (int i = 0; i < DataX.Length; i++)
                        sum += DataX[i] * DataX[i] * DataY[i];
                    return sum;
                }
            }
            if (ch == 6)
            {
                if (temp[1] == "X" && temp[2] == "Y" && DataX != null && DataY != null)
                {
                    for (int i = 0; i < DataX.Length; i++)
                        sum += DataX[i] * DataX[i] * DataY[i] * DataY[i];
                    return sum;
                }
            }
            if (ch == 7)
            {
                if (temp[1] == "X" && temp[2] == "Y" && DataX != null && DataY != null)
                {
                    for (int i = 0; i < DataX.Length; i++)
                        sum += DataX[i] * DataX[i] * DataX[i] * DataY[i] * DataY[i] * DataY[i];
                    return sum;
                }
            }
            if (ch == 8)
            {
                if (temp[1] == "Y" && DataY != null)
                {
                    for (int i = 0; i < DataX.Length; i++)
                        sum += DataY[i];
                    return sum;
                }
            }
            return 0;
        }
        private void BinDist(string t)
        {
            string[] temp = t.Split(',');
            double n = EvaluateReal(temp[0]);
            double p = EvaluateReal(temp[1]);
            double q = 1 - p;
            FunctionTable ft = new FunctionTable();
            ft.Hide();
            ds.Tables.Clear();
            func_table.Clear();
            for (double i = 0; i <= n; i += 1)
            {
                double x = Comb(n, i) * Math.Pow(p, i) * Math.Pow(q, n - i);
                func_table.Add(i, x);
            }
            DataTable dt = ds.Tables.Add("Function");
            dt.Columns.Add("x", typeof(double));
            dt.Columns.Add("f(x)", typeof(double));
            IDictionaryEnumerator en = MATHEMATICS.func_table.GetEnumerator();
            DataRow dr = null;
            while (en.MoveNext())
            {
                double index = (double)en.Key;
                double val = (double)en.Value;
                dr = dt.NewRow();
                dr["x"] = index;
                dr["f(x)"] = val;
                dt.Rows.Add(dr);
            }
            ft.Show();
            ft.Text = "Binomial Distribution";
        }
        private void PoisDist(string t)
        {
            string[] temp = t.Split(',');
            double m = EvaluateReal(temp[0]);
            double n = EvaluateReal(temp[1]);
            FunctionTable ft = new FunctionTable();
            ft.Hide();
            ds.Tables.Clear();
            func_table.Clear();
            for (double i = 0; i <= n; i += 1)
            {
                double x = (Math.Pow(Math.E, -m) * Math.Pow(m, i)) / fact(i);
                func_table.Add(i, x);
            }
            DataTable dt = ds.Tables.Add("Function");
            dt.Columns.Add("x", typeof(double));
            dt.Columns.Add("f(x)", typeof(double));
            IDictionaryEnumerator en = MATHEMATICS.func_table.GetEnumerator();
            DataRow dr = null;
            while (en.MoveNext())
            {
                double index = (double)en.Key;
                double val = (double)en.Value;
                dr = dt.NewRow();
                dr["x"] = index;
                dr["f(x)"] = val;
                dt.Rows.Add(dr);
            }
            ft.Show();
            ft.Text = "Poisson Distribution";
        }
        private void NormDist(string t)
        {
            string[] temp = t.Split(',');
            double m = EvaluateReal(temp[0]);
            double s = EvaluateReal(temp[1]);
            double n = EvaluateReal(temp[2]);
            double con = Math.Pow(Math.Sqrt(2 * Math.PI) * s, -1);
            FunctionTable ft = new FunctionTable();
            ft.Hide();
            ds.Tables.Clear();
            func_table.Clear();
            for (double i = -n; i <= n; i += 0.001)
            {
                double y = Phi(i);
                func_table.Add(i, y);
            }
            DataTable dt = ds.Tables.Add("Function");
            dt.Columns.Add("x", typeof(double));
            dt.Columns.Add("f(x)", typeof(double));
            IDictionaryEnumerator en = MATHEMATICS.func_table.GetEnumerator();
            DataRow dr = null;
            while (en.MoveNext())
            {
                double index = (double)en.Key;
                double val = (double)en.Value;
                dr = dt.NewRow();
                dr["x"] = index;
                dr["f(x)"] = val;
                dt.Rows.Add(dr);
            }
            ft.Show();
            ft.Text = "Normal Distribution";
        }
        public Complex EvaluateComplex(string expression)
        {
            Complex z;
            string expr = null;
            bool is_unary = false;
            bool next_unary = false;
            int parens = 0;
            int expr_len = 0;
            string ch = null;
            string lexpr = null;
            string rexpr = null;
            int best_pos = 0;
            Precedence best_prec = default(Precedence);
            expr = expression.Replace(" ", "");
            expr_len = (expr).Length;
            if (expr_len == 0)
            {
                z.real = z.imag = 0.0;
                return z;
            }
            is_unary = true;
            best_prec = Precedence.None;
            for (int pos = 0; pos <= expr_len - 1; pos++)
            {
                ch = expr.Substring(pos, 1);
                next_unary = false;
                if (ch == " ")
                {
                }
                else if (ch == "(")
                {
                    parens += 1;
                    next_unary = true;
                }
                else if (ch == ")")
                {
                    parens -= 1;
                    next_unary = false;
                    if (parens < 0)
                    {
                        throw new FormatException("Too many close parentheses in '" + expression + "'");
                    }
                }
                else if (parens == 0)
                {
                    if (ch=="!"|ch == "R" | ch == "∠" | ch == "^" | ch == "*" | ch == "×" | ch == "∙" | ch == "/" | ch == "E" | ch == "%" | ch == "+" | ch == "-" | ch == ",")
                    {
                        next_unary = true;
                        switch (ch)
                        {
                            case "!":
                                if (best_prec >= Precedence.Factorial)
                                {
                                    best_prec = Precedence.Factorial;
                                    best_pos = pos;
                                }
                                break;
                            case "∠":
                                if (best_prec >= Precedence.Angle)
                                {
                                    best_prec = Precedence.Angle;
                                    best_pos = pos;
                                }
                                break;
                            case "^":
                            case "E":
                            case "R":
                                if (best_prec >= Precedence.Power)
                                {
                                    best_prec = Precedence.Power;
                                    best_pos = pos;
                                }
                                break;
                            case "*":
                            case "/":
                            case "×":
                            case "∙":
                                if (best_prec >= Precedence.Times)
                                {
                                    best_prec = Precedence.Times;
                                    best_pos = pos;
                                }

                                break;
                            case "+":
                            case "-":
                                if ((!is_unary) & best_prec >= Precedence.Plus)
                                {
                                    best_prec = Precedence.Plus;
                                    best_pos = pos;
                                }
                                break;
                        }
                    }
                }
                is_unary = next_unary;
            }
            if (parens != 0)
            {
                throw new FormatException("Missing close parenthesis in '" + expression + "'");
            }
            if (best_prec < Precedence.None)
            {
                lexpr = expr.Substring(0, best_pos);
                rexpr = expr.Substring(best_pos + 1);
                switch (expr.Substring(best_pos, 1))
                {
                    case "R":
                        {
                            try
                            {
                                return rootCreal(EvaluateComplex(rexpr), EvaluateReal(lexpr));
                            }
                            catch
                            {
                                return powC(EvaluateComplex(rexpr), 1 / EvaluateComplex(lexpr));
                            }
                        }
                    case "∠":
                        return polToCart(lexpr, rexpr);
                    case "/":
                        return EvaluateComplex(lexpr) / EvaluateComplex(rexpr);
                    case "E":
                        return EvaluateComplex(lexpr) * powC(new Complex(10.0, 0.0), EvaluateComplex(rexpr));
                    case "^":
                        return powC(EvaluateComplex(lexpr), EvaluateComplex(rexpr));
                    case "*":
                    case "×":
                    case "∙":
                        return EvaluateComplex(lexpr) * EvaluateComplex(rexpr);
                    case "+":
                        return EvaluateComplex(lexpr) + EvaluateComplex(rexpr);
                    case "-":
                        return EvaluateComplex(lexpr) - EvaluateComplex(rexpr);
                }
            }
            if (expr.EndsWith("i"))
            {
                string k = expr.Substring(0, expr_len - 1);
                z.imag = this.EvaluateComplex(expr.Substring(0, expr_len - 1)).real;
                if (k == string.Empty)
                    z.imag = 1;
                z.real = 0.0;
                return z;
            }
            if (expr.EndsWith("²"))
                return powC(EvaluateComplex(expr.Substring(0, expr_len - 1)), new Complex(2, 0));
            if (expr.EndsWith("!"))
                return la_gamma(EvaluateComplex(expr.Substring(0, expr_len - 1)) + 1);
            if (expr.StartsWith("∛"))
                return rootCreal(EvaluateComplex(expr.Substring(1)), 3);
            if (expr.EndsWith("³"))
                return powC(EvaluateComplex(expr.Substring(0, expr_len - 1)), new Complex(3, 0));
            if (expr.EndsWith("⁻¹"))
                return powC(EvaluateComplex(expr.Substring(0, expr_len - 2)), new Complex(-1, 0));
            if (expr.StartsWith("√"))
                return rootCreal(EvaluateComplex(expr.Substring(1)), 2);
            if (expr.StartsWith("+"))
            {
                z = (EvaluateComplex(expr.Substring(1)));
                return z;
            }
            if (expr.StartsWith("-"))
            {
                z = -(EvaluateComplex(expr.Substring(1)));
                return z;
            }
            if (expr.StartsWith("(") & expr.EndsWith(")"))
            {
                return EvaluateComplex(expr.Substring(1, expr_len - 2));
            }
            string[] sexp = new string[101];
            // Look for Fun(expr2).
            if (expr_len > 3 & expr.EndsWith(")"))
            {
                // Find the first (.
                int paren_pos = expr.IndexOf("(");
                if (paren_pos > 0)
                {
                    // See what the function is.
                    lexpr = expr.Substring(0, paren_pos);
                    rexpr = expr.Substring(paren_pos + 1, expr_len - paren_pos - 2);
                    switch (lexpr)
                    {
                        case "sin":
                            return sinC(this.EvaluateComplex(rexpr));
                        case "cos":
                            return cosC(this.EvaluateComplex(rexpr));
                        case "tan":
                            return tanC(this.EvaluateComplex(rexpr));
                        case "cosec":
                            return cosecC(this.EvaluateComplex(rexpr));
                        case "sec":
                            return secC(this.EvaluateComplex(rexpr));
                        case "cot":
                            return cotC(this.EvaluateComplex(rexpr));
                        case "sinh":
                            return sinhC(EvaluateComplex(rexpr));
                        case "cosh":
                            return coshC(EvaluateComplex(rexpr));
                        case "tanh":
                            return tanhC(EvaluateComplex(rexpr));
                        case "cosech":
                            return cosechC(EvaluateComplex(rexpr));
                        case "sech":
                            return coshC(EvaluateComplex(rexpr));
                        case "coth":
                            return cothC(EvaluateComplex(rexpr));
                        case "asin":
                            return asinC(EvaluateComplex(rexpr));
                        case "acos":
                            return acosC(EvaluateComplex(rexpr));
                        case "atan":
                            return atanC(EvaluateComplex(rexpr));
                        case "acosec":
                            return acosecC(EvaluateComplex(rexpr));
                        case "asec":
                            return asecC(EvaluateComplex(rexpr));
                        case "acot":
                            return acotC(EvaluateComplex(rexpr));
                        case "asinh":
                            return asinhC(EvaluateComplex(rexpr));
                        case "acosh":
                            return acoshC(EvaluateComplex(rexpr));
                        case "atanh":
                            return atanhC(EvaluateComplex(rexpr));
                        case "acosech":
                            return acosechC(EvaluateComplex(rexpr));
                        case "asech":
                            return asechC(EvaluateComplex(rexpr));
                        case "acoth":
                            return acothC(EvaluateComplex(rexpr));
                        case "mod":
                            return Mod(EvaluateComplex(rexpr));
                        case "Re":
                            return Real(EvaluateComplex(rexpr));
                        case "Im":
                            return Imag(EvaluateComplex(rexpr));
                        case "arg":
                            return arg(EvaluateComplex(rexpr));
                        case "powe":
                            return expC(EvaluateComplex(rexpr));
                        case "Log":
                            return Log((rexpr));
                        case "inv":
                            return invC(EvaluateComplex(rexpr));
                        case "conj":
                            return conjugate(this.EvaluateComplex(rexpr));
                        case "F":
                            sexp = rexpr.Split(';');
                            return ComplexFunc(sexp[0], EvaluateComplex(sexp[1]));
                        case "F'":
                            sexp = rexpr.Split(';');
                            return diffrentiate(sexp[0], EvaluateComplex(sexp[1]));
                        case "equC":
                            sexp = rexpr.Split(';');
                            return NewtonRaphson(sexp[0]);
                        case "ftable":
                            sexp = rexpr.Split(';');
                            Cftable(sexp[0], EvaluateComplex(sexp[1]), EvaluateComplex(sexp[2]), EvaluateReal(sexp[3]));
                            return Complex.zero();
                        case "Z":
                        case "z":
                            string[] temp = rexpr.Split(',');
                            z.real = Convert.ToDouble(temp[0]);
                            z.imag = Convert.ToDouble(temp[1]);
                            return z;
                    }
                }
            }
            if (m_Primatives.Contains(expr))
            {
                Complex value = new Complex();
                try
                {
                     value= EvaluateComplex((m_Primatives[expr]).ToString());
                    return value;
                }
                catch (Exception)
                {
                    System.Windows.MessageBox.Show("Error in evaluation","Error",System.Windows.MessageBoxButton.OK,System.Windows.MessageBoxImage.Error);
                }
            }
            try
            {
                z.real = EvaluateReal(expr);
                z.imag = 0.0;
                return z;
            }
            catch (Exception)
            {
                throw new FormatException("Error evaluating '" + expression + "' as a constant.");
            }
        }
        string assign(double x)
        {
            if (x < 0)
                return "";
            else
                return "+";
        }
        private Complex Real(Complex z)
        {
            Complex p = z;
            p.imag = 0;
            return p;
        }
        private Complex Imag(Complex z)
        {
            Complex p = z;
            p.real = 0.0;
            return p;
        }
        private Complex Log(string p)
        {
            Complex z, z1;
            int pos = p.LastIndexOf(',');
            string st1;
            try
            {
                st1 = p.Substring(0, pos);
            }
            catch
            {
                st1 = "";
            }
            string st2 = p.Substring(pos + 1);
            z = (EvaluateComplex(st2));
            z1 = EvaluateComplex(st1);
            if (z1 == Complex.zero())
                z1 = new Complex(Math.E, 0.0);
            return LogC(z) / LogC(z1);
        }
        private Complex sinC(Complex z)
        {
            Complex k;
            double a = z.real;
            double b = z.imag;
            k.real = Math.Sin(a) * Math.Cosh(b);
            k.imag = Math.Cos(a) * Math.Sinh(b);
            return k;
        }
        private Complex cosC(Complex z)
        {
            Complex k;
            double a = z.real;
            double b = z.imag;
            k.real = Math.Cos(a) * Math.Cosh(b);
            k.imag = -Math.Sin(a) * Math.Sinh(b);
            return k;
        }
        private Complex tanC(Complex z)
        {
            Complex k;
            double a = z.real;
            double b = z.imag;
            double d = Math.Cos(2 * a) + Math.Cosh(2 * b);
            k.real = Math.Sin(2 * a) / d;
            k.imag = Math.Sinh(2 * b) / d;
            return k;
        }
        private Complex cosecC(Complex z)
        {
            Complex k = sinC(z);
            return invC(k);
        }
        private Complex secC(Complex z)
        {
            Complex k = cosC(z);
            return invC(k);
        }
        private Complex cotC(Complex z)
        {
            Complex k = tanC(z);
            return invC(k);
        }
        private Complex Mod(Complex z)
        {
            Complex k;
            k.real = Math.Sqrt(z.real * z.real + z.imag * z.imag);
            k.imag = 0;
            return k;
        }
        private Complex expC(Complex z)
        {
            Complex f;
            double a = z.real;
            double b = z.imag;
            double p = Math.Exp(a);
            f.real = p * Math.Cos(b);
            f.imag = p * Math.Sin(b);
            return f;
        }
        private Complex NewtonRaphson(string fz)
        {
            Complex z;
            z.real = 8;
            z.imag = 0;
            List<Complex> arr = new List<Complex>();
            Complex nextZ;
            arr.Add(z);
            int n = 100;
            for (int i = 1; i <= n; i++)
            {
                nextZ = arr[i - 1] - (ComplexFunc(fz, arr[i - 1]) / diffrentiate(fz, arr[i - 1]));
                arr.Add(nextZ);
            }
            Complex r = arr[n];
            solutions.Add(r.real.ToString() + assign(r.imag) + r.imag.ToString() + "i");
            arr.Clear();
            z.real = -8.0;
            z.imag = 0;
            arr.Add(z);
            for (int i = 1; i <= n; i++)
            {
                nextZ = arr[i - 1] - (ComplexFunc(fz, arr[i - 1]) / diffrentiate(fz, arr[i - 1]));
                arr.Add(nextZ);
            }
            r = arr[n];
            solutions.Add(r.real.ToString() + assign(r.imag) + r.imag.ToString() + "i");
            return r;
        }
        private Complex diffrentiate(string fz, Complex z)
        {
            Complex dz;
            dz.real = 0.0000000162;
            dz.imag = 0.0000000162;
            Complex j = z + dz;
            Complex a = ComplexFunc(fz, j);
            Complex b = ComplexFunc(fz, z);
            Complex y = (a - b) / (dz);
            return y;
        }
        private Complex secDiffrentiate(string fz, Complex z)
        {
            Complex dz;
            dz.real = 0.0000000162;
            dz.imag = 0.0000000162;
            Complex a = ComplexFunc(fz, z + dz);
            Complex b = ComplexFunc(fz, z - dz);
            Complex c = 2.0 * ComplexFunc(fz, z);
            Complex x = (a - b + c) / (dz * dz);
            return x;
        }
        private Complex powC(Complex z, Complex z1)
        {
            Complex f;
            double a1 = z.real;
            double b1 = z.imag;
            double c1 = z1.real;
            double d1 = z1.imag;
            double l1 = 0.5 * Math.Log(a1 * a1 + b1 * b1);
            double t1 = Math.Atan2(b1, a1);
            double p1 = c1 * l1 - d1 * t1;
            double p2 = c1 * t1 + d1 * l1;
            double r = Math.Exp(p1);
            f.real = r * Math.Cos(p2);
            f.imag = r * Math.Sin(p2);
            return f;
        }
        private Complex rootCreal(Complex z, double n)
        {
            solutions.Clear();
            Complex f;
            double r = Math.Sqrt(z.real * z.real + z.imag * z.imag);
            double t = Math.Atan2(z.imag, z.real);
            double t1;
            for (int k = 0; k < n; k++)
            {
                t1 = (t + 2 * k * Math.PI) / n;
                f.real = Math.Round(Math.Pow(r, 1 / n) * Math.Cos(t1), rounding_number);
                f.imag = Math.Round(Math.Pow(r, 1 / n) * Math.Sin(t1), 10);
                solutions.Add(f.ToString());
            }
            f.real = Math.Pow(r, 1 / n) * Math.Cos((t / n));
            f.imag = Math.Pow(r, 1 / n) * Math.Sin((t / n));
            return f;
        }
        private Complex sqrtC(Complex z)
        {
            Complex f;
            double a = z.real;
            double b = z.imag;
            double s1 = Math.Sqrt(a * a + b * b);
            int c = Math.Sign(b);
            if (c == 1)
            {
                f.real = Math.Sqrt((a + s1) / 2.0);
                f.imag = Math.Sqrt((s1 - a) / 2.0);
                solutions.Add("±(" + f.real + "+" + f.imag + "i)");
                return f;
            }
            else
            {
                f.real = Math.Sqrt((a + s1) / 2.0);
                f.imag = -Math.Sqrt((s1 - a) / 2.0);
                solutions.Add("±(" + f.real + assign(f.imag) + f.imag + "i)");
                return f;
            }
        }
        private Complex arg(Complex z)
        {
            Complex f;
            f.real = Math.Atan2(z.imag, z.real) * invfactor;
            f.imag = 0;
            return f;
        }
        private Complex invC(Complex z)
        {
            double c;
            Complex k;
            c = z.real * z.real + z.imag * z.imag;
            k.real = z.real / c;
            k.imag = -z.imag / c;
            return k;
        }
        private Complex LogC(Complex z)
        {
            double c, m;
            Complex k;
            m = z.real * z.real + z.imag * z.imag;
            c = Math.Log(m);
            k.real = 0.5 * c;
            k.imag = Math.Atan2(z.imag, z.real);
            return k;
        }
        int sign(double x)
        {
            if (x <= 0)
                return -1;
            return 1;
        }
        private Complex asinC(Complex z)
        {
            Complex d;
            double x = z.real;
            double y = z.imag;
            double a = 0.5 * Math.Sqrt((x + 1) * (x + 1) + y * y) + 0.5 * Math.Sqrt((x - 1) * (x - 1) + y * y);
            double b = 0.5 * Math.Sqrt((x + 1) * (x + 1) + y * y) - 0.5 * Math.Sqrt((x - 1) * (x - 1) + y * y);
            d.real = Math.Asin(b);
            d.imag = sign(y) * Math.Log(a + Math.Sqrt(a * a - 1));
            return d;
        }
        private Complex acosC(Complex z)
        {
            Complex d;
            double x = z.real;
            double y = z.imag;
            double a = 0.5 * Math.Sqrt((x + 1) * (x + 1) + y * y) + 0.5 * Math.Sqrt((x - 1) * (x - 1) + y * y);
            double b = 0.5 * Math.Sqrt((x + 1) * (x + 1) + y * y) - 0.5 * Math.Sqrt((x - 1) * (x - 1) + y * y);
            d.real = Math.Acos(b);
            d.imag = -sign(y) * Math.Log(a + Math.Sqrt(a * a - 1));
            return d;
        }
        private Complex atanC(Complex z)
        {
            Complex d;
            double x = z.real;
            double y = z.imag;
            double a = sign(y) * 0.5 * Math.Atan2((2 * x), (1 - x * x - y * y));
            double b = sign(y) * 0.5 * atanh((2 * y) / (1 + x * x + y * y));
            d.real = a;
            d.imag = b;
            return d;
        }
        private Complex acosecC(Complex z)
        {
            Complex c = invC(z);
            return sinC(c);
        }
        private Complex asecC(Complex z)
        {
            Complex c = invC(z);
            return cosC(c);
        }
        private Complex acotC(Complex z)
        {
            Complex c = invC(z);
            return tanC(c);
        }
        private Complex sinhC(Complex z)
        {
            double x = z.real;
            double y = z.imag;
            Complex c;
            c.real = Math.Sinh(x) * Math.Cos(y);
            c.imag = Math.Cosh(x) * Math.Sin(y);
            return c;
        }
        private Complex coshC(Complex z)
        {
            double x = z.real;
            double y = z.imag;
            Complex c;
            c.real = Math.Cosh(x) * Math.Cos(y);
            c.imag = Math.Sinh(x) * Math.Sin(y);
            return c;
        }
        private Complex tanhC(Complex z)
        {
            Complex d;
            double x = z.real;
            double y = z.imag;
            double a = Math.Cosh(2 * x) + Math.Cos(2 * y);
            d.real = Math.Sinh(2 * x) / a;
            d.imag = Math.Sin(2 * y) / a;
            return d;
        }
        private Complex cosechC(Complex z)
        {
            Complex r = sinhC(z);
            return invC(r);
        }
        private Complex sechC(Complex z)
        {
            Complex r = coshC(z);
            return invC(r);
        }
        private Complex cothC(Complex z)
        {
            Complex r = tanhC(z);
            return invC(r);
        }
        private Complex asinhC(Complex z)
        {
            Complex k = z + rootCreal((z * z + 1.0), 2);
            Complex m = LogC(k);
            return m;
        }
        private Complex acoshC(Complex z)
        {
            Complex k = z + rootCreal((z * z - 1.0), 2);
            Complex m = LogC(k);
            return m;
        }
        private Complex atanhC(Complex z)
        {
            Complex x = (1 + z) / (1 - z);
            Complex y = LogC(x);
            return 0.5 * y;
        }
        private Complex acosechC(Complex z)
        {
            Complex r = invC(z);
            return asinhC(r);
        }
        private Complex asechC(Complex z)
        {
            Complex r = invC(z);
            return acoshC(r);
        }
        private Complex acothC(Complex z)
        {
            Complex r = invC(z);
            return atanhC(r);
        }
        private double atanh(double x)
        {
            return 0.5 * Math.Log((1 + x) / (1 - x));
        }
        private Complex conjugate(Complex a)
        {
            Complex z;
            z.real = a.real;
            z.imag = -a.imag;
            return z;
        }
        //private Complex cartToPol(Complex z)
        //{
        //    Complex f;
        //    f.real = Math.Sqrt(z.real * z.real + z.imag * z.imag);
        //    f.imag = Math.Atan2(z.imag, z.real) * invfactor;
        //    return f;
        //}
        private Complex polToCart(string a, string b)
        {
            Complex f;
            double r = EvaluateReal(a);
            double t = EvaluateReal(b);
            f.real = Math.Round(r * Math.Cos(t * factor), 12);
            f.imag = Math.Round(r * Math.Sin(t * factor), 12);
            return f;
        }
        private Complex ComplexFunc(string fx, Complex z)
        {
            fx = fx.Replace("z", "(x+(y)i)");
            string r = fx.Replace("x", z.real.ToString());
            string r1 = r.Replace("y", z.imag.ToString());
            Complex s = EvaluateComplex(r1);
            return s;
        }
        private Complex ComplexFunc(string fx, double x,double y)
        {
            fx = fx.Replace("z", "(x+(y)i)");
            string r = fx.Replace("x", x.ToString());
            string r1 = r.Replace("y", y.ToString());
            Complex s = EvaluateComplex(r1);
            return s;
        }
        private double log(string p1, string p2)
        {
            double c = EvaluateReal(p1);
            double d = EvaluateReal(p2);
            if (p1 == "")
                c = 10;
            return log(d) / log(c);
        }
        private double log(double d)
        {
            if (d < 0)
                return double.NegativeInfinity;
            else
                return Math.Log(d);
        }
        public double fact(double value)
        {
            double fact = 1;
            for (int i = 1; i <= value; i++)
                fact *= i;
            return fact;
        }
        private double la_gamma(double x)
        {
            double[] p = { 0.99999999999980993, 676.5203681218851, -1259.1392167224028, 771.32342877765313, -176.61502916214059, 12.507343278686905, -0.13857109526572012, 9.9843695780195716e-6, 1.5056327351493116e-7 };
            int g = 7;
            if (x < 0.5)
                return Math.PI / (Math.Sin(Math.PI * x) * la_gamma(1 - x));
            x -= 1;
            double a = p[0];
            double t = x + g + 0.5;
            for (int i = 1; i < p.Length; i++)
            {
                a += p[i] / (x + i);
            }
            return Math.Sqrt(2 * Math.PI) * Math.Pow(t, x + 0.5) * Math.Exp(-t) * a;
        }
        private Complex la_gamma(Complex x)
        {
            double[] p = { 0.99999999999980993, 676.5203681218851, -1259.1392167224028, 771.32342877765313, -176.61502916214059, 12.507343278686905, -0.13857109526572012, 9.9843695780195716e-6, 1.5056327351493116e-7 };
            int g = 7;
            if (x < 0.5)
                return Math.PI / (sinC(Math.PI * x) * la_gamma(1 - x));
            x -= 1;
            Complex a =new Complex(p[0],0);
            Complex t = x + g + 0.5;
            for (int i = 1; i < p.Length; i++)
            {
                a += p[i] / (x + i);
            }
            return Math.Sqrt(2 * Math.PI) * powC(t, x + 0.5) * expC(-t) * a;
        }
        private double log(double a, double b)
        {
            if (a <= 0 || b <= 0)
                throw new ArgumentException("Argument cannot be zero");
            return (Math.Log(b) / Math.Log(a));
        }
        private double FEval(string s, string var, double a)
        {
            string k = s.Replace(var, a.ToString());
            double c = EvaluateReal(k);
            return c;
        }
        private double func2(string s, double a, double b)
        {
            string k;
            s = s.Replace("x", a.ToString());
            k = s.Replace("y", b.ToString());
            double c = this.EvaluateReal(k);
            return Convert.ToDouble(c.ToString());
        }
        private double func3(string s, double a, double b, double c)
        {
            string k, u;
            s = s.Replace("x", a.ToString());
            k = s.Replace("y", b.ToString());
            u = k.Replace("z", c.ToString());
            double x = this.EvaluateReal(u);
            return Convert.ToDouble(x.ToString());
        }
        private double partial_derivative(string fx, char var, double a, double b, double c)
        {
            double d;
            string s1;
            if (var == 'x')
            {
                fx = fx.Replace("y", b.ToString());
                s1 = fx.Replace("z", c.ToString());
                d = diffrentiate(s1, "x", a);
                return d;
            }
            else if (var == 'y')
            {
                fx = fx.Replace("x", a.ToString());
                s1 = fx.Replace("z", c.ToString());
                d = diffrentiate(s1, "y", b);
                return d;
            }
            else if (var == 'z')
            {
                fx = fx.Replace("x", a.ToString());
                s1 = fx.Replace("y", b.ToString());
                d = diffrentiate(s1, "z", c);
                return d;
            }
            else
                return 0;
        }
        private double Dec(double x)
        {
            return (x - (int)(x));
        }
        private int Int(double x)
        {
            return (int)x;
        }
        private double root(double x, double y)
        {
            return (Math.Pow(x, (1 / y)));
        }
        private double Perm(double x, double y)
        {
            double n = fact(x);
            double r = fact(x - y);
            double b = n / r;
            return b;
        }
        private double Comb(double x, double y)
        {
            double n = fact(x);
            double r = fact(y);
            double c = r * fact(x - y);
            return n / c;
        }
        private double cubeRoot(double d)
        {
            if (d < 0.0)
            {
                return -cubeRoot(-d);
            }
            else
            {
                return Math.Pow(d, 1.0 / 3.0);
            }
        }
        private double sinhIn(double x)
        {
            double a = Math.Sqrt((x * x) + 1);
            return Math.Log((x + a));
        }
        private double coshIn(double x)
        {
            double c = Math.Sqrt(x + 1);
            double c1 = Math.Sqrt(x - 1);
            double d = c * c1;
            return Math.Log(x + d);
        }
        private double tanhIn(double x)
        {
            double d = x + 1;
            double d1 = 1 - x;
            double e = d / d1;
            double k = Math.Log(e);
            return 0.5 * k;
        }
        private double integrate(string[] fx)
        {
            int ch = (int)this.EvaluateReal(fx[0]);
            string s = fx[1].Substring(0, fx[1].Length - 2);
            if (ch == 0 || ch == 1)
            {
                double a = this.EvaluateReal(fx[2]);
                double b = this.EvaluateReal(fx[3]);
                try
                {
                    if (ch == 0)
                    {
                        int v = lroots.Length;
                        double c1 = (b - a) / 2, c2 = (b + a) / 2, sum = 0;
                        int i;
                        for (i = 0; i < v; i++)
                            sum += weights[i] * FEval(s, "x", c1 * lroots[i] + c2);
                        return c1 * sum;
                    }
                    else if (ch == 1)
                    {
                        int i;
                        double n = 30000;
                        double s1 = 0, s2 = 0, s3 = 0, h, d1, d2, d3;
                        h = (b - a) / n;
                        d2 = FEval(s, "x", a);
                        d3 = FEval(s, "x", b);
                        d1 = d2 + d3;
                        for (i = 3; i <= n - 3; i += 3)
                        {
                            s2 += FEval(s, "x", a + (i * h));
                        }
                        for (i = 1; i <= n - 1; i++)
                        {
                            s1 += FEval(s, "x", a + (i * h));
                        }
                        s3 = s1 - s2;
                        double x = (0.375 * h) * (d1 + (2 * s2) + (3 * s3));
                        return x;
                    }
                    else
                        return 0;
                }
                catch
                {
                    throw new FormatException("Syntax Error");
                }
            }
            else if (ch == 2)
            {
                double sum = 0, sum3 = 0, sum1 = 0, k2, j;
                if (DataX == null || DataY == null)
                    throw new ArgumentException("X and Y values cannot be empty");
                else
                {
                    int count = DataX.Length;
                    List<double> yFx = new List<double>(count);
                    if (count != DataY.Length)
                        throw new Exception("Size of X and Y should match");
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            j = func2(s, DataX[i], DataY[i]);
                            yFx.Add(j);
                        }
                        sum = yFx[0] + yFx[yFx.Count - 1];
                        double h = DataX[1] - DataX[0];
                        for (int i = 3; i < count - 2; i += 3)
                        {
                            sum3 += yFx[i];
                        }
                        for (int i = 1; i < count -1; i++)
                        {
                            sum1 += yFx[i];
                        }
                        k2 = sum1 - sum3;
                        double u = (0.375 * h) * (sum + 2 * sum3 + 3 * k2);
                        return u;
                    }
                }
            }
            else
                return 0;
        }
        private double sum(string s, double a, double b, double h)
        {
            double s1 = 0;
            for (double i = a; i <= b; i += h)
            {
                s1 += FEval(s, "x", i);
            }
            return s1;
        }
        private double product(string s, double a, double b, double h)
        {
            double p = 1;
            for (double i = a; i <= b; i += h)
            {
                p *= FEval(s, "x", i);
            }
            return p;
        }
        private double diffrentiate(string s, string var, double a)
        {
            double dx = 0.000000162;
            double fxh = FEval(s, var, a + dx);
            double f2 = 0;
            double fx = FEval(s, var, a - dx);
            double d = fxh - fx;
            f2 = d / (2 * dx);
            return f2;
        }
        private double limitEval(string s, double a)
        {
            double[] xm = new double[10];
            double[] xp = new double[10];
            double[] fxm = new double[10];
            double[] fxp = new double[10];
            for (int i = 0; i <= 9; i++)
            {
                xp[i] = ((a * Math.Pow(10, i)) + 0.10) / (Math.Pow(10, i));
            }
            for (int i = 0; i <= 9; i++)
            {
                xm[i] = ((a * Math.Pow(10, i)) - 0.10) / (Math.Pow(10, i));
            }
            for (int i = 0; i <= 9; i++)
            {
                fxp[i] = FEval(s, "x", xp[i]);
            }
            for (int i = 0; i <= 9; i++)
            {
                fxm[i] = FEval(s, "x", xm[i]);
            }
            return Math.Round(fxp[9], 10);
        }
        private double checkContinuity(string fx, double a)
        {
            double x = FEval(fx, "x", a);
            double l = limitEval(fx, a);
            if (x == double.NegativeInfinity || x == double.PositiveInfinity || l == double.NegativeInfinity || l == double.PositiveInfinity)
                return 0;
            if (x == double.NaN || l == double.NaN) return 0;
            if (Math.Round(x, 1) != Math.Round(l, 1)) return 0;
            return 1;
        }
        private double equ(string[] x)
        {
            int ch = (int)EvaluateReal(x[0]);
            solutions.Clear();
            if (ch == 0)
            {
                try
                {
                    //linear equation in one variable
                    double a = EvaluateReal(x[1]);
                    double b = EvaluateReal(x[2]);
                    return b / a;
                }
                catch
                {
                    throw new FormatException("Syntax Error.Overflow of parameters");
                }
            }
            else if (ch == 1)
            {
                try
                {   //linear equations in two variables
                    double a1 = EvaluateReal(x[1]);
                    double a2 = EvaluateReal(x[2]);
                    double b1 = EvaluateReal(x[3]);
                    double b2 = EvaluateReal(x[4]);
                    double c1 = EvaluateReal(x[5]);
                    double c2 = EvaluateReal(x[6]);
                    double d, dx, dy, x1, y1;
                    d = a1 * b2 - a2 * b1;
                    dx = c1 * b2 - c2 * b1;
                    dy = a1 * c1 - a2 * c2;
                    x1 = dx / d;
                    y1 = dy / d;
                    if (MATHEMATICS.isFrac)
                    {
                        solutions.Add("x=" + Math.Round(x1, precision).ToString(true));
                        solutions.Add("y=" + Math.Round(y1, precision).ToString(true));
                    }
                    if (!MATHEMATICS.isFrac)
                    {
                        solutions.Add("x=" + Math.Round(x1, precision).ToString(false));
                        solutions.Add("y=" + Math.Round(y1, precision).ToString(false));
                    }
                    return 0;
                }
                catch
                {
                    throw new FormatException("Syntax Error.Overflow of parameters");
                }
            }
            else if (ch == 2)
            {
                try
                {
                    double a1 = EvaluateReal(x[1]);
                    double a2 = EvaluateReal(x[2]);
                    double a3 = EvaluateReal(x[3]);
                    double b1 = EvaluateReal(x[4]);
                    double b2 = EvaluateReal(x[5]);
                    double b3 = EvaluateReal(x[6]);
                    double c1 = EvaluateReal(x[7]);
                    double c2 = EvaluateReal(x[8]);
                    double c3 = EvaluateReal(x[9]);
                    double d1 = EvaluateReal(x[10]);
                    double d2 = EvaluateReal(x[11]);
                    double d3 = EvaluateReal(x[12]);
                    double d = a1 * (b2 * c3 - c2 * b3) - b1 * (a2 * c3 - a3 * c2) + c1 * (a2 * b3 - b2 * a3);
                    double dx = d1 * (b2 * c3 - c2 * b3) - b1 * (d2 * c3 - d3 * c2) + c1 * (d2 * b3 - b2 * d3);
                    double dy = a1 * (d2 * c3 - c2 * d3) - d1 * (a2 * c3 - a3 * c2) + c1 * (a2 * d3 - d2 * a3);
                    double dz = a1 * (b2 * d3 - d2 * b3) - b1 * (a2 * d3 - a3 * d2) + d1 * (a2 * b3 - b2 * a3);
                    double x1 = 0, y = 0, z = 0;
                    x1 = dx / d;
                    y = dy / d;
                    z = dz / d;
                    if (MATHEMATICS.isFrac)
                    {
                        solutions.Add("x=" + Math.Round(x1, precision).ToString(true));
                        solutions.Add("y=" + Math.Round(y, precision).ToString(true));
                        solutions.Add("z=" + Math.Round(z, precision).ToString(true));
                    }
                    if (!MATHEMATICS.isFrac)
                    {
                        solutions.Add("x=" + Math.Round(x1, precision).ToString(false));
                        solutions.Add("y=" + Math.Round(y, precision).ToString(false));
                        solutions.Add("z=" + Math.Round(z, precision).ToString(false));
                    }
                    return 0;
                }
                catch
                {
                    throw new FormatException("Syntax Error.Overflow of parameters");
                }
            }
            else if (ch == 3)
            {
                try
                {
                    double a = EvaluateReal(x[1]);
                    double b = EvaluateReal(x[2]);
                    double c = EvaluateReal(x[3]);
                    double x1, x2, d;
                    d = (b * b - 4 * a * c);
                    if (d > 0)
                    {
                        x1 = -b + Math.Sqrt(d) / (2 * a);
                        x2 = -b - Math.Sqrt(d) / (2 * a);
                        if (MATHEMATICS.isFrac)
                        {
                            solutions.Add("x₁=" + Math.Round(x1, precision).ToString(true));
                            solutions.Add("x₂=" + Math.Round(x2, precision).ToString(true));
                        }
                        if (!MATHEMATICS.isFrac)
                        {
                            solutions.Add("x₁=" + Math.Round(x1, precision).ToString(false));
                            solutions.Add("x₂=" + Math.Round(x2, precision).ToString(false));
                        }
                        return 0;
                    }
                    else if (d < 0)
                    {
                        x1 = -b / (2 * a);
                        double u = Math.Sqrt(Math.Abs(d)) / (2 * a);
                        if (MATHEMATICS.isFrac)
                        {
                            solutions.Add(("x₁=" + Math.Round(x1, precision).ToString(true) + "+(" + Math.Round(u, precision).ToString(true)).ToString() + ")i");
                            solutions.Add(("x₂=" + Math.Round(x1, precision).ToString(true) + "-( " + Math.Round(u, precision).ToString(true)).ToString() + ")i");
                        }
                        if (!MATHEMATICS.isFrac)
                        {
                            solutions.Add(("x₁=" + Math.Round(x1, precision).ToString(false) + "+( " + Math.Round(u, precision).ToString(false)).ToString() + ")i");
                            solutions.Add(("x₂=" + Math.Round(x1, precision).ToString(false) + "-(" + Math.Round(u, precision).ToString(false)).ToString() + ")i");
                        }
                        return 0;
                    }
                    else if (d == 0)
                    {
                        x1 = -b / (2 * a);
                        return Math.Round(x1, precision);
                    }
                    else
                        return 0;
                }
                catch
                {
                    throw new FormatException("Syntax Error");
                }
            }
            else if (ch == 4)
            {
                double a = EvaluateReal(x[1]);
                double b = EvaluateReal(x[2]);
                double c = EvaluateReal(x[3]);
                double d = EvaluateReal(x[4]);
                double i, j, k, l, m, n, p, x1, x2, x3, r, s, t, u, y3, y2;
                double f = (((3 * c) / a) - ((b * b) / (a * a))) / 3.0;
                double g = (((2 * b * b * b) / (a * a * a)) - ((9 * b * c) / (a * a)) + ((27 * d) / a)) / 27.0;
                double h = ((g * g) / 4.0) + ((f * f * f) / 27.0);
                if (h > 0)
                {
                    r = -(g / 2) + Math.Sqrt(h);
                    s = this.cubeRoot(r);
                    t = -(g / 2) - Math.Sqrt(h);
                    u = this.cubeRoot(t);
                    x1 = (s + u) - (b / (3 * a));
                    x2 = -(s + u) / 2.0 - (b / (3 * a));
                    y2 = (s - u) * (Math.Sqrt(3)) / 2;
                    x3 = -(s + u) / 2.0 - (b / (3 * a));
                    y3 = (s - u) * (Math.Sqrt(3)) / 2;
                    if (MATHEMATICS.isFrac)
                    {
                        solutions.Add("x₁=" + Math.Round(x1, precision).ToString(true));
                        solutions.Add("x₂=" + Math.Round(x2, precision).ToString(true) + "+(" + Math.Round(y2, precision).ToString(true) + ")i");
                        solutions.Add("x₃=" + Math.Round(x3, precision).ToString(true) + "-(" + Math.Round(y3, precision).ToString(true) + ")i");
                    }
                    if (!MATHEMATICS.isFrac)
                    {
                        solutions.Add("x₁=" + Math.Round(x1, precision).ToString(false));
                        solutions.Add("x₂=" + Math.Round(x2, precision).ToString(false) + "+(" + Math.Round(y2, precision).ToString(false) + ")i");
                        solutions.Add("x₃=" + Math.Round(x3, precision).ToString(false) + "-(" + Math.Round(y3, precision).ToString(false) + ")i");
                    }
                    return 0;
                }
                else if (h < 0)
                {
                    i = Math.Sqrt(((g * g) / 4) - h);
                    j = this.cubeRoot(i);
                    k = Math.Acos(-(g / (2 * i)));
                    l = j * -1;
                    m = Math.Cos(k / 3);
                    n = Math.Sqrt(3) * Math.Sin(k / 3);
                    p = (b / (3 * a)) * -1;
                    x1 = (-(2 * j) * Math.Cos(k / 3)) - (b / (3 * a));
                    x2 = l * (m + n) + p;
                    x3 = l * (m - n) + p;
                    if (MATHEMATICS.isFrac)
                    {
                        solutions.Add("x₁=" + Math.Round(x1, precision).ToString(true));
                        solutions.Add("x₂=" + Math.Round(x2, precision).ToString(true));
                        solutions.Add("x₃=" + Math.Round(x3, precision).ToString(true));
                    }
                    if (!MATHEMATICS.isFrac)
                    {
                        solutions.Add("x₁=" + Math.Round(x1, precision).ToString(false));
                        solutions.Add("x₂=" + Math.Round(x2, precision).ToString(false));
                        solutions.Add("x₃=" + Math.Round(x3, precision).ToString(false));
                    }
                    return 0;
                }
                else if (f == 0 || g == 0 || h == 0)
                {
                    x1 = this.cubeRoot(d / a);
                    return Math.Round(x1, precision);
                }
                else
                    return 0;
            }
            else if (ch == 5)
            {
                string s = x[1];
                double a = EvaluateReal(x[2]);
                List<double> x2 = new List<double>();
                double n = 100;
                x2.Add(a);
                for (int i = 1; i <= n; i++)
                {
                    double r1 = x2[i - 1];
                    double r2 = r1 - (FEval(s, "x", r1) / diffrentiate(s, "x", r1));
                    x2.Add(r2);
                }
                return Math.Round(x2[(int)n], precision);
            }
            else if (ch == 6)
            {
                try
                {
                    string s = x[1];
                    double x0 = EvaluateReal(x[2]);
                    double y0 = EvaluateReal(x[3]);
                    double x1 = EvaluateReal(x[4]);
                    double h = EvaluateReal(x[5]);
                    int c1 = (int)EvaluateReal(x[6]);
                    List<double> xv = new List<double>(100);
                    List<double> y = new List<double>(101);
                    double n, k, k1, k2, k3, k4, u;
                    n = (x1 - x0) / h;
                    double p, q;
                    if (c1 == 0)
                    {
                        //Euler's Method
                        y.Add(y0);
                        for (double i = x0; i <= x1; i += h)
                            xv.Add(i);
                        for (int j = 1; j <= n; j++)
                        {
                            p = y[j - 1];
                            q = h * func2(s, xv[j - 1], y[j - 1]);
                            y.Add(p + q);
                        }
                        u = y[(int)n];
                        return Math.Round(u, precision);
                    }
                    else if (c1 == 1)
                    {
                        //Runge Kutta Method
                        y.Add(y0);
                        for (double i = x0; i <= x1; i += h)
                            xv.Add(i);
                        for (int j = 0; j < n; j++)
                        {
                            k1 = h * func2(s, xv[j], y[j]);
                            k2 = h * func2(s, xv[j] + (h / 2), y[j] + (k1 / 2));
                            k3 = h * func2(s, xv[j] + (h / 2), y[j] + (k2 / 2));
                            k4 = h * func2(s, xv[j] + (h / 2), y[j] + (k3));
                            k = (0.16666666666666666666666666666667 * (k1 + (2 * k2) + (2 * k3) + k4));
                            y.Add(y[j] + k);
                        }
                        u = y[(int)n];
                        return Math.Round(u, precision);
                    }
                    else
                        return double.NaN;
                }
                catch
                {
                    throw new FormatException("Syntax Error");
                }
            }
            else
                return 0;
        }
        private int hcf(int[] a, int n)
        {
            int hcf = a[0];
            for (int i = 1; i < n; i++)
            {
                hcf = gcd(hcf, a[i]);
            }
            return hcf;
        }
        private int lcma(int[] a, int n)
        {
            int lcm1 = a[0];
            for (int i = 1; i < n; i++)
            {
                lcm1 = lcm(lcm1, a[i]);
            }
            return lcm1;
        }
        private int gcd(int x, int y)
        {
            int m, i;
            if (x > y)
                m = y;
            else
                m = x;
            for (i = m; i >= 1; i--)
            {
                if (x % i == 0 && y % i == 0)
                    break;
            }
            return i;
        }
        private int lcm(int a, int b)
        {
            int c = gcd(a, b);
            int x = a * b;
            return x / c;
        }
        private double rectify(string s, double a, double b)
        {
            double n = 40000;
            double l = 0, t, dx;
            List<double> x = new List<double>();
            List<double> y = new List<double>();
            dx = (b - a) / n;
            for (double i = a; i <= b; i += dx)
                x.Add(i);
            int n1 = x.Count;
            for (int i = 0; i < n1; i += 1)
                y.Add(FEval(s, "x", x[i]));
            l = y[0];
            for (int i = 1; i < n1; i++)
            {
                t = Math.Sqrt(dx * dx + Math.Pow((y[i] - y[i - 1]), 2));
                l += t;
            }
            return l;
        }
        //-----Use round for solutions)=========================================
        private double polar(double x, double y)
        {
            solutions.Clear();
            double r = Math.Sqrt(x * x + y * y);
            double t = Math.Atan2(y, x) * invfactor;
            if (MATHEMATICS.isFrac)
            {
                solutions.Add("r=" + Math.Round(r, precision).ToString(true));
                solutions.Add("θ=" + Math.Round(t, precision).ToString(true));
            }
            if (!MATHEMATICS.isFrac)
            {
                solutions.Add("r=" + Math.Round(r, precision).ToString(false));
                solutions.Add("θ=" + Math.Round(t, precision).ToString(false));
            }
            return 0;
        }
        private double rect(double r, double t)
        {
            solutions.Clear();
            double x = r * Math.Cos(t * factor);
            double y = r * Math.Sin(t * factor);
            if (MATHEMATICS.isFrac)
            {
                solutions.Add("x=" + Math.Round(x, precision).ToString(true));
                solutions.Add("y=" + Math.Round(y, precision).ToString(true));
            }
            if (!MATHEMATICS.isFrac)
            {
                solutions.Add("x=" + Math.Round(x, precision).ToString(false));
                solutions.Add("y=" + Math.Round(y, precision).ToString(false));
            }
            return 0;
        }
        private double ftable(string fx, double a, double b, double h)
        {
            FunctionTable ft = new FunctionTable();
            ft.Hide();
            ds.Tables.Clear();
            func_table.Clear();
            for (double i = a; i <= b; i += h)
            {
                double x = Math.Round(FEval(fx, "x", i), precision);
                func_table.Add(i, x);
            }
            DataTable dt = ds.Tables.Add("Function");
            dt.Columns.Add("x", typeof(double));
            dt.Columns.Add("f(x)", typeof(double));
            IDictionaryEnumerator en = MATHEMATICS.func_table.GetEnumerator();
            DataRow dr = null;
            while (en.MoveNext())
            {
                double index = (double)en.Key;
                double val = (double)en.Value;
                dr = dt.NewRow();
                dr["x"] = index;
                dr["f(x)"] = val;
                dt.Rows.Add(dr);
            }
            ft.Show();
            ft.Text = "y = " + fx;
            return 0;
        }
        private void Cftable(string fz, Complex a, Complex b, double h)
        {
            FunctionTable ft = new FunctionTable();
            ft.Hide();
            ds.Tables.Clear();
            func_table.Clear();
            double i, j;
            if (a.real <= b.real && a.imag <= b.imag)
            {
                System.Windows.MessageBox.Show("here");
                for (i = a.real; i <= b.real; i += h)
                {
                    for (j = a.imag; j <= b.imag; j += h)
                    {
                        Complex d = ComplexFunc(fz, i, j);
                        string z = i + assign(j) + j + "i";
                        func_table[z]= d.ToString();
                    }
                }
            }
            if (a.real <= b.real && a.imag >= b.imag)
            {
                for (i = a.real; i <= b.real; i += h)
                {
                    for (j = b.imag; j <= a.imag; j += h)
                    {
                        Complex d = ComplexFunc(fz, i, j);
                        string z = i + assign(j) + j + "i";
                        func_table[z]= d.ToString();
                    }
                }
            }
            if (a.real >= b.real && a.imag <= b.imag)
            {
                for (i = b.real; i <= a.real; i += h)
                {
                    for (j = a.imag; j <= b.imag; j += h)
                    {
                        Complex d = ComplexFunc(fz, i, j);
                        string z = i + assign(j) + j + "i";
                        func_table[z]= d.ToString();
                    }
                }
            }
            if (a.real >= b.real && a.imag >= b.imag)
            {
                for (i = b.real; i <= a.real; i += h)
                {
                    for (j = b.imag; j <= a.imag; j += h)
                    {
                        Complex d = ComplexFunc(fz, i, j);
                        string z = i + assign(j) + j + "i";
                        func_table[z]= d.ToString();
                    }
                }
            }
            DataTable dt = ds.Tables.Add("Function");
            dt.Columns.Add("z", typeof(string));
            dt.Columns.Add("f(z)", typeof(string));
            IDictionaryEnumerator en = MATHEMATICS.func_table.GetEnumerator();
            DataRow dr = null;
            while (en.MoveNext())
            {
                string  index = en.Key.ToString();
                string val = en.Value.ToString();
                dr = dt.NewRow();
                dr["z"] = index;
                dr["f(z)"] = val;
                dt.Rows.Add(dr);
            }
            ft.Show();
            ft.Text = "w = " + fz;
        }
        private double conversion(int qty, int a)
        {
            switch (qty)
            {
                case 1://angle
                    {
                        switch (a)
                        {
                            case 0:
                                return 1;
                            case 1:
                                return 0.0174532925199433;
                            case 2:
                                return 1.111111111111111;
                            case 3:
                                return 1;
                            case 4:
                                return 57.29577951308233;
                            case 5:
                                return 63.66197723675814;
                            case 6:
                                return 1;
                            case 7:
                                return 0.015707963267949;
                            case 8:
                                return 0.9;
                            default:
                                return 0;
                        }
                    }
                case 2://area
                    {
                        switch (a)
                        {
                            //acres-
                            case 0:
                                return 1;
                            case 1:
                                return 0.40468564224;
                            case 2:
                                return 40468564.224;
                            case 3:
                                return 43560;
                            case 4:
                                return 6272640;
                            case 5:
                                return 0.0040468564224;
                            case 6:
                                return 4046.8564224;
                            case 7:
                                return 0.0015625;
                            case 8:
                                return 4046856422.4;
                            case 9:
                                return 4840;
                            //hectares-
                            case 10:
                                return 2.471053814671653;
                            case 11:
                                return 1;
                            case 12:
                                return 100000000;
                            case 13:
                                return 107639.1041670972;
                            case 14:
                                return 15500031.000062;
                            case 15:
                                return 0.01;
                            case 16:
                                return 10000;
                            case 17:
                                return 0.0038610215854245;
                            case 18:
                                return 10000000000;
                            case 19:
                                return 11959.9004630108;
                            //sq-cm--
                            case 20:
                                return 2.471053814671653e-8;
                            case 21:
                                return 0.00000001;
                            case 22:
                                return 1;
                            case 23:
                                return 0.001076391041671;
                            case 24:
                                return 0.15500031000062;
                            case 25:
                                return 0.0000000001;
                            case 26:
                                return 0.0001;
                            case 27:
                                return 3.861021585424458e-11;
                            case 28:
                                return 100;
                            case 29:
                                return 1.19599004630108e-4;
                            //sq feet--
                            case 30:
                                return 2.295684113865932e-5;
                            case 31:
                                return 0.000009290304;
                            case 32:
                                return 929.0304;
                            case 33:
                                return 1;
                            case 34:
                                return 144;
                            case 35:
                                return 0.00000009290304;
                            case 36:
                                return 0.09290304;
                            case 37:
                                return 3.587006427915519e-8;
                            case 38:
                                return 92903.04;
                            case 39:
                                return 0.1111111111111111;
                            //square inch---
                            case 40:
                                return 1.594225079073564e-7;
                            case 41:
                                return 0.000000064516;
                            case 42:
                                return 6.4516;
                            case 43:
                                return 0.0069444444444444;
                            case 44:
                                return 1;
                            case 45:
                                return 0.00000000064516;
                            case 46:
                                return 0.00064516;
                            case 47:
                                return 2.490976686052444e-10;
                            case 48:
                                return 645.16;
                            case 49:
                                return 7.716049382716049e-4;
                            //sq km----
                            case 50:
                                return 247.1053814671653;
                            case 51:
                                return 100;
                            case 52:
                                return 10000000000;
                            case 53:
                                return 10763910.41670972;
                            case 54:
                                return 1550003100.0062;
                            case 55:
                                return 1;
                            case 56:
                                return 1000000;
                            case 57:
                                return 0.3861021585424458;
                            case 58:
                                return 1000000000000;
                            case 59:
                                return 1195990.04630108;
                            //sqm---
                            case 60:
                                return 2.471053814671653e-4;
                            case 61:
                                return 0.0001;
                            case 62:
                                return 10000;
                            case 63:
                                return 10.76391041670972;
                            case 64:
                                return 1550.0031000062;
                            case 65:
                                return 0.000001;
                            case 66:
                                return 1;
                            case 67:
                                return 3.861021585424458e-7;
                            case 68:
                                return 1000000;
                            case 69:
                                return 1.19599004630108;
                            //sqmile------
                            case 70:
                                return 640;
                            case 71:
                                return 258.9988110336;
                            case 72:
                                return 25899881103.36;
                            case 73:
                                return 27878400;
                            case 74:
                                return 4014489600;
                            case 75:
                                return 2.589988110336;
                            case 76:
                                return 2589988.110336;
                            case 77:
                                return 1;
                            case 78:
                                return 2589988110336;
                            case 79:
                                return 3097600;
                            //sqmm------
                            case 80:
                                return 2.471053814671653e-10;
                            case 81:
                                return 0.0000000001;
                            case 82:
                                return 0.01;
                            case 83:
                                return 1.076391041670972e-5;
                            case 84:
                                return 0.0015500031000062;
                            case 85:
                                return 0.000000000001;
                            case 86:
                                return 0.000001;
                            case 87:
                                return 3.861021585424458e-13;
                            case 88:
                                return 1;
                            case 89:
                                return 1.19599004630108e-6;
                            //sqyd------
                            case 90:
                                return 2.066115702479339e-4;
                            case 91:
                                return 0.000083612736;
                            case 92:
                                return 8361.2736;
                            case 93:
                                return 9;
                            case 94:
                                return 1296;
                            case 95:
                                return 0.00000083612736;
                            case 96:
                                return 0.83612736;
                            case 97:
                                return 3.228305785123967e-7;
                            case 98:
                                return 836127.36;
                            case 99:
                                return 1;
                            default:
                                return 0;
                        }
                    }
                case 3://energy
                    {
                        switch (a)
                        {
                            //btu--
                            case 0:
                                return 1;
                            case 1:
                                return 251.9957963122194;
                            case 2:
                                return 6.585142025517001e+21;
                            case 3:
                                return 778.1693709678747;
                            case 4:
                                return 1055.056;
                            case 5:
                                return 0.2519957963122194;
                            case 6:
                                return 1.055056;
                            //calorie--
                            case 7:
                                return 0.003968320164996;
                            case 8:
                                return 1;
                            case 9:
                                return 2.61319518892216e+19;
                            case 10:
                                return 3.088025206594056;
                            case 11:
                                return 4.1868;
                            case 12:
                                return 0.001;
                            case 13:
                                return 0.0041868;
                            //eV--
                            case 14:
                                return 1.518570132770204e-22;
                            case 15:
                                return 3.826732898633801e-20;
                            case 16:
                                return 1;
                            case 17:
                                return 1.181704764988391e-19;
                            case 18:
                                return 1.60217653e-19;
                            case 19:
                                return 3.826732898633801e-23;
                            case 20:
                                return 1.60217653e-22;
                            //foot pound---
                            case 21:
                                return 0.0012850672839464;
                            case 22:
                                return 0.3238315535328652;
                            case 23:
                                return 8.462350577132721e+18;
                            case 24:
                                return 1;
                            case 25:
                                return 1.3558179483314;
                            case 26:
                                return 3.238315535328652e-4;
                            case 27:
                                return 0.0013558179483314;
                            //joule---
                            case 28:
                                return 9.478169879134378e-4;
                            case 29:
                                return 0.2388458966274959;
                            case 30:
                                return 6.241509479607718e+18;
                            case 31:
                                return 0.7375621492772656;
                            case 32:
                                return 1;
                            case 33:
                                return 2.388458966274959e-4;
                            case 34:
                                return 0.001;
                            //kC-----
                            case 35:
                                return 3.968320164995981;
                            case 36:
                                return 1000;
                            case 37:
                                return 2.61319518892216e+22;
                            case 38:
                                return 3088.025206594056;
                            case 39:
                                return 4186.8;
                            case 40:
                                return 1;
                            case 41:
                                return 4.1868;
                            //kJ
                            case 42:
                                return 0.9478169879134378;
                            case 43:
                                return 238.8458966274959;
                            case 44:
                                return 6.241509479607718e+21;
                            case 45:
                                return 737.5621492772656;
                            case 46:
                                return 1000;
                            case 47:
                                return 0.2388458966274959;
                            case 48:
                                return 1;
                            default:
                                return 0;
                        }
                    }
                case 4://length
                    {
                        switch (a)
                        {  //carat----
                            case 0:
                                return 1;
                            case 1:
                                return 0.00000001;
                            case 2:
                                return 4.970969537898672e-12;
                            case 3:
                                return 5.468066491688539e-11;
                            case 4:
                                return 3.280839895013123e-10;
                            case 5:
                                return 9.84251968503937e-10;
                            case 6:
                                return 3.937007874015748e-9;
                            case 7:
                                return 0.0000000000001;
                            case 8:
                                return 4.970969537898672e-10;
                            case 9:
                                return 0.0000000001;
                            case 10:
                                return 0.0001;
                            case 11:
                                return 6.21371192237334e-14;
                            case 12:
                                return 0.0000001;
                            case 13:
                                return 0.1;
                            case 14:
                                return 5.399568034557235e-14;
                            case 15:
                                return 2.371063015836614e-8;
                            case 16:
                                return 1.988387815159469e-11;
                            case 17:
                                return 4.374453193350831e-10;
                            case 18:
                                return 1.093613298337708e-10;
                            //centigram----//////////////////////////////////////////////////////////////////////////////////////////////////
                            case 19:
                                return 100000000;
                            case 20:
                                return 1;
                            case 21:
                                return 4.970969537898672e-4;
                            case 23:
                                return 0.0054680664916885;
                            case 24:
                                return 0.0328083989501312;
                            case 25:
                                return 0.0984251968503937;
                            case 26:
                                return 0.3937007874015748;
                            case 27:
                                return 0.00001;
                            case 28:
                                return 0.0497096953789867;
                            case 29:
                                return 0.01;
                            case 30:
                                return 10000;
                            case 31:
                                return 6.21371192237334e-6;
                            case 32:
                                return 10;
                            case 33:
                                return 10000000;
                            case 34:
                                return 5.399568034557235e-6;
                            case 35:
                                return 2.371063015836614;
                            case 36:
                                return 0.0019883878151595;
                            case 37:
                                return 0.0437445319335083;
                            case 38:
                                return 0.0109361329833771;
                            //decigram---
                            case 39:
                                return 201168000000;
                            case 40:
                                return 2011.68;
                            case 41:
                                return 1;
                            case 42:
                                return 11;
                            case 43:
                                return 66;
                            case 44:
                                return 198;
                            case 45:
                                return 792;
                            case 46:
                                return 0.0201168;
                            case 47:
                                return 100;
                            case 48:
                                return 20.1168;
                            case 49:
                                return 20116800;
                            case 50:
                                return 20116800;
                            case 51:
                                return 20116.8;
                            case 52:
                                return 20116800000;
                            case 53:
                                return 0.0108622030237581;
                            case 54:
                                return 4769.8200476982;
                            case 55:
                                return 4;
                            case 56:
                                return 88;
                            case 57:
                                return 22;
                            //dekagram---///////////////////////////////////////////////////////////////////////////////////////////////////////////
                            case 58:
                                return 18288000000;
                            case 59:
                                return 182.88;
                            case 60:
                                return 0.0909090909090909;
                            case 61:
                                return 1;
                            case 62:
                                return 6;
                            case 63:
                                return 18;
                            case 64:
                                return 72;
                            case 65:
                                return 0.0018288;
                            case 66:
                                return 9.090909090909091;
                            case 67:
                                return 1.8288;
                            case 68:
                                return 1828800;
                            case 69:
                                return 0.0011363636363636;
                            case 70:
                                return 1828.8;
                            case 71:
                                return 1828800000;
                            case 72:
                                return 9.874730021598272e-4;
                            case 73:
                                return 433.6200043362;
                            case 74:
                                return 0.3636363636363636;
                            case 75:
                                return 8;
                            case 76:
                                return 2;
                            //gram---
                            case 77:
                                return 3048000000;
                            case 78:
                                return 30.48; ;
                            case 79:
                                return 0.0151515151515152;
                            case 80:
                                return 0.1666666666666667;
                            case 81:
                                return 1;
                            case 82:
                                return 3;
                            case 83:
                                return 12;
                            case 84:
                                return 0.0003048;
                            case 85:
                                return 1.515151515151515;
                            case 86:
                                return 0.3048;
                            case 87:
                                return 304800;
                            case 88:
                                return 1.893939393939394e-4;
                            case 89:
                                return 304.8;
                            case 90:
                                return 304800000;
                            case 91:
                                return 1.645788336933045e-4;
                            case 92:
                                return 72.27000072270001;
                            case 93:
                                return 0.0606060606060606;
                            case 94:
                                return 1.333333333333333;
                            case 95:
                                return 0.3333333333333333;
                            //hectogram
                            case 96:
                                return 1016000000;
                            case 97:
                                return 10.16;
                            case 98:
                                return 0.0050505050505051;
                            case 99:
                                return 0.0555555555555556;
                            case 100:
                                return 0.3333333333333333;
                            case 101:
                                return 1;
                            case 102:
                                return 4;
                            case 103:
                                return 0.0001016;
                            case 104:
                                return 0.5050505050505051;
                            case 105:
                                return 0.1016;
                            case 106:
                                return 101600;
                            case 107:
                                return 6.313131313131313e-5;
                            case 108:
                                return 101.6;
                            case 109:
                                return 101600000;
                            case 110:
                                return 5.485961123110151e-5;
                            case 111:
                                return 24.0900002409;
                            case 112:
                                return 0.0202020202020202;
                            case 113:
                                return 0.4444444444444444;
                            case 114:
                                return 0.1111111111111111;
                            //kg----
                            case 115:
                                return 254000000;
                            case 116:
                                return 2.54;
                            case 117:
                                return 0.0012626262626263;
                            case 118:
                                return 0.0138888888888889;
                            case 119:
                                return 0.0833333333333333;
                            case 120:
                                return 0.25;
                            case 121:
                                return 1;
                            case 122:
                                return 0.0000254;
                            case 123:
                                return 0.1262626262626263;
                            case 124:
                                return 0.0254;
                            case 125:
                                return 25400;
                            case 126:
                                return 1.578282828282828e-5;
                            case 127:
                                return 25.4;
                            case 128:
                                return 25400000;
                            case 129:
                                return 1.371490280777538e-5;
                            case 130:
                                return 6.022500060225001;
                            case 131:
                                return 0.0050505050505051;
                            case 132:
                                return 0.1111111111111111;
                            case 133:
                                return 0.0277777777777778;
                            //longton---
                            case 134:
                                return 10000000000000;
                            case 135:
                                return 100000;
                            case 136:
                                return 49.70969537898672;
                            case 137:
                                return 546.8066491688539;
                            case 138:
                                return 3280.839895013123;
                            case 139:
                                return 9842.51968503937;
                            case 140:
                                return 39370.07874015748;
                            case 141:
                                return 1;
                            case 142:
                                return 4970.969537898672;
                            case 143:
                                return 1000;
                            case 144:
                                return 1000000000;
                            case 145:
                                return 0.621371192237334;
                            case 146:
                                return 1000000;
                            case 147:
                                return 1000000000000;
                            case 148:
                                return 0.5399568034557235;
                            case 149:
                                return 237106.3015836614;
                            case 150:
                                return 198.8387815159469;
                            case 151:
                                return 4374.453193350831;
                            case 152:
                                return 1093.613298337708;
                            //mg----
                            case 153:
                                return 2011680000;
                            case 154:
                                return 20.1168;
                            case 155:
                                return 0.01;
                            case 156:
                                return 0.11;
                            case 157:
                                return 0.66;
                            case 158:
                                return 1.98;
                            case 159:
                                return 7.92;
                            case 160:
                                return 0.000201168;
                            case 161:
                                return 1;
                            case 162:
                                return 0.201168;
                            case 163:
                                return 201168;
                            case 164:
                                return 0.000125;
                            case 165:
                                return 201.168;
                            case 166:
                                return 201168000;
                            case 167:
                                return 1.08622030237581e-4;
                            case 168:
                                return 47.698200476982;
                            case 169:
                                return 0.04;
                            case 170:
                                return 0.88;
                            case 171:
                                return 0.22;
                            //ounce---
                            case 172:
                                return 10000000000;
                            case 173:
                                return 100;
                            case 174:
                                return 0.0497096953789867;
                            case 175:
                                return 0.5468066491688539;
                            case 176:
                                return 3.280839895013123;
                            case 177:
                                return 9.84251968503937;
                            case 178:
                                return 39.37007874015748;
                            case 179:
                                return 0.001;
                            case 180:
                                return 4.970969537898672;
                            case 181:
                                return 1;
                            case 182:
                                return 1000000;
                            case 183:
                                return 6.21371192237334e-4;
                            case 184:
                                return 1000;
                            case 185:
                                return 1000000000;
                            case 186:
                                return 5.399568034557235e-4;
                            case 187:
                                return 237.1063015836614;
                            case 188:
                                return 0.1988387815159469;
                            case 189:
                                return 4.374453193350831;
                            case 190:
                                return 1.093613298337708;
                            //pound---
                            case 191:
                                return 10000;
                            case 192:
                                return 0.0001;
                            case 193:
                                return 4.970969537898672e-8;
                            case 194:
                                return 5.468066491688539e-7;
                            case 195:
                                return 3.280839895013123e-6;
                            case 196:
                                return 9.84251968503937e-6; ;
                            case 197:
                                return 3.937007874015748e-5;
                            case 198:
                                return 0.000000001;
                            case 199:
                                return 4.970969537898672e-6;
                            case 200:
                                return 0.000001;
                            case 201:
                                return 1;
                            case 202:
                                return 6.21371192237334e-10;
                            case 203:
                                return 0.001;
                            case 204:
                                return 1000;
                            case 205:
                                return 5.399568034557235e-10;
                            case 206:
                                return 2.371063015836614e-4;
                            case 207:
                                return 1.988387815159469e-7;
                            case 208:
                                return 4.374453193350831e-6;
                            case 209:
                                return 1.093613298337708e-6;
                            //shton
                            case 210:
                                return 16093440000000;
                            case 211:
                                return 160934.4;
                            case 212:
                                return 80;
                            case 213:
                                return 880;
                            case 214:
                                return 5280;
                            case 215:
                                return 15840;
                            case 216:
                                return 63360;
                            case 217:
                                return 1.609344;
                            case 218:
                                return 8000;
                            case 219:
                                return 1609.344;
                            case 220:
                                return 1609344000;
                            case 221:
                                return 1;
                            case 222:
                                return 1609344;
                            case 223:
                                return 1609344000000;
                            case 224:
                                return 0.8689762419006479;
                            case 225:
                                return 381585.603815856;
                            case 226:
                                return 320;
                            case 227:
                                return 7040;
                            case 228:
                                return 1760;
                            //stone---
                            case 229:
                                return 10000000;
                            case 230:
                                return 0.1;
                            case 231:
                                return 4.970969537898672e-5;
                            case 232:
                                return 5.468066491688539e-4;
                            case 233:
                                return 0.0032808398950131;
                            case 234:
                                return 0.0098425196850394;
                            case 235:
                                return 0.0393700787401575;
                            case 236:
                                return 0.000001;
                            case 237:
                                return 0.0049709695378987;
                            case 238:
                                return 0.001;
                            case 239:
                                return 1000;
                            case 240:
                                return 6.21371192237334e-7;
                            case 241:
                                return 1;
                            case 242:
                                return 1000000;
                            case 243:
                                return 5.399568034557235e-7;
                            case 244:
                                return 0.2371063015836614;
                            case 245:
                                return 1.988387815159469e-4;
                            case 246:
                                return 1.988387815159469e-4;
                            case 247:
                                return 0.0010936132983377;
                            //tonne---/////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            case 248:
                                return 10;
                            case 249:
                                return 0.0000001;
                            case 250:
                                return 4.970969537898672e-11;
                            case 251:
                                return 5.468066491688539e-10;
                            case 252:
                                return 3.280839895013123e-9;
                            case 253:
                                return 9.84251968503937e-9;
                            case 254:
                                return 3.937007874015748e-8;
                            case 255:
                                return 0.000000000001;
                            case 256:
                                return 4.970969537898672e-9;
                            case 257:
                                return 0.000000001;
                            case 258:
                                return 0.001;
                            case 259:
                                return 6.21371192237334e-13;
                            case 260:
                                return 0.000001;
                            case 261:
                                return 1;
                            case 262:
                                return 5.399568034557235e-13;
                            case 263:
                                return 2.371063015836614e-7;
                            case 264:
                                return 1.988387815159469e-10;
                            case 265:
                                return 4.374453193350831e-9;
                            case 266:
                                return 1.093613298337708e-9;
                            ///
                            case 267:
                                return 18520000000000;
                            case 268:
                                return 185200;
                            case 269:
                                return 92.0623558418834;
                            case 270:
                                return 1012.685914260717;
                            case 271:
                                return 6076.115485564304;
                            case 272:
                                return 18228.34645669291;
                            case 273:
                                return 72913.38582677165;
                            case 274:
                                return 1.852;
                            case 275:
                                return 9206.23558418834;
                            case 276:
                                return 1852;
                            case 277:
                                return 1852000000;
                            case 278:
                                return 1.150779448023543;
                            case 279:
                                return 1852000;
                            case 280:
                                return 1852000000000;
                            case 281:
                                return 1;
                            case 282:
                                return 439120.870532941;
                            case 283:
                                return 368.2494233675336;
                            case 284:
                                return 8101.487314085739;
                            case 285:
                                return 2025.371828521435;
                            ///
                            case 286:
                                return 42175176;
                            case 287:
                                return 0.42175176;
                            case 288:
                                return 2.096515151515152e-4;
                            case 289:
                                return 0.0023061666666667;
                            case 290:
                                return 0.013837;
                            case 291:
                                return 0.041511;
                            case 292:
                                return 0.166044;
                            case 293:
                                return 0.0000042175176;
                            case 294:
                                return 0.0209651515151515;
                            case 295:
                                return 0.0042175176;
                            case 296:
                                return 4217.5176;
                            case 297:
                                return 2.620643939393939e-6;
                            case 298:
                                return 4.2175176;
                            case 299:
                                return 4217517.6;
                            case 300:
                                return 2.277277321814255e-6;
                            case 301:
                                return 1;
                            case 302:
                                return 8.386060606060606e-4;
                            case 303:
                                return 0.0184493333333333;
                            case 304:
                                return 0.0046123333333333;
                            ///
                            case 305:
                                return 50292000000;
                            case 306:
                                return 502.92;
                            case 307:
                                return 0.25;
                            case 308:
                                return 2.75;
                            case 309:
                                return 16.5;
                            case 310:
                                return 49.5;
                            case 311:
                                return 198;
                            case 312:
                                return 0.0050292;
                            case 313:
                                return 25;
                            case 314:
                                return 5.0292;
                            case 315:
                                return 5.0292;
                            case 316:
                                return 0.003125;
                            case 317:
                                return 5029.2;
                            case 318:
                                return 5029200000;
                            case 319:
                                return 0.0027155507559395;
                            case 320:
                                return 1192.45501192455;
                            case 321:
                                return 1;
                            case 322:
                                return 22;
                            case 323:
                                return 5.5;
                            ///
                            case 324:
                                return 2286000000;
                            case 325:
                                return 22.86;
                            case 326:
                                return 0.0113636363636364;
                            case 327:
                                return 0.125;
                            case 328:
                                return 0.75;
                            case 329:
                                return 2.25;
                            case 330:
                                return 9;
                            case 331:
                                return 0.0002286;
                            case 332:
                                return 1.136363636363636;
                            case 333:
                                return 0.2286;
                            case 334:
                                return 228600;
                            case 335:
                                return 1.420454545454545e-4;
                            case 336:
                                return 228.6;
                            case 337:
                                return 228600000;
                            case 338:
                                return 1.234341252699784e-4;
                            case 339:
                                return 54.20250054202501;
                            case 340:
                                return 0.0454545454545455;
                            case 341:
                                return 1;
                            case 342:
                                return 0.25;
                            ///
                            case 343:
                                return 9144000000;
                            case 344:
                                return 91.44;
                            case 345:
                                return 0.0454545454545455;
                            case 346:
                                return 0.5;
                            case 347:
                                return 3;
                            case 348:
                                return 9;
                            case 349:
                                return 36;
                            case 350:
                                return 0.0009144;
                            case 351:
                                return 4.545454545454545;
                            case 352:
                                return 0.9144;
                            case 353:
                                return 914400;
                            case 354:
                                return 914400;
                            case 355:
                                return 914.4;
                            case 356:
                                return 914400000;
                            case 357:
                                return 4.937365010799136e-4;
                            case 358:
                                return 216.8100021681;
                            case 359:
                                return 0.1818181818181818;
                            case 360:
                                return 4;
                            case 361:
                                return 1;
                            default:
                                return 0;
                        }
                    }
                case 5://power
                    {
                        switch (a)
                        {
                            //btu/m----
                            case 0:
                                return 1;
                            case 1:
                                return 778.1693709678747;
                            case 2:
                                return 0.0235808900293295;
                            case 3:
                                return 0.0175842666666667;
                            case 4:
                                return 17.58426666666667;
                            //fp/m--
                            case 5:
                                return 0.0012850672839464;
                            case 6:
                                return 1;
                            case 7:
                                return 3.030303030303029e-5;
                            case 8:
                                return 2.259696580552333e-5;
                            case 9:
                                return 0.0225969658055233;
                            //hp---
                            case 10:
                                return 42.40722037023268;
                            case 11:
                                return 33000.00000000001;
                            case 12:
                                return 1;
                            case 13:
                                return 0.7456998715822702;
                            case 14:
                                return 745.6998715822702;
                            //kW----
                            case 15:
                                return 56.86901927480627;
                            case 16:
                                return 44253.72895663593;
                            case 17:
                                return 1.341022089595028;
                            case 18:
                                return 1;
                            case 19:
                                return 1000;
                            //W-----
                            case 20:
                                return 0.0568690192748063;
                            case 21:
                                return 44.25372895663593;
                            case 22:
                                return 0.001341022089595;
                            case 23:
                                return 0.001;
                            case 24:
                                return 1;
                            default: return 0;
                        }
                    }
                case 6:///pressure
                    {
                        switch (a)
                        {
                            //atmosphere
                            case 0:
                                return 1;
                            case 1:
                                return 1.01325;
                            case 2:
                                return 101.325;
                            case 3:
                                return 760.1275318829707;
                            case 4:
                                return 101325;
                            case 5:
                                return 14.69594940039221;
                            //bar
                            case 6:
                                return 0.9869232667160128;
                            case 7:
                                return 1;
                            case 8:
                                return 100;
                            case 9:
                                return 750.1875468867217;
                            case 10:
                                return 100000;
                            case 11:
                                return 14.50377438972831;
                            //kP
                            case 12:
                                return 0.0098692326671601;
                            case 13:
                                return 0.01;
                            case 14:
                                return 1;
                            case 15:
                                return 7.501875468867217;
                            case 16:
                                return 1000;
                            case 17:
                                return 0.1450377438972831;
                            //mOfHg
                            case 18:
                                return 0.0013155687145324;
                            case 19:
                                return 0.001333;
                            case 20:
                                return 0.1333;
                            case 21:
                                return 1;
                            case 22:
                                return 133.3;
                            case 23:
                                return 0.0193335312615078;
                            //Pascal
                            case 24:
                                return 9.869232667160128e-6;
                            case 25:
                                return 0.00001;
                            case 26:
                                return 0.001;
                            case 27:
                                return 0.0075018754688672;
                            case 28:
                                return 1;
                            case 29:
                                return 1.450377438972831e-4;
                            //psi
                            case 30:
                                return 0.068045961016531;
                            case 31:
                                return 0.06894757;
                            case 32:
                                return 6.894757;
                            case 33:
                                return 51.72360840210053;
                            case 34:
                                return 6894.757;
                            case 35:
                                return 1;
                            default:
                                return 0;
                        }
                    }
                case 7://temperature
                    {
                        switch (a)
                        {
                            //dgc----
                            case 0:
                                return 1;
                            case 1:
                                return 33.8;
                            case 2:
                                return 274.15;
                            //deg fare---
                            case 3:
                                return -17.22222222222222;
                            case 4:
                                return 1;
                            case 5:
                                return 255.9277777777778;
                            //kelvin------
                            case 6:
                                return -272.15;
                            case 7:
                                return -457.87;
                            case 8:
                                return 1;
                            default:
                                return 0;
                        }
                    }
                case 8://time
                    {
                        switch (a)
                        {
                            //day----
                            case 0:
                                return 1;
                            case 1:
                                return 24;
                            case 2:
                                return 86400000000;
                            case 3:
                                return 86400000;
                            case 4:
                                return 1440;
                            case 5:
                                return 86400;
                            case 6:
                                return 0.1428571428571429;
                            //hour----
                            case 7:
                                return 0.0416666666666667;
                            case 8:
                                return 1;
                            case 9:
                                return 3600000000;
                            case 10:
                                return 3600000;
                            case 11:
                                return 60;
                            case 12:
                                return 3600;
                            case 13:
                                return 0.005952380952381;
                            //microseconds-----
                            case 14:
                                return 1.157407407407407e-11;
                            case 15:
                                return 2.777777777777778e-10;
                            case 16:
                                return 1;
                            case 17:
                                return 0.001;
                            case 18:
                                return 1.666666666666667e-8;
                            case 19:
                                return 0.000001;
                            case 20:
                                return 1.653439153439153e-12;
                            //milliseconds---
                            case 21:
                                return 1.157407407407407e-8;
                            case 22:
                                return 2.777777777777778e-7;
                            case 23:
                                return 1000;
                            case 24:
                                return 1;
                            case 25:
                                return 1.666666666666667e-5;
                            case 26:
                                return 0.001;
                            case 27:
                                return 1.653439153439153e-9;
                            //minutes-----
                            case 28:
                                return 6.944444444444444e-4;
                            case 29:
                                return 0.0166666666666667;
                            case 30:
                                return 60000000;
                            case 31:
                                return 60000;
                            case 32:
                                return 1;
                            case 33:
                                return 60;
                            case 34:
                                return 9.920634920634921e-5;
                            //seconds----
                            case 35:
                                return 1.157407407407407e-5;
                            case 36:
                                return 2.777777777777778e-4;
                            case 37:
                                return 1000000;
                            case 38:
                                return 1000;
                            case 39:
                                return 0.0166666666666667;
                            case 40:
                                return 1;
                            case 41:
                                return 1.653439153439153e-6;
                            //week--
                            case 42:
                                return 7;
                            case 43:
                                return 168;
                            case 44:
                                return 604800000000;
                            case 45:
                                return 604800000;
                            case 46:
                                return 10080;
                            case 47:
                                return 604800;
                            case 48:
                                return 1;
                            default:
                                return 0;
                        }
                    }
                case 9://velocity
                    {
                        switch (a)
                        {
                            //cm/s----
                            case 0:
                                return 1;
                            case 1:
                                return 0.0328083989501312;
                            case 2:
                                return 0.036;
                            case 3:
                                return 0.019438444924406;
                            case 4:
                                return 2.938641460175678e-5;
                            case 5:
                                return 0.01;
                            case 6:
                                return 0.022369362920544;
                            //fps-----
                            case 7:
                                return 30.48;
                            case 8:
                                return 1;
                            case 9:
                                return 1.09728;
                            case 10:
                                return 0.5924838012958963;
                            case 11:
                                return 8.956979170615466e-4;
                            case 12:
                                return 0.3048;
                            case 13:
                                return 0.6818181818181818;
                            //kmph---
                            case 14:
                                return 27.77777777777778;
                            case 15:
                                return 0.9113444152814232;
                            case 16:
                                return 1;
                            case 17:
                                return 0.5399568034557235;
                            case 18:
                                return 8.162892944932439e-4;
                            case 19:
                                return 0.2777777777777778;
                            case 20:
                                return 0.621371192237334;
                            //knots----
                            case 21:
                                return 51.44444444444444;
                            case 22:
                                return 1.687809857101196;
                            case 23:
                                return 1.852;
                            case 24:
                                return 1;
                            case 25:
                                return 0.0015117677734015;
                            case 26:
                                return 0.5144444444444444;
                            case 27:
                                return 1.150779448023543;
                            //mach----
                            case 28:
                                return 34029.33;
                            case 29:
                                return 1116.447834645669;
                            case 30:
                                return 1225.05588;
                            case 31:
                                return 661.4772570194384;
                            case 32:
                                return 1;
                            case 33:
                                return 340.2933;
                            case 34:
                                return 761.2144327129563;
                            //mps----
                            case 35:
                                return 100;
                            case 36:
                                return 3.280839895013123;
                            case 37:
                                return 3.6;
                            case 38:
                                return 1.943844492440605;
                            case 39:
                                return 0.0029386414601757;
                            case 40:
                                return 1;
                            case 41:
                                return 2.2369362920544024;
                            //miph---
                            case 42:
                                return 44.704;
                            case 43:
                                return 1.466666666666667;
                            case 44:
                                return 1.609344;
                            case 45:
                                return 0.8689762419006479;
                            case 46:
                                return 0.0013136902783569;
                            case 47:
                                return 0.44704;
                            case 48:
                                return 1;
                            default: return 0;
                        }
                    }
                case 10://vlme
                    {
                        switch (a)
                        {  //carat----
                            case 0:
                                return 1;
                            case 1:
                                return 3.531466672148859e-5;
                            case 2:
                                return 0.0610237440947323;
                            case 3:
                                return 0.000001;
                            case 4:
                                return 1.307950619314392e-6;
                            case 5:
                                return 0.035195079727854;
                            case 6:
                                return 0.033814022701843;
                            case 7:
                                return 2.199692482990878e-4;
                            case 8:
                                return 2.641720523581484e-4;
                            case 9:
                                return 0.001;
                            case 10:
                                return 0.0017597539863927;
                            case 11:
                                return 0.0021133764188652;
                            case 12:
                                return 8.798769931963512e-4;
                            case 13:
                                return 0.0010566882094326;
                            //centigram----//////////////////////////////////////////////////////////////////////////////////////////////////
                            case 14:
                                return 28316.846592;
                            case 15:
                                return 1;
                            case 16:
                                return 1728;
                            case 17:
                                return 0.028316846592;
                            case 18:
                                return 0.037037037037037;
                            case 19:
                                return 996.6136734468521;
                            case 20:
                                return 957.5064935064935;
                            case 21:
                                return 6.228835459042826;
                            case 22:
                                return 7.480519480519481;
                            case 23:
                                return 28.316846592;
                            case 24:
                                return 49.83068367234261;
                            case 25:
                                return 59.84415584415584;
                            case 26:
                                return 24.9153418361713;
                            case 27:
                                return 29.92207792207792;
                            //decigram---
                            case 28:
                                return 16.387064;
                            case 29:
                                return 5.787037037037037e-4;
                            case 30:
                                return 1;
                            case 31:
                                return 0.000016387064;
                            case 32:
                                return 2.143347050754458e-5;
                            case 33:
                                return 0.5767440239854468;
                            case 34:
                                return 0.5541125541125541;
                            case 35:
                                return 0.003604650149909;
                            case 36:
                                return 0.0043290043290043;
                            case 37:
                                return 0.016387064;
                            case 38:
                                return 0.0288372011992723;
                            case 39:
                                return 0.0346320346320346;
                            case 40:
                                return 0.0144186005996362;
                            case 41:
                                return 0.0173160173160173;
                            //dekagram---
                            case 42:
                                return 1000000;
                            case 43:
                                return 35.31466672148859;
                            case 44:
                                return 61023.74409473228;
                            case 45:
                                return 1;
                            case 46:
                                return 1.307950619314392;
                            case 47:
                                return 35195.07972785405;
                            case 48:
                                return 33814.022701843;
                            case 49:
                                return 219.9692482990878;
                            case 50:
                                return 264.1720523581484;
                            case 51:
                                return 1000;
                            case 52:
                                return 1759.753986392702;
                            case 53:
                                return 2113.376418865187;
                            case 54:
                                return 879.8769931963512;
                            case 55:
                                return 1056.688209432594;
                            //gram---
                            case 56:
                                return 764554.857984;
                            case 57:
                                return 27;
                            case 58:
                                return 46656;
                            case 59:
                                return 0.764554857984;
                            case 60:
                                return 1;
                            case 61:
                                return 26908.56918306501;
                            case 62:
                                return 25852.67532467532;
                            case 63:
                                return 168.1785573941563;
                            case 64:
                                return 201.974025974026;
                            case 65:
                                return 764.554857984;
                            case 66:
                                return 1345.42845915325;
                            case 67:
                                return 1615.792207792208;
                            case 68:
                                return 672.7142295766252;
                            case 69:
                                return 807.8961038961039;
                            //hectogram
                            case 70:
                                return 28.4130625;
                            case 71:
                                return 0.0010033978327243;
                            case 72:
                                return 1.733871454947634;
                            case 73:
                                return 0.0000284130625;
                            case 74:
                                return 3.716288269349353e-5;
                            case 75:
                                return 1;
                            case 76:
                                return 0.9607599404038839;
                            case 77:
                                return 0.00625;
                            case 78:
                                return 0.0075059370344053;
                            case 79:
                                return 0.0284130625;
                            case 80:
                                return 0.05;
                            case 81:
                                return 0.0600474962752427;
                            case 82:
                                return 0.025;
                            case 83:
                                return 0.0300237481376214;
                            //kg----
                            case 84:
                                return 29.5735295625;
                            case 85:
                                return 0.0010443793402778;
                            case 86:
                                return 1.8046875;
                            case 87:
                                return 0.0000295735295625;
                            case 88:
                                return 3.868071630658436e-5;
                            case 89:
                                return 1.040842730786236;
                            case 90:
                                return 1;
                            case 91:
                                return 0.006505267067414;
                            case 92:
                                return 0.0078125;
                            case 93:
                                return 0.0295735295625;
                            case 94:
                                return 0.0520421365393118;
                            case 95:
                                return 0.0625;
                            case 96:
                                return 0.0260210682696559;
                            case 97:
                                return 0.03125;
                            //longton---
                            case 98:
                                return 4546.09;
                            case 99:
                                return 0.1605436532358921;
                            case 100:
                                return 277.4194327916215;
                            case 101:
                                return 0.00454609;
                            case 102:
                                return 0.005946061230959;
                            case 103:
                                return 160;
                            case 104:
                                return 153.7215904646214;
                            case 105:
                                return 1;
                            case 106:
                                return 1.200949925504855;
                            case 107:
                                return 4.54609;
                            case 108:
                                return 8;
                            case 109:
                                return 9.607599404038839;
                            case 110:
                                return 4;
                            case 111:
                                return 4.80379970201942;
                            //mg----
                            case 112:
                                return 3785.411784;
                            case 113:
                                return 0.1336805555555556;
                            case 114:
                                return 231;
                            case 115:
                                return 0.003785411784;
                            case 116:
                                return 0.0049511316872428;
                            case 117:
                                return 133.2278695406382;
                            case 118:
                                return 128;
                            case 119:
                                return 0.8326741846289889;
                            case 120:
                                return 1;
                            case 121:
                                return 3.785411784;
                            case 122:
                                return 6.661393477031911;
                            case 123:
                                return 8;
                            case 124:
                                return 3.330696738515955;
                            case 125:
                                return 4;
                            //ounce---
                            case 126:
                                return 1000;
                            case 127:
                                return 0.0353146667214886;
                            case 128:
                                return 61.02374409473228;
                            case 129:
                                return 0.001;
                            case 130:
                                return 0.0013079506193144;
                            case 131:
                                return 35.19507972785405;
                            case 132:
                                return 33.814022701843;
                            case 133:
                                return 0.2199692482990878;
                            case 134:
                                return 0.2641720523581484;
                            case 135:
                                return 1;
                            case 136:
                                return 1.759753986392702;
                            case 137:
                                return 2.113376418865187;
                            case 138:
                                return 0.8798769931963512;
                            case 139:
                                return 1.056688209432594;
                            //pound---
                            case 140:
                                return 568.26125;
                            case 141:
                                return 0.0200679566544865;
                            case 142:
                                return 34.67742909895269;
                            case 143:
                                return 0.00056826125;
                            case 144:
                                return 7.432576538698707e-4;
                            case 145:
                                return 20;
                            case 146:
                                return 19.21519880807768;
                            case 147:
                                return 0.125;
                            case 148:
                                return 0.1501187406881069;
                            case 149:
                                return 0.56826125;
                            case 150:
                                return 1;
                            case 151:
                                return 1.200949925504855;
                            case 152:
                                return 0.5;
                            case 153:
                                return 0.6004749627524275;
                            //shton
                            case 154:
                                return 473.176473;
                            case 155:
                                return 0.0167100694444444;
                            case 156:
                                return 28.875;
                            case 157:
                                return 0.000473176473;
                            case 158:
                                return 6.188914609053498e-4;
                            case 159:
                                return 16.65348369257978;
                            case 160:
                                return 16;
                            case 161:
                                return 0.1040842730786236;
                            case 162:
                                return 0.125;
                            case 163:
                                return 0.473176473;
                            case 164:
                                return 0.8326741846289889;
                            case 165:
                                return 1;
                            case 166:
                                return 0.4163370923144944;
                            case 167:
                                return 0.5;
                            //stone---
                            case 168:
                                return 1136.5225;
                            case 169:
                                return 0.040135913308973;
                            case 170:
                                return 69.35485819790537;
                            case 171:
                                return 0.0011365225;
                            case 172:
                                return 0.0014865153077397;
                            case 173:
                                return 40;
                            case 174:
                                return 38.43039761615536;
                            case 175:
                                return 0.25;
                            case 176:
                                return 0.3002374813762137;
                            case 177:
                                return 1.1365225;
                            case 178:
                                return 2;
                            case 179:
                                return 2.40189985100971;
                            case 180:
                                return 1;
                            case 181:
                                return 1.200949925504855;
                            //tonne---
                            case 182:
                                return 946.352946;
                            case 183:
                                return 0.0334201388888889;
                            case 184:
                                return 57.75;
                            case 185:
                                return 0.000946352946;
                            case 186:
                                return 0.0012377829218107;
                            case 187:
                                return 33.30696738515955;
                            case 188:
                                return 32;
                            case 189:
                                return 0.2081685461572472;
                            case 190:
                                return 0.25;
                            case 191:
                                return 0.946352946;
                            case 192:
                                return 1.665348369257978;
                            case 193:
                                return 2;
                            case 194:
                                return 0.8326741846289889;
                            case 195:
                                return 1;
                            default:
                                return 0;
                        }
                    }
                case 11://mass
                    {
                        switch (a)
                        {  //carat----
                            case 0:
                                return 1;
                            case 1:
                                return 20;
                            case 2:
                                return 2;
                            case 3:
                                return 0.02;
                            case 4:
                                return 0.2;
                            case 5:
                                return 0.002;
                            case 6:
                                return 0.0002;
                            case 7:
                                return 1.968413055222121e-7;
                            case 8:
                                return 200;
                            case 9:
                                return 0.0070547923899161;
                            case 10:
                                return 4.409245243697552e-4;
                            case 11:
                                return 2.204622621848776e-7;
                            case 12:
                                return 3.149460888355394e-5;
                            case 13:
                                return 0.0000002;
                            //centigram----
                            case 14:
                                return 0.05;
                            case 15:
                                return 1;
                            case 16:
                                return 0.1;
                            case 17:
                                return 0.001;
                            case 18:
                                return 0.01;
                            case 19:
                                return 0.0001;
                            case 20:
                                return 0.00001;
                            case 21:
                                return 9.842065276110606e-9;
                            case 22:
                                return 10;
                            case 23:
                                return 3.527396194958041e-4;
                            case 24:
                                return 2.204622621848776e-5;
                            case 25:
                                return 1.102311310924388e-8;
                            case 26:
                                return 1.574730444177697e-6;
                            case 27:
                                return 0.00000001;
                            //decigram---
                            case 28:
                                return 0.5;
                            case 29:
                                return 10;
                            case 30:
                                return 1;
                            case 31:
                                return 0.01;
                            case 32:
                                return 0.1;
                            case 33:
                                return 0.001;
                            case 34:
                                return 0.0001;
                            case 35:
                                return 9.842065276110606e-8;
                            case 36:
                                return 100;
                            case 37:
                                return 0.003527396194958;
                            case 38:
                                return 2.204622621848776e-4;
                            case 39:
                                return 1.102311310924388e-7;
                            case 40:
                                return 1.574730444177697e-5;
                            case 41:
                                return 0.0000001;
                            //dekagram---
                            case 42:
                                return 50;
                            case 43:
                                return 1000;
                            case 44:
                                return 100;
                            case 45:
                                return 1;
                            case 46:
                                return 10;
                            case 47:
                                return 0.1;
                            case 48:
                                return 0.01;
                            case 49:
                                return 9.842065276110606e-6;
                            case 50:
                                return 10000;
                            case 51:
                                return 0.3527396194958041;
                            case 52:
                                return 0.0220462262184878;
                            case 53:
                                return 1.102311310924388e-5;
                            case 54:
                                return 0.0015747304441777;
                            case 55:
                                return 0.00001;
                            //gram---
                            case 56:
                                return 5;
                            case 57:
                                return 100;
                            case 58:
                                return 10;
                            case 59:
                                return 0.1;
                            case 60:
                                return 1;
                            case 61:
                                return 0.01;
                            case 62:
                                return 0.001;
                            case 63:
                                return 9.842065276110606e-7;
                            case 64:
                                return 1000;
                            case 65:
                                return 0.0352739619495804;
                            case 66:
                                return 0.0022046226218488;
                            case 67:
                                return 1.102311310924388e-6;
                            case 68:
                                return 1.574730444177697e-4;
                            case 69:
                                return 0.000001;
                            //hectogram
                            case 70:
                                return 500;
                            case 71:
                                return 10000;
                            case 72:
                                return 1000;
                            case 73:
                                return 10;
                            case 74:
                                return 100;
                            case 75:
                                return 1;
                            case 76:
                                return 0.1;
                            case 77:
                                return 9.842065276110606e-5;
                            case 78:
                                return 100000;
                            case 79:
                                return 3.527396194958041;
                            case 80:
                                return 0.2204622621848776;
                            case 81:
                                return 1.102311310924388e-4;
                            case 82:
                                return 0.015747304441777;
                            case 83:
                                return 0.0001;
                            //kg----
                            case 84:
                                return 5000;
                            case 85:
                                return 100000;
                            case 86:
                                return 10000;
                            case 87:
                                return 100;
                            case 88:
                                return 1000;
                            case 89:
                                return 10;
                            case 90:
                                return 1;
                            case 91:
                                return 9.842065276110606e-4;
                            case 92:
                                return 1000000;
                            case 93:
                                return 35.27396194958041;
                            case 94:
                                return 2.204622621848776;
                            case 95:
                                return 0.0011023113109244;
                            case 96:
                                return 0.1574730444177697;
                            case 97:
                                return 0.001;
                            //longton---
                            case 98:
                                return 5080234.544;
                            case 99:
                                return 101604690.88;
                            case 100:
                                return 10160469.088;
                            case 101:
                                return 101604.69088;
                            case 102:
                                return 1016046.9088;
                            case 103:
                                return 10160.469088;
                            case 104:
                                return 1016.0469088;
                            case 105:
                                return 1;
                            case 106:
                                return 1016046908.8;
                            case 107:
                                return 35840;
                            case 108:
                                return 2240;
                            case 109:
                                return 1.12;
                            case 110:
                                return 160;
                            case 111:
                                return 1.0160469088;
                            //mg----
                            case 112:
                                return 0.005;
                            case 113:
                                return 0.1;
                            case 114:
                                return 0.01;
                            case 115:
                                return 0.0001;
                            case 116:
                                return 0.001;
                            case 117:
                                return 0.00001;
                            case 118:
                                return 0.000001;
                            case 119:
                                return 9.842065276110606e-10;
                            case 120:
                                return 1;
                            case 121:
                                return 3.527396194958041e-5;
                            case 122:
                                return 2.204622621848776e-6;
                            case 123:
                                return 1.102311310924388e-9;
                            case 124:
                                return 1.574730444177697e-7;
                            case 125:
                                return 0.000000001;
                            //ounce---
                            case 126:
                                return 141.747615625;
                            case 127:
                                return 2834.9523125;
                            case 128:
                                return 283.49523125;
                            case 129:
                                return 2.8349523125;
                            case 130:
                                return 28.349523125;
                            case 131:
                                return 0.28349523125;
                            case 132:
                                return 0.028349523125;
                            case 133:
                                return 2.790178571428571e-5;
                            case 134:
                                return 28349.523125;
                            case 135:
                                return 1;
                            case 136:
                                return 0.0625;
                            case 137:
                                return 0.00003125;
                            case 138:
                                return 0.0044642857142857;
                            case 139:
                                return 0.000028349523125;
                            //pound---
                            case 140:
                                return 2267.96185;
                            case 141:
                                return 45359.237;
                            case 142:
                                return 4535.9237;
                            case 143:
                                return 45.359237;
                            case 144:
                                return 453.59237;
                            case 145:
                                return 4.5359237;
                            case 146:
                                return 0.45359237;
                            case 147:
                                return 4.464285714285714e-4;
                            case 148:
                                return 453592.37;
                            case 149:
                                return 16;
                            case 150:
                                return 1;
                            case 151:
                                return 0.0005;
                            case 152:
                                return 0.0714285714285714;
                            case 153:
                                return 0.00045359237;
                            //shton
                            case 154:
                                return 4535923.7;
                            case 155:
                                return 90718474;
                            case 156:
                                return 9071847.4;
                            case 157:
                                return 90718.474;
                            case 158:
                                return 907184.74;
                            case 159:
                                return 9071.8474;
                            case 160:
                                return 907.18474;
                            case 161:
                                return 0.8928571428571429;
                            case 162:
                                return 907184740;
                            case 163:
                                return 32000;
                            case 164:
                                return 2000;
                            case 165:
                                return 1;
                            case 166:
                                return 142.8571428571429;
                            case 167:
                                return 0.90718474;
                            //stone---
                            case 168:
                                return 31751.4659;
                            case 169:
                                return 635029.318;
                            case 170:
                                return 63502.9318;
                            case 171:
                                return 635.029318;
                            case 172:
                                return 6350.29318;
                            case 173:
                                return 63.5029318;
                            case 174:
                                return 6.35029318;
                            case 175:
                                return 0.00625;
                            case 176:
                                return 6350293.18;
                            case 177:
                                return 224;
                            case 178:
                                return 14;
                            case 179:
                                return 0.007;
                            case 180:
                                return 1;
                            case 181:
                                return 0.00635029318;
                            //tonne---
                            case 182:
                                return 5000000;
                            case 183:
                                return 100000000;
                            case 184:
                                return 10000000;
                            case 185:
                                return 100000;
                            case 186:
                                return 1000000;
                            case 187:
                                return 10000;
                            case 188:
                                return 1000;
                            case 189:
                                return 0.9842065276110606;
                            case 190:
                                return 1000000000;
                            case 191:
                                return 35273.96194958041;
                            case 192:
                                return 2204.622621848776;
                            case 193:
                                return 1.102311310924388;
                            case 194:
                                return 157.4730444177697;
                            case 195:
                                return 1;
                            default:
                                return 0;
                        }
                    }
                default:
                    return 0;
            }
        }
        public Vector EvaluateVector(string expression)
        {
            Vector v;
            string expr = null;
            bool is_unary = false;
            bool next_unary = false;
            int parens = 0;
            int expr_len = 0;
            string ch = null;
            string lexpr = null;
            string rexpr = null;
            int best_pos = 0;
            Precedence best_prec = default(Precedence);
            expr = expression.Replace(" ", "");
            expr_len = (expr).Length;
            if (expr_len == 0)
            {
                v.x = v.y = v.z = 0.0;
                return v;
            }
            is_unary = true;
            best_prec = Precedence.None;
            for (int pos = 0; pos <= expr_len - 1; pos++)
            {
                ch = expr.Substring(pos, 1);
                next_unary = false;
                if (ch == " ")
                {
                }
                else if (ch == "(")
                {
                    parens += 1;
                    next_unary = true;
                }
                else if (ch == ")")
                {
                    parens -= 1;
                    next_unary = false;
                    if (parens < 0)
                    {
                        System.Windows.MessageBox.Show(parens.ToString());
                        //throw new FormatException("Too many close parentheses in '" + expression + "'");
                    }
                }
                else if (parens == 0)
                {
                    if (ch=="="|ch == "^" | ch == "/" | ch == "*" | ch == "×" | ch == "∙" | ch == "+" | ch == "-")
                    {
                        next_unary = true;
                        switch (ch)
                        {
                            case "^":
                                if (best_prec >= Precedence.Power)
                                {
                                    best_prec = Precedence.Power;
                                    best_pos = pos;
                                }
                                break;
                            case "*":
                            case "∙":
                            case "×":
                            case "/":
                                if (best_prec >= Precedence.Times)
                                {
                                    best_prec = Precedence.Times;
                                    best_pos = pos;
                                }
                                break;
                            case "+":
                            case "-":
                                if ((!is_unary) & best_prec >= Precedence.Plus)
                                {
                                    best_prec = Precedence.Plus;
                                    best_pos = pos;
                                }
                                break;
                            case "=":
                                if ((!is_unary) & best_prec >= Precedence.equals)
                                {
                                    best_prec = Precedence.equals;
                                    best_pos = pos;
                                }
                                break;
                        }
                    }
                }
                is_unary = next_unary;
            }
            if (parens != 0)
            {
                throw new FormatException("Missing close parenthesis in '" + expression + "'");
            }
            if (expr.StartsWith("[") & expr.EndsWith("]"))
            {
                string k = expr.Substring(1, expr_len - 2);
                string[] exp = k.Split(';');
                return this.boxProduct(EvaluateVector(exp[0]), EvaluateVector(exp[1]), EvaluateVector(exp[2]));
            }
            if (best_prec < Precedence.None)
            {
                lexpr = expr.Substring(0, best_pos);
                rexpr = expr.Substring(best_pos + 1);
                switch (expr.Substring(best_pos, 1))
                {
                    case "^":     
                        {
                            v.y = v.z = 0.0;
                            v.x = 1.0;
                            return Math.Pow(EvaluateReal(lexpr), EvaluateReal(rexpr)) * v;
                        }
                    case "∙":
                        return dotProduct(EvaluateVector(lexpr), EvaluateVector(rexpr));
                    case "×":
                        return crossProduct(EvaluateVector(lexpr), EvaluateVector(rexpr));
                    case "/":
                        return EvaluateVector(lexpr) / EvaluateReal(rexpr);
                    case "*":
                        return EvaluateReal(rexpr) * EvaluateVector(lexpr);
                    case "+":
                        return EvaluateVector(lexpr) + EvaluateVector(rexpr);
                    case "-":
                        return EvaluateVector(lexpr) - EvaluateVector(rexpr);
                    case "=":
                        m_Primatives[lexpr] = EvaluateVector(rexpr);
v.x = v.y = v.z = 0;
return v;
                     }
            }
            if (expr.StartsWith("+"))
            {
                return EvaluateVector(expr.Substring(1));
            }
            if (expr.StartsWith("-"))
            {
                return -EvaluateVector(expr.Substring(1));
            }
            if (expr.StartsWith("(") & expr.EndsWith(")"))
            {
                return EvaluateVector(expr.Substring(1, expr_len - 2));
            }
            string[] sexp = new string[101];
            if (expr_len > 3 & expr.EndsWith(")"))
            {
                int paren_pos = expr.IndexOf("(");
                if (paren_pos > 0)
                {
                    lexpr = expr.Substring(0, paren_pos);
                    rexpr = expr.Substring(paren_pos + 1, expr_len - paren_pos - 2);
                    switch (lexpr)
                    {
                        case "mag":
                            return magnitude(EvaluateVector(rexpr));
                        case "dir":
                            sexp = rexpr.Split(';');
                            return direction(EvaluateVector(sexp[0]), EvaluateVector(sexp[1]));
                        case "trip":
                            sexp = rexpr.Split(';');
                            return tripProduct(EvaluateVector(sexp[0]), EvaluateVector(sexp[1]), EvaluateVector(sexp[2]));
                        case "curl":
                            return curl(rexpr);
                        case "div":
                            return divergence(rexpr);
                        case "grad":
                            return grad(rexpr);
                        case "V":
                        case "v":
                            string[] temp = rexpr.Split(',');
                            v.x = EvaluateReal(temp[0]);
                            v.y = EvaluateReal(temp[1]);
                            v.z = EvaluateReal(temp[2]);
                            return v;
                    }
                }
            }
            if (m_Primatives.Contains(expr))
            {
                Vector value=new Vector();
                try
                {
                    value = EvaluateVector((m_Primatives[expr]).ToString());
                    return value;
                }
                catch (Exception)
                {
                    System.Windows.MessageBox.Show("Error in evaluation", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
            }
            try
            {
                v.y = v.z = 0.0;
                v.x = EvaluateReal(expr);
                return v;
            }
            catch (Exception)
            {
                throw new FormatException("Syntax Error.");
            }

        } //VECTOR PARSER
        private Vector grad(string rexpr)
        {
            //CALCULATES GRADIENT OF FUNCTION
            //CALL grad(f(xyz);a;b;c)
            string[] x = rexpr.Split(';');
            string fxyz = x[0];
            fxyz = fxyz.Remove(0, 2);
            fxyz = fxyz.Remove(fxyz.Length - 1, 1);
            double a = Convert.ToDouble(x[1]);
            double b = Convert.ToDouble(x[2]);
            double c = Convert.ToDouble(x[3]);
            Vector v;
            v.x = partial_derivative(fxyz, 'x', a, b, c);
            v.y = partial_derivative(fxyz, 'y', a, b, c);
            v.z = partial_derivative(fxyz, 'z', a, b, c);
            return v;
        }
        private Vector curl(string rexpr)
        {
            //CALCULATES GRADIENT OF FUNCTION
            //CALL curl(f(solutionsonenets in i,j,k);a;b;c)
            string[] x = rexpr.Split(';');
            double a = Convert.ToDouble(x[1]);
            double b = Convert.ToDouble(x[2]);
            double c = Convert.ToDouble(x[3]);
            x[0] = x[0].Remove(0, 2);
            x[0] = x[0].Remove(x[0].Length - 1, 1);
            string[] f = x[0].Split(',');
            string f1 = f[0], f2 = f[1], f3 = f[2];
            Vector v;
            v.x = partial_derivative(f3, 'y', a, b, c) - partial_derivative(f2, 'z', a, b, c);
            v.y = partial_derivative(f1, 'z', a, b, c) - partial_derivative(f3, 'x', a, b, c);
            v.z = partial_derivative(f2, 'x', a, b, c) - partial_derivative(f1, 'y', a, b, c);
            return v;
        }
        private Vector boxProduct(Vector v1, Vector v2, Vector v3)
        {
            double a1 = v1.x, b1 = v1.y, c1 = v1.z, a2 = v2.x, b2 = v2.y, c2 = v2.z, a3 = v3.x, b3 = v3.y, c3 = v3.z;
            double box1 = a1 * (b2 * c3 - b3 * c2);
            double box2 = -b1 * (a2 * c3 - c2 * a3);
            double box3 = c1 * (a2 * b3 - b2 * a3);
            Vector c;
            c.x = box1 + box2 + box3;
            c.y = 0.0;
            c.z = 0.0;
            return c;
        }
        private Vector magnitude(Vector v1)
        {
            double a1 = v1.x, b1 = v1.y, c1 = v1.z;
            Vector c;
            c.x = Math.Sqrt(a1 * a1 + b1 * b1 + c1 * c1);
            c.y = 0.0;
            c.z = 0.0;
            return c;
        }
        private Vector dotProduct(Vector v1, Vector v2)
        {
            double a1 = v1.x, b1 = v1.y, c1 = v1.z, a2 = v2.x, b2 = v2.y, c2 = v2.z;
            double dp1 = a1 * a2 + b1 * b2 + c1 * c2;
            Vector v;
            v.x = dp1;
            v.y = v.z = 0.0;
            return v;
        }
        private Vector direction(Vector v1, Vector v2)
        {
            Vector v = dotProduct(v1, v2);
            Vector z = magnitude(v1);
            Vector z2 = magnitude(v2);
            double c = z.x * z2.x;
            Vector f;
            f.x = Math.Acos(v.x / c) * invfactor;
            f.y = f.z = 0.0;
            return f;
        }
        private Vector divergence(string s)
        {
            //CALCULATES GRADIENT OF FUNCTION
            //CALL div(f(solutionsonenets in i,j,k);a;b;c)
            string[] g = s.Split(';');
            string vfx = g[0];
            double a = Convert.ToDouble(g[1]);
            double b = Convert.ToDouble(g[2]);
            double c = Convert.ToDouble(g[3]);
            vfx = vfx.Remove(0, 2);
            vfx = vfx.Remove(vfx.Length - 1, 1);
            string[] h = vfx.Split(',');
            double g1 = partial_derivative(h[0], 'x', a, b, c);
            double g2 = partial_derivative(h[1], 'y', a, b, c);
            double g3 = partial_derivative(h[2], 'z', a, b, c);
            Vector v;
            v.x = g1 + g2 + g3;
            v.y = v.z = 0.0;
            return v;
        }
        private Vector crossProduct(Vector v1, Vector v2)
        {
            double a1 = v1.x, b1 = v1.y, c1 = v1.z, a2 = v2.x, b2 = v2.y, c2 = v2.z;
            Vector v;
            v.x = b1 * c2 - c1 * b2;
            v.y = -(a1 * c2 - c1 * a2);
            v.z = a1 * b2 - b1 * a2;
            return v;
        }
        private Vector tripProduct(Vector v1, Vector v2, Vector v3)
        {
            Vector dp1 = dotProduct(v1, v3);
            Vector dp2 = dotProduct(v1, v2);
            double a1 = v1.x, b1 = v1.y, c1 = v1.z, a2 = v2.x, b2 = v2.y, c2 = v2.z, a3 = v3.x, b3 = v3.y, c3 = v3.z;
            double x1 = dp1.x * a2;
            double y1 = dp1.x * b2;
            double z1 = dp1.x * c2;
            double x2 = dp2.x * a1;
            double y2 = dp2.x * b1;
            double z2 = dp2.x * c1;
            Vector f;
            f.x = x1 - x2;
            f.y = y1 - y2;
            f.z = z1 - z2;
            return f;
        }
        public Matrix EvaluateMatrix(string expression)
        {
            string expr = null;
            bool is_unary = false;
            bool next_unary = false;
            int parens = 0;
            int expr_len = 0;
            string ch = null;
            string lexpr = null;
            string rexpr = null;
            double d = 0;
            int best_pos = 0;
            Precedence best_prec = default(Precedence);
            expr = expression.Replace(" ", "");
            expr_len = (expr).Length;
            if (expr_len == 0)
            {
                return Matrix.ZeroMatrix(1, 1);
            }
            is_unary = true;
            best_prec = Precedence.None;
            for (int pos = 0; pos <= expr_len - 1; pos++)
            {
                ch = expr.Substring(pos, 1);
                next_unary = false;
                if (ch == " ")
                {
                }
                else if (ch == "(")
                {
                    parens += 1;
                    next_unary = true;
                }
                else if (ch == ")")
                {
                    parens -= 1;
                    next_unary = false;
                    if (parens < 0)
                    {
                        throw new FormatException("Too many close parentheses in '" + expression + "'");
                    }
                }
                else if (parens == 0)
                {
                    if (ch=="="|ch == @"\" | ch == "/" | ch == "÷" | ch == "^" | ch == "*" | ch == "×" | ch == "∙" | ch == "+" | ch == "-")
                    {
                        next_unary = true;
                        switch (ch)
                        {
                            case "^":
                                if (best_prec >= Precedence.Power)
                                {
                                    best_prec = Precedence.Power;
                                    best_pos = pos;
                                }
                                break;
                            case "=":
                                if (best_prec >= Precedence.equals)
                                {
                                    best_prec = Precedence.equals;
                                    best_pos = pos;
                                }
                                break;
                            case "/":
                            case @"\":
                            case "*":
                            case "∙":
                            case "×":
                            case "÷":
                                if (best_prec >= Precedence.Times)
                                {
                                    best_prec = Precedence.Times;
                                    best_pos = pos;
                                }
                                break;
                            case "+":
                            case "-":
                                if ((!is_unary) & best_prec >= Precedence.Plus)
                                {
                                    best_prec = Precedence.Plus;
                                    best_pos = pos;
                                }
                                break;
                        }
                    }
                }
                is_unary = next_unary;
            }
            if (parens != 0)
            {
                throw new FormatException("Missing close parenthesis in '" + expression + "'");
            }
            if (best_prec < Precedence.None)
            {
                lexpr = expr.Substring(0, best_pos);
                rexpr = expr.Substring(best_pos + 1);
                switch (expr.Substring(best_pos, 1))
                {
                    case "^":
                        return Matrix.Power(EvaluateMatrix(lexpr), int.Parse(EvaluateReal(rexpr).ToString()));
                    case "∙":
                        return EvaluateReal(lexpr) * EvaluateMatrix(rexpr);
                    case "/":
                        return EvaluateMatrix(lexpr) / EvaluateMatrix(rexpr);
                    case @"\":
                        return EvaluateMatrix(lexpr) / EvaluateReal(rexpr);
                    case "=":
                        m_Primatives[lexpr] = Matrix.Format(EvaluateMatrix(rexpr));
                        return Matrix.ZeroMatrix(1,1);
                    case "÷":
                        return EvaluateReal(lexpr) / EvaluateMatrix(rexpr);
                    case "*":
                    case "×":
                        return EvaluateMatrix(lexpr) * EvaluateMatrix(rexpr);
                    case "+":
                        return EvaluateMatrix(lexpr) + EvaluateMatrix(rexpr); ;
                    case "-":
                        return EvaluateMatrix(lexpr) - EvaluateMatrix(rexpr); ;
                }
            }
            if (expr.StartsWith("+"))
            {
                return EvaluateMatrix(expr.Substring(1));
            }
            if (expr.StartsWith("-"))
            {
                return -EvaluateMatrix(expr.Substring(1));
            }
            if (expr.EndsWith("⁻¹"))
                return (EvaluateMatrix(expr.Substring(0, expr_len - 2)).Invert());
            if (expr.StartsWith("(") & expr.EndsWith(")"))
            {
                return EvaluateMatrix(expr.Substring(1, expr_len - 2));
            }
            string[] sexp = new string[101];
            if (expr_len > 3 & expr.EndsWith(")"))
            {
                int paren_pos = expr.IndexOf("(");
                if (paren_pos > 0)
                {
                    lexpr = expr.Substring(0, paren_pos);
                    rexpr = expr.Substring(paren_pos + 1, expr_len - paren_pos - 2);
                    switch (lexpr)
                    {
                        case "trn":
                            return Matrix.Transpose(EvaluateMatrix(rexpr));
                        case "det":
                            Matrix c = (EvaluateMatrix(rexpr));
                            d = c.Det();
                            return d * Matrix.IdentityMatrix(1, 1);
                        case "inv":
                            c = EvaluateMatrix(rexpr);
                            return c.Invert();
                        case "I":
                            sexp = rexpr.Split(',');
                            c = Matrix.IdentityMatrix(int.Parse(sexp[0]), int.Parse(sexp[1]));
                            return c;
                        case "exp":
                            return Matrix.MatExp(EvaluateMatrix(rexpr));
                        case "Log":
                            return Matrix.MatLog(EvaluateMatrix(rexpr));
                        case "sin":
                            return Matrix.MatSin(EvaluateMatrix(rexpr));
                        case "cos":
                            return Matrix.MatCos(EvaluateMatrix(rexpr));
                        case "tan":
                            return Matrix.MatTan(EvaluateMatrix(rexpr));
                        case "cosec":
                            return Matrix.MatCosec(EvaluateMatrix(rexpr));
                        case "sec":
                            return Matrix.MatSec(EvaluateMatrix(rexpr));
                        case "cot":
                            return Matrix.MatCot(EvaluateMatrix(rexpr));
                        case "asin":
                            return Matrix.MatAsin(EvaluateMatrix(rexpr));
                        case "acos":
                            return Matrix.MatAcos(EvaluateMatrix(rexpr));
                        case "atan":
                            return Matrix.MatAtan(EvaluateMatrix(rexpr));
                        case "acosec":
                            return Matrix.MatAcosec(EvaluateMatrix(rexpr));
                        case "asec":
                            return Matrix.MatAsec(EvaluateMatrix(rexpr));
                        case "acot":
                            return Matrix.MatAcot(EvaluateMatrix(rexpr));
                        case "sinh":
                            return Matrix.MatSinh(EvaluateMatrix(rexpr));
                        case "cosh":
                            return Matrix.MatCosh(EvaluateMatrix(rexpr));
                        case "tanh":
                            return Matrix.MatTanh(EvaluateMatrix(rexpr));
                        case "cosech":
                            return Matrix.MatCosech(EvaluateMatrix(rexpr));
                        case "sech":
                            return Matrix.MatSech(EvaluateMatrix(rexpr));
                        case "coth":
                            return Matrix.MatCoth(EvaluateMatrix(rexpr));
                        case "asinh":
                            return Matrix.MatAsinh(EvaluateMatrix(rexpr));
                        case "acosh":
                            return Matrix.MatAcosh(EvaluateMatrix(rexpr));
                        case "atanh":
                            return Matrix.MatAtanh(EvaluateMatrix(rexpr));
                        case "acosech":
                            return Matrix.MatAcosech(EvaluateMatrix(rexpr));
                        case "asech":
                            return Matrix.MatAsech(EvaluateMatrix(rexpr));
                        case "acoth":
                            return Matrix.MatAcoth(EvaluateMatrix(rexpr));
                        case "disp":
                            return EvaluateMatrix(rexpr);
                    }
                }
            }
            if (expr_len > 3 & expr.EndsWith("]"))
            {
                int paren_pos = expr.IndexOf("[");
                if (paren_pos > 0)
                {
                    lexpr = expr.Substring(0, paren_pos);
                    rexpr = expr.Substring(paren_pos + 1, expr_len - paren_pos - 2);
                    switch (lexpr)
                    {
                        case "M":
                        case "m":
                            return Matrix.Parse(rexpr);
                    }
                }
            }
            if (m_Primatives.Contains(expr))
            {
                Matrix value = new Matrix(1, 1);
                try
                {
                    value =EvaluateMatrix((m_Primatives[expr]).ToString());
                    return value; 
                  
                }
                catch (Exception)
                {
                    System.Windows.MessageBox.Show("Error in evaluation", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
            }
           
            try
            {
                double c = EvaluateReal(expr);
                return c * Matrix.IdentityMatrix(1, 1);
            }
            catch (Exception)
            {
                throw new FormatException("Syntax Error");
            }
        }
        public Polynomial EvaluatePolynomial(string expression)
        {
            string expr = null;
            bool is_unary = false;
            bool next_unary = false;
            int parens = 0;
            int expr_len = 0;
            string ch = null;
            string lexpr = null;
            string rexpr = null;
            int best_pos = 0;
            Precedence best_prec = default(Precedence);
            expr = expression.Replace(" ", "");
            expr_len = (expr).Length;
            if (expr_len == 0)
                return Polynomial.zeroPoly(1);
            is_unary = true;
            best_prec = Precedence.None;
            for (int pos = 0; pos <= expr_len - 1; pos++)
            {
                ch = expr.Substring(pos, 1);
                next_unary = false;
                if (ch == " ")
                {
                }
                else if (ch == "(")
                {
                    parens += 1;
                    next_unary = true;
                }
                else if (ch == ")")
                {
                    parens -= 1;
                    next_unary = false;
                    if (parens < 0)
                    {
                        throw new FormatException("Too many close parentheses in '" + expression + "'");
                    }
                }
                else if (parens == 0)
                {
                    if (ch=="="|ch == "/" | ch == "÷" | ch == @"\" | ch == "^" | ch == "*" | ch == "×" | ch == "∙" | ch == "+" | ch == "-")
                    {
                        next_unary = true;
                        switch (ch)
                        {
                            case "^":
                                if (best_prec >= Precedence.Power)
                                {
                                    best_prec = Precedence.Power;
                                    best_pos = pos;
                                }
                                break;
                            case "=":
                                if (best_prec >= Precedence.equals)
                                {
                                    best_prec = Precedence.equals;
                                    best_pos = pos;
                                }
                                break;
                            case "*":
                            case "∙":
                            case "×":
                            case "÷":
                            case "/":
                            case @"\":
                                if (best_prec >= Precedence.Times)
                                {
                                    best_prec = Precedence.Times;
                                    best_pos = pos;
                                }
                                break;
                            case "+":
                            case "-":
                                if ((!is_unary) & best_prec >= Precedence.Plus)
                                {
                                    best_prec = Precedence.Plus;
                                    best_pos = pos;
                                }
                                break;
                        }
                    }
                }
                is_unary = next_unary;
            }
            if (parens != 0)
            {
                throw new FormatException("Missing close parenthesis in '" + expression + "'");
            }
            if (best_prec < Precedence.None)
            {
                lexpr = expr.Substring(0, best_pos);
                rexpr = expr.Substring(best_pos + 1);
                switch (expr.Substring(best_pos, 1))
                {
                    case "^":
                        return Polynomial.power(EvaluatePolynomial(lexpr), int.Parse(EvaluateReal(rexpr).ToString()));
                    case "=":
                        m_Primatives[lexpr] = Polynomial.Format(EvaluatePolynomial(rexpr));
                        return Polynomial.zeroPoly(1);
                    case "*":
                        return EvaluatePolynomial(lexpr) * EvaluatePolynomial(rexpr);
                    case "/":
                        return EvaluatePolynomial(lexpr) / EvaluatePolynomial(rexpr);
                    case @"\":
                        return EvaluateReal(lexpr) / EvaluatePolynomial(rexpr);
                    case "÷":
                        return EvaluatePolynomial(lexpr) / EvaluateReal(rexpr);
                    case "+":
                        return EvaluatePolynomial(lexpr) + EvaluatePolynomial(rexpr);
                    case "-":
                        return EvaluatePolynomial(lexpr) - EvaluatePolynomial(rexpr); ;
                }
            }
            if (expr.StartsWith("+"))
            {
                return EvaluatePolynomial(expr.Substring(1));
            }
            if (expr.StartsWith("-"))
            {
                return -EvaluatePolynomial(expr.Substring(1));
            }
            if (expr.StartsWith("(") & expr.EndsWith(")"))
            {
                return EvaluatePolynomial(expr.Substring(1, expr_len - 2));
            }
        //    string[] sexp = new string[101];
            if (expr_len > 3 & expr.EndsWith(")"))
            {
                // Find the first (.
                int paren_pos = expr.IndexOf("(");
                if (paren_pos > 0)
                {
                    lexpr = expr.Substring(0, paren_pos);
                    rexpr = expr.Substring(paren_pos + 1, expr_len - paren_pos - 2);
                    switch (lexpr)
                    {
                        case "disp":
                            return EvaluatePolynomial(rexpr);
                        case "P":
                        case "p":
                            return Polynomial.Parse(rexpr);
                    }
                }
            }
            if (m_Primatives.Contains(expr))
            {
                Polynomial value = new Polynomial(1);
                try
                {
                    value = EvaluatePolynomial((m_Primatives[expr]).ToString());
                    return value;
                }
                catch (Exception)
                {
                    System.Windows.MessageBox.Show("Error in evaluation", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
            }
            try
            {
                double c = EvaluateReal(expr);
                return c*EvaluatePolynomial(expr);
            }
            catch (Exception)
            {
                throw new Exception("Error");
            }
        }
    }
    public static class DoubleExtension
    {
        static string decToFrac(double d)
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
        public static string ToString(this double some, bool dectofrac)
        {
            if (dectofrac & MATHEMATICS.precision <= 6)
            {
                return decToFrac(some);
            }
            else if (!dectofrac || MATHEMATICS.precision > 6)
            {
                return some.ToString();
            }
            else
                return some.ToString();
        }
    }
}
