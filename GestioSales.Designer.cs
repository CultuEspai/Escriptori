namespace CultuEspai
{
    partial class GestioSales
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
            this.dataGridViewSales = new System.Windows.Forms.DataGridView();
            this.dataGridViewCaracteristiques = new System.Windows.Forms.DataGridView();
            this.buttonEditSala = new System.Windows.Forms.Button();
            this.buttonEditChar = new System.Windows.Forms.Button();
            this.buttonDeleteChar = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.gestioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarisToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonAddChar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCaracteristiques)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewSales
            // 
            this.dataGridViewSales.AllowUserToAddRows = false;
            this.dataGridViewSales.AllowUserToDeleteRows = false;
            this.dataGridViewSales.AllowUserToResizeRows = false;
            this.dataGridViewSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSales.Location = new System.Drawing.Point(26, 78);
            this.dataGridViewSales.MultiSelect = false;
            this.dataGridViewSales.Name = "dataGridViewSales";
            this.dataGridViewSales.ReadOnly = true;
            this.dataGridViewSales.RowHeadersWidth = 47;
            this.dataGridViewSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSales.Size = new System.Drawing.Size(505, 325);
            this.dataGridViewSales.TabIndex = 0;
            // 
            // dataGridViewCaracteristiques
            // 
            this.dataGridViewCaracteristiques.AllowUserToAddRows = false;
            this.dataGridViewCaracteristiques.AllowUserToDeleteRows = false;
            this.dataGridViewCaracteristiques.AllowUserToResizeRows = false;
            this.dataGridViewCaracteristiques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCaracteristiques.Location = new System.Drawing.Point(580, 78);
            this.dataGridViewCaracteristiques.MultiSelect = false;
            this.dataGridViewCaracteristiques.Name = "dataGridViewCaracteristiques";
            this.dataGridViewCaracteristiques.ReadOnly = true;
            this.dataGridViewCaracteristiques.RowHeadersWidth = 47;
            this.dataGridViewCaracteristiques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCaracteristiques.Size = new System.Drawing.Size(303, 325);
            this.dataGridViewCaracteristiques.TabIndex = 1;
            // 
            // buttonEditSala
            // 
            this.buttonEditSala.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(183)))), ((int)(((byte)(167)))));
            this.buttonEditSala.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditSala.Location = new System.Drawing.Point(38, 43);
            this.buttonEditSala.Name = "buttonEditSala";
            this.buttonEditSala.Size = new System.Drawing.Size(70, 25);
            this.buttonEditSala.TabIndex = 2;
            this.buttonEditSala.Text = "Edit";
            this.buttonEditSala.UseVisualStyleBackColor = false;
            this.buttonEditSala.Click += new System.EventHandler(this.buttonEditSala_Click);
            // 
            // buttonEditChar
            // 
            this.buttonEditChar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(183)))), ((int)(((byte)(167)))));
            this.buttonEditChar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditChar.Location = new System.Drawing.Point(675, 43);
            this.buttonEditChar.Name = "buttonEditChar";
            this.buttonEditChar.Size = new System.Drawing.Size(70, 25);
            this.buttonEditChar.TabIndex = 3;
            this.buttonEditChar.Text = "Edit";
            this.buttonEditChar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonEditChar.UseVisualStyleBackColor = false;
            this.buttonEditChar.Click += new System.EventHandler(this.buttonEditChar_Click);
            // 
            // buttonDeleteChar
            // 
            this.buttonDeleteChar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(183)))), ((int)(((byte)(167)))));
            this.buttonDeleteChar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteChar.Location = new System.Drawing.Point(814, 43);
            this.buttonDeleteChar.Name = "buttonDeleteChar";
            this.buttonDeleteChar.Size = new System.Drawing.Size(56, 25);
            this.buttonDeleteChar.TabIndex = 4;
            this.buttonDeleteChar.Text = "Delete";
            this.buttonDeleteChar.UseVisualStyleBackColor = false;
            this.buttonDeleteChar.Click += new System.EventHandler(this.buttonDeleteChar_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestioToolStripMenuItem,
            this.exitsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(906, 27);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip1";
            // 
            // gestioToolStripMenuItem
            // 
            this.gestioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesToolStripMenuItem1,
            this.usuarisToolStripMenuItem1});
            this.gestioToolStripMenuItem.Name = "gestioToolStripMenuItem";
            this.gestioToolStripMenuItem.Size = new System.Drawing.Size(62, 23);
            this.gestioToolStripMenuItem.Text = "Gestió";
            // 
            // salesToolStripMenuItem1
            // 
            this.salesToolStripMenuItem1.Name = "salesToolStripMenuItem1";
            this.salesToolStripMenuItem1.Size = new System.Drawing.Size(131, 24);
            this.salesToolStripMenuItem1.Text = "Sales";
            // 
            // usuarisToolStripMenuItem1
            // 
            this.usuarisToolStripMenuItem1.Name = "usuarisToolStripMenuItem1";
            this.usuarisToolStripMenuItem1.Size = new System.Drawing.Size(131, 24);
            this.usuarisToolStripMenuItem1.Text = "Usuaris";
            this.usuarisToolStripMenuItem1.Click += new System.EventHandler(this.usuarisToolStripMenuItem_Click);
            // 
            // exitsToolStripMenuItem
            // 
            this.exitsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.exitsToolStripMenuItem.Name = "exitsToolStripMenuItem";
            this.exitsToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.exitsToolStripMenuItem.Text = "Exit";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(137, 24);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(137, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // buttonAddChar
            // 
            this.buttonAddChar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(183)))), ((int)(((byte)(167)))));
            this.buttonAddChar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddChar.Location = new System.Drawing.Point(594, 43);
            this.buttonAddChar.Name = "buttonAddChar";
            this.buttonAddChar.Size = new System.Drawing.Size(75, 25);
            this.buttonAddChar.TabIndex = 8;
            this.buttonAddChar.Text = "Add";
            this.buttonAddChar.UseVisualStyleBackColor = false;
            this.buttonAddChar.Click += new System.EventHandler(this.buttonAddChar_Click);
            // 
            // GestioSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(72)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(906, 437);
            this.Controls.Add(this.buttonAddChar);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.buttonDeleteChar);
            this.Controls.Add(this.buttonEditChar);
            this.Controls.Add(this.buttonEditSala);
            this.Controls.Add(this.dataGridViewCaracteristiques);
            this.Controls.Add(this.dataGridViewSales);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "GestioSales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCaracteristiques)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSales;
        private System.Windows.Forms.DataGridView dataGridViewCaracteristiques;
        private System.Windows.Forms.Button buttonEditSala;
        private System.Windows.Forms.Button buttonEditChar;
        private System.Windows.Forms.Button buttonDeleteChar;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem gestioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem usuarisToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitsToolStripMenuItem;
        private System.Windows.Forms.Button buttonAddChar;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}