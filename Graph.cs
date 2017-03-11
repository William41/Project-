using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Windows.Threading;
namespace Algebra_And_Calculus
{
    public partial class Graph : Form
    {
        public Graph()
        {
            InitializeComponent();
        }
        Graphics g;
        public bool car, pol, para = false;
        public string fx;
        public bool X = false; //plot x as y
        public static int type;
        private void Graph_Closed(object sender, FormClosedEventArgs e)
        {
            this.Visible = false;
        }
        private void Graph_Closing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }
        private void Graph_Load(object sender, EventArgs e)
        {

        }
        private void Graph_Paint(object sender, PaintEventArgs e)
        {
        }

        private void picGraph_Click(object sender, EventArgs e)
        {

        }

        private void picGraph_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
