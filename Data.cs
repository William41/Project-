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
    public partial class Data : Form
    {
        public Data()
        {
            InitializeComponent();
        }
        private void chkX_CheckedChanged(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn dgtc = new DataGridViewTextBoxColumn();
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Consolas", 13f);
            dgtc.HeaderText = "X";
            dgtc.DefaultCellStyle.Font = new Font("Consolas", 12f);
            dgtc.Name = "X";
            
            if (chkX.Checked == true)
            {
                dataGridView1.Columns.Add(dgtc);
                dataGridView1.Columns["X"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
                dataGridView1.Columns["X"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (chkX.Checked == false)
                dataGridView1.Columns.Remove("X");
        }
        private void chkY_CheckedChanged(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn dgtc = new DataGridViewTextBoxColumn();
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Consolas", 13f);
            dgtc.HeaderText = "Y";
            dgtc.Name = "Y";
            dgtc.DefaultCellStyle.Font = new Font("Consolas", 12f);
            if (chkY.Checked == true)
            {
                dataGridView1.Columns.Add(dgtc);
                dataGridView1.Columns["Y"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
                dataGridView1.Columns["Y"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (chkY.Checked == false)
                dataGridView1.Columns.Remove("Y");
        }
        private void chkFreq_CheckedChanged(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn dgtc = new DataGridViewTextBoxColumn();
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Consolas", 13f);
            dgtc.HeaderText = "freq";
            dgtc.Name = "freq";
            dgtc.DefaultCellStyle.Font = new Font("Consolas", 12f);
            if (chkFreq.Checked == true)
            {
                dataGridView1.Columns.Add(dgtc);
                dataGridView1.Columns["freq"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
                dataGridView1.Columns["freq"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (chkFreq.Checked == false)
                dataGridView1.Columns.Remove("freq");
        }
        private void chkKey_CheckedChanged(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn dgtc = new DataGridViewTextBoxColumn();
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Consolas", 13f);
            dgtc.HeaderText = "key";
            dgtc.Name = "key";
            dgtc.DefaultCellStyle.Font = new Font("Consolas", 12f);
            if (chkKey.Checked == true)
            {
                dataGridView1.Columns.Add(dgtc);
                dataGridView1.Columns["key"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
                dataGridView1.Columns["key"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (chkKey.Checked == false)
                dataGridView1.Columns.Remove("key");
        }
        private void Accept_Click(object sender, EventArgs e)
        {
            if (chkX.Checked == true)
            {
                int count = 0;
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells["X"].Value == null || dataGridView1.Rows[i].Cells["X"].Value == DBNull.Value)
                    {
                        count++;
                    }
                }
                MATHEMATICS.DataX = new double[dataGridView1.RowCount - count - 1];
                for (int i = 0; i < dataGridView1.RowCount - count - 1; i++)
                    MATHEMATICS.DataX[i] = Convert.ToDouble(dataGridView1.Rows[i].Cells["X"].Value);
                MATHEMATICS.m_Primatives["nX"] = MATHEMATICS.DataX.Length;
            }
            else if (chkX.Checked == false)
                MATHEMATICS.DataX = null;
            if (chkY.Checked == true)
            {
                int county = 0;
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells["Y"].Value == null || dataGridView1.Rows[i].Cells["Y"].Value == DBNull.Value)
                    {
                        county++;
                    }
                }
                MATHEMATICS.DataY = new double[dataGridView1.RowCount - county - 1];
                for (int i = 0; i < dataGridView1.Rows.Count - county - 1; i++)
                    MATHEMATICS.DataY[i] = Convert.ToDouble(dataGridView1.Rows[i].Cells["Y"].Value);
                MATHEMATICS.m_Primatives["nY"] = MATHEMATICS.DataY.Length;
            }
            else if (chkY.Checked == false)
                MATHEMATICS.DataY = null;
            if (chkFreq.Checked == true)
            {
                int count = 0;
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells["freq"].Value == null || dataGridView1.Rows[i].Cells["freq"].Value == DBNull.Value)
                    {
                        count++;
                    }
                }
                MATHEMATICS.freq = new double[dataGridView1.RowCount - count - 1];
                for (int i = 0; i < dataGridView1.RowCount - count - 1; i++)
                    MATHEMATICS.freq[i] = Convert.ToDouble(dataGridView1.Rows[i].Cells["freq"].Value);
            }
            else if (chkX.Checked == false)
                MATHEMATICS.freq = null;
            if (chkKey.Checked == true)
            {
                int count = 0;
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells["key"].Value == null || dataGridView1.Rows[i].Cells["key"].Value == DBNull.Value)
                    {
                        count++;
                    }
                }
                MATHEMATICS.key = new string[dataGridView1.RowCount - count - 1];
                for (int i = 0; i < dataGridView1.Rows.Count - count - 1; i++)
                    MATHEMATICS.key[i] = Convert.ToString(dataGridView1.Rows[i].Cells["key"].Value);
            }
            else if (chkX.Checked == false)
                MATHEMATICS.key = null;
        }
    }
}
