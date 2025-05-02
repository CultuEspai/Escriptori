namespace CultuEspai
{
    partial class GestioEntrades
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
            this.buttonAddEntrada = new System.Windows.Forms.Button();
            this.buttonDeleteEntrada = new System.Windows.Forms.Button();
            this.dataGridViewEntrades = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntrades)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddEntrada
            // 
            this.buttonAddEntrada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(183)))), ((int)(((byte)(167)))));
            this.buttonAddEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddEntrada.Location = new System.Drawing.Point(39, 32);
            this.buttonAddEntrada.Name = "buttonAddEntrada";
            this.buttonAddEntrada.Size = new System.Drawing.Size(75, 25);
            this.buttonAddEntrada.TabIndex = 25;
            this.buttonAddEntrada.Text = "Add";
            this.buttonAddEntrada.UseVisualStyleBackColor = false;
            this.buttonAddEntrada.Click += new System.EventHandler(this.buttonAddEntrada_Click);
            // 
            // buttonDeleteEntrada
            // 
            this.buttonDeleteEntrada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(183)))), ((int)(((byte)(167)))));
            this.buttonDeleteEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteEntrada.Location = new System.Drawing.Point(397, 32);
            this.buttonDeleteEntrada.Name = "buttonDeleteEntrada";
            this.buttonDeleteEntrada.Size = new System.Drawing.Size(70, 25);
            this.buttonDeleteEntrada.TabIndex = 23;
            this.buttonDeleteEntrada.Text = "Delete";
            this.buttonDeleteEntrada.UseVisualStyleBackColor = false;
            this.buttonDeleteEntrada.Click += new System.EventHandler(this.buttonDeleteEntrada_Click);
            // 
            // dataGridViewEntrades
            // 
            this.dataGridViewEntrades.AllowUserToAddRows = false;
            this.dataGridViewEntrades.AllowUserToDeleteRows = false;
            this.dataGridViewEntrades.AllowUserToResizeRows = false;
            this.dataGridViewEntrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEntrades.Location = new System.Drawing.Point(25, 74);
            this.dataGridViewEntrades.MultiSelect = false;
            this.dataGridViewEntrades.Name = "dataGridViewEntrades";
            this.dataGridViewEntrades.ReadOnly = true;
            this.dataGridViewEntrades.RowHeadersWidth = 47;
            this.dataGridViewEntrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEntrades.Size = new System.Drawing.Size(458, 221);
            this.dataGridViewEntrades.TabIndex = 21;
            // 
            // GestioEntrades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(72)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(507, 330);
            this.Controls.Add(this.buttonAddEntrada);
            this.Controls.Add(this.buttonDeleteEntrada);
            this.Controls.Add(this.dataGridViewEntrades);
            this.Name = "GestioEntrades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrades";
            this.Load += new System.EventHandler(this.GestioEntrades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntrades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAddEntrada;
        private System.Windows.Forms.Button buttonDeleteEntrada;
        private System.Windows.Forms.DataGridView dataGridViewEntrades;
    }
}