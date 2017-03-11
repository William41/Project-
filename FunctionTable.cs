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
    public partial class FunctionTable : Form
    {
        public FunctionTable()
        {
            InitializeComponent();
        }
        private void FunctionTable_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = MATHEMATICS.ds.Tables[0];
            for (int i = 0; i < 2; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[i].DefaultCellStyle.Font = new System.Drawing.Font("SegoeUI", 12F);
                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
                dataGridView1.Columns[i].HeaderCell.Style.Font = new System.Drawing.Font("SegoeUI", 12F);
            }
        }
    }
}
