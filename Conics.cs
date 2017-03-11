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
using System.Windows.Forms;

namespace Algebra_And_Calculus
{
    public partial class Conics : Form
    {
        public Conics()
        {
            InitializeComponent();
        }
        private void Conics_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = MATHEMATICS.conics.Cast<DictionaryEntry>().Select(x => new
            {
                Col1 = x.Key.ToString(),
                Col2 = x.Value.ToString()
            }).ToList();
        }
    }
}
