namespace Algebra_And_Calculus
{
    partial class Data
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
            this.chkX = new System.Windows.Forms.CheckBox();
            this.chkFreq = new System.Windows.Forms.CheckBox();
            this.chkY = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Accept = new System.Windows.Forms.Button();
            this.chkKey = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkX
            // 
            this.chkX.AutoSize = true;
            this.chkX.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkX.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkX.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chkX.Location = new System.Drawing.Point(12, 12);
            this.chkX.Name = "chkX";
            this.chkX.Size = new System.Drawing.Size(94, 22);
            this.chkX.TabIndex = 0;
            this.chkX.Text = "DataSet X";
            this.chkX.UseVisualStyleBackColor = true;
            this.chkX.CheckedChanged += new System.EventHandler(this.chkX_CheckedChanged);
            // 
            // chkFreq
            // 
            this.chkFreq.AutoSize = true;
            this.chkFreq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkFreq.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFreq.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chkFreq.Location = new System.Drawing.Point(199, 12);
            this.chkFreq.Name = "chkFreq";
            this.chkFreq.Size = new System.Drawing.Size(96, 22);
            this.chkFreq.TabIndex = 1;
            this.chkFreq.Text = "Frequency";
            this.chkFreq.UseVisualStyleBackColor = true;
            this.chkFreq.CheckedChanged += new System.EventHandler(this.chkFreq_CheckedChanged);
            // 
            // chkY
            // 
            this.chkY.AutoSize = true;
            this.chkY.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkY.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkY.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chkY.Location = new System.Drawing.Point(106, 12);
            this.chkY.Name = "chkY";
            this.chkY.Size = new System.Drawing.Size(93, 22);
            this.chkY.TabIndex = 2;
            this.chkY.Text = "DataSet Y";
            this.chkY.UseVisualStyleBackColor = true;
            this.chkY.CheckedChanged += new System.EventHandler(this.chkY_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(371, 351);
            this.dataGridView1.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.splitContainer1.Panel1.Controls.Add(this.chkKey);
            this.splitContainer1.Panel1.Controls.Add(this.Accept);
            this.splitContainer1.Panel1.Controls.Add(this.chkX);
            this.splitContainer1.Panel1.Controls.Add(this.chkFreq);
            this.splitContainer1.Panel1.Controls.Add(this.chkY);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(371, 450);
            this.splitContainer1.SplitterDistance = 95;
            this.splitContainer1.TabIndex = 4;
            // 
            // Accept
            // 
            this.Accept.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Accept.Location = new System.Drawing.Point(143, 58);
            this.Accept.Name = "Accept";
            this.Accept.Size = new System.Drawing.Size(75, 23);
            this.Accept.TabIndex = 3;
            this.Accept.Text = "Accept";
            this.Accept.UseVisualStyleBackColor = true;
            this.Accept.Click += new System.EventHandler(this.Accept_Click);
            // 
            // chkKey
            // 
            this.chkKey.AutoSize = true;
            this.chkKey.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkKey.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkKey.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.chkKey.Location = new System.Drawing.Point(295, 12);
            this.chkKey.Name = "chkKey";
            this.chkKey.Size = new System.Drawing.Size(55, 22);
            this.chkKey.TabIndex = 4;
            this.chkKey.Text = "Key";
            this.chkKey.UseVisualStyleBackColor = true;
            this.chkKey.CheckedChanged += new System.EventHandler(this.chkKey_CheckedChanged);
            // 
            // Data
            // 
            this.AcceptButton = this.Accept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(371, 450);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Data";
            this.Text = "Create Data Sets";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkX;
        private System.Windows.Forms.CheckBox chkFreq;
        private System.Windows.Forms.CheckBox chkY;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button Accept;
        private System.Windows.Forms.CheckBox chkKey;
    }
}