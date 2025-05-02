namespace CultuEspai
{
    partial class EditUser
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
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.comboBoxTipus = new System.Windows.Forms.ComboBox();
            this.checkBoxActiu = new System.Windows.Forms.CheckBox();
            this.labelTipus = new System.Windows.Forms.Label();
            this.labelP = new System.Windows.Forms.Label();
            this.labelC = new System.Windows.Forms.Label();
            this.labelN = new System.Windows.Forms.Label();
            this.labelNom = new System.Windows.Forms.Label();
            this.labelCorreu = new System.Windows.Forms.Label();
            this.labelContrasenya = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(183)))), ((int)(((byte)(167)))));
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelar.Location = new System.Drawing.Point(27, 186);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(70, 25);
            this.buttonCancelar.TabIndex = 26;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(183)))), ((int)(((byte)(167)))));
            this.buttonGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGuardar.Location = new System.Drawing.Point(275, 186);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(70, 25);
            this.buttonGuardar.TabIndex = 25;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = false;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // comboBoxTipus
            // 
            this.comboBoxTipus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipus.FormattingEnabled = true;
            this.comboBoxTipus.Location = new System.Drawing.Point(164, 134);
            this.comboBoxTipus.Name = "comboBoxTipus";
            this.comboBoxTipus.Size = new System.Drawing.Size(172, 21);
            this.comboBoxTipus.TabIndex = 24;
            // 
            // checkBoxActiu
            // 
            this.checkBoxActiu.AutoSize = true;
            this.checkBoxActiu.Checked = true;
            this.checkBoxActiu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActiu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxActiu.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBoxActiu.Location = new System.Drawing.Point(155, 186);
            this.checkBoxActiu.Name = "checkBoxActiu";
            this.checkBoxActiu.Size = new System.Drawing.Size(71, 28);
            this.checkBoxActiu.TabIndex = 23;
            this.checkBoxActiu.Text = "Actiu";
            this.checkBoxActiu.UseVisualStyleBackColor = true;
            // 
            // labelTipus
            // 
            this.labelTipus.AutoSize = true;
            this.labelTipus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipus.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelTipus.Location = new System.Drawing.Point(23, 134);
            this.labelTipus.Name = "labelTipus";
            this.labelTipus.Size = new System.Drawing.Size(133, 24);
            this.labelTipus.TabIndex = 19;
            this.labelTipus.Text = "Tipus d\'usuari:";
            // 
            // labelP
            // 
            this.labelP.AutoSize = true;
            this.labelP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelP.Location = new System.Drawing.Point(23, 95);
            this.labelP.Name = "labelP";
            this.labelP.Size = new System.Drawing.Size(120, 24);
            this.labelP.TabIndex = 18;
            this.labelP.Text = "Contrasenya:";
            // 
            // labelC
            // 
            this.labelC.AutoSize = true;
            this.labelC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelC.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelC.Location = new System.Drawing.Point(23, 61);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(73, 24);
            this.labelC.TabIndex = 17;
            this.labelC.Text = "Correu:";
            // 
            // labelN
            // 
            this.labelN.AutoSize = true;
            this.labelN.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelN.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelN.Location = new System.Drawing.Point(23, 28);
            this.labelN.Name = "labelN";
            this.labelN.Size = new System.Drawing.Size(117, 24);
            this.labelN.TabIndex = 16;
            this.labelN.Text = "Nom usuari: ";
            // 
            // labelNom
            // 
            this.labelNom.AutoSize = true;
            this.labelNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNom.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelNom.Location = new System.Drawing.Point(160, 28);
            this.labelNom.Name = "labelNom";
            this.labelNom.Size = new System.Drawing.Size(112, 24);
            this.labelNom.TabIndex = 27;
            this.labelNom.Text = "Nom_usuari";
            // 
            // labelCorreu
            // 
            this.labelCorreu.AutoSize = true;
            this.labelCorreu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCorreu.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelCorreu.Location = new System.Drawing.Point(160, 61);
            this.labelCorreu.Name = "labelCorreu";
            this.labelCorreu.Size = new System.Drawing.Size(129, 24);
            this.labelCorreu.TabIndex = 28;
            this.labelCorreu.Text = "Correu_usuari";
            // 
            // labelContrasenya
            // 
            this.labelContrasenya.AutoSize = true;
            this.labelContrasenya.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContrasenya.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelContrasenya.Location = new System.Drawing.Point(160, 95);
            this.labelContrasenya.Name = "labelContrasenya";
            this.labelContrasenya.Size = new System.Drawing.Size(176, 24);
            this.labelContrasenya.TabIndex = 29;
            this.labelContrasenya.Text = "Contrasenya_usuari";
            // 
            // EditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(72)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(370, 241);
            this.Controls.Add(this.labelContrasenya);
            this.Controls.Add(this.labelCorreu);
            this.Controls.Add(this.labelNom);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.comboBoxTipus);
            this.Controls.Add(this.checkBoxActiu);
            this.Controls.Add(this.labelTipus);
            this.Controls.Add(this.labelP);
            this.Controls.Add(this.labelC);
            this.Controls.Add(this.labelN);
            this.Name = "EditUser";
            this.Text = "Editar usuari";
            this.Load += new System.EventHandler(this.EditUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.ComboBox comboBoxTipus;
        private System.Windows.Forms.CheckBox checkBoxActiu;
        private System.Windows.Forms.Label labelTipus;
        private System.Windows.Forms.Label labelP;
        private System.Windows.Forms.Label labelC;
        private System.Windows.Forms.Label labelN;
        private System.Windows.Forms.Label labelNom;
        private System.Windows.Forms.Label labelCorreu;
        private System.Windows.Forms.Label labelContrasenya;
    }
}