namespace TestRSS
{
    partial class Form1
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.ColumnAvsnitt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnNamn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnFreq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnKategori = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvKategori = new System.Windows.Forms.ListView();
            this.tbKategori = new System.Windows.Forms.TextBox();
            this.Ny = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnAvsnitt,
            this.ColumnNamn,
            this.ColumnFreq,
            this.ColumnKategori});
            this.listView1.Location = new System.Drawing.Point(3, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(744, 471);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ColumnAvsnitt
            // 
            this.ColumnAvsnitt.Text = "Avsnitt";
            this.ColumnAvsnitt.Width = 213;
            // 
            // ColumnNamn
            // 
            this.ColumnNamn.Text = "Namn";
            this.ColumnNamn.Width = 260;
            // 
            // ColumnFreq
            // 
            this.ColumnFreq.Text = "Freq";
            this.ColumnFreq.Width = 294;
            // 
            // ColumnKategori
            // 
            this.ColumnKategori.Text = "Kategori";
            this.ColumnKategori.Width = 616;
            // 
            // lvKategori
            // 
            this.lvKategori.Location = new System.Drawing.Point(778, 23);
            this.lvKategori.Name = "lvKategori";
            this.lvKategori.Size = new System.Drawing.Size(299, 270);
            this.lvKategori.TabIndex = 1;
            this.lvKategori.UseCompatibleStateImageBehavior = false;
            // 
            // tbKategori
            // 
            this.tbKategori.Location = new System.Drawing.Point(778, 331);
            this.tbKategori.Name = "tbKategori";
            this.tbKategori.Size = new System.Drawing.Size(299, 26);
            this.tbKategori.TabIndex = 2;
            // 
            // Ny
            // 
            this.Ny.Location = new System.Drawing.Point(778, 394);
            this.Ny.Name = "Ny";
            this.Ny.Size = new System.Drawing.Size(75, 23);
            this.Ny.TabIndex = 3;
            this.Ny.Text = "button1";
            this.Ny.UseVisualStyleBackColor = true;
            this.Ny.Click += new System.EventHandler(this.Ny_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 563);
            this.Controls.Add(this.Ny);
            this.Controls.Add(this.tbKategori);
            this.Controls.Add(this.lvKategori);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ColumnAvsnitt;
        private System.Windows.Forms.ColumnHeader ColumnNamn;
        private System.Windows.Forms.ColumnHeader ColumnFreq;
        private System.Windows.Forms.ColumnHeader ColumnKategori;
        private System.Windows.Forms.ListView lvKategori;
        private System.Windows.Forms.TextBox tbKategori;
        private System.Windows.Forms.Button Ny;
    }
}

