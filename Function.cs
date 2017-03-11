using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algebra_And_Calculus
{
    public partial class Function : Form
    {
        public Function()
        {
            InitializeComponent();
        }
        MATHEMATICS math = new MATHEMATICS(12);
        private void button1_Click(object sender, EventArgs e)
        {
            MATHEMATICS.func_List.Add(txtName.Text,txtValue.Text);
            if (radioButton1.Checked == true)
                MATHEMATICS.var_count = 1;
            if (radioButton3.Checked == true)
                MATHEMATICS.var_count = 2;
            if (radioButton2.Checked == true)
                MATHEMATICS.var_count = 3;
        }
    }
}
