namespace CultuEspai
{
    partial class DeleteEntrades
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
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.labelEntradesVenudes = new System.Windows.Forms.Label();
            this.numericUpDownQuantitat = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelEntrades = new System.Windows.Forms.Label();
            this.labelTornar = new System.Windows.Forms.Label();
            this.labelDiners = new System.Windows.Forms.Label();
            this.labelNumEntrades = new System.Windows.Forms.Label();
            this.labelButaques = new System.Windows.Forms.Label();
            this.listBoxButaques = new System.Windows.Forms.ListBox();
            this.labelDePagament = new System.Windows.Forms.Label();
            this.labelNomEsdeveniment = new System.Windows.Forms.Label();
            this.labelNomUsuari = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantitat)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(183)))), ((int)(((byte)(167)))));
            this.buttonGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGuardar.Location = new System.Drawing.Point(443, 354);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(70, 25);
            this.buttonGuardar.TabIndex = 30;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = false;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(183)))), ((int)(((byte)(167)))));
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelar.Location = new System.Drawing.Point(42, 354);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(70, 25);
            this.buttonCancelar.TabIndex = 31;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // labelEntradesVenudes
            // 
            this.labelEntradesVenudes.AutoSize = true;
            this.labelEntradesVenudes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEntradesVenudes.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelEntradesVenudes.Location = new System.Drawing.Point(26, 112);
            this.labelEntradesVenudes.Name = "labelEntradesVenudes";
            this.labelEntradesVenudes.Size = new System.Drawing.Size(156, 20);
            this.labelEntradesVenudes.TabIndex = 32;
            this.labelEntradesVenudes.Text = "Número d\'entrades:";
            // 
            // numericUpDownQuantitat
            // 
            this.numericUpDownQuantitat.Location = new System.Drawing.Point(418, 162);
            this.numericUpDownQuantitat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownQuantitat.Name = "numericUpDownQuantitat";
            this.numericUpDownQuantitat.Size = new System.Drawing.Size(66, 20);
            this.numericUpDownQuantitat.TabIndex = 33;
            this.numericUpDownQuantitat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(26, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "Entrades de l\'usuari:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(26, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "Entrades per l\'esdeveniment:";
            // 
            // labelEntrades
            // 
            this.labelEntrades.AutoSize = true;
            this.labelEntrades.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEntrades.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelEntrades.Location = new System.Drawing.Point(26, 159);
            this.labelEntrades.Name = "labelEntrades";
            this.labelEntrades.Size = new System.Drawing.Size(234, 20);
            this.labelEntrades.TabIndex = 38;
            this.labelEntrades.Text = "Número d\'entrades a eliminar:";
            // 
            // labelTornar
            // 
            this.labelTornar.AutoSize = true;
            this.labelTornar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTornar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelTornar.Location = new System.Drawing.Point(26, 311);
            this.labelTornar.Name = "labelTornar";
            this.labelTornar.Size = new System.Drawing.Size(414, 20);
            this.labelTornar.TabIndex = 39;
            this.labelTornar.Text = "Diners a tornar a l\'usuari, en cas de que ja hagi pagat:";
            // 
            // labelDiners
            // 
            this.labelDiners.AutoSize = true;
            this.labelDiners.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiners.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelDiners.Location = new System.Drawing.Point(494, 311);
            this.labelDiners.Name = "labelDiners";
            this.labelDiners.Size = new System.Drawing.Size(42, 20);
            this.labelDiners.TabIndex = 40;
            this.labelDiners.Text = "xxx€";
            // 
            // labelNumEntrades
            // 
            this.labelNumEntrades.AutoSize = true;
            this.labelNumEntrades.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumEntrades.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelNumEntrades.Location = new System.Drawing.Point(439, 112);
            this.labelNumEntrades.Name = "labelNumEntrades";
            this.labelNumEntrades.Size = new System.Drawing.Size(33, 20);
            this.labelNumEntrades.TabIndex = 41;
            this.labelNumEntrades.Text = "xxx";
            // 
            // labelButaques
            // 
            this.labelButaques.AutoSize = true;
            this.labelButaques.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelButaques.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelButaques.Location = new System.Drawing.Point(26, 210);
            this.labelButaques.Name = "labelButaques";
            this.labelButaques.Size = new System.Drawing.Size(196, 20);
            this.labelButaques.TabIndex = 43;
            this.labelButaques.Text = "Número de les butaques:";
            // 
            // listBoxButaques
            // 
            this.listBoxButaques.FormattingEnabled = true;
            this.listBoxButaques.Location = new System.Drawing.Point(418, 197);
            this.listBoxButaques.Name = "listBoxButaques";
            this.listBoxButaques.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxButaques.Size = new System.Drawing.Size(118, 69);
            this.listBoxButaques.TabIndex = 44;
            // 
            // labelDePagament
            // 
            this.labelDePagament.AutoSize = true;
            this.labelDePagament.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDePagament.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelDePagament.Location = new System.Drawing.Point(26, 278);
            this.labelDePagament.Name = "labelDePagament";
            this.labelDePagament.Size = new System.Drawing.Size(254, 20);
            this.labelDePagament.TabIndex = 45;
            this.labelDePagament.Text = "L\'esdeveniment es de pagament.";
            // 
            // labelNomEsdeveniment
            // 
            this.labelNomEsdeveniment.AutoSize = true;
            this.labelNomEsdeveniment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomEsdeveniment.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelNomEsdeveniment.Location = new System.Drawing.Point(263, 60);
            this.labelNomEsdeveniment.Name = "labelNomEsdeveniment";
            this.labelNomEsdeveniment.Size = new System.Drawing.Size(273, 20);
            this.labelNomEsdeveniment.TabIndex = 46;
            this.labelNomEsdeveniment.Text = "Nom de l\'esdeveniment seleccionat";
            // 
            // labelNomUsuari
            // 
            this.labelNomUsuari.AutoSize = true;
            this.labelNomUsuari.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomUsuari.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelNomUsuari.Location = new System.Drawing.Point(297, 27);
            this.labelNomUsuari.Name = "labelNomUsuari";
            this.labelNomUsuari.Size = new System.Drawing.Size(216, 20);
            this.labelNomUsuari.TabIndex = 47;
            this.labelNomUsuari.Text = "Nom de l\'usuari seleccionat";
            // 
            // DeleteEntrades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(72)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(562, 415);
            this.Controls.Add(this.labelNomUsuari);
            this.Controls.Add(this.labelNomEsdeveniment);
            this.Controls.Add(this.labelDePagament);
            this.Controls.Add(this.listBoxButaques);
            this.Controls.Add(this.labelButaques);
            this.Controls.Add(this.labelNumEntrades);
            this.Controls.Add(this.labelDiners);
            this.Controls.Add(this.labelTornar);
            this.Controls.Add(this.labelEntrades);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownQuantitat);
            this.Controls.Add(this.labelEntradesVenudes);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGuardar);
            this.Name = "DeleteEntrades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrades";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantitat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label labelEntradesVenudes;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantitat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelEntrades;
        private System.Windows.Forms.Label labelTornar;
        private System.Windows.Forms.Label labelDiners;
        private System.Windows.Forms.Label labelNumEntrades;
        private System.Windows.Forms.Label labelButaques;
        private System.Windows.Forms.ListBox listBoxButaques;
        private System.Windows.Forms.Label labelDePagament;
        private System.Windows.Forms.Label labelNomEsdeveniment;
        private System.Windows.Forms.Label labelNomUsuari;
    }
}