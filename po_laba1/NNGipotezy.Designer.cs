namespace po_laba1
{
    partial class NNGipotezy
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
            this.button29 = new System.Windows.Forms.Button();
            this.domainUpDown2 = new System.Windows.Forms.DomainUpDown();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.label29 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label30 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button29
            // 
            this.button29.Location = new System.Drawing.Point(386, 8);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(36, 20);
            this.button29.TabIndex = 16;
            this.button29.Text = "Ок";
            this.button29.UseVisualStyleBackColor = true;
            this.button29.Click += new System.EventHandler(this.button29_Click);
            // 
            // domainUpDown2
            // 
            this.domainUpDown2.Location = new System.Drawing.Point(189, 8);
            this.domainUpDown2.Name = "domainUpDown2";
            this.domainUpDown2.Size = new System.Drawing.Size(64, 20);
            this.domainUpDown2.TabIndex = 15;
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Location = new System.Drawing.Point(119, 8);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(64, 20);
            this.domainUpDown1.TabIndex = 14;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(12, 11);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(101, 13);
            this.label29.TabIndex = 13;
            this.label29.Text = "Перевірка гіпотез:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkGray;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.label30);
            this.panel4.Location = new System.Drawing.Point(12, 31);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(421, 221);
            this.panel4.TabIndex = 12;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label30.Location = new System.Drawing.Point(4, 4);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(41, 13);
            this.label30.TabIndex = 0;
            this.label30.Text = "label30";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Багатовимірні середнi (рівні DC)",
            "k n-вимірних середніх (розбіжні DC)",
            "збіг DC"});
            this.comboBox1.Location = new System.Drawing.Point(259, 8);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 17;
            // 
            // NNGipotezy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 264);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button29);
            this.Controls.Add(this.domainUpDown2);
            this.Controls.Add(this.domainUpDown1);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.panel4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NNGipotezy";
            this.Text = "Перевірка гіпотез";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.DomainUpDown domainUpDown2;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}