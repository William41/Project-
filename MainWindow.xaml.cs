using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace Algebra_And_Calculus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtInput.Focus();
            radReal.IsChecked = true;
            rbDeg.IsChecked = true;
            MATHEMATICS.m_Primatives["π"] = Math.PI;
            MATHEMATICS.m_Primatives["e"] = Math.E;
            MATHEMATICS.m_Primatives["Ans"] = 0;
            MATHEMATICS.m_Primatives["MatAns"] = Matrix.ZeroMatrix(1,1).ToString();
            MATHEMATICS.m_Primatives["polyAns"] = Polynomial.Format(Polynomial.zeroPoly(1));
        }
        MATHEMATICS math = new MATHEMATICS(12);
        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = "";
            txtOutput.Text = "0";
            txtInput.Focus();
        }
        private void btnAC_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = "";
            txtOutput.Text = "0";
            txtInput.Focus();
            MATHEMATICS.DataX = null;
            MATHEMATICS.DataY = null;
            MATHEMATICS.freq = null;
            MATHEMATICS.key = null;
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
        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "0");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "1");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "2");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "3");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "4");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "5");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "6");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "7");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "8");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "9");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnPoint_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, ".");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void bksp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int CursorPosition = txtInput.SelectionStart;
                txtInput.Text = txtInput.Text.Remove(CursorPosition - 1, 1);
                txtInput.Focus();
                txtInput.CaretIndex = txtInput.Text.Length;
            }
            catch
            {
                System.Windows.MessageBox.Show("Error.Cannot backspace further");
                txtInput.Focus();
            }
        }
        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "+");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "-");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnMult_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "*");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "/");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnOpenParen_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnCloseParen_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, ")");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnFact_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "!");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnPerm_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "P");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnComb_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "C");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnExp_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "E");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnPow_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "^(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void Manual_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnpowe_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "powe(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnMod_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "mod(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnLoga_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "log(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnLn_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "ln(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnSqr_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "²");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnDec_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "dec(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnCbrt_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "∛(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnConst_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "const(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnGcd_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "gcd(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnLcm_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "lcm(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnSqrt_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "√(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnPerc_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "perc(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnCube_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "³");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnDms_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "dms(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnConv_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "conv(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnDeg_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "deg(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnRoot_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "r");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnInt_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "int(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnPol_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "pol(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnRec_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "rec(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnReci_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, ")⁻¹");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnFloor_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "floor(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnCeil_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "ceil(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnSign_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "sign(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnComma_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, ",");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnSin_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "sin(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnCos_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "cos(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnTan_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "tan(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnCosec_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "cosec(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnSec_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "sec(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnCot_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "cot(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnAsin_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "asin(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnAcos_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "acos(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnAtan_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "atan(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnAcosec_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "acosec(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnAsec_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "asec(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnAcot_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "acot(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnSinh_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "sinh(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnCosh_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "cosh(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnTanh_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "tanh(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnCosech_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "cosech(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnSech_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "sech(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnCoth_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "coth(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnAsinh_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "asinh(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnAcosh_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "acosh(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnAtanh_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "atanh(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnAcosech_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "acosech(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnAsech_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "asech(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnAcoth_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "acoth(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnI_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "i");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnZ_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "z(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnAngle_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "∠");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnArg_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "arg(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnMatInv_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "inv(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnDet_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "det(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnTrn_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "trn(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnDisp_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "disp(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnM_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "M[");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnID_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "I(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnReal_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "Re(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnImag_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "Im(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnEquals_Click(object sender, RoutedEventArgs e)//////////////////////////////////////////
        {
            MATHEMATICS.precision = (int)slPrecision.Value;
            txtOutput.Focus();
            //try
            //{
                lblAnswer.UnselectAll();
                MATHEMATICS.solutions.Clear();
                lblAnswer.ItemsSource = MATHEMATICS.solutions;
                if (radComplex.IsChecked == true)
                {
                    txtOutput.Text = math.EvaluateComplex(txtInput.Text).ToString();
                    lstHistory.Items.Add(txtInput.Text + "=" + txtOutput.Text);
                }
                else if (radMatrix.IsChecked == true)
                {
                    txtOutput.Text = math.EvaluateMatrix(txtInput.Text).ToString();
                    lstHistory.Items.Add(txtInput.Text);
                }
                else if (radVector.IsChecked == true)
                {
                    int n = txtInput.Text.Length - txtInput.Text.Replace("∙", "").Length;
                    int n1 = txtInput.Text.Length - txtInput.Text.Replace("×", "").Length;
                    txtOutput.Text = math.EvaluateVector(txtInput.Text).ToString();
                    lstHistory.Items.Add(txtInput.Text + "=" + txtOutput.Text);
                }
                else if (radPolynomial.IsChecked == true)
                {
                    txtOutput.Text = math.EvaluatePolynomial(txtInput.Text).ToString();
                    lstHistory.Items.Add(txtInput.Text);
                }
                else if (radReal.IsChecked == true)
                {
                    double val = math.EvaluateReal(txtInput.Text);
                    string frac = "";
                    if (MATHEMATICS.isFrac == true & MATHEMATICS.precision <= 6)
                        frac = decToFrac(Math.Round(val, MATHEMATICS.precision));
                    else if (MATHEMATICS.isFrac == false || MATHEMATICS.precision > 6)
                        frac = Math.Round(val, MATHEMATICS.precision).ToString();
                    txtOutput.Text = frac;
                    lstHistory.Items.Add(txtInput.Text + "=" + txtOutput.Text);
                    MATHEMATICS.m_Primatives["Ans"] = txtOutput.Text;
                }
            //}
            //catch (Exception ex)
            //{
            //    txtOutput.Text = ex.Message.ToString();
            //}
            
        }
        private void btnFx_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "fu(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnFtable_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "ftable(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnParDer_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "pD(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnIntegral_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "∫(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnLimits_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "lim(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnContinuity_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "cont(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnFproduct_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "∏(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnFplot_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "fplot(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnFsum_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "∑(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnRect_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "rectify(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnEqu_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "equ(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnDIff_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, @"d\dx(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnDiffEqu_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "equ(6;");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnTera_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "T");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnGiga_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "G");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnMega_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "M");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnKilo_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "k");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnMilli_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "m");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnMicro_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "μ");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnNano_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "n");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnPico_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "p");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnFermi_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "f");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnVector_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "v(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "∙");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnCross_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "×");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnMag_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "mag(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnDir_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "dir(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnCurl_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "curl(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnGrad_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "grad(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnDiv1_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "div(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnTrip_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "trip(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnBox_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "[]");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnDefX_Click(object sender, RoutedEventArgs e)
        {
            Data d = new Data();
            d.ShowDialog();
        }
        private void btnDefY_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "Y(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnDefF_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "f(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnX_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.GetKeyStates(Key.CapsLock) == KeyStates.Toggled)
                txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "X");
            else
                txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "x");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnY_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.GetKeyStates(Key.CapsLock) == KeyStates.Toggled)
                txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "Y");
            else
                txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "y");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnT_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "Z(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnPz_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "pr(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnQz_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "Q(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnRz_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "r(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnA1_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.GetKeyStates(Key.CapsLock) == KeyStates.Toggled)
                txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "A");
            else
                txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "a");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnB1_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.GetKeyStates(Key.CapsLock) == KeyStates.Toggled)
                txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "B");
            else
                txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "b");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnC2_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.GetKeyStates(Key.CapsLock) == KeyStates.Toggled)
                txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "C");
            else
                txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "c");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnD_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.GetKeyStates(Key.CapsLock) == KeyStates.Toggled)
                txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "D");
            else
                txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "d");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnE_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.GetKeyStates(Key.CapsLock) == KeyStates.Toggled)
                txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "E");
            else
                txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "e");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnF_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.GetKeyStates(Key.CapsLock) == KeyStates.Toggled)
                txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "F");
            else
                txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "f");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnM1_Click(object sender, RoutedEventArgs e)
        {
            if (Keyboard.GetKeyStates(Key.CapsLock) == KeyStates.Toggled)
                txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "M");
            else
                txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "m");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnMean_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "mean(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnMedian_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "median(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnMode_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "mode(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnSd_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "sd(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnSdPop_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "sdp(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnCov_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "cov(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnCorr_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "corr(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnChart_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "chart(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnSumX_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "sum(1;X)");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnSumx2_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "sum(2;X)");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnSumX3_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "sum(3;X)");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnSumXY_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "sum(4;X;Y)");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnSumSumX2Y_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "sum(5;X;Y)");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnSumX2Y2_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "sum(6;X;Y)");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnRange_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "range(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnQd_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "qd(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "cfit(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnA_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "a");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnB_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "b");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnC1_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "c");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnNormal_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "Norm(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnSumX3Y3_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "sum(7;X;Y)");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnSumY_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "sum(8;Y)");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "min(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnMax_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "max(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void bntN_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "nX");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnBin_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "Bin(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnPois_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "Pois(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnArea_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "area(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnVol_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "vol(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnPerimeter_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "peri(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnCentroid_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "cent(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnDistForm_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "dist(1,");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnMidPt_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "midpoint(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnSolveTri_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "tri(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnSecFormula_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "secf(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnCircle_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "circle(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnDistBet_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "dist(2,");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnDistPoint_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "dist(3,");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnParabola_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "parabola(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnEllipse_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "ellipse(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnHyperbola_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "hyperbola(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnKey_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "key(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void radReal_Checked(object sender, RoutedEventArgs e)
        {
            txtOutput.Text = "0";
            txtOutput.Height = 30;
            lblAnswer.Height = 83;
            txtOutput.FontSize = 19;
            tMode.Text = "REAL";
        }
        private void radComplex_Checked(object sender, RoutedEventArgs e)
        {
            txtOutput.Text = "0";
            txtOutput.Height = 30;
            lblAnswer.Height = 83;
            txtOutput.FontSize = 19;
            tMode.Text = "COMPLEX";
        }
        private void radVector_Checked(object sender, RoutedEventArgs e)
        {
            txtOutput.Text = "0";
            txtOutput.Height = 30;
            lblAnswer.Height = 83;
            txtOutput.FontSize = 19;
            tMode.Text = "VECTOR";
            txtInput.Text = "";
        }
        private void radMatrix_Checked(object sender, RoutedEventArgs e)
        {
            txtOutput.Text = "0";
            txtOutput.FontSize = 16;
            txtOutput.Height = 68;
            lblAnswer.Height = 49;
            tMode.Text = "MATRIX";
            txtInput.Text = "";
        }
        private void btnSemiColon_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, ";");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnSec1_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "\"");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnDegSym_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "°");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnMin1_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "'");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnGrad1_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "ᵍ");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnRad_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "ʳ");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnDeg1_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "ᵈ");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnF_z_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "F'(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnFz_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "F(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnEquZ_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "equC(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void radPolynomial_Checked(object sender, RoutedEventArgs e)
        {
            txtOutput.Text = "0";
            txtOutput.FontSize = 16;
            txtOutput.Height = 68;
            lblAnswer.Height = 49;
            tMode.Text = "POLYNOMIAL";
            txtInput.Text = "";
        }
        private void rbRad_Checked(object sender, RoutedEventArgs e)
        {
            math.Mode = Mode.RAD;
            tSystem.Text = "RADIANS";
        }
        private void rbDeg_Checked(object sender, RoutedEventArgs e)
        {
            math.Mode = Mode.DEG;
            tSystem.Text = "DEGREES";
        }
        private void rbGrad_Checked(object sender, RoutedEventArgs e)
        {
            math.Mode = Mode.GRAD;
            tSystem.Text = "GRADIANS";
        }
        private void cmbDisp_SelChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)cmbDisp.SelectedItem;
            string s = typeItem.Content.ToString();
            if (s == "FRACTIONAL")
            {
                MATHEMATICS.isFrac = true;
            }
            else if (s == "DECIMAL")
            {
                MATHEMATICS.isFrac = false;
            }
        }
        private void cmbSystem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)cmbSystem.SelectedItem;
            string s = typeItem.Content.ToString();
            if (s == "Cartesian")
            {
                MATHEMATICS.isCart = true;
                MATHEMATICS.isPol = false;
            }
            else if (s == "Polar")
            {
                MATHEMATICS.isPol = true;
                MATHEMATICS.isCart = false;
            }
        }
        private void btnMatDiv1_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "÷");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnMatDiv2_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, @"\");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void chk3d_Checked(object sender, RoutedEventArgs e)
        {
            MATHEMATICS.is3d = 1;
        }
        private void chk3d_Unchecked(object sender, RoutedEventArgs e)
        {
            MATHEMATICS.is3d = 0;
        }
        private void btnPi_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "π");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnEc_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "e");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnLogFile_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)cmbDrive.SelectedItem;
            string s = typeItem.Content.ToString();
            string path = s + @":\Calc++ " + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            if (!File.Exists(path))
            {
                FileStream fs = File.Create(path);
                fs.Close();
            }
            using (TextWriter tw = File.AppendText(path))
            {
                tw.WriteLine("---------------------FILE GENERATED BY CALC++------------------");
                foreach (string item in lstHistory.Items)
                    tw.WriteLine(DateTime.Now.ToString("dd-mm-yyyy hh:mm:ss   ") +item);
            }
        }
        private void lstHistory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] x = lstHistory.SelectedItem.ToString().Split('=');
            txtInput.Text = x[0];
        }
        private void btnPerc1_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "%");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnRnd_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "rnd(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnRan_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "ran(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void lblAnswer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sel = lblAnswer.SelectedItem;
            if (sel != null)
            {
                if ((lblAnswer.SelectedItem.ToString().Contains('=')))
                {
                    string[] split = lblAnswer.SelectedItem.ToString().Split('=');
                     txtOutput.Text=txtInput.Text = split[1];
                }
                else if ((!lblAnswer.SelectedItem.ToString().Contains('=')))
                {
                    txtInput.Text = lblAnswer.SelectedItem.ToString();
                }
            }
        }
        private void btnDisp1_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "disp(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnSolveTri2_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "solveTri(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnAns_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "Ans");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnMatAns_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "MatAns");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnPolyAns_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "polyAns");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnPoly_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "P(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnSol_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, txtOutput.Text);
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnSz_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "S(");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnNInf_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "-∞");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void btnInf_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = txtInput.Text.Insert(txtInput.CaretIndex, "∞");
            txtInput.Focus();
            txtInput.CaretIndex = txtInput.Text.Length;
        }
        private void calc_Loaded(object sender, RoutedEventArgs e)
        {
            MATHEMATICS.m_Primatives["∞"] =1.732e308;
            MATHEMATICS.m_Primatives["-∞"] = -1.732e308;
            MATHEMATICS.m_Primatives["Infinity"] = 1.732e308;
            MATHEMATICS.m_Primatives["-Infinity"] = -1.732e308;
        }
        private void nd1_ValueChanged(object sender, EventArgs e)
        {
            MATHEMATICS.X = (int)nd1.Value;
        }
        private void nd2_ValueChanged(object sender, EventArgs e)
        {
            MATHEMATICS.Y = (int)nd2.Value;
        }
        private void btnDefineFx_Click(object sender, RoutedEventArgs e)
        {
            Function fx = new Function();
            fx.Show();
        }
    }
}