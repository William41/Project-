namespace Algebra_And_Calculus
{
    partial class Graph
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picGraph = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // picGraph
            // 
            this.picGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picGraph.Location = new System.Drawing.Point(0, 0);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(478, 456);
            this.picGraph.TabIndex = 1;
            this.picGraph.TabStop = false;
            this.picGraph.Click += new System.EventHandler(this.picGraph_Click);
            this.picGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.picGraph_Paint);
            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(478, 456);
            this.Controls.Add(this.picGraph);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Graph";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "f(x)=";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Graph_Closing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Graph_Closed);
            this.Load += new System.EventHandler(this.Graph_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Graph_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox picGraph;




    }
}