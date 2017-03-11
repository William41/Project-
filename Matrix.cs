using System;
using System.Text;
namespace Algebra_And_Calculus
{
    public class Matrix
    {
        public int rows;
        public int cols;
        public double[,] mat;
        public Matrix L;
        public Matrix U;
        private int[] pi;
        private double detOfP = 1;
        public Matrix(int iRows, int iCols)
        {
            rows = iRows;
            cols = iCols;
            mat = new double[rows, cols];
        }
        public Boolean IsSquare()
        {
            return (rows == cols);
        }
        public double this[int iRow, int iCol]      // Access this matrix as a 2D array
        {
            get { return mat[iRow, iCol]; }
            set { mat[iRow, iCol] = value; }
        }
        public Matrix GetCol(int k)
        {
            Matrix m = new Matrix(rows, 1);
            for (int i = 0; i < rows; i++) m[i, 0] = mat[i, k];
            return m;
        }
        public void SetCol(Matrix v, int k)
        {
            for (int i = 0; i < rows; i++) mat[i, k] = v[i, 0];
        }
        public void MakeLU()                        // Function for LU decomposition
        {
            if (!IsSquare()) throw new MException("The matrix is not square!");
            L = IdentityMatrix(rows, cols);
            U = Duplicate();

            pi = new int[rows];
            for (int i = 0; i < rows; i++) pi[i] = i;

            double p = 0;
            double pom2;
            int k0 = 0;
            int pom1 = 0;

            for (int k = 0; k < cols - 1; k++)
            {
                p = 0;
                for (int i = k; i < rows; i++)      // find the row with the biggest pivot
                {
                    if (Math.Abs(U[i, k]) > p)
                    {
                        p = Math.Abs(U[i, k]);
                        k0 = i;
                    }
                }
                if (p == 0) // samé nuly ve sloupci
                    throw new MException("The matrix is singular!");

                pom1 = pi[k]; pi[k] = pi[k0]; pi[k0] = pom1;    // switch two rows in permutation matrix

                for (int i = 0; i < k; i++)
                {
                    pom2 = L[k, i]; L[k, i] = L[k0, i]; L[k0, i] = pom2;
                }

                if (k != k0) detOfP *= -1;

                for (int i = 0; i < cols; i++)                  // Switch rows in U
                {
                    pom2 = U[k, i]; U[k, i] = U[k0, i]; U[k0, i] = pom2;
                }

                for (int i = k + 1; i < rows; i++)
                {
                    L[i, k] = U[i, k] / U[k, k];
                    for (int j = k; j < cols; j++)
                        U[i, j] = U[i, j] - L[i, k] * U[k, j];
                }
            }
        }
        public Matrix SolveWith(Matrix v)                        // Function solves Ax = v in confirmity with solution vector "v"
        {
            if (rows != cols) throw new MException("The matrix is not square!");
            if (rows != v.rows) throw new MException("Wrong number of results in solution vector!");
            if (L == null) MakeLU();

            Matrix b = new Matrix(rows, 1);
            for (int i = 0; i < rows; i++) b[i, 0] = v[pi[i], 0];   // switch two items in "v" due to permutation matrix

            Matrix z = SubsForth(L, b);
            Matrix x = SubsBack(U, z);

            return x;
        }
        public Matrix Invert()                                   // Function returns the inverted matrix
        {
            if (L == null) MakeLU();

            Matrix inv = new Matrix(rows, cols);

            for (int i = 0; i < rows; i++)
            {
                Matrix Ei = Matrix.ZeroMatrix(rows, 1);
                Ei[i, 0] = 1;
                Matrix col = SolveWith(Ei);
                inv.SetCol(col, i);
            }
            return inv;
        }
        public double Det()                         // Function for determinant
        {
            if (L == null) MakeLU();
            double det = detOfP;
            for (int i = 0; i < rows; i++) det *= U[i, i];
            return det;
        }
        public Matrix GetP()                        // Function returns permutation matrix "P" due to permutation vector "pi"
        {
            if (L == null) MakeLU();

            Matrix matrix = ZeroMatrix(rows, cols);
            for (int i = 0; i < rows; i++) matrix[pi[i], i] = 1;
            return matrix;
        }
        public Matrix Duplicate()                   // Function returns the copy of this matrix
        {
            Matrix matrix = new Matrix(rows, cols);
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = mat[i, j];
            return matrix;
        }
        public static Matrix SubsForth(Matrix A, Matrix b)          // Function solves Ax = b for A as a lower triangular matrix
        {
            if (A.L == null) A.MakeLU();
            int n = A.rows;
            Matrix x = new Matrix(n, 1);

            for (int i = 0; i < n; i++)
            {
                x[i, 0] = b[i, 0];
                for (int j = 0; j < i; j++) x[i, 0] -= A[i, j] * x[j, 0];
                x[i, 0] = x[i, 0] / A[i, i];
            }
            return x;
        }
        public static Matrix SubsBack(Matrix A, Matrix b)           // Function solves Ax = b for A as an upper triangular matrix
        {
            if (A.L == null) A.MakeLU();
            int n = A.rows;
            Matrix x = new Matrix(n, 1);

            for (int i = n - 1; i > -1; i--)
            {
                x[i, 0] = b[i, 0];
                for (int j = n - 1; j > i; j--) x[i, 0] -= A[i, j] * x[j, 0];
                x[i, 0] = x[i, 0] / A[i, i];
            }
            return x;
        }
        public static Matrix ZeroMatrix(int iRows, int iCols)       // Function generates the zero matrix
        {
            Matrix matrix = new Matrix(iRows, iCols);
            for (int i = 0; i < iRows; i++)
                for (int j = 0; j < iCols; j++)
                    matrix[i, j] = 0;
            return matrix;
        }
        public static Matrix IdentityMatrix(int iRows, int iCols)   // Function generates the identity matrix
        {
            Matrix matrix = ZeroMatrix(iRows, iCols);
            for (int i = 0; i < Math.Min(iRows, iCols); i++)
                matrix[i, i] = 1;
            return matrix;
        }
        public static Matrix RandomMatrix(int iRows, int iCols, int dispersion)       // Function generates the random matrix
        {
            Random random = new Random();
            Matrix matrix = new Matrix(iRows, iCols);
            for (int i = 0; i < iRows; i++)
                for (int j = 0; j < iCols; j++)
                    matrix[i, j] = random.Next(-dispersion, dispersion);
            return matrix;
        }
        public static Matrix Parse(string ps)           
            // Function parses the matrix from string
        {
            MATHEMATICS math = new MATHEMATICS(10);
            string s = NormalizeMatrixString(ps);
            string[] rows = ps.Split(';');
            string[] nums = rows[0].Split(',');
            Matrix matrix = new Matrix(rows.Length, nums.Length);
            try
            {
                for (int i = 0; i < rows.Length; i++)
                {
                    nums = rows[i].Split(',');
                    for (int j = 0; j < nums.Length; j++)
                        matrix[i, j] = math.EvaluateReal(nums[j]);
                }
            }
            catch (FormatException) { throw new MException("Wrong input format!"); }
            return matrix;
        }
        public static Matrix Parse2(string ps)
        // Function parses the matrix from string
        {
            MATHEMATICS math = new MATHEMATICS(10);
            string s = NormalizeMatrixString(ps);
            string[] rows = ps.Split('\n');
            string[] nums = rows[0].Split('\t');
            Matrix matrix = new Matrix(rows.Length, nums.Length);
            try
            {
                for (int i = 0; i < rows.Length; i++)
                {
                    nums = rows[i].Split('\t');
                    for (int j = 0; j < nums.Length; j++)
                        matrix[i, j] = math.EvaluateReal(nums[j]);
                }
            }
            catch (FormatException) { throw new MException("Wrong input format!"); }
            return matrix;
        }
        string decToFrac(double d)
        {
            string str = d.ToString();
            if (str.Contains("."))
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
        public static string Format(Matrix m)
        {
            StringBuilder s1 = new StringBuilder();
            int y = MATHEMATICS.precision;
            s1.Append("M[");
            //  string format = String.Concat("{0:F", y, "}");
            if (MATHEMATICS.isFrac == true & MATHEMATICS.precision <= 6)
            {
                for (int i = 0; i <m. rows; i++)
                {
                    for (int j = 0; j < m.cols; j++)
                    {
                        s1.Append(m.decToFrac(m[i, j]) + ",");
                    }
                    s1.Length--;
                    s1.Append(";");
                }
            }
            else if (MATHEMATICS.isFrac == false || MATHEMATICS.precision > 6)
            {
                for (int i = 0; i < m.rows; i++)
                {
                    for (int j = 0; j < m.cols; j++)
                    {
                        s1.Append(Math.Round((m[i, j]), y) + ",");
                    }
                    s1.Length--;
                    s1.Append(";");
                }
            }
            string u = s1.ToString();
            return u.Substring(0, u.Length - 1) + "]";
        }
        public override string ToString()                           // Function returns matrix as a string
        {
            string s = "";
            StringBuilder s1 = new StringBuilder();
            int y = MATHEMATICS.precision;
            s1.Append("M[");
            //  string format = String.Concat("{0:F", y, "}");
            if (MATHEMATICS.isFrac == true & MATHEMATICS.precision <= 6)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        s += decToFrac(mat[i, j]) + " ";
                        s1.Append(decToFrac(mat[i, j]) + ",");
                    }
                    s1.Length--;
                    s1.Append(";");
                    s += "\r\n";
                }
            }
            else if (MATHEMATICS.isFrac == false || MATHEMATICS.precision > 6)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        s += Math.Round((mat[i, j]), y) + "   ";
                        s1.Append(Math.Round((mat[i, j]), y) + ",");
                    }
                    s1.Length--;
                    s1.Append(";");
                    s += "\n";
                }
            }
            string u = s1.ToString();
            MATHEMATICS.m_Primatives["MatAns"] = u.Substring(0, u.Length - 1) + "]";
            return s;
        }
        public static Matrix Transpose(Matrix m)              // Matrix transpose, for any rectangular matrix
        {
            Matrix t = new Matrix(m.cols, m.rows);
            for (int i = 0; i < m.rows; i++)
                for (int j = 0; j < m.cols; j++)
                    t[j, i] = m[i, j];
            return t;
        }
        public static Matrix Power(Matrix m, int pow)           // Power matrix to exponent
        {
            if (pow == 0) return IdentityMatrix(m.rows, m.cols);
            if (pow == 1) return m.Duplicate();
            if (pow == -1) return m.Invert();

            Matrix x;
            if (pow < 0) { x = m.Invert(); pow *= -1; }
            else x = m.Duplicate();

            Matrix ret = IdentityMatrix(m.rows, m.cols);
            while (pow != 0)
            {
                if ((pow & 1) == 1) ret *= x;
                x *= x;
                pow >>= 1;
            }
            return ret;
        }
        public static Matrix NormalMultiply(Matrix m1, Matrix m2)                  // Stupid matrix multiplication
        {
            if (m1.cols != m2.rows) throw new MException("Dimension Error!");
            
            Matrix result = ZeroMatrix(m1.rows, m2.cols);
            for (int i = 0; i < result.rows; i++)
                for (int j = 0; j < result.cols; j++)
                    for (int k = 0; k < m1.cols; k++)
                        result[i, j] += m1[i, k] * m2[k, j];
            return result;
        }
        private static Matrix Multiply(Matrix m, double n)                          // Multiplication by constant n
        {
            Matrix r = new Matrix(m.rows, m.cols);
            for (int i = 0; i < m.rows; i++)
                for (int j = 0; j < m.cols; j++)
                    r[i, j] = m[i, j] * n;
            return r;
        }
        public static Matrix  MatExp(Matrix A)
        {
            MATHEMATICS math=new MATHEMATICS(12);
            if(!A.IsSquare())
                throw new Exception("Required Square Matrix");
            Matrix I=IdentityMatrix(A.rows,A.cols);
            Matrix s = new Matrix(A.rows, A.cols);
            for (int i = 1; i <= 12; i++)
                s += (Matrix.Power(A, i)) / math.fact(i);
            return I + s;
        }
        public static Matrix MatSin(Matrix A)
        {
            MATHEMATICS math = new MATHEMATICS(12);
            if (!A.IsSquare())
                throw new Exception("Required Square Matrix");
            Matrix I = IdentityMatrix(A.rows, A.cols);
            Matrix s = new Matrix(A.rows, A.cols);
            for (int i = 0; i <= 12; i++)
                s += Math.Pow(-1, i) * ((Matrix.Power(A, 2 * i + 1)) / math.fact(2 * i + 1));
            return s;
        }
        public static Matrix MatCos(Matrix A)
        {
            MATHEMATICS math = new MATHEMATICS(12);
            if (!A.IsSquare())
                throw new Exception("Required Square Matrix");
            Matrix I = IdentityMatrix(A.rows, A.cols);
            Matrix s = new Matrix(A.rows, A.cols);
            for (int i = 0; i <= 12; i++)
                s += Math.Pow(-1, i) * ((Matrix.Power(A, 2 * i)) / math.fact(2 * i));
            return s;
        }
        public static Matrix MatTan(Matrix A)
        {
            if (!A.IsSquare())
                throw new Exception("Required Square Matrix");
            Matrix m = MatSin(A) / MatCos(A);
            return m;
        }
        public static Matrix MatCosec(Matrix A)
        {
            if (!A.IsSquare())
                throw new Exception("Required Square Matrix");
            Matrix m = 1 / MatSin(A);
            return m;
        }
        public static Matrix MatSec(Matrix A)
        {
            if (!A.IsSquare())
                throw new Exception("Required Square Matrix");
            Matrix m = 1 / MatCos(A);
            return m;
        }
        public static Matrix MatCot(Matrix A)
        {
            if (!A.IsSquare())
                throw new Exception("Required Square Matrix");
            Matrix m = 1 / MatTan(A);
            return m;
        }
        public static Matrix MatAsin(Matrix A)
        {
            MATHEMATICS math = new MATHEMATICS(12);
            if (!A.IsSquare())
                throw new Exception("Required Square Matrix");
            Matrix I = IdentityMatrix(A.rows, A.cols);
            Matrix s = new Matrix(A.rows, A.cols);
            for (int i = 0; i <= 12; i++)
                s += (math.fact(2 * i) * Matrix.Power(A, 2 * i + 1)) / (Math.Pow(4, i) * math.fact(i) * math.fact(i) * (2 * i + 1));
            return s;
        }
        public static Matrix MatAtan(Matrix A)
        {
            MATHEMATICS math = new MATHEMATICS(12);
            if (!A.IsSquare())
                throw new Exception("Required Square Matrix");
            Matrix I = IdentityMatrix(A.rows, A.cols);
            Matrix s = new Matrix(A.rows, A.cols);
            for (int i = 0; i <= 12; i++)
                s += (math.fact(-1 * i) * Matrix.Power(A, 2 * i + 1)) / ((2 * i + 1));
            return s;
        }
        public static Matrix MatAcos(Matrix A)
        {
            if (!A.IsSquare())
                throw new Exception("Required Square Matrix");
            Matrix I = IdentityMatrix(A.rows, A.cols);
            Matrix s = (Math.PI / 2) * I;
            Matrix m = Matrix.MatAsin(A);
            return s - m;
        }
        public static Matrix MatAcosec(Matrix A)
        {
            if (!A.IsSquare())
                throw new Exception("Required Square Matrix");
            Matrix m = Matrix.MatAsin(A.Invert());
            return m;
        }
        public static Matrix MatAsec(Matrix A)
        {
            if (!A.IsSquare())
                throw new Exception("Required Square Matrix");
            Matrix m = Matrix.MatAcos(A.Invert());
            return m;
        }
        public static Matrix MatAcot(Matrix A)
        {
            if (!A.IsSquare())
                throw new Exception("Required Square Matrix");
            Matrix m = Matrix.MatAtan(A.Invert());
            return m;
        }
        public static Matrix MatSinh(Matrix A)
        {
            MATHEMATICS math = new MATHEMATICS(12);
            if (!A.IsSquare())
                throw new Exception("Required Square Matrix");
            Matrix I = IdentityMatrix(A.rows, A.cols);
            Matrix s = new Matrix(A.rows, A.cols);
            for (int i = 0; i <= 12; i++)
                s += ((Matrix.Power(A, 2 * i + 1)) / math.fact(2 * i + 1));
            return s;
        }
        public static Matrix MatCosh(Matrix A)
        {
            MATHEMATICS math = new MATHEMATICS(12);
            if (!A.IsSquare())
                throw new Exception("Required Square Matrix");
            Matrix I = IdentityMatrix(A.rows, A.cols);
            Matrix s = new Matrix(A.rows, A.cols);
            for (int i = 0; i <= 12; i++)
                s += ((Matrix.Power(A, 2 * i)) / math.fact(2 * i));
            return s;
        }
        public static Matrix MatTanh(Matrix A)
        {
            if (!A.IsSquare())
                throw new Exception("Required Square Matrix");
            Matrix s = new Matrix(A.rows, A.cols);
            s = Matrix.MatSinh(A) / Matrix.MatCosh(A);
            return s;
        }
        public static Matrix MatCosech(Matrix A)
        {
            if (!A.IsSquare())
                throw new Exception("Required Square Matrix");
            Matrix s = new Matrix(A.rows, A.cols);
            s = 1 / Matrix.MatSinh(A);
            return s;
        }
        public static Matrix MatSech(Matrix A)
        {
            if (!A.IsSquare())
                throw new Exception("Required Square Matrix");
            Matrix s = new Matrix(A.rows, A.cols);
            s = 1 / Matrix.MatCosh(A);
            return s;
        }
        public static Matrix MatCoth(Matrix A)
        {
            if (!A.IsSquare())
                throw new Exception("Required Square Matrix");
            Matrix s = new Matrix(A.rows, A.cols);
            s = Matrix.MatCosh(A) / Matrix.MatSinh(A);
            return s;
        }
        public static Matrix MatLog(Matrix A)
        {
            MATHEMATICS math = new MATHEMATICS(12);
            if (!A.IsSquare())
                throw new Exception("Required Square Matrix");
            Matrix I = IdentityMatrix(A.rows, A.cols);
            Matrix s = new Matrix(A.rows, A.cols);
            for (int i = 1; i <= 12; i++)
                s += Math.Pow(-1, i + 1) * ((Matrix.Power(A - I, i)) / i);
            return s;
        }
        public static Matrix MatAsinh(Matrix A)
        {
            MATHEMATICS math = new MATHEMATICS(12);
            if (!A.IsSquare())
                throw new Exception("Required Square Matrix");
            Matrix I = IdentityMatrix(A.rows, A.cols);
            Matrix s = new Matrix(A.rows, A.cols);
            for (int i = 0; i <= 12; i++)
                s += (Math.Pow(-1,i)*math.fact(2 * i) * Matrix.Power(A, 2 * i + 1)) / (Math.Pow(4, i) * math.fact(i) * math.fact(i) * (2 * i + 1));
            return s;
        }
        public static Matrix MatAcosh(Matrix A)
        {
            MATHEMATICS math = new MATHEMATICS(12);
            if (!A.IsSquare())
                throw new Exception("Required Square Matrix");
            Matrix s = new Matrix(A.rows, A.cols);
            for (int i = 1; i <= 12; i++)
                s += (math.fact(2 * i) * Matrix.Power(A, -2 * i)) / (Math.Pow(4, i) * math.fact(i) * math.fact(i) * (2 * i));
            return MatLog(2 * A) - s;
        }
        public static Matrix MatAtanh(Matrix A)
        {
            MATHEMATICS math = new MATHEMATICS(12);
            if (!A.IsSquare())
                throw new Exception("Required Square Matrix");
            Matrix I = IdentityMatrix(A.rows, A.cols);
            Matrix s = new Matrix(A.rows, A.cols);
            for (int i = 0; i <= 12; i++)
                s += (Matrix.Power(A, 2 * i + 1)) / ((2 * i + 1));
            return s;
        }
        public static Matrix MatAcosech(Matrix A)
        {
            if (!A.IsSquare())
                throw new Exception("Required Square Matrix");
            Matrix m = Matrix.MatAsinh(A.Invert());
            return m;
        }
        public static Matrix MatAsech(Matrix A)
        {
            if (!A.IsSquare())
                throw new Exception("Required Square Matrix");
            Matrix m = Matrix.MatAcosh(A.Invert());
            return m;
        }
        public static Matrix MatAcoth(Matrix A)
        {
            if (!A.IsSquare())
                throw new Exception("Required Square Matrix");
            Matrix m = Matrix.MatAtanh(A.Invert());
            return m;
        }
        private static Matrix Add(Matrix m1, Matrix m2)         // Sčítání matic
        {
            if (m1.rows != m2.rows || m1.cols != m2.cols) throw new MException("Dimension Error");
            Matrix r = new Matrix(m1.rows, m1.cols);
            for (int i = 0; i < r.rows; i++)
                for (int j = 0; j < r.cols; j++)
                    r[i, j] = m1[i, j] + m2[i, j];
            return r;
        }
        public static string NormalizeMatrixString(string matStr)	
        {
            // Remove any multiple spaces
            while (matStr.IndexOf("  ") != -1)
                matStr = matStr.Replace("  ", " ");

            // Remove any spaces before or after newlines
            matStr = matStr.Replace(" \r\n", "\r\n");
            matStr = matStr.Replace("\r\n ", "\r\n");

            // If the data ends in a newline, remove the trailing newline.
            // Make it easier by first replacing \r\n’s with |’s then
            // restore the |’s with \r\n’s
            matStr = matStr.Replace("\r\n", "|");
            while (matStr.LastIndexOf("|") == (matStr.Length - 1))
                matStr = matStr.Substring(0, matStr.Length - 1);

            matStr = matStr.Replace("|", "\r\n");
            return matStr.Trim();
        }
        public static Matrix operator -(Matrix m)
        { return Matrix.Multiply(m,-1); }
        public static Matrix operator +(Matrix m1, Matrix m2)
        { return Matrix.Add(m1, m2); }
        public static Matrix operator -(Matrix m1, Matrix m2)
        { return Matrix.Add(m1, -m2); }
        public static Matrix operator *(Matrix m1, Matrix m2)
        { return Matrix.NormalMultiply(m1, m2); }
        public static Matrix operator *(double n, Matrix m)
        { return Matrix.Multiply(m,n); }
        public static Matrix operator /(Matrix m1, Matrix m2)
        {
            return m1 * m2.Invert();
        }
        public static Matrix operator /(double a, Matrix m1)
        {
            int x = m1.rows;
            int y = m1.cols;
            Matrix m = a * Matrix.IdentityMatrix(x, y);
            return m1 * m.Invert();
        }
        public static Matrix operator /(Matrix m1, double a)
        {
            return Multiply(m1, 1 / a);
        }
    }
    public class MException : Exception
    {
        public MException(string Message)
            : base(Message)
        { }
    }
}
