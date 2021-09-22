namespace wifi_bruter
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.lb = new System.Windows.Forms.ListBox();
            this.reff = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.refreshtimer = new System.Windows.Forms.Timer(this.components);
            this.brute = new System.Windows.Forms.Button();
            this.loadword = new System.Windows.Forms.Button();
            this.state = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.delp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb
            // 
            this.lb.FormattingEnabled = true;
            this.lb.Items.AddRange(new object[] {
            "test"});
            this.lb.Location = new System.Drawing.Point(12, 12);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(250, 342);
            this.lb.Sorted = true;
            this.lb.TabIndex = 0;
            // 
            // reff
            // 
            this.reff.Location = new System.Drawing.Point(268, 331);
            this.reff.Name = "reff";
            this.reff.Size = new System.Drawing.Size(170, 23);
            this.reff.TabIndex = 1;
            this.reff.Text = "Refresh";
            this.reff.UseVisualStyleBackColor = true;
            this.reff.Click += new System.EventHandler(this.reff_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(268, 276);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(170, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "5000";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Auto Refresh (miliseconds):";
            // 
            // refreshtimer
            // 
            this.refreshtimer.Enabled = true;
            this.refreshtimer.Interval = 5000;
            this.refreshtimer.Tick += new System.EventHandler(this.refreshtimer_Tick);
            // 
            // brute
            // 
            this.brute.Location = new System.Drawing.Point(268, 12);
            this.brute.Name = "brute";
            this.brute.Size = new System.Drawing.Size(170, 44);
            this.brute.TabIndex = 4;
            this.brute.Text = "Brute";
            this.brute.UseVisualStyleBackColor = true;
            this.brute.Click += new System.EventHandler(this.brute_Click);
            // 
            // loadword
            // 
            this.loadword.Location = new System.Drawing.Point(268, 150);
            this.loadword.Name = "loadword";
            this.loadword.Size = new System.Drawing.Size(170, 35);
            this.loadword.TabIndex = 5;
            this.loadword.Text = "Load Wordlist";
            this.loadword.UseVisualStyleBackColor = true;
            this.loadword.Click += new System.EventHandler(this.loadword_Click);
            // 
            // state
            // 
            this.state.AutoSize = true;
            this.state.Location = new System.Drawing.Point(12, 357);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(62, 13);
            this.state.TabIndex = 6;
            this.state.Text = "Status : idle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "By Metal Ghost";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Location = new System.Drawing.Point(294, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "GitHub.com/metal-ghost";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // delp
            // 
            this.delp.Location = new System.Drawing.Point(268, 302);
            this.delp.Name = "delp";
            this.delp.Size = new System.Drawing.Size(170, 23);
            this.delp.TabIndex = 9;
            this.delp.Text = "Delete Profile";
            this.delp.UseVisualStyleBackColor = true;
            this.delp.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 378);
            this.Controls.Add(this.delp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.state);
            this.Controls.Add(this.loadword);
            this.Controls.Add(this.brute);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.reff);
            this.Controls.Add(this.lb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "WiFi Bruter";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb;
        private System.Windows.Forms.Button reff;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer refreshtimer;
        private System.Windows.Forms.Button brute;
        private System.Windows.Forms.Button loadword;
        private System.Windows.Forms.Label state;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button delp;
    }
}

