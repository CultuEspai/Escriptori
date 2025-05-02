namespace CultuEspai
{
    partial class AddUser
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
            this.labelNom = new System.Windows.Forms.Label();
            this.labelCorreu = new System.Windows.Forms.Label();
            this.labelContrasenya = new System.Windows.Forms.Label();
            this.labelTipus = new System.Windows.Forms.Label();
            this.textBoxNom = new System.Windows.Forms.TextBox();
            this.textBoxCorreu = new System.Windows.Forms.TextBox();
            this.textBoxContra = new System.Windows.Forms.TextBox();
            this.checkBoxActiu = new System.Windows.Forms.CheckBox();
            this.comboBoxTipus = new System.Windows.Forms.ComboBox();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNom
            // 
            this.labelNom.AutoSize = true;
            this.labelNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNom.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelNom.Location = new System.Drawing.Point(19, 38);
            this.labelNom.Name = "labelNom";
            this.labelNom.Size = new System.Drawing.Size(117, 24);
            this.labelNom.TabIndex = 0;
            this.labelNom.Text = "Nom usuari: ";
            // 
            // labelCorreu
            // 
            this.labelCorreu.AutoSize = true;
            this.labelCorreu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCorreu.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelCorreu.Location = new System.Drawing.Point(19, 71);
            this.labelCorreu.Name = "labelCorreu";
            this.labelCorreu.Size = new System.Drawing.Size(73, 24);
            this.labelCorreu.TabIndex = 1;
            this.labelCorreu.Text = "Correu:";
            // 
            // labelContrasenya
            // 
            this.labelContrasenya.AutoSize = true;
            this.labelContrasenya.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContrasenya.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelContrasenya.Location = new System.Drawing.Point(19, 105);
            this.labelContrasenya.Name = "labelContrasenya";
            this.labelContrasenya.Size = new System.Drawing.Size(120, 24);
            this.labelContrasenya.TabIndex = 2;
            this.labelContrasenya.Text = "Contrasenya:";
            // 
            // labelTipus
            // 
            this.labelTipus.AutoSize = true;
            this.labelTipus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipus.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelTipus.Location = new System.Drawing.Point(19, 144);
            this.labelTipus.Name = "labelTipus";
            this.labelTipus.Size = new System.Drawing.Size(133, 24);
            this.labelTipus.TabIndex = 3;
            this.labelTipus.Text = "Tipus d\'usuari:";
            // 
            // textBoxNom
            // 
            this.textBoxNom.Location = new System.Drawing.Point(151, 40);
            this.textBoxNom.Name = "textBoxNom";
            this.textBoxNom.Size = new System.Drawing.Size(190, 20);
            this.textBoxNom.TabIndex = 5;
            // 
            // textBoxCorreu
            // 
            this.textBoxCorreu.Location = new System.Drawing.Point(151, 73);
            this.textBoxCorreu.Name = "textBoxCorreu";
            this.textBoxCorreu.Size = new System.Drawing.Size(190, 20);
            this.textBoxCorreu.TabIndex = 6;
            // 
            // textBoxContra
            // 
            this.textBoxContra.Location = new System.Drawing.Point(151, 107);
            this.textBoxContra.Name = "textBoxContra";
            this.textBoxContra.Size = new System.Drawing.Size(190, 20);
            this.textBoxContra.TabIndex = 7;
            // 
            // checkBoxActiu
            // 
            this.checkBoxActiu.AutoSize = true;
            this.checkBoxActiu.Checked = true;
            this.checkBoxActiu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActiu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxActiu.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBoxActiu.Location = new System.Drawing.Point(151, 196);
            this.checkBoxActiu.Name = "checkBoxActiu";
            this.checkBoxActiu.Size = new System.Drawing.Size(71, 28);
            this.checkBoxActiu.TabIndex = 8;
            this.checkBoxActiu.Text = "Actiu";
            this.checkBoxActiu.UseVisualStyleBackColor = true;
            // 
            // comboBoxTipus
            // 
            this.comboBoxTipus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipus.FormattingEnabled = true;
            this.comboBoxTipus.Location = new System.Drawing.Point(151, 145);
            this.comboBoxTipus.Name = "comboBoxTipus";
            this.comboBoxTipus.Size = new System.Drawing.Size(190, 21);
            this.comboBoxTipus.TabIndex = 9;
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(183)))), ((int)(((byte)(167)))));
            this.buttonGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGuardar.Location = new System.Drawing.Point(271, 196);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(70, 25);
            this.buttonGuardar.TabIndex = 14;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = false;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(183)))), ((int)(((byte)(167)))));
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelar.Location = new System.Drawing.Point(23, 196);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(70, 25);
            this.buttonCancelar.TabIndex = 15;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(72)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(363, 251);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.comboBoxTipus);
            this.Controls.Add(this.checkBoxActiu);
            this.Controls.Add(this.textBoxContra);
            this.Controls.Add(this.textBoxCorreu);
            this.Controls.Add(this.textBoxNom);
            this.Controls.Add(this.labelTipus);
            this.Controls.Add(this.labelContrasenya);
            this.Controls.Add(this.labelCorreu);
            this.Controls.Add(this.labelNom);
            this.Name = "AddUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nou usuari";
            this.Load += new System.EventHandler(this.AddUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNom;
        private System.Windows.Forms.Label labelCorreu;
        private System.Windows.Forms.Label labelContrasenya;
        private System.Windows.Forms.Label labelTipus;
        private System.Windows.Forms.TextBox textBoxNom;
        private System.Windows.Forms.TextBox textBoxCorreu;
        private System.Windows.Forms.TextBox textBoxContra;
        private System.Windows.Forms.CheckBox checkBoxActiu;
        private System.Windows.Forms.ComboBox comboBoxTipus;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonCancelar;
    }
}