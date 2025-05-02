namespace CultuEspai
{
    partial class AddEntrada
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
            this.labelNomUsuari = new System.Windows.Forms.Label();
            this.labelNomEsdeveniment = new System.Windows.Forms.Label();
            this.labelDePagament = new System.Windows.Forms.Label();
            this.listBoxButaques = new System.Windows.Forms.ListBox();
            this.labelButaques = new System.Windows.Forms.Label();
            this.labelPreu = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownQuantitat = new System.Windows.Forms.NumericUpDown();
            this.labelEntrades = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.comboBoxUsuaris = new System.Windows.Forms.ComboBox();
            this.comboBoxEsdeveniments = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantitat)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNomUsuari
            // 
            this.labelNomUsuari.AutoSize = true;
            this.labelNomUsuari.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomUsuari.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelNomUsuari.Location = new System.Drawing.Point(312, 40);
            this.labelNomUsuari.Name = "labelNomUsuari";
            this.labelNomUsuari.Size = new System.Drawing.Size(216, 20);
            this.labelNomUsuari.TabIndex = 62;
            this.labelNomUsuari.Text = "Nom de l\'usuari seleccionat";
            // 
            // labelNomEsdeveniment
            // 
            this.labelNomEsdeveniment.AutoSize = true;
            this.labelNomEsdeveniment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomEsdeveniment.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelNomEsdeveniment.Location = new System.Drawing.Point(312, 76);
            this.labelNomEsdeveniment.Name = "labelNomEsdeveniment";
            this.labelNomEsdeveniment.Size = new System.Drawing.Size(188, 20);
            this.labelNomEsdeveniment.TabIndex = 61;
            this.labelNomEsdeveniment.Text = "Nom de l\'esdeveniment ";
            // 
            // labelDePagament
            // 
            this.labelDePagament.AutoSize = true;
            this.labelDePagament.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDePagament.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelDePagament.Location = new System.Drawing.Point(41, 225);
            this.labelDePagament.Name = "labelDePagament";
            this.labelDePagament.Size = new System.Drawing.Size(254, 20);
            this.labelDePagament.TabIndex = 60;
            this.labelDePagament.Text = "L\'esdeveniment es de pagament.";
            // 
            // listBoxButaques
            // 
            this.listBoxButaques.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxButaques.FormattingEnabled = true;
            this.listBoxButaques.IntegralHeight = false;
            this.listBoxButaques.ItemHeight = 20;
            this.listBoxButaques.Location = new System.Drawing.Point(429, 114);
            this.listBoxButaques.Name = "listBoxButaques";
            this.listBoxButaques.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxButaques.Size = new System.Drawing.Size(99, 100);
            this.listBoxButaques.TabIndex = 59;
            this.listBoxButaques.SelectedIndexChanged += new System.EventHandler(this.listBoxButaques_SelectedIndexChanged);
            // 
            // labelButaques
            // 
            this.labelButaques.AutoSize = true;
            this.labelButaques.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelButaques.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelButaques.Location = new System.Drawing.Point(41, 162);
            this.labelButaques.Name = "labelButaques";
            this.labelButaques.Size = new System.Drawing.Size(196, 20);
            this.labelButaques.TabIndex = 58;
            this.labelButaques.Text = "Número de les butaques:";
            // 
            // labelPreu
            // 
            this.labelPreu.AutoSize = true;
            this.labelPreu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPreu.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelPreu.Location = new System.Drawing.Point(486, 225);
            this.labelPreu.Name = "labelPreu";
            this.labelPreu.Size = new System.Drawing.Size(42, 20);
            this.labelPreu.TabIndex = 56;
            this.labelPreu.Text = "xxx€";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(41, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 20);
            this.label1.TabIndex = 53;
            this.label1.Text = "Entrades per l\'esdeveniment:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(41, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 20);
            this.label2.TabIndex = 52;
            this.label2.Text = "Entrades per l\'usuari:";
            // 
            // numericUpDownQuantitat
            // 
            this.numericUpDownQuantitat.Location = new System.Drawing.Point(462, 125);
            this.numericUpDownQuantitat.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownQuantitat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownQuantitat.Name = "numericUpDownQuantitat";
            this.numericUpDownQuantitat.Size = new System.Drawing.Size(66, 20);
            this.numericUpDownQuantitat.TabIndex = 51;
            this.numericUpDownQuantitat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelEntrades
            // 
            this.labelEntrades.AutoSize = true;
            this.labelEntrades.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12727F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEntrades.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelEntrades.Location = new System.Drawing.Point(41, 125);
            this.labelEntrades.Name = "labelEntrades";
            this.labelEntrades.Size = new System.Drawing.Size(156, 20);
            this.labelEntrades.TabIndex = 50;
            this.labelEntrades.Text = "Número d\'entrades:";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(183)))), ((int)(((byte)(167)))));
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelar.Location = new System.Drawing.Point(30, 266);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(70, 25);
            this.buttonCancelar.TabIndex = 49;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(183)))), ((int)(((byte)(167)))));
            this.buttonGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGuardar.Location = new System.Drawing.Point(477, 266);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(70, 25);
            this.buttonGuardar.TabIndex = 48;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = false;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // comboBoxUsuaris
            // 
            this.comboBoxUsuaris.FormattingEnabled = true;
            this.comboBoxUsuaris.Location = new System.Drawing.Point(316, 39);
            this.comboBoxUsuaris.Name = "comboBoxUsuaris";
            this.comboBoxUsuaris.Size = new System.Drawing.Size(212, 21);
            this.comboBoxUsuaris.TabIndex = 63;
            this.comboBoxUsuaris.SelectedIndexChanged += new System.EventHandler(this.comboBoxUsuaris_SelectedIndexChanged);
            // 
            // comboBoxEsdeveniments
            // 
            this.comboBoxEsdeveniments.FormattingEnabled = true;
            this.comboBoxEsdeveniments.Location = new System.Drawing.Point(316, 75);
            this.comboBoxEsdeveniments.Name = "comboBoxEsdeveniments";
            this.comboBoxEsdeveniments.Size = new System.Drawing.Size(212, 21);
            this.comboBoxEsdeveniments.TabIndex = 64;
            this.comboBoxEsdeveniments.SelectedIndexChanged += new System.EventHandler(this.comboBoxNomEsdeveniment_SelectedIndexChanged);
            // 
            // AddEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(72)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(568, 318);
            this.Controls.Add(this.comboBoxEsdeveniments);
            this.Controls.Add(this.comboBoxUsuaris);
            this.Controls.Add(this.labelNomUsuari);
            this.Controls.Add(this.labelNomEsdeveniment);
            this.Controls.Add(this.labelDePagament);
            this.Controls.Add(this.listBoxButaques);
            this.Controls.Add(this.labelButaques);
            this.Controls.Add(this.labelPreu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownQuantitat);
            this.Controls.Add(this.labelEntrades);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGuardar);
            this.Name = "AddEntrada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddEntrada";
            this.Load += new System.EventHandler(this.AddEntrada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantitat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNomUsuari;
        private System.Windows.Forms.Label labelNomEsdeveniment;
        private System.Windows.Forms.Label labelDePagament;
        private System.Windows.Forms.ListBox listBoxButaques;
        private System.Windows.Forms.Label labelButaques;
        private System.Windows.Forms.Label labelPreu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantitat;
        private System.Windows.Forms.Label labelEntrades;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.ComboBox comboBoxUsuaris;
        private System.Windows.Forms.ComboBox comboBoxEsdeveniments;
    }
}