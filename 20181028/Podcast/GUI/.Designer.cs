﻿namespace Podcast
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFrekvens = new System.Windows.Forms.ComboBox();
            this.cbKategori = new System.Windows.Forms.ComboBox();
            this.btnNyFeed = new System.Windows.Forms.Button();
            this.btnSparaFeed = new System.Windows.Forms.Button();
            this.btnTaBortFeed = new System.Windows.Forms.Button();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnNyKategori = new System.Windows.Forms.Button();
            this.btnAndraKategori = new System.Windows.Forms.Button();
            this.btnTaBortKategori = new System.Windows.Forms.Button();
            this.tbKategori = new System.Windows.Forms.TextBox();
            this.lvBeskrivning = new System.Windows.Forms.ListView();
            this.lbAvsnitt = new System.Windows.Forms.ListBox();
            this.lvFeed = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbKategori = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 457);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(458, 448);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Uppdateringsfrekvens";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(767, 448);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 29);
            this.label3.TabIndex = 3;
            this.label3.Text = "Kategori";
            // 
            // cbFrekvens
            // 
            this.cbFrekvens.FormattingEnabled = true;
            this.cbFrekvens.Items.AddRange(new object[] {
            "5",
            "10",
            "15"});
            this.cbFrekvens.Location = new System.Drawing.Point(453, 484);
            this.cbFrekvens.Margin = new System.Windows.Forms.Padding(2);
            this.cbFrekvens.Name = "cbFrekvens";
            this.cbFrekvens.Size = new System.Drawing.Size(242, 37);
            this.cbFrekvens.TabIndex = 4;
            // 
            // cbKategori
            // 
            this.cbKategori.FormattingEnabled = true;
            this.cbKategori.Location = new System.Drawing.Point(759, 489);
            this.cbKategori.Margin = new System.Windows.Forms.Padding(2);
            this.cbKategori.Name = "cbKategori";
            this.cbKategori.Size = new System.Drawing.Size(319, 37);
            this.cbKategori.TabIndex = 5;
            // 
            // btnNyFeed
            // 
            this.btnNyFeed.Location = new System.Drawing.Point(16, 542);
            this.btnNyFeed.Margin = new System.Windows.Forms.Padding(2);
            this.btnNyFeed.Name = "btnNyFeed";
            this.btnNyFeed.Size = new System.Drawing.Size(196, 49);
            this.btnNyFeed.TabIndex = 6;
            this.btnNyFeed.Text = "Ny..";
            this.btnNyFeed.UseVisualStyleBackColor = true;
            this.btnNyFeed.Click += new System.EventHandler(this.btnNyFeed_Click);
            // 
            // btnSparaFeed
            // 
            this.btnSparaFeed.Location = new System.Drawing.Point(453, 542);
            this.btnSparaFeed.Margin = new System.Windows.Forms.Padding(2);
            this.btnSparaFeed.Name = "btnSparaFeed";
            this.btnSparaFeed.Size = new System.Drawing.Size(196, 49);
            this.btnSparaFeed.TabIndex = 7;
            this.btnSparaFeed.Text = "Ändra";
            this.btnSparaFeed.UseVisualStyleBackColor = true;
            // 
            // btnTaBortFeed
            // 
            this.btnTaBortFeed.Location = new System.Drawing.Point(759, 542);
            this.btnTaBortFeed.Margin = new System.Windows.Forms.Padding(2);
            this.btnTaBortFeed.Name = "btnTaBortFeed";
            this.btnTaBortFeed.Size = new System.Drawing.Size(196, 49);
            this.btnTaBortFeed.TabIndex = 8;
            this.btnTaBortFeed.Text = "Ta Bort";
            this.btnTaBortFeed.UseVisualStyleBackColor = true;
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(16, 491);
            this.tbUrl.Margin = new System.Windows.Forms.Padding(2);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(406, 35);
            this.tbUrl.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 611);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 29);
            this.label4.TabIndex = 11;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1116, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 29);
            this.label5.TabIndex = 12;
            this.label5.Text = "Kategorier";
            // 
            // btnNyKategori
            // 
            this.btnNyKategori.Location = new System.Drawing.Point(1121, 479);
            this.btnNyKategori.Margin = new System.Windows.Forms.Padding(2);
            this.btnNyKategori.Name = "btnNyKategori";
            this.btnNyKategori.Size = new System.Drawing.Size(196, 49);
            this.btnNyKategori.TabIndex = 14;
            this.btnNyKategori.Text = "Ny..";
            this.btnNyKategori.UseVisualStyleBackColor = true;
            this.btnNyKategori.Click += new System.EventHandler(this.btnNyKategori_Click);
            // 
            // btnAndraKategori
            // 
            this.btnAndraKategori.Location = new System.Drawing.Point(1379, 477);
            this.btnAndraKategori.Margin = new System.Windows.Forms.Padding(2);
            this.btnAndraKategori.Name = "btnAndraKategori";
            this.btnAndraKategori.Size = new System.Drawing.Size(196, 49);
            this.btnAndraKategori.TabIndex = 15;
            this.btnAndraKategori.Text = "Ändra";
            this.btnAndraKategori.UseVisualStyleBackColor = true;
            this.btnAndraKategori.Click += new System.EventHandler(this.btnAndraKategori_Click);
            // 
            // btnTaBortKategori
            // 
            this.btnTaBortKategori.Location = new System.Drawing.Point(1631, 477);
            this.btnTaBortKategori.Margin = new System.Windows.Forms.Padding(2);
            this.btnTaBortKategori.Name = "btnTaBortKategori";
            this.btnTaBortKategori.Size = new System.Drawing.Size(196, 49);
            this.btnTaBortKategori.TabIndex = 16;
            this.btnTaBortKategori.Text = "Ta Bort";
            this.btnTaBortKategori.UseVisualStyleBackColor = true;
            this.btnTaBortKategori.Click += new System.EventHandler(this.btnTaBortKategori_Click);
            // 
            // tbKategori
            // 
            this.tbKategori.Location = new System.Drawing.Point(1121, 416);
            this.tbKategori.Margin = new System.Windows.Forms.Padding(2);
            this.tbKategori.Name = "tbKategori";
            this.tbKategori.Size = new System.Drawing.Size(706, 35);
            this.tbKategori.TabIndex = 17;
            // 
            // lvBeskrivning
            // 
            this.lvBeskrivning.Location = new System.Drawing.Point(1121, 565);
            this.lvBeskrivning.Margin = new System.Windows.Forms.Padding(2);
            this.lvBeskrivning.Name = "lvBeskrivning";
            this.lvBeskrivning.Size = new System.Drawing.Size(717, 258);
            this.lvBeskrivning.TabIndex = 18;
            this.lvBeskrivning.UseCompatibleStateImageBehavior = false;
            // 
            // lbAvsnitt
            // 
            this.lbAvsnitt.FormattingEnabled = true;
            this.lbAvsnitt.ItemHeight = 29;
            this.lbAvsnitt.Location = new System.Drawing.Point(16, 645);
            this.lbAvsnitt.Margin = new System.Windows.Forms.Padding(2);
            this.lbAvsnitt.Name = "lbAvsnitt";
            this.lbAvsnitt.Size = new System.Drawing.Size(1062, 178);
            this.lbAvsnitt.TabIndex = 19;
            // 
            // lvFeed
            // 
            this.lvFeed.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvFeed.Location = new System.Drawing.Point(16, 29);
            this.lvFeed.Margin = new System.Windows.Forms.Padding(2);
            this.lvFeed.Name = "lvFeed";
            this.lvFeed.Size = new System.Drawing.Size(1072, 381);
            this.lvFeed.TabIndex = 20;
            this.lvFeed.UseCompatibleStateImageBehavior = false;
            this.lvFeed.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Avsnitt";
            this.columnHeader1.Width = 140;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Namn";
            this.columnHeader2.Width = 158;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Frekvens";
            this.columnHeader3.Width = 195;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Kategori";
            this.columnHeader4.Width = 169;
            // 
            // lbKategori
            // 
            this.lbKategori.FormattingEnabled = true;
            this.lbKategori.ItemHeight = 29;
            this.lbKategori.Location = new System.Drawing.Point(1121, 49);
            this.lbKategori.Margin = new System.Windows.Forms.Padding(2);
            this.lbKategori.Name = "lbKategori";
            this.lbKategori.Size = new System.Drawing.Size(717, 352);
            this.lbKategori.TabIndex = 21;
            this.lbKategori.SelectedIndexChanged += new System.EventHandler(this.selectKategoriItem);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1891, 857);
            this.Controls.Add(this.lbKategori);
            this.Controls.Add(this.lvFeed);
            this.Controls.Add(this.lbAvsnitt);
            this.Controls.Add(this.lvBeskrivning);
            this.Controls.Add(this.tbKategori);
            this.Controls.Add(this.btnTaBortKategori);
            this.Controls.Add(this.btnAndraKategori);
            this.Controls.Add(this.btnNyKategori);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.btnTaBortFeed);
            this.Controls.Add(this.btnSparaFeed);
            this.Controls.Add(this.btnNyFeed);
            this.Controls.Add(this.cbKategori);
            this.Controls.Add(this.cbFrekvens);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFrekvens;
        private System.Windows.Forms.ComboBox cbKategori;
        private System.Windows.Forms.Button btnNyFeed;
        private System.Windows.Forms.Button btnSparaFeed;
        private System.Windows.Forms.Button btnTaBortFeed;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnNyKategori;
        private System.Windows.Forms.Button btnAndraKategori;
        private System.Windows.Forms.Button btnTaBortKategori;
        private System.Windows.Forms.TextBox tbKategori;
        private System.Windows.Forms.ListView lvBeskrivning;
        private System.Windows.Forms.ListBox lbAvsnitt;
        private System.Windows.Forms.ListView lvFeed;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListBox lbKategori;
    }
}

