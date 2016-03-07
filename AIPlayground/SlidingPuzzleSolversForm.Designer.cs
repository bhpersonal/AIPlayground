namespace AIPlayground
{
    partial class SlidingPuzzlesSolversForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RandomSolveButton = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DfsSolve = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.NodesLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.NodesGeneratedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ExpandedNodesLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.RetainedNodesLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SecondsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.IDNaiveButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.AStarButton = new System.Windows.Forms.Button();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.IdaButton = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.WidaButton = new System.Windows.Forms.Button();
            this.WidaValueText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(12, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(589, 420);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.RandomSolveButton);
            this.groupBox1.Location = new System.Drawing.Point(607, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 60);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Random search";
            // 
            // RandomSolveButton
            // 
            this.RandomSolveButton.Location = new System.Drawing.Point(6, 19);
            this.RandomSolveButton.Name = "RandomSolveButton";
            this.RandomSolveButton.Size = new System.Drawing.Size(135, 32);
            this.RandomSolveButton.TabIndex = 0;
            this.RandomSolveButton.Text = "Solve";
            this.RandomSolveButton.UseVisualStyleBackColor = true;
            this.RandomSolveButton.Click += new System.EventHandler(this.RandomSolveButton_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.Location = new System.Drawing.Point(12, 12);
            this.trackBar1.Minimum = 2;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(268, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Value = 3;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.DfsSolve);
            this.groupBox2.Location = new System.Drawing.Point(607, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 62);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DFS (random order - same as random search)";
            // 
            // DfsSolve
            // 
            this.DfsSolve.Location = new System.Drawing.Point(6, 19);
            this.DfsSolve.Name = "DfsSolve";
            this.DfsSolve.Size = new System.Drawing.Size(135, 37);
            this.DfsSolve.TabIndex = 0;
            this.DfsSolve.Text = "Solve";
            this.DfsSolve.UseVisualStyleBackColor = true;
            this.DfsSolve.Click += new System.EventHandler(this.DfsButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NodesLabel,
            this.NodesGeneratedLabel,
            this.ExpandedNodesLabel,
            this.RetainedNodesLabel,
            this.SecondsLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 507);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(936, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // NodesLabel
            // 
            this.NodesLabel.Name = "NodesLabel";
            this.NodesLabel.Size = new System.Drawing.Size(41, 17);
            this.NodesLabel.Text = "Nodes";
            // 
            // NodesGeneratedLabel
            // 
            this.NodesGeneratedLabel.Name = "NodesGeneratedLabel";
            this.NodesGeneratedLabel.Size = new System.Drawing.Size(84, 17);
            this.NodesGeneratedLabel.Text = "Generated = ...";
            // 
            // ExpandedNodesLabel
            // 
            this.ExpandedNodesLabel.Name = "ExpandedNodesLabel";
            this.ExpandedNodesLabel.Size = new System.Drawing.Size(81, 17);
            this.ExpandedNodesLabel.Text = "Expanded = ...";
            // 
            // RetainedNodesLabel
            // 
            this.RetainedNodesLabel.Name = "RetainedNodesLabel";
            this.RetainedNodesLabel.Size = new System.Drawing.Size(76, 17);
            this.RetainedNodesLabel.Text = "Retained = ...";
            // 
            // SecondsLabel
            // 
            this.SecondsLabel.Name = "SecondsLabel";
            this.SecondsLabel.Size = new System.Drawing.Size(68, 17);
            this.SecondsLabel.Text = "Seconds =  ";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.IDNaiveButton);
            this.groupBox3.Location = new System.Drawing.Point(607, 199);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(317, 62);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ID";
            // 
            // IDNaiveButton
            // 
            this.IDNaiveButton.Location = new System.Drawing.Point(6, 19);
            this.IDNaiveButton.Name = "IDNaiveButton";
            this.IDNaiveButton.Size = new System.Drawing.Size(135, 37);
            this.IDNaiveButton.TabIndex = 0;
            this.IDNaiveButton.Text = "Solve";
            this.IDNaiveButton.UseVisualStyleBackColor = true;
            this.IDNaiveButton.Click += new System.EventHandler(this.IDNaiveButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.AStarButton);
            this.groupBox4.Location = new System.Drawing.Point(607, 267);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(317, 62);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "A*  (manhanttan)";
            // 
            // AStarButton
            // 
            this.AStarButton.Location = new System.Drawing.Point(6, 19);
            this.AStarButton.Name = "AStarButton";
            this.AStarButton.Size = new System.Drawing.Size(135, 37);
            this.AStarButton.TabIndex = 0;
            this.AStarButton.Text = "Solve";
            this.AStarButton.UseVisualStyleBackColor = true;
            this.AStarButton.Click += new System.EventHandler(this.AStarButton_Click);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(286, 12);
            this.trackBar2.Maximum = 1000;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(532, 45);
            this.trackBar2.TabIndex = 5;
            this.trackBar2.ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(824, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 35);
            this.button3.TabIndex = 6;
            this.button3.Text = "New";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.IdaButton);
            this.groupBox5.Location = new System.Drawing.Point(607, 335);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(317, 62);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "IDA* (manhattan)";
            // 
            // IdaButton
            // 
            this.IdaButton.Location = new System.Drawing.Point(6, 19);
            this.IdaButton.Name = "IdaButton";
            this.IdaButton.Size = new System.Drawing.Size(135, 37);
            this.IdaButton.TabIndex = 0;
            this.IdaButton.Text = "Solve";
            this.IdaButton.UseVisualStyleBackColor = true;
            this.IdaButton.Click += new System.EventHandler(this.IdaButton_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.WidaValueText);
            this.groupBox6.Controls.Add(this.WidaButton);
            this.groupBox6.Location = new System.Drawing.Point(607, 403);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(317, 62);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "WIDA* (manhattan)";
            // 
            // WidaButton
            // 
            this.WidaButton.Location = new System.Drawing.Point(6, 19);
            this.WidaButton.Name = "WidaButton";
            this.WidaButton.Size = new System.Drawing.Size(135, 37);
            this.WidaButton.TabIndex = 0;
            this.WidaButton.Text = "Solve";
            this.WidaButton.UseVisualStyleBackColor = true;
            this.WidaButton.Click += new System.EventHandler(this.WidaButton_Click);
            // 
            // WidaValueText
            // 
            this.WidaValueText.Location = new System.Drawing.Point(196, 32);
            this.WidaValueText.Name = "WidaValueText";
            this.WidaValueText.Size = new System.Drawing.Size(100, 20);
            this.WidaValueText.TabIndex = 1;
            this.WidaValueText.Text = "1.5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(166, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "W=";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(589, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // SlidingPuzzlesSolversForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 529);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "SlidingPuzzlesSolversForm";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.QueensSolversForm_Resize);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button RandomSolveButton;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button DfsSolve;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel NodesLabel;
        private System.Windows.Forms.ToolStripStatusLabel NodesGeneratedLabel;
        private System.Windows.Forms.ToolStripStatusLabel ExpandedNodesLabel;
        private System.Windows.Forms.ToolStripStatusLabel RetainedNodesLabel;
        private System.Windows.Forms.ToolStripStatusLabel SecondsLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button IDNaiveButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button AStarButton;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button IdaButton;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button WidaButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox WidaValueText;
        private System.Windows.Forms.TextBox textBox1;
    }
}

